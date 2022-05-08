namespace RenderTest.Vec

open System.Drawing
open RenderTest

type RGBA = byte Vec4

module RGBA =
    let black = Vec4.same 255uy
    let transparent = Vec4.same 0uy
    
    let solid (c : RGB) =
        Vec4.make c.R c.G c.B 255uy
    
    let rgb (c : RGBA) =
        Vec3.make c.R c.G c.B
        
    let composite (rgb : RGB) (rgba : RGBA) : RGB =
        let r = Math.qLerp rgb.R rgba.R rgba.A
        let g = Math.qLerp rgb.G rgba.G rgba.A
        let b = Math.qLerp rgb.B rgba.B rgba.A
        Vec3.make r g b
        
    let blend (rgba1 : RGBA) (rgba2 : RGBA) : RGBA = rgba1 // todo : Fix lol
        
        
    let fromColor (c : Color) =
        Vec4.make c.R c.G c.B c.A

    let inline invert (c : RGBA) =
        Vec4.make (255uy - c.R) (255uy - c.G) (255uy - c.B) c.A
        
