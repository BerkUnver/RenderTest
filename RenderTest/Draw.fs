namespace RenderTest

open System
open RenderTest
open RenderTest.Vec

type Draw = single Vec2 -> RGB -> RGB

module Draw =
    /// draw this then that
    let (==>) draw1 draw2 =
        fun pos rgb ->
            draw1 pos rgb
            |> draw2 pos
            
    let rect color (size: single Vec2) =
        fun (pos : single Vec2) bkg ->
            if
                (pos.X >= 0f)
                && (pos.X <= size.X)
                && (pos.Y >= 0f)
                && (pos.Y <= size.Y)
            then color
            else bkg
            
    let move transform (func : Draw) : Draw =
        fun pos -> func (pos - transform)
    
    let scale scaleAmount (func : Draw) : Draw =
        fun pos -> func (pos / scaleAmount)
    
    let rotate theta (func : Draw) : Draw =
        fun pos ->
            let newPos = {
                X = pos.X * cos theta + pos.Y * sin theta
                Y = -pos.X * sin theta + pos.Y * cos theta 
            }
            func newPos
    
    let pixel (block : RGB Block2D) =
        fun (pos : single Vec2) (bkg : RGB) ->
            let xSize = Block2D.xSize block
            let ySize = Block2D.ySize block
            
            let posInt = Vec2.map int pos
            let exceedX = posInt.X < 0 || posInt.X >= xSize
            let exceedY = posInt.Y < 0 || posInt.Y >= ySize
            
            if exceedX || exceedY
            then bkg
            else
                let coords = Vec2.map int pos
                Block2D.at coords block
            
    let testPipeline =
        pixel (Bitmap.load "Griffin.png").Value
        |> scale (Vec2.make 2f 2f)
        // |> move (Vec2.make 100f 0f)
        // |> rotate (single Math.PI / 4f)