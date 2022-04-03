namespace RenderTest.Vec

[<Struct>]
type 'T Vec4 =
    {
        X : 'T
        Y : 'T
        Z : 'T
        W : 'T
    }
    member inline s.R = s.X
    member inline s.G = s.Y
    member inline s.B = s.Z
    member inline s.A = s.W

module Vec4 =
    let inline make x y z w = {
        X = x
        Y = y
        Z = z
        W = w
    }
    let inline same x = make x x x x
    let map f v =
        make (f v.X) (f v.Y) (f v.Z) (f v.W)