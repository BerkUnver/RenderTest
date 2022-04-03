namespace RenderTest

// open Microsoft.FSharp.Core
// open RenderTest.Vec
// 
// 
// type SolidDraw = SVec2 -> RGB ValueOption
// type AlphaDraw = SVec2 -> RGBA
// 
// module Draw =
//     let (-->) (d1 : SolidDraw) (d2 : SolidDraw) : SolidDraw =
//         fun pos ->
//             match d2 pos with
//             | ValueNone -> d1 pos
//             | x -> x
//     
//     let (-=>) (d1 : SolidDraw) (d2 : AlphaDraw) =
//         fun pos ->
//             let c = d2 pos
//             match c.A with
//             | 255uy -> c
//             | 0uy -> d1 pos |> RGBA.solid
//             | a ->
//                 let rgb = d1 pos
//                 RGBA.composite
// 
// 
// 
