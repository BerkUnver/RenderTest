module RenderTest.Model

open RenderTest.Vec

type Item = // Elm style lol
    { Pos : single Vec2
    ; Rot : single
    ; Img : RGBA Block2D 
    }

type Model = Item List

let rec view model =
    match model with
    | [] -> Draw.solid RGBA.transparent
    | head :: tail ->
        Draw.fromBlock head.Img
        |> Draw.rotate head.Rot
        |> Draw.move head.Pos
        |> Draw.overlay (view tail)
    

let test =
    let img = (Image.load "Griffin.png").Value
    [
        {
            Pos = Vec2.make 0f 0f
            Rot = 0f
            Img = img
        }
        {
            Pos = Vec2.make 100f 100f
            Rot = -(Math.pi / 6f)
            Img = img
        }
    ]
    
let testView = view test