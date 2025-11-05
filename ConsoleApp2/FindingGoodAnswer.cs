using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public static class FindingGoodAnswer  ///<summary> самая первая игра 
    {
        public static double mathematics(double a, double b)  ///<summary> математические действия
        {
            return Math.Round((-4 * Math.Pow(Math.Sin(3 * a), 3)) + (Math.Pow(b, 0.5) / Math.Log(b + 2)), 2);

        }
        public static void game(double a)   ///<summary> проверка и ввывод попыток
        {
            int r = 3;
            Console.WriteLine("Введите ответ:");
            double ansver = Check.check(Console.ReadLine());
            for (int i = 0; i < 2; i++)
            {
                if (ansver == a)
                {
                    Console.WriteLine("верный ответ");
                    i = i + 3;
                }
                else
                {
                    r--;
                    Console.Write("Отсалось попыток{0}\nневерно, попробуте заново: ", r);
                    ansver = Check.check(Console.ReadLine());
                }
                if (r == 1)
                {
                    Console.WriteLine("Вы проиграли: \nверный ответ:{0}", a);
                }
            }
        }
        public static void fullgame()  ///<summary> вся игра 
        {

            Console.WriteLine("введите чиcло a");
            double a = Check.check(Console.ReadLine());
            Console.WriteLine("введите число b");
            double b = Check.check(Console.ReadLine());
            double result = mathematics(a, b);
            game(result);
        }
    }
}
