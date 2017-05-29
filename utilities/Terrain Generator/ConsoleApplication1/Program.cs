using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using SCL.Diagnose;
using VolxEngine.Terrain;

namespace reliefMaker
{
    class Program
    {
        public static string Img;

        static void Main(string[] args)
        {
            Console.WriteLine("----- Code Performance Test 1 -----");

            Console.WriteLine("Name of Function: {0}", "GreyscaleMap.To3D(string)");
            Console.WriteLine("Number of Calls: 1");
            long noc = 1;//long.Parse();
            Console.Write("Image Path: ");
            Img = (args != null && args.Length > 0) ? args[0] : Console.ReadLine();
            Console.WriteLine(Img);
            Console.Write("Greyscale to Z-factor: ");
            Point2DGrey.GreyscaleFactor = float.Parse(Console.ReadLine());
            Console.WriteLine("Beginning execution...");
            Action func = GetCall();
            var result = Execute(func, noc);
            Console.WriteLine("Average Ticks/c: {0}", result[0]);
            Console.WriteLine("Average Milliseconds/c: {0}   |  Average Seconds/c: {1}", result[1], result[2]);
            Console.WriteLine("Absolute Ticks: {0}", result[3]);
            Console.WriteLine("Absolute Milliseconds: {0}   |  Absolute Seconds: {1}", result[4], result[5]);

            Console.WriteLine();
            Main(null);
        }

        static Action GetCall()
        {
            GreyscaleMap map = GreyscaleMap.FromImage((Bitmap)Image.FromFile(Img));

            return () =>
                       {
                           //using (ActionLog log = new ActionLog(@"greymap_.log", true))
                           //{
                               //log.SetClient(map);
                               var polys = map.To3D();
                               var max = new Point2D(map.Width - 1, map.Height - 1);
                               //Polygon.ProjectToBitmap(polys, max, true).Save(Path.GetFileNameWithoutExtension(Img) + "_res_filled.png");
                               //Polygon.ProjectToBitmap(polys, max, false).Save(@"C:\Users\QUARK\Desktop\res_poly.png");
                               Polygon.ToWavefront(polys, Path.GetFileNameWithoutExtension(Img) + ".obj", (map.Width - 1),(map.Height -1 ), 1);
                           //}
                       };
        }

        static readonly Random Random = new Random();
        static int GetRandomNumber(int max)
        {
            int res = 0;
            do
            {
                res = Random.Next();
            } while (res > max || res < 0);
            return res;
        }

        static long[] Execute(Action call, long noc)
        {
            long[] result = new long[6];

            Stopwatch watch = new Stopwatch();
            long absTicks = 0, absMillis = 0;
            

            //for (int i = 0; i < noc; i++)
            //{
            //    watch.Start();
            //    call();
            //    watch.Stop();
            //    absTicks += watch.ElapsedTicks;
            //    absMillis += watch.ElapsedMilliseconds;
            //    absSeconds += (long)Math.Round(watch.ElapsedMilliseconds / 1000D, 0);
            //    watch.Reset();
            //}

            Parallel.For(0, noc, (i) =>
                                     {
                                         watch.Start();
                                         call();
                                         watch.Stop();
                                         absTicks += watch.ElapsedTicks;
                                         absMillis += watch.ElapsedMilliseconds;
                                         watch.Reset();
                                     });

            result[0] = absTicks / noc;
            result[1] = absMillis / noc;
            result[2] = (absMillis / 1000) / noc;
            result[3] = absTicks;
            result[4] = absMillis;
            result[5] = (absMillis / 1000);

            return result;
        }
    }
}
