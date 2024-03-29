﻿namespace RenderTest.Vec

[<Struct>]
type 'T Vec3 =
    {
        X : 'T
        Y : 'T
        Z : 'T
    }
    
    member inline s.R = s.X
    member inline s.G = s.Y
    member inline s.B = s.Z

module Vec3 = 
    let inline make x y z = {
        X = x
        Y = y
        Z = z
    }
    
    let map f vec =
        let {X = x; Y = y; Z = z} = vec
        make (f x) (f y) (f z)
        