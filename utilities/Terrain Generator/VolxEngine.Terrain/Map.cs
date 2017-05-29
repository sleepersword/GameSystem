using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SCL.Diagnose;

namespace VolxEngine.Terrain
{

    /// <summary>
    /// Represents a 2-dimensional sorted array of points.
    /// </summary>
    /// <typeparam name="T">The type of the used point class, must inherit IPoint.</typeparam>
    public abstract class Map<T> where T : IPoint
    {
        public abstract int Width { get; }
        public abstract int Height { get; }

        public abstract T this[int x, int y] { get; set; }
    }
}
