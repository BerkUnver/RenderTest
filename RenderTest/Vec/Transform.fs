namespace RenderTest.Vec

[<Struct>]
// 24 bits
type Transform = {
    X : single Vec2
    Y : single Vec2
    Origin: single Vec2
}

module Transform =
    let zero = {
        X = Vec2.make 1f 0f
        Y = Vec2.make 0f 1f
        Origin = Vec2.zeroF
    }