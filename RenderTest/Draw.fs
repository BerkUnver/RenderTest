namespace RenderTest

open RenderTest.Vec

type Draw = single Vec2 -> RGB -> RGB

module Draw =
    /// draw this then that
    let (==>) draw1 draw2 =
        fun pos rgb ->
            draw1 pos rgb
            |> draw2 pos
            
    let rect color (pos: single Vec2) (size: single Vec2) =
        let bounds = pos + size
        fun (p : single Vec2) bkg ->
            if
                (p.X >= pos.X)
                && (p.X <= bounds.X)
                && (p.Y >= pos.Y)
                && (p.Y <= bounds.Y)
            then color
            else bkg
            
    let move transform (func : Draw) : Draw =
        fun pos -> func (pos - transform)
    
    let scale scaleAmount (func : Draw) : Draw =
        fun pos -> func (pos / scaleAmount)
    
    let testPipeline =
        let size = Vec2.make 100f 100f
        let pos = size;
        let drawRect = rect RGB.red pos size
        
        let size = Vec2.make 50f 50f
        let pos2 = Vec2.make 100f 50f
        
        let s = Vec2.make 2f 2f
        let mv = Vec2.make 100f 0f
        let drawRect2 =
            rect RGB.green pos2 size 
            |> scale s
            |> move mv
            // Declarative programming is real
            
        fun point -> point |> (drawRect ==> drawRect2) >> RGB.int32