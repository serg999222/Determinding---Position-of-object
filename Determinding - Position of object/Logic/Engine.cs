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
       
        public List<ManagePoint> ManagePoints { get; set; }

        public  Engine()
        {
            ManagePoints = new List<ManagePoint>();
        }
      

        public void LoadPoints()
        {
            ManagePoints.Clear();
            var pointItemsColection = Points.GetItems;
            ManagePoint point = null;
            Vector2? nextPoint = null;
            
            for (int i = 0; i < pointItemsColection.Length; i++)
            {
                var currentPoint = pointItemsColection[i];
                Vector2? nextCurrentPoint =null;
                if ( i < pointItemsColection.Length - 1)
                {
                    var nextCurrPoint = pointItemsColection[i + 1];
                    nextCurrentPoint = new Vector2(nextCurrPoint.X, nextCurrPoint.Y);
                }
                
                

                point = new ManagePoint
                    (new Vector2(currentPoint.X, currentPoint.Y),
                    currentPoint.V, (i == 0 ? TimeSpan.Zero : point.TimeEnd),
                    nextCurrentPoint);
                ManagePoints.Add(point);
            }
        }

        public ManagePoint GetManagePoint(TimeSpan time)
        {
            ManagePoint result = ManagePoints.FirstOrDefault(i => i.TimeBegin <= time && i.TimeEnd > time);
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
