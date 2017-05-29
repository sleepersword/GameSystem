using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolxEngine.Terrain
{
    public class Polygon
    {
        public Point3D A, B, C;

        public Polygon(Point3D a, Point3D b, Point3D c)
        {
            A = a;
            B = b;
            C = c;
        }

        public static Bitmap ProjectToBitmap(Polygon[] polys, Point2D max, bool filled = false)
        {
            Bitmap bit = new Bitmap(max.X + 1, max.Y+ 1);
            Graphics gr = Graphics.FromImage(bit);
            gr.Clear(Color.White);
            gr.Flush();

            foreach (var p in polys)
            {
                Point a = new Point(p.A.X, p.A.Y);
                Point b = new Point(p.B.X, p.B.Y);
                Point c = new Point(p.C.X, p.C.Y);

                int avg = (p.B.Z + p.A.Z + p.C.Z) / 3;
                Color color = Color.FromArgb(255, avg, avg, avg);

                gr.DrawPolygon(new Pen(color, 1), new[] { a, b, c });
                if (filled) gr.FillPolygon(new SolidBrush(color), new[] { a, b, c });
                gr.Flush();
            }

            gr.Dispose();
            return bit;
        }

        public static void ToWavefront(Polygon[] polys, string filePath, float strideX, float strideY, int shrinkFactor = 1)
        {
            strideX = strideX/shrinkFactor;
            strideY = strideY/shrinkFactor;
            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                for (int index = 0; index < polys.Length; index += 2*shrinkFactor)
                {
                    var p1 = polys[index];
                    var p2 = polys[index + 1];
                    sw.WriteLine("v {0} {1} {2}", p1.A.X, p1.A.Y, p1.A.Z);
                    sw.WriteLine("vt {0} {1}", (p1.A.X / strideX).ToString(CultureInfo.InvariantCulture), (p1.A.Z / strideY).ToString(CultureInfo.InvariantCulture));
                    sw.WriteLine("v {0} {1} {2}", p1.B.X, p1.B.Y, p1.B.Z);
                    sw.WriteLine("vt {0} {1}", (p1.B.X / strideX).ToString(CultureInfo.InvariantCulture), (p1.B.Z / strideY).ToString(CultureInfo.InvariantCulture));
                    sw.WriteLine("v {0} {1} {2}", p1.C.X, p1.C.Y, p1.C.Z);
                    sw.WriteLine("vt {0} {1}", (p1.C.X / strideX).ToString(CultureInfo.InvariantCulture), (p1.C.Z / strideY).ToString(CultureInfo.InvariantCulture));
                    sw.WriteLine("v {0} {1} {2}", p2.B.X, p2.B.Y, p2.B.Z);
                    sw.WriteLine("vt {0} {1}", (p2.B.X / strideX).ToString(CultureInfo.InvariantCulture), (p2.B.Z / strideY).ToString(CultureInfo.InvariantCulture));
                }

                for (int i = 0; i / 2 < polys.Length; i += 4*shrinkFactor)
                {
                    if ((i/3f)%strideX == 0f) continue;
                    sw.WriteLine("f {0}/{1} {2}/{3} {4}/{5}", i + 1, i + 1, i + 2, i + 2, i + 3, i + 3);
                    sw.WriteLine("f {0}/{1} {2}/{3} {4}/{5}", i + 2, i + 2, i + 4, i + 4, i + 3, i + 3);
                }
            }
        }

        public override string ToString()
        {
            return string.Format(@"Polygon ({0} |  {1} |  {2})", A, B, C);
        }
    }
}
