module RenderTest.Image

open System
open System.Drawing
open RenderTest.Vec

let load (path : string) =
    try
        use img = new Bitmap (path)
        
        let rgb = Array2D.create img.Height img.Width RGBA.black
        
        let xSize = img.Width - 1
        let ySize = img.Height - 1
        for x in 0 .. xSize do
            for y in 0 .. ySize do
                rgb[y, x] <-
                    img.GetPixel(x, y)
                    |> RGBA.fromColor
              
        rgb
        |> Block2D
        |> Some
    with
    | :? ArgumentException -> None
    
let pixel block =
    fun pos ->
        match Block2D.atSafe pos block with
        | ValueNone -> RGBA.transparent
        | ValueSome c -> c
    
let pixelSingle (pos : single Vec2) block =
    Vec2.map int pos
    |> pixel block

let invertPixelSingle pos block =
    block
    |> pixelSingle pos 
    |> RGBA.invert

let Griffin = (load "Griffin.png").Value