using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Check ///<summary> чек на числа
    {
        public static double check(string a) ///<summary> чек на дабл
        {
            double a1;
            while (!double.TryParse(a, out a1))
            {
                Console.WriteLine("Неверный ввод попробуйте заново:");
                a = Console.ReadLine();
            }
            return a1;
        }
        public static int checkint(string a) ///<summary> чек на инт
        {
            int a1;
            while (!int.TryParse(a, out a1))
            {
                Console.WriteLine("Неверный ввод попробуйте заново:");
                a = Console.ReadLine();
            }
            return a1;
        }
    }
}
