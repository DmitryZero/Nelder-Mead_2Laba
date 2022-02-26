using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nelder_Mead_2Laba
{
    class SimplexFunc
    {
        public static double ObjFunc(Point point)
        {
            return 305 * point.X * point.X +
                500 * point.Y * point.Y + 100;
        }
        /*public static double ObjFunc(Point point)
        {
            return point.X * point.X + point.X * point.Y + point.Y * point.Y - 6 * point.X - 9 * point.Y;
        }*/
    }
}
