namespace RenderTest

open RenderTest
open RenderTest.Vec

type Draw = single Vec2 -> RGB -> RGB

module Draw =
    /// draw this then that
    let (==>) draw1 draw2 =
        fun pos rgb ->
            draw1 pos rgb
            |> draw2 pos
    
    let solid rgb = fun _ _ -> rgb
    
    let bound (size : single Vec2) draw =
        fun (pos : single Vec2) bkg ->
            if pos.X < 0f || pos.X > size.X || pos.Y < 0f || pos.Y > size.Y
            then bkg
            else draw pos bkg
            
    let rect rgb (size: single Vec2) =
        solid rgb
        |> bound size
            
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
    

    
    // apply alpha effect
    let block (block : RGBA Block2D) =
        fun pos rgb ->
            block
            |> Image.pixelSingle pos 
            |> RGBA.composite rgb
            
    let invertBlock (block : RGBA Block2D) =
        fun pos rgb ->
            block
            |> Image.pixelSingle pos
            |> RGBA.invert
            |> RGBA.composite rgb
            
    let testPipeline =
        let drawImg = block Image.Griffin
        let drawImgInv = invertBlock Image.Griffin
        
        let big = 
            drawImgInv
            |> scale (Vec2.same 2f)
            
        let small =
            drawImg
            |> scale (Vec2.same 0.5f)
            
        let rect =
            Vec2.same 100f
            |> rect RGB.red
            
        rect ==> small ==> big
        // |> move (Vec2.make 100f 0f)
        // |> rotate (single Math.PI / 4f)