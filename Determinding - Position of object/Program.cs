

using Determinding___Position_of_object.Data;
using Determinding___Position_of_object.Logic;
using System.Numerics;

internal class Program
{
    private static void Main(string[] args)
    {
        var engine = new Engine();
        engine.LoadPoints();

        /* Задаємо значення часу в секундах та розміщуемо в список  */
        var times = new double[] {0, 33, 3, 4, 6 , 25 };
       
        foreach(var time in times)
        {
            var point = engine.GetPoint(TimeSpan.FromSeconds(time));
            if(float.IsNaN(point.X) && float.IsNaN(point.Y))
            {
                Console.WriteLine($" { time} :За поточний час було перевищено сумарну відстань заданих точок");
            }
            else
            {
                Console.WriteLine($" {time} : x - {point.X}  y - {point.Y}");
            }
           
        }

    }
}