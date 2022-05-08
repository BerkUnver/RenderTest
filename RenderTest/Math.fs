module RenderTest.Math

    open System

    let qLerp (a : byte) (b : byte) (w : byte) =
        let diff = int b - int a
        let mid =
            diff * int w
            >>> 8
            |> byte
        a + mid
    
    let pi = single Math.PI
    let tau = pi * 2f