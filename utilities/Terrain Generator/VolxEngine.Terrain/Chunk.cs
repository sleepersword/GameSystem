using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolxEngine.Terrain
{
    public class Chunk
    {
        public virtual int Size { get { return _data.Length; }}

        public virtual Map<Point3D> ParentMap { get; private set; }

        public virtual Chunk LeftDock { get; protected set; }
        public virtual Chunk RightDock { get; protected set; }
        public virtual Chunk TopDock { get; protected set; }
        public virtual Chunk BottomDock { get; protected set; }

        private readonly float[,] _data;

        public Chunk(int size)
        {
            _data = new float[size,size];
            _data.Initialize();
        }

        public Chunk(int size, params IPoint[] points)
        {
            if (points.Length != size * size) throw new Exception("Wrong amount of IPoints");
            _data = new float[size, size];
            foreach (IPoint p in points)
            {
                var locs = p.GetLocation();
                _data[locs[0], locs[1]] = locs[3];
            }
        }

        public Chunk(int size, params float[] heights)
        {
            if (heights.Length != size * size) throw new Exception("Wrong amount of float values");

            _data = new float[size, size];
            int i = 0;
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    _data[x, y] = heights[i];
                    i++;
                }
            }
        }

        public Point3D this[int x, int y] 
        {
            get
            {
                return new Point3D(x, y, _data[x, y]);
            }
            set
            {
                _data[x, y] = value.Z;
            }
        }

        public void SetDock(Chunk dock, DockDirection dir)
        {
            switch (dir)
            {
                case DockDirection.Right:
                    RightDock = dock;
                    dock.LeftDock = this;
                    break;
                case DockDirection.Left:
                    LeftDock = dock;
                    dock.RightDock = this;
                    break;
                case DockDirection.Top:
                    TopDock = dock;
                    dock.BottomDock = this;
                    break;
                case DockDirection.Bottom:
                    BottomDock = dock;
                    dock.TopDock = this;
                    break;
            }
        }

        public void ToStream(Stream st)
        {
            using (BinaryWriter sw = new BinaryWriter(st))
            {
                sw.Write(Size);
                for (int y = 0; y < Size; y++)
                {
                    for (int x = 0; x < Size; x++)
                    {
                        sw.Write(_data[x, y]);
                    }
                }
            }
        }

        public static Chunk FromStream(Stream st)
        {
            using (BinaryReader br = new BinaryReader(st))
            {
                int size = br.ReadInt32();
                float[] heights = new float[size * size];

                for (int i = 0; i < size*size; i++)
                {
                    heights[i] = br.ReadSingle();
                }
                return new Chunk(size, heights);
            }
        }
    }

    public enum DockDirection 
    {
        Right,
        Left,
        Top,
        Bottom
    }
}
