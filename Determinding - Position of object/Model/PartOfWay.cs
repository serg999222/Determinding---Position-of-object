using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Determinding___Position_of_object.Model
{
    internal class PartOfWay
    {
        public Vector2 Point { get; set; }
        public float Speed { get; set; }
        public Vector2? NextPoint { get; set; }
        public Vector2 Vector { get; set; }
        public TimeSpan TimeBegin { get; set; }
        public TimeSpan TimeEnd { get; set; }
        public TimeSpan Time { get; set; }
        public float Lenght { get; set; } 

        public PartOfWay(Vector2 point, float speed, TimeSpan timeBegin, Vector2? nextPoint)
        {
            Point = point;
            Speed = speed;
            NextPoint = nextPoint;
            TimeBegin = timeBegin;
            Vector = ((Vector2)(nextPoint == null ? Point - point : nextPoint - point));
            Lenght = Vector.Length();
            Time = Lenght != 0 ? TimeSpan.FromSeconds(Lenght / speed) : TimeSpan.MaxValue;
            TimeEnd = Time == TimeSpan.MaxValue ? TimeSpan.MaxValue :  Time + timeBegin;

        }


        public Vector2 GetPoint(TimeSpan time)
        {
            if (time < TimeBegin)
            {
                return new Vector2(float.NaN, float.NaN);
            }
            if (time == TimeBegin)
            {
                return Point;
            }
            var localTime = time - TimeBegin;
            var distance = localTime.TotalSeconds * Speed;
            var normVector = Vector2.Normalize(Vector);
            var result = Point + normVector * (float)distance;
            return result;
        }
    }
}
