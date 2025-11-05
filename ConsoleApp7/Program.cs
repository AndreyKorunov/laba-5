
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication16
{
    class Program
    {
        static (int X, int Y) apple;
        static void Main(string[] args)
        {
            (int X, int Y) apple;

            {
                int s = 1;
                do
                {
                    int nomder;

                    Console.WriteLine("1.Отгадай ответ \n2. Об авторе \n3. Выход");
                    while (!int.TryParse(Console.ReadLine(), out nomder))
                    {
                        Console.WriteLine("неверный ввод");
                        Console.WriteLine("1.Отгадай ответ \n2. Об авторе \n3. Выход");
                    }
                    switch (nomder)
                    {
                        case 1:
                            int r = 3;
                            string ansver1;
                            double ansver;
                            double a;
                            double b;
                            Console.WriteLine("введите чиcло a");
                            while (!double.TryParse(Console.ReadLine(), out a))
                            {
                                Console.WriteLine("Неверный ввод \n введите чиcло a");
                            }
                            Console.WriteLine("введите число b");
                            while (!double.TryParse(Console.ReadLine(), out b))
                            {
                                Console.WriteLine("Неверный ввод \n введите чиcло b");
                            }
                            double f = (-4 * Math.Pow(Math.Sin(3 * a), 3)) + (Math.Pow(b, 0.5) / Math.Log(b + 2));
                            double result = Math.Round(f, 2);
                            Console.WriteLine("Введите ответ:");
                            while (!double.TryParse(Console.ReadLine(), out ansver))
                            {
                                Console.WriteLine("Неверный ввод \n введите ответ:");
                            }

                            for (int i = 0; i < 2; i++)
                            {

                                if (ansver == result)
                                {
                                    Console.WriteLine("верный ответ");
                                    i = i + 3;

                                }
                                else if (b < 0)
                                {
                                    Console.WriteLine("корень из отрецательного числа");
                                    i = i + 3;
                                }

                                else
                                {
                                    r--;

                                    Console.WriteLine("Отсалось попыток{0} \n  неверно, попробуте заново:", r);



                                    while (!double.TryParse(Console.ReadLine(), out ansver))
                                    {
                                        Console.WriteLine("Неверный ввод \n введите ответ:");
                                    }

                                }
                                if (r == 1)
                                {


                                    Console.WriteLine("Вы проиграли: \nверный ответ:{0}", result);
                                }


                            }

                            break;
                        case 2:
                            Console.WriteLine("Автор: Корунов Андрей Александрович \n группа 6106-090301D");
                            break;




                        case 3:


                            string д;
                            string н;

                            do
                            {
                                Console.WriteLine("Вы уверены что хотите выйти?\n д\n н");
                                string h = (Console.ReadLine());
                                if (h == "н")
                                {
                                    s = s + 2;
                                }

                                else if (h == "д")
                                {
                                    System.Environment.Exit(0);
                                }
                                else if (h != "н" && h != "д")
                                {

                                    Console.WriteLine("неверный ввод");


                                }
                            }
                            while (s == 1);
                            break;


                        default:
                            Console.WriteLine("неверный ввод");
                            break;
                    }



                }

                while (s == 1);
            }
        }
    }
}