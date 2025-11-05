using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO.Ports;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
class program
{
    public static double check(string a)
    {
        double a1;
        while (!double.TryParse(a, out a1))
        {
            Console.WriteLine("Неверный ввод попробуйте заново:");
            a = Console.ReadLine();
        }
        return a1;
    }
    public static double fre(double a)
    {
        double coefficient;
        if (a == 1)
        {
            coefficient = 1;
            return coefficient;
        }
        if (a == 2)
        {
            coefficient = 1.2;
            return coefficient;
        }
        if (a == 3)
        {
            coefficient = 0.85;
            return coefficient;
        }
        return a;
        
    }
    public static double two(double a)
    {
        double coefficientWeather;
        if (a == 1)
        {
            coefficientWeather = 1;
            return coefficientWeather;
        }
        if (a == 2)
        {
            coefficientWeather = 1.1;
            return coefficientWeather;
        }
        return a;

    }

    static void Main(string[] args)
    {
        int s = 1;
        int o = 1;
        do
        {
            int nomber;
            Console.WriteLine("1.Рассчитать поездку\n2.Выход");
            while (!int.TryParse(Console.ReadLine(), out nomber))
            {
                Console.WriteLine("неверный ввод");
                Console.Write("1.Рассчитать поездку\n2.Выход");
            }
            switch (nomber)
            {
                case 1:

                    double coefficient;
                    double coefficientWeather;
                    Console.WriteLine("введите расстояние в км:");
                    double distance = check(Console.ReadLine());
                    Console.WriteLine("введите цену топлива за литр:");
                    double price = check(Console.ReadLine());
                    Console.WriteLine("введите средний расход топлива на 100 км:");
                    double priceForDistance = check(Console.ReadLine());
                    Console.WriteLine("введите вид транспорта: \n1.Легковой автомобиль\n2.Грузовик \n3.Мотоцикл");
                    double car = check(Console.ReadLine());
                    double car1 = car;
                    for (; car1 < 0 || car1 > 3;)
                    {
                        Console.WriteLine("Неверный ввод попробуйте заново:");
                        car = check(Console.ReadLine());
                        car1 = car;
                    }

                    Console.WriteLine("введите сезон: \n1.лето\n2.зима");
                    double weather = check(Console.ReadLine());
                    double weather1 = weather;
                    for (; weather1 < 0 || weather1 > 2;)
                    {
                        Console.WriteLine("Неверный ввод попробуйте заново:");
                        weather = check(Console.ReadLine());
                        weather1 = weather;
                    }
                    coefficient = fre(car);
                    coefficientWeather = two(weather);
                    double consumption = distance * (priceForDistance / 100);
                    double fullprice = price * consumption;
                    double fullfullprice = fullprice * coefficient * coefficientWeather;
                    Console.WriteLine("Расход топлива:{0:f2}", consumption);
                    Console.WriteLine("Стоимость топлива:{0:f2}", fullprice);
                    Console.WriteLine("машшиный коэффициент:{0:f2}", coefficient);
                    Console.WriteLine("Сезонный коэффициент:{0:f2}", coefficientWeather);
                    Console.WriteLine("Итоговая стоимость{0:f2}", fullfullprice);
                    do
                    {
                        Console.WriteLine("Хотите сделать еще один расчет?(да/нет)");
                        string h = (Console.ReadLine());
                        if (h == "нет")
                        {
                            System.Environment.Exit(0);
                        }

                        else if (h == "да")
                        {
                            s = s + 2;
                        }
                        else if (h != "нет" && h != "да")
                        {

                            Console.WriteLine("неверный ввод");


                        }
                    }
                    while (s == 1);

                    break;

                case 2:


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
        while (o == 1);
    }

}
