namespace RenderTest

open RenderTest
open RenderTest.Vec

type Draw = SVec2 -> RGB -> RGB
type SolidDraw = SVec2 -> RGB ValueOption
type AlphaDraw = SVec2 -> RGBA

module Draw =
    let solid rgb = fun _ _ -> rgb
            
    let rect size color =
        fun pos ->
            if Vec2.contains size pos
            then ValueSome color
            else ValueNone
            
    let move transform (func : SVec2 -> 'T) =
        fun pos -> func (pos - transform)
    
    let scale scaleAmount (func : SVec2 -> 'T)  =
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
            
            
    let startDrawA (draw : AlphaDraw) : Draw =
        fun pos bkg  ->
            let color = draw pos
            match color.A with
            | 255uy -> RGBA.rgb color
            | 0uy -> bkg
            | _ -> RGBA.composite bkg color
    
    let thenDrawA (drawOver : AlphaDraw) (drawUnder : Draw) : Draw =
        fun pos bkg ->
            let color = drawOver pos
            match color.A with
            | 255uy -> RGBA.rgb color
            | 0uy -> drawUnder pos bkg
            | _ -> RGBA.composite (drawUnder pos bkg) color
        
    let thenDrawS (draw2 : SolidDraw) (draw1 : Draw) : Draw =
        fun pos bkg ->
            match draw2 pos with
            | ValueNone -> draw1 pos bkg
            | ValueSome rgb -> rgb
            
    let testPipeline =
        let griffin pos = Image.pixelSingle pos Image.Griffin
        let rect =
            let size = Vec2.make 100f 100f
            rect size RGB.red
            
        startDrawA griffin
        |> thenDrawS rect