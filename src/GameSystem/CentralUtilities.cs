using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem
{
    public static class CentralUtilities
    {
        private static Random _rand;

        static CentralUtilities()
        {
            _rand = new Random(Guid.NewGuid().GetHashCode());
        }

        #region Random Methods

        /// <summary>
        /// Returns a random double between 0 and 1.
        /// </summary>
        public static double RandomDouble()
        {
            return _rand.NextDouble();
        }

        /// <summary>
        /// Returns a nonnegative random integer.
        /// </summary>
        public static int RandomInteger()
        {
            return _rand.Next();
        }

        /// <summary>
        /// Returns an integer betweeen 0 and max.
        /// </summary>
        /// <param name="max">The maximum value.</param>
        public static int RandomInteger(int max)
        {
            return _rand.Next(max);
        }

        /// <summary>
        /// Returns an integer betweeen min and max.
        /// </summary>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        public static int RandomInteger(int min, int max)
        {
            return _rand.Next(min, max);
        }

        #endregion
        
    }
}
