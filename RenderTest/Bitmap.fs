module RenderTest.Bitmap

open System
open System.Drawing
open RenderTest.Vec

let load (path : string) =
    try
        use img = new Bitmap (path)
        
        let rgb = Array2D.create img.Height img.Width RGB.black
        
        let xSize = img.Width - 1
        let ySize = img.Height - 1
        for x in 0 .. xSize do
            for y in 0 .. ySize do
                rgb[y, x] <-
                    img.GetPixel(x, y)
                    |> RGB.fromColor
              
        rgb
        |> Block2D
        |> Some
    with
    | :? ArgumentException -> None
