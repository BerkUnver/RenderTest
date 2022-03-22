namespace RenderTest.Vec

[<Struct>]
type 'T Vec2 =
    { X : 'T
      Y : 'T }
    
    static member inline map func vec2 = {
        X = func vec2.X
        Y = func vec2.Y
    }
    static member inline map2 func a b = {
        X = func a.X b.X
        Y = func a.Y b.Y
    }
    static member inline (+) (a, b) = Vec2<_>.map2 (+) a b 
    static member inline (-) (a, b) = Vec2<_>.map2 (-) a b
    static member inline (*) (a, b) = Vec2<_>.map2 (*) a b
    static member inline (/) (a, b) = Vec2<_>.map2 (/) a b

module Vec2 =
    let inline make x y = {X = x; Y = y;}
    let (+) (a : single Vec2) (b : single Vec2) =  make (a.X + b.X) (a.Y + b.Y)