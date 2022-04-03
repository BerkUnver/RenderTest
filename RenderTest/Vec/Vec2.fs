namespace RenderTest.Vec


[<Struct>]
type 'T Vec2 =
    { X : 'T
      Y : 'T }
    
    static member Map func vec2 = {
        X = func vec2.X
        Y = func vec2.Y
    }
    static member Map2 func a b = {
        X = func a.X b.X
        Y = func a.Y b.Y
    }
    static member inline (+) (a, b) = Vec2<_>.Map2 (+) a b 
    static member inline (-) (a, b) = Vec2<_>.Map2 (-) a b
    static member inline (*) (a, b) = Vec2<_>.Map2 (*) a b
    static member inline (/) (a, b) = Vec2<_>.Map2 (/) a b

type SVec2 = single Vec2
module Vec2 =
    let inline map<'T, 'O> = Vec2.Map<'T, 'O>
    let inline make x y = {X = x; Y = y;}
    let inline same x = make x x
    let zeroF = make 0f 0f