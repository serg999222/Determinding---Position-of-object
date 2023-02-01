using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Determinding___Position_of_object.Data
{
    internal class Points
    {
        public static PointsItem[] GetItems => new PointsItem[]
        {
            new PointsItem { X = 1, Y = 1, V = 1 },
            new PointsItem { X = 2, Y = 3, V = 5 },
            new PointsItem { X = 19, Y = 33, V = 5 },
            new PointsItem { X = 1, Y = 4, V = 5 },
            new PointsItem { X = 1, Y = 5, V = 1 },
            new PointsItem { X = 1, Y = 6, V = 1 },
        };
    };
}
