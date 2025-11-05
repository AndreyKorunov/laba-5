using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp2
{
    internal class SnakeGame /// класс хранит всю логику игры змейка
    {
        const int Width = 20; ///<summary> константа ширины
        const int Height = 20; ///<summary> константа высоты
        const int BarriersCount = 40; ///<summary> количество барьеров
        static char[,] masiv = new char[Height, Width]; ///<summary> массив 20 на 20
        static List<(int X, int Y)> barriers = new List<(int X, int Y)>();///<summary> список расположения барберов (их координаты x и y)
        enum Direction { Up, Down, Left, Right, stay };///<summary> константа направления ( вверз вниз влево вправо стойка)
        static Direction currentDirection = Direction.stay;///<summary> само направление которое мы будем менять (изночально стоим не рыпаемся)
        static LinkedList<(int X, int Y)> snake = new LinkedList<(int X, int Y)>();/// <summary>список с координатами змеи
        static (int X, int Y) apple;///<summary> невероятный кортедж!! нужен для записи координат яблок(так легче чем через список)
        static Random rand = new Random();///<summary> переменная ранд 
        static int score = 0;///<summary> счетчик яблок
        static bool gameover = false;///<summary> гаме овер чтоб игру закончить
        static int number;///<summary> меняем сложность чем меньше тем сложнее
        public static void Snakegame() ///<summary> сам код игры
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
            Reset();

        }
        static void CreateMasiv()        ///<summary> создаем массив
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    masiv[y, x] = '.';
                }
            }
        }
        static void PlaceBarriers()    ///<summary> ставим барьеры в клетки где нету змейки и есть точки и добавляем их всех в список
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

        static bool SnakeContains((int X, int Y) coordinates)   ///<summary> чекает на совпадения с координатами из списка змеки, введённые координаты и там bool
        {
            foreach (var s in snake)
            {
                if (s.X == coordinates.X && s.Y == coordinates.Y)
                    return true;
            }
            return false;
        }

        static void ShowMasiv() ///<summary> показывает массив
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

        static void Move()   ///<summary> меняет направление змейки
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

        static void MoveSnake()   ///<summary> двигает змейку
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

        static void PlaceSnake()   ///<summary> располагает змеку в самом начале
        {
            var start = (X: rand.Next(0, Width), Y: rand.Next(0, Height));
            snake.AddFirst(start);
            masiv[start.Y, start.X] = 'O';
        }

        static void PlaceApple()  ///<summary> располагает яблоко в самом начале
        {
            (int X, int Y) position;
            do
            {
                position = (X: rand.Next(0, Width), Y: rand.Next(0, Height));
            } while (masiv[position.Y, position.X] != '.' && SnakeContains(position));
            apple = position;
            masiv[apple.Y, apple.X] = 'A';
        }
        static void GameOver((int X, int Y) newHead)  ///<summary> чекаем на порожение
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
        public static void Reset()  ///<summary> обнавляем все переменые чтоб чикл норм работал
        {
            currentDirection = Direction.stay;
            score = 0;
            gameover = false;
            snake.Clear();
        }
        public static void Сomplexity() ///<summary> сложность как сложность от легкого к сложному
        {
            Console.WriteLine("Выберите сложность(1, 2, 3)");
            number = Check.checkint(Console.ReadLine());
            while (number != 1 && number != 2 && number != 3)
            {
                Console.WriteLine("Неверный ввод попробуйте заново:");
                number = Check.checkint(Console.ReadLine());
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
    }
}
