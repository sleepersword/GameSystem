using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using SCL.Diagnose;
using VolxEngine.Terrain;

namespace VolxEngine.Terrain
{
    public interface IPoint
    {
        int[] GetLocation();

        System.Drawing.Point ToStandartPoint();
    }

    public struct Point2DGrey : ISerializable, IPoint
    {
        public int X, Y, Greyscale;

        public Point2DGrey(int x, int y, int grey)
        {
            X = x;
            Y = y;
            Greyscale = grey;
        }

        public Point2DGrey(float x, float y, float grey)
        {
            X = (int)x;
            Y = (int)y;
            Greyscale = (int)grey;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("X", X);
            info.AddValue("Y", Y);
            info.AddValue("Greyscale", Greyscale);
        }

        public static float GreyscaleFactor = 0.5f;

        public static implicit operator Point3D(Point2DGrey point)
        {
            return new Point3D(point.X, point.Y, point.Greyscale * GreyscaleFactor);
        }

        public int[] GetLocation()
        {
            return new[] { X, Y, (int)(Greyscale * GreyscaleFactor) };
        }

        public Point ToStandartPoint()
        {
            return new Point(X, Y);
        }
    }

    public struct Point2D : ISerializable, IPoint
    {
        public int X, Y;

        public Point2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point2D(float x, float y)
        {
            X = (int)x;
            Y = (int)y;
        }

        public static Point2D operator +(Point2D a, Point2D b)
        {
            return new Point2D(a.X + b.X, a.Y + b.Y);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("X", X);
            info.AddValue("Y", Y);
        }

        public int[] GetLocation()
        {
            return new[] {X, Y, 0};
        }

        public Point ToStandartPoint()
        {
            return new Point(X, Y);
        }
    }

    public struct Point3D : ISerializable, IPoint
    {
        public int X, Y, Z;

        public Point3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Point3D(float x, float y, float z)
        {
            X = (int)x;
            Y = (int)y;
            Z = (int)z;
        }

        public static Point3D operator +(Point3D a, Point3D b)
        {
            return new Point3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("X", X);
            info.AddValue("Y", Y);
            info.AddValue("Z", Z);
        }

        public int[] GetLocation()
        {
            return new[] {X, Y, Z};
        }

        public Point ToStandartPoint()
        {
            return new Point(X, Y);
        }

        public override string ToString()
        {
            return string.Format("[{0};{1};{2}]", X, Y, Z);
        }
    }
}
