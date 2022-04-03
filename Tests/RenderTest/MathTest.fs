module TestsFs.RenderTest.MathTest

open System
open RenderTest
open Xunit
open Xunit.Abstractions

type T(c : ITestOutputHelper) =
    [<Fact>]
    member _.lerp () =
        let i = Math.qLerp 0uy 255uy 255uy
        c.WriteLine <| i.ToString()
        i = 255uy
        |> Assert.True

[<Fact>]        
let lerp () =
    Math.qLerp 0uy 255uy 255uy = 255uy
    |> Assert.True

