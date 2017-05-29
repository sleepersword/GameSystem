using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SCL.Media.Drawing
{
    /// <summary>
    /// Provides extension methods for the Image class in System.Drawing.
    /// </summary>
    public static class ImageEX
    {

        public static readonly Image NullImage = new Bitmap(0, 0);
        
        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="width">The width to resize to.</param>
        /// <param name="newHeight">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Image Resize(this Image image, int newWidth, int newHeight)
        {
            return Resize(image, new Rectangle(0,0, newWidth, newHeight));
        }

        /// <summary>
        /// Resize the image to the specified size.
        /// </summary>
        /// <param name="newSize">The size to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Image Resize(this Image image, Size newSize)
        {
            return Resize(image, new Rectangle(0, 0, newSize.Width, newSize.Height));
        }

        /// <summary>
        /// Resize the image to fit the specified rectangle.
        /// </summary>
        /// <param name="destRectangle">The rectangle to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Image Resize(this Image image, Rectangle destRectangle)
        {
            var destImage = new Bitmap(destRectangle.Width, destRectangle.Height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRectangle, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        public static Image MakeGrayscale(Image original)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            //get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);

            //create the grayscale ColorMatrix
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][] 
      {
         new float[] {.3f, .3f, .3f, 0, 0},
         new float[] {.59f, .59f, .59f, 0, 0},
         new float[] {.11f, .11f, .11f, 0, 0},
         new float[] {0, 0, 0, 1, 0},
         new float[] {0, 0, 0, 0, 1}
      });

            //create some image attributes
            ImageAttributes attributes = new ImageAttributes();

            //set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);

            //draw the original image on the new image
            //using the grayscale color matrix
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
               0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

            //dispose the Graphics object
            g.Dispose();
            return newBitmap;
        }
        
        //First define a struct the size of one pixel.
        //[StructLayout(LayoutKind.Sequential)]
        //public struct ArgbPixel
        //{
        //    public byte blue;
        //    public byte green;
        //    public byte red;
        //    public byte alpha;
        //}

        ////public static void EditBitmap3(Bitmap bitmap)
        //{
        //    //Create a rectangle covering the area we want to edit.
        //    Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
        //    //Now lock the bitmap bits. We can specify the format we want the data in
        //    //As we want to edit the A R G and B in a byte we'll specify 32 bits per pixel
        //    //Alpha red green blue as the format and set the lock mode to read write.
        //    BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
        //    //Get the pointer to the first byte
        //    IntPtr scan0 = bitmapData.Scan0;
        //    //Now we move into unsafe code
        //    unsafe
        //    {
        //        //Create a pointer to a Pixel struct and point it at the Scan0 pointer.
        //        fixed (ArgbPixel* pixel = (ArgbPixel*)scan0)
        //        {
        //            //Now we can begin our loops. The loops serve no purpose other than to make sure
        //            //we loop the right number of times.
        //            for (int y = 0; y < bitmap.Height; y++)
        //            {
        //                for (int x = 0; x < bitmap.Width; x++)
        //                {
        //                    //Set the pixel values. Like in C++ we have to use the ->
        //                    //accessor as this is an unmanaged pointer.
        //                    pixel->blue = 0;
        //                    pixel->green = 0;
        //                    //Increment the pixel pointer. When you ++ a pointer it actually
        //                    //moves forward the same length as the size of the structure. In this
        //                    //case 4 bytes long. This means we're now pointing at the next pixel.
        //                    pixel++;
        //                }
        //            }
        //        }
        //    }
        //    //Now unlock the bits again and we're done.
        //    bitmap.UnlockBits(bitmapData);
        //}

        /// <summary>
        /// Writes the image data to the current position in the given stream.
        /// </summary>
        /// <param name="stream">The stream, where the image shall be written.</param>
        /// <param name="format">The ImageFormat with which the image shall be encoded.</param>
        public static void ToStream(this Image image, Stream stream, ImageFormat format)
        {
            byte[] data;
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                data = ms.ToArray();
            }
            stream.Write(BitConverter.GetBytes(data.Length), 0, 4);
            stream.Write(data, 0, data.Length);
        }

        /// <summary>
        /// Writes the image data to the current position in the given stream.
        /// </summary>
        /// <param name="stream">The stream, where the image shall be written.</param>
        /// <param name="format">The ImageFormat with which the image shall be encoded.</param>
        public static Image FromStream(this Image image, Stream stream, ImageFormat format)
        {
            byte[] lengthBytes = null;
            stream.Read(lengthBytes, 0, 4);
            int length = BitConverter.ToInt32(lengthBytes, 0);
            byte[] data = null;
            stream.Read(data, 0, length);
            System.Drawing.Image img;

            using (MemoryStream ms = new MemoryStream(data))
            {
                img = System.Drawing.Image.FromStream(ms);
            }
            return img;
        }
    }
}
