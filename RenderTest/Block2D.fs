// unused
namespace RenderTest

open RenderTest.Vec

type 'T Block2D =
    private
    | Block2D of 'T[,]
    
module Block2D =
    let wrapUnsafe a = Block2D a
    let inline private unwrap b = match b with Block2D a -> a
    let xSize (b : 'T Block2D) = (unwrap b).GetLength 1
    let ySize (b : 'T Block2D) = (unwrap b).GetLength 0
    let at (p : int Vec2) (b : 'T Block2D) = (unwrap b).[p.Y, p.X]
    
    let atSafe (pos : int Vec2) block =
        if
            pos.X < 0
            || pos.X >= xSize block
            || pos.Y < 0
            || pos.Y >= ySize block
        then ValueNone
        else
            block
            |> at pos
            |> ValueSome
            
    let size b = Vec2.make (xSize b) (ySize b)
    
    let map (func : 'T -> 'O) block =
        let arr = unwrap block
        let len1 = (arr.GetLength 0) - 1
        let len2 = (arr.GetLength 1) - 1
        
        let newArr = Array2D.zeroCreate len1 len2
        
        for y in 0 .. len1 do
            for x in 0 .. len2 do
                newArr.[y, x] <- func arr.[y, x]
                
        Block2D newArr