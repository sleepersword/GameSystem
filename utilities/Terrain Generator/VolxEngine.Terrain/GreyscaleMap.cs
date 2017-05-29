using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCL.Diagnose;

namespace VolxEngine.Terrain
{
    public class GreyscaleMap : Map<Point2DGrey>, IActionLogClient
    {
        private readonly int[,] _data;

        public override int Height
        {
            get { return _data.GetLength(1); }
        }

        public override int Width
        {
            get { return _data.GetLength(0); }
        }

        public override Point2DGrey this[int x, int y]
        {
            get { return new Point2DGrey(x, y, _data[x, y]); }
            set { Fill(value);}
        }

        public event ActionLog.LogEventHandler LogEvent;

        public GreyscaleMap(int width, int height)
        {
            _data = new int[width, height];
        }

        public void Fill(params Point2DGrey[] points)
        {
            Log("Beginning to fill GreyscaleMap with " + points.Length + " points", EventState.Info);
            foreach (var point in points) {
                if (point.X >= Width || point.Y >= Height)
                {
                    Log("One of the given points is outside the map area", EventState.Error);
                    throw new ArgumentOutOfRangeException("points", point, "The given point is outside the map area.");
                }

                _data[point.X, point.Y] = point.Greyscale;
            }
            Log("Filled GreyscaleMap with points", EventState.Info);
        }
        
        public void Fill(int x, int y, int grey)
        {
            Log("Beginning to fill GreyscaleMap with 1 point", EventState.Info);
            if (x >= Width)
            {
                Log("The x-coordinate of the given point is outside the map area",EventState.Error);
                throw new ArgumentOutOfRangeException("x", x, "The given x-coordinate is outside the map area.");
            }
            else if (y >= Height)
            {
                Log("The y-coordinate of the given point is outside the map area", EventState.Error);
                throw new ArgumentOutOfRangeException("y", y, "The given y-coordinate is outside the map area.");
            }
            _data[x, y] = grey; 
            Log("Filled GreyscaleMap with 1 point",EventState.Info);
        }

        public static GreyscaleMap FromImage(Bitmap img)
        {
            var map = new GreyscaleMap(img.Width, img.Height);

            for (int x = 0; x < img.Width; x++)
            {
                for (int y = 0; y < img.Height; y++)
                {
                    if (img.GetPixel(x, y).A == 0) map._data[x, y] = 0;
                    int grey = (int)(img.GetPixel(x, y).GetBrightness() * 255);
                    map._data[x, (-y+img.Height-1)] = grey;
                }
            }
            return map;
        }

        public Bitmap ToGreyscaleImage(bool blackWhite = false, int lim = 0)
        {
            Log("Beginning to convert GreyscaleMap to greyscale image", EventState.Info);
            var img = new Bitmap(Width, Height, PixelFormat.Format32bppArgb);

            Log("Created new bitmap with width=" + Width + " and height=" + Height, EventState.Info);

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    int grey = this[x, y].Greyscale;
                    if (blackWhite)
                    {
                        img.SetPixel(x, y, grey < lim ? Color.Black : Color.White);
                    }
                    else
                    {
                        Color color = Color.FromArgb(255, grey, grey, grey);
                        img.SetPixel(x, y, color);
                    }
                } 
                Log("Completed collumn #" + x, EventState.Info);
            } 
            Log("Converted GreyscaleMap to greyscale image", EventState.Info);
            return img;
        }

        public Polygon[] To3D()
        {
            Log("Beginning to convert GreyscaleMap to array of Polygons", EventState.Info);
            Polygon[] result = new Polygon[2*(Width-1)*(Height-1)];
            int index = 0;

            for (int y = 0; y < Height - 1; y++)
            {
                for (int x = 0; x < Width - 1; x++)
                {
                    Point3D a = new Point3D(x, this[x, y].Greyscale * Point2DGrey.GreyscaleFactor, y);
                    Point3D b = new Point3D(x + 1, this[x + 1, y].Greyscale * Point2DGrey.GreyscaleFactor, y);
                    Point3D c = new Point3D(x, this[x, y + 1].Greyscale*Point2DGrey.GreyscaleFactor, y + 1);
                    Point3D d = new Point3D(x + 1, this[x + 1, y + 1].Greyscale * Point2DGrey.GreyscaleFactor, y + 1);
                    result[index] = new Polygon(a, b, c);
                    result[index + 1] = new Polygon(b, d, c);
                    index += 2;
                }
                Log("Completed collumn #" + y, EventState.Info);
            }
            //Parallel.For(0, Height - 1, (y) =>
            //{
            //    for (int x = 0; x < Width - 1; x++)
            //    {
            //        Point3D a = this[x, y];
            //        Point3D b = this[x + 1, y];
            //        Point3D c = this[x, y + 1];
            //        Point3D d = this[x + 1, y + 1];
            //        result[index] = new Polygon(a, b, c);
            //        result[index + 1] = new Polygon(b, d, c);
            //        index += 2;
            //    }
            //});
            Log("Converted GreyscaleMap to array of Polygons",EventState.Info);
            return result;
        }

        private void Log(string message, EventState state)
        {
            if (LogEvent != null) LogEvent(new Event("GreyscaleMap",message,state));
        }
    }
}
