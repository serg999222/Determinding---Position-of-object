using Determinding___Position_of_object.Data;
using Determinding___Position_of_object.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Determinding___Position_of_object.Logic
{
    internal class Engine
    {
       
        public List<PartOfWay> PartOfWays { get; set; }

        public  Engine()
        {
            PartOfWays = new List<PartOfWay>();
        }
      

        public void LoadPoints()
        {
            PartOfWays.Clear();
            var pointItemsColection = Points.GetItems;
            PartOfWay point = null;

            
            for (int i = 0; i < pointItemsColection.Length; i++)
            {
                var currentPoint = pointItemsColection[i];
                Vector2? nextCurrentPoint =null;
                if ( i < pointItemsColection.Length - 1)
                {
                    var nextCurrPoint = pointItemsColection[i + 1];
                    nextCurrentPoint = new Vector2(nextCurrPoint.X, nextCurrPoint.Y);
                }
                
                

                point = new PartOfWay
                    (new Vector2(currentPoint.X, currentPoint.Y),
                    currentPoint.V, (i == 0 ? TimeSpan.Zero : point.TimeEnd),
                    nextCurrentPoint);
                PartOfWays.Add(point);
            }
        }

        public PartOfWay GetManagePoint(TimeSpan time)
        {
            PartOfWay result = PartOfWays.FirstOrDefault(i => i.TimeBegin <= time && i.TimeEnd > time);
            return result;
        }

      public Vector2 GetPoint(TimeSpan time)
        {
            var point = GetManagePoint(time);
            var result = point?.GetPoint(time) ?? new Vector2(float.NaN, float.NaN);
            return result;

        }


    }
}
