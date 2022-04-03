namespace RenderTest

open System.Drawing
open System.Drawing.Imaging
open System.Windows.Forms

open Microsoft.FSharp.NativeInterop
open RenderTest.Vec

#nowarn "9"

module Program =
    let height = 270
    let width = 480
    let stride = width * 4

    [<EntryPoint>]
    let main _ =
        let pixels = Array2D.create height width RGB.black
        let bitmap =
            let intPixels =
                let arr = Array2D.zeroCreate height width
                for x in 0 .. (width - 1) do
                    for y in 0 .. (height - 1) do
                        let pt = Vec2.make (float32 x) (float32 y)
                        arr.[y, x] <-
                            Draw.testPipeline pt pixels.[y, x]
                            |> RGB.int32
                arr
            use arrayPtr = fixed &intPixels[0, 0]
            new Bitmap (width, height, stride, PixelFormat.Format32bppRgb, NativePtr.toNativeInt arrayPtr)

        use picBox = new PictureBox ()
        picBox.Image <- bitmap
        picBox.Dock <- DockStyle.Fill
        
        use form = new Form ()
        form.Size <- Size (width, height)
        form.Controls.Add picBox
        Application.Run form
        0