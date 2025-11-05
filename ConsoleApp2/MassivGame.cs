using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class MassivGame  ///<summary> класс под игру с массивом
    {
        public int[] a = new int[10];
        public static int[] masive(int n) ///<summary> создаём массив и заполняем рондомом
        {
            int[] masiv = new int[n];
            masiv = random(masiv, (int)n);
            return masiv;


        }
        public static int[] random(int[] a, int n) ///<summary> заполнсяем рандомом
        {
            Random nombers = new Random();
            for (int i = 0; i < n; i++)
            {
                a[i] = nombers.Next(-10000, 10000);
            }
            return a;
        }
        public static int checkmas(string a)  ///<summary> чекаем на отрицательный размер
        {
            int f = Check.checkint(a);

            while (f <= 0)
            {
                Console.WriteLine("размер такого массива не может быть\n попробуте заново:");
                f = Check.checkint(Console.ReadLine());
            }
            return f;
        }
        public static int[] copy(int[] a)  ///<summary> копировка
        {
            int[] b = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                b[i] = a[i];
            }
            return b;
        }
        public static int[] gnomic(int[] a)///<summary> сортировка гномиком
        {
            int i = 0;
            while (i < a.Length)
            {
                if (i == 0 || a[i] >= a[i - 1])
                    i++;
                else
                {
                    int y = a[i];
                    a[i] = a[i - 1];
                    a[i - 1] = y;
                    i--;

                }

            }
            return a;
        }
        public static int[] SelectionSorsorting(int[] a)///<summary> сортировка сальтом
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[j] < a[min])
                    {
                        min = j;
                    }
                }
                int b = a[i];
                a[i] = a[min];
                a[min] = b;
                min = i;
            }
            return a;
        }
        public static void sazemassive(int[] a) ///<summary> если больше 10 не ввыводим на экран
        {
            string rezult = "";
            if (a.Length > 10)
            {
                Console.WriteLine("размер массива больше 10");
            }
            else foreach (int i in a)
                {
                    rezult += i.ToString() + ",";
                }
            Console.WriteLine(rezult);


        }
        public static void massivegame() ///<summary> сама прога для константы (10)
        {
            int[] a = new int[10];
            a = masive(10);
            int[] b = copy(a);
            int[] c = copy(a);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            b = gnomic(b);
            stopwatch.Stop();
            var Time = stopwatch.Elapsed;
            stopwatch.Start();
            b = gnomic(b);
            stopwatch.Stop();
            var Time2 = stopwatch.Elapsed;
            Console.WriteLine(Time);
            Console.WriteLine(Time2);
            if (Time < Time2)
            {
                Console.WriteLine("1.Способ быстрее");
            }
            else Console.WriteLine("2.Способ быстрее");
            sazemassive(a);
            sazemassive(b);
        }
        public static void massivegame(int n) ///<summary> сама прога для пользовательского числа
        {
            int[] a = new int[10];
            a = masive(n);
            int[] b = copy(a);
            int[] c = copy(a);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            b = gnomic(b);
            stopwatch.Stop();
            var Time = stopwatch.Elapsed;
            stopwatch.Start();
            b = gnomic(b);
            stopwatch.Stop();
            var Time2 = stopwatch.Elapsed;
            Console.WriteLine(Time);
            Console.WriteLine(Time2);
            if (Time < Time2)
            {
                Console.WriteLine("1.Способ быстрее");
            }
            else Console.WriteLine("2.Способ быстрее");
            sazemassive(a);
            sazemassive(b);
        }
    }
}
