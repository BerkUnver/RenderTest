module RenderTest.Math
    let qLerp (a : byte) (b : byte) (w : byte) =
        let diff = int b - int a
        let mid =
            diff * int w
            >>> 8
            |> byte
        a + mid
