module RenderTest.Draw

open Microsoft.FSharp.Core
open RenderTest.Vec

type Draw = single Vec2 -> byte Vec4


let solid (rgba : RGBA) (_ : single Vec2) = rgba

let fromBlock block pos = Image.pixelSingle pos block

let overlay (drawUnder : Draw) (drawOver : Draw) : Draw =
    fun pos ->
        let first = drawOver pos
        match first.A with
        | 255uy -> first
        | 0uy -> drawUnder pos
        | _ -> RGBA.blend first <| drawUnder pos
        
let rotate (theta : single) (draw : Draw) : Draw =
    fun pos ->
        let x = pos.X * cos theta + pos.Y * sin theta
        let y = -pos.X * sin theta + pos.Y * cos theta
        draw (Vec2.make x y)
        
let move (offset : single Vec2) (draw : Draw) pos = draw (pos - offset)

let scale (scale : single Vec2) (draw : Draw) pos = draw (pos / scale)
