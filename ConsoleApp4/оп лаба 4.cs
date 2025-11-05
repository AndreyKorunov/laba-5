
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
        const int Width = 20;
        const int Height = 20;
        const int BarriersCount = 40;
        static char[,] masiv = new char[Height, Width];
        static List<(int X, int Y)> barriers = new List<(int X, int Y)>();
        enum Direction { Up, Down, Left, Right, stay };
        static Direction currentDirection = Direction.stay;
        static LinkedList<(int X, int Y)> snake = new LinkedList<(int X, int Y)>();
        static (int X, int Y) apple;
        static Random rand = new Random();
        static int score = 0;
        static int b = 0;
        static bool gameover = false;
        static int number = 300;
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
                            fullgame();
                            break;
                        case 2:
                            name();
                            break;
                        case 3:
                            massivegame();
                            break;

                        case 4:
                            Snakegame();
                            Reset();
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
        }
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
        }
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
        }
        public static void Snakegame()
        {

            Сomplexity();
            CreateMasiv();
            PlaceBarriers();
            PlaceSnake();
            PlaceApple();
            while (!gameover)
            {
                ShowMasiv();
                Move();
                MoveSnake();
                Thread.Sleep(number);
            }
            Console.Clear();
            Console.WriteLine("\n\n\n");
            Console.WriteLine($"игра окончена. ваш результат: {score}");
            Console.WriteLine("\n\n\n");

        }
        static void CreateMasiv()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    masiv[y, x] = '.';
                }
            }
        }
        static void PlaceBarriers()
        {
            int placed = 0;
            while (placed < BarriersCount)
            {
                var point = (X: rand.Next(0, Width), Y: rand.Next(0, Height));
                if (masiv[point.Y, point.X] == '.' && !SnakeContains(point))
                {
                    masiv[point.Y, point.X] = 'X';
                    barriers.Add(point);
                    placed++;
                }
            }
        }

        static bool SnakeContains((int X, int Y) coordinates)
        {
            foreach (var s in snake)
            {
                if (s.X == coordinates.X && s.Y == coordinates.Y)
                    return true;
            }
            return false;
        }

        static void ShowMasiv()
        {
            Console.SetCursorPosition(0, 0);
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Console.Write($"{masiv[y, x]}" + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Очки: {score}");
        }

        static void Move()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        currentDirection = Direction.Up;
                        break;
                    case ConsoleKey.DownArrow:
                        currentDirection = Direction.Down;
                        break;
                    case ConsoleKey.LeftArrow:
                        currentDirection = Direction.Left;
                        break;
                    case ConsoleKey.RightArrow:
                        currentDirection = Direction.Right;
                        break;
                }
            }
        }

        static void MoveSnake()
        {
            var head = snake.First.Value;
            (int X, int Y) newHead = head;

            switch (currentDirection)
            {
                case Direction.Up:
                    newHead = (X: head.X, Y: head.Y - 1);
                    break;
                case Direction.Down:
                    newHead = (X: head.X, Y: head.Y + 1);
                    break;
                case Direction.Left:
                    newHead = (X: head.X - 1, Y: head.Y);
                    break;
                case Direction.Right:
                    newHead = (X: head.X + 1, Y: head.Y);
                    break;
            }
            GameOver(newHead);
        }

        static void PlaceSnake()
        {
            var start = (X: rand.Next(0, Width), Y: rand.Next(0, Height));
            snake.AddFirst(start);
            masiv[start.Y, start.X] = 'O';
        }

        static void PlaceApple()
        {
            (int X, int Y) position;
            do
            {
                position = (X: rand.Next(0, Width), Y: rand.Next(0, Height));
            } while (masiv[position.Y, position.X] != '.' && SnakeContains(position));
            apple = position;
            masiv[apple.Y, apple.X] = 'A';
        }
        static void GameOver((int X, int Y) newHead)
        {
            if (newHead.X < 0 || newHead.X >= Width || newHead.Y < 0 || newHead.Y >= Height)
            {
                gameover = true;
                return;
            }
            if (SnakeContains(newHead) && currentDirection != Direction.stay)
            {
                gameover = true;
                return;
            }
            if (masiv[newHead.Y, newHead.X] == 'X')
            {
                gameover = true;
                return;
            }
            if (currentDirection != Direction.stay)
            {
                snake.AddFirst(newHead);
                masiv[newHead.Y, newHead.X] = 'O';
            }
            if (newHead.X == apple.X && newHead.Y == apple.Y)
            {
                score++;
                PlaceApple();
            }
            else
            {
                if (currentDirection != Direction.stay)
                {
                    var tail = snake.Last.Value;
                    snake.RemoveLast();
                    masiv[tail.Y, tail.X] = '.';
                }
            }
        }
        public static void Outt()
        {
            Console.WriteLine("Вы уверены что хотите выйти?\n д\n н");
            string a = Console.ReadLine();
            if (Out(a)) System.Environment.Exit(0);
        }
        public static void Reset()
        {
            currentDirection = Direction.stay;
            score = 0;
            gameover = false;
            snake.Clear();
        }
        public static void Сomplexity()
        {
            Console.WriteLine("Выберите сложность(1, 2, 3)");
            number = int.Parse(Console.ReadLine());
            while (number != 1 && number != 2 && number != 3)
            {
                Console.WriteLine("Неверный ввод попробуйте заново:");
                number = int.Parse(Console.ReadLine());
            }
            switch (number)
            {
                case 1:
                    number = 300;
                    break;
                case 2:
                    number = 200;
                    break;
                case 3:
                    number = 100;
                    break;
                default:
                    Console.WriteLine("неверный ввод");
                    break;
            }
        }
        public static double Check(string a)
        {
            double a1;
            while (!double.TryParse(a, out a1))
            {
                Console.WriteLine("Неверный ввод попробуйте заново:");
                a = Console.ReadLine();
            }
            return a1;
        }
        public static double mathematics(double a, double b)
        {
            return Math.Round((-4 * Math.Pow(Math.Sin(3 * a), 3)) + (Math.Pow(b, 0.5) / Math.Log(b + 2)), 2);

        }
        public static void game(double a)
        {
            int r = 3;
            Console.WriteLine("Введите ответ:");
            double ansver = Check(Console.ReadLine());
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
                    ansver = Check(Console.ReadLine());
                }
                if (r == 1)
                {
                    Console.WriteLine("Вы проиграли: \nверный ответ:{0}", a);
                }
            }
        }
        public static void fullgame()
        {

            Console.WriteLine("введите чиcло a");
            double a = Check(Console.ReadLine());
            Console.WriteLine("введите число b");
            double b = Check(Console.ReadLine());
            double result = mathematics(a, b);
            game(result);
        }
        public static int[] masive(int n)
        {
            int[] masiv = new int[n];
            masiv = random(masiv, (int)n);
            return masiv;


        }
        public static int[] random(int[] a, int n)
        {
            Random nombers = new Random();
            for (int i = 0; i < n; i++)
            {
                a[i] = nombers.Next(-10000, 10000);
            }
            return a;
        }
        public static int checkmas(string a)
        {
            int f = checkint(a);

            while (f <= 0)
            {
                Console.WriteLine("размер такого массива не может быть\n попробуте заново:");
                f = checkint(Console.ReadLine());
            }
            return f;
        }
        public static int[] copy(int[] a)
        {
            int[] b = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                b[i] = a[i];
            }
            return b;
        }
        public static int checkint(string a)
        {
            int a1;
            while (!int.TryParse(a, out a1))
            {
                Console.WriteLine("Неверный ввод попробуйте заново:");
                a = Console.ReadLine();
            }
            return a1;
        }
        public static int[] gnomic(int[] a)
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
        public static int[] SelectionSorsorting(int[] a)
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
        public static void sazemassive(int[] a)
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
        public static void massivegame()
        {
            Console.WriteLine("Введите размер массива");
            int n = checkmas(Console.ReadLine());
            int[] a = masive(n);
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