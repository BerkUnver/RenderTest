// unused
namespace RenderTest

open RenderTest.Vec

type 'T Block2D = private Block2D of 'T[,]

module Block2D =
    let wrapUnsafe a = Block2D a
    let inline private unwrap b = match b with Block2D a -> a
    let at (point : int Vec2) (b : 'T Block2D) = (unwrap b).[point.Y, point.X]
    let width (b : 'T Block2D) = (unwrap b).GetLength 0
    let height (b : 'T Block2D) = (unwrap b).GetLength 1
    let map (func : 'T -> 'O) block =
        let arr = unwrap block
        let len1 = arr.GetLength 0
        let len2 = arr. GetLength 1
        let newArr = Array2D.zeroCreate len1 len2
        for x in 0 .. len1 do
            for y in 0 .. len2 do
                newArr.[x, y] <- func arr.[x, y]
        Block2D newArr