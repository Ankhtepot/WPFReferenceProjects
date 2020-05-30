using System;
using System.Collections.Generic;
using System.Text;

namespace ItemsAsGridLine.Extensions
{
    public static class PZIntExtensions
    {
        public static int Clamp(this int input, int min, int max)
        {
            if (input < min) return min;
            if (input > max) return max;

            return input;
        }
    }
}
