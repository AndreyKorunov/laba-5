using ConsoleApp2;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace ConsoleApplication16
{
    
    class Program
    {
        
        static void Main(string[] args)
        {
            
            int nomber;
            {
                int s = 1;
                do
                {
                    nomber = Start();
                    switch (nomber)
                    {
                        case 1:
                            FindingGoodAnswer.fullgame();
                            break;
                        case 2:
                            name();
                            break;
                        case 3:
                            Console.WriteLine("введите размер массива");
                            int a = Check.checkint(Console.ReadLine());
                            MassivGame.massivegame();
                            Console.WriteLine("\n\n");
                            MassivGame.massivegame(a);
                            break;

                        case 4:
                            SnakeGame.Snakegame();
                            break;
                        case 5:
                            Outt();
                            break;
                        default:
                            Console.WriteLine("неверный ввод");
                            break;
                    }
                }
                while (s == 1);
            }
        }

        public static void name()
        {
            Console.WriteLine("Автор: Корунов Андрей Александрович \n группа 6106-090301D");
        } ///<summary> ввывод меня и группы 
        public static int Start()
        {
            int nomber;
            Console.WriteLine("1.Отгадай ответ \n2.Об авторе \n3.Сортировка массива\n4.Игра змейка\n5.Выход\n");
            while (!int.TryParse(Console.ReadLine(), out nomber))
            {
                Console.WriteLine("неверный ввод");
                Console.Write("1.Отгадай ответ \n2.Об авторе \n3.Сортировка массива\n4.Игра змейка\n5.Выход\n");
            }
            return nomber;
        }  ///<summary> стартуем
        public static bool Out(string a)
        {


            while (a != "д" && a != "н")
            {
                Console.WriteLine("неверный ввод");
                a = (Console.ReadLine());
            }
            if (a == "д")
            {
                return true;
            }

            return false;
        }  ///<summary> основной код выхода
        public static void Outt()
        {
            Console.WriteLine("Вы уверены что хотите выйти?\n д\n н");
            string a = Console.ReadLine();
            if (Out(a)) System.Environment.Exit(0);
        }///<summary> это чтоб красиво было
    }

}
    
