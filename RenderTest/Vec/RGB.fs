namespace RenderTest.Vec

open System.Drawing
open Microsoft.FSharp.Core

type RGB = byte Vec3

module RGB =
    
    let red = Vec3.make 255uy 0uy 0uy
    let green = Vec3.make 0uy 255uy 0uy
    let blue = Vec3.make 0uy 0uy 255uy
    let black = Vec3.make 0uy 0uy 0uy
    let inline r (rgb : RGB) = rgb.X
    let inline g (rgb : RGB) = rgb.Y
    let inline b (rgb : RGB) = rgb.Z
    
    let int32 (rgb : RGB) =
        let r = r rgb |> int <<< 16
        let g = g rgb |> int <<< 8
        let b = b rgb |> int
        r ||| g ||| b
        
    let fromInt32 (i : int) =
        let r = i <<< 16 |> byte
        let g = i <<< 8 |> byte
        let b = byte i
        Vec3.make r g b
        
    let fromColor (color : Color) =
        Vec3.make color.R color.G color.B