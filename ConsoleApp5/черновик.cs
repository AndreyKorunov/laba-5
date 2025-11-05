using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
class Program
{
    static (int X, int Y) apple;
    static void Main()
    {
        int apples = 0;
        int number = 0;
        string[,] masiv = CreateMasiv();
        Сonclusion(masiv);
        List<Point> body = Head(masiv);
        for (int s = 0; s > -10;)
        {
            Console.WriteLine("Ваш счет:{0}", apples);
            apples =  apples + Movement(body, masiv);
            if (apples < 0)
            {
                int op = apples + 100;
                Console.WriteLine("вы проиграли!\nВаш счет:{0}", op);
                s = s - 100;
            }
            
        }
    }

    public static List<Point> Head(string[,] s)
    {
        List<Point> ds = new List<Point>();
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {

                if (s[i, j] == "0")
                {
                    int a = i;
                    int b = j;
                    List<Point> body = new List<Point>();
                    body.Add(new Point(a, b));
                    return body;
                }
            }
        }
        return ds;
    }
    public static List<Point> Apple(string[,] s)
    {
        List<Point> h = new List<Point>();
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                if (s[i, j] == "A")
                {
                    int a = i;
                    int b = j;
                    List<Point> apple = new List<Point>();
                    apple.Add(new Point(a, b));
                    a = 1; b = 0;
                    apple.Add(new Point(a, b));
                    return apple;
                }
            }
        }
        return h;
    }
    public static void Сonclusion(string[,] a)
    {
        int rows = a.GetUpperBound(0) + 1;
        int columns = a.Length / rows;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write($"{a[i, j]}" + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    public static int Movement(List<Point> body, string[,] masiv)
    {
        List<Point> apple = Apple(masiv);
        Point head = body[0];
        Point newHead = new Point(head.X, head.Y);
        Point apple1 = apple[0];
        Point apple2 = new Point(apple1.X, apple1.Y);
        int j = 1;
        int s = 0;
        ConsoleKeyInfo left = Console.ReadKey();
        
        
            if (left.Key == ConsoleKey.LeftArrow)
            {
                newHead.Y--;
            }
            if (left.Key == ConsoleKey.DownArrow)
            {
                newHead.X++;
            }
            if (left.Key == ConsoleKey.UpArrow)
            {
                newHead.X--;
            }
            if (left.Key == ConsoleKey.RightArrow)
            {
                newHead.Y++;
            }
            else if (left.Key != ConsoleKey.RightArrow && left.Key != ConsoleKey.UpArrow && left.Key != ConsoleKey.DownArrow && left.Key != ConsoleKey.LeftArrow)
            {
                Console.WriteLine("Неверный ввод попробуй снова:");
            }
            int number = 0;
            int X = newHead.X;
            int Y = newHead.Y;
            body.Insert(0, newHead);
            int x = apple2.X;
            int y = apple2.Y;  
            if (x == X && y == Y)
            {
                masiv[x, y] = "0";
                for (int i = 0; i < 1; i++)
                {
                    number = 1;
                    Random g = new Random();
                    int a = g.Next(1, 20);
                    g = new Random();
                    int b = g.Next(1, 20);
                    if (masiv[a, b] == "X")
                    {
                        i--;
                    }
                    if (masiv[a, b] == "0")
                    {
                        i--;
                    }
                    if (masiv[a, b] == ".")
                    {
                        masiv[a, b] = "A";
                        i = i + 100;
                        apple = Apple(masiv);
                        
                        Сonclusion(masiv);
                        return number;
                    }
                }
            }
            if (masiv[X, Y] == "X")
            {
                s = -100;
            }
            if (masiv[X, Y] == "0")
            {
                s = -100;
            }
            if (masiv[X, Y] == "_")
            {
                s = -100;
            }
            if (masiv[X, Y] == "|")
            {
                s = -100;
            }
            else
            {
                Point lastPoint = body.Last();
                int o = lastPoint.X;
                int p = lastPoint.Y;
                masiv[o, p] = ".";
                body.RemoveAt(body.Count - 1);
                masiv[X, Y] = "0";
                Сonclusion(masiv);
            }
        
        return s;
    }
    public static string[,] AppleCreate(string[,] masiv)
    {
        
        for (int i = 0; i < 1; i++)
        {
            Random g = new Random();
            int x = g.Next(1, 20);
            g = new Random();
            int y = g.Next(1, 20);
            if (masiv[x, y] == "X")
            {
                i--;
            }
            if (masiv[x, y] == "0")
            {
                i--;
            }
            if (masiv[x, y] == ".")
            {
                masiv[x, y] = "A";
                i = i + 100;
                return masiv;
            }
        }
        return masiv;
    }
    public static string[,] CreateMasiv()
    {

        string[,] masiv = new string[21, 21];
        for (int i = 1; i < 20; i++)
        {
            for (int j = 1; j < 20; j++)
            {
                masiv[i, j] = ".";
            }
        }
        for (int i = 1; i < 20; i++)
        {
            int j = 0;
            masiv[i,j] = "|";
        }
        for (int i = 1; i < 20; i++)
        {
            int j = 20;
            masiv[i, j] = "|";
        }
        for (int j = 0; j < 21; j++)
        {
            int i = 20;
            masiv[i, j] = "_";
        }
        for (int j = 0; j < 21; j++)
        {
            int i = 0;
            masiv[i, j] = "_";
        }
        for (int i = 0; i < 40; i++)
        {
            Random g = new Random();
            int l = g.Next(2, 19);
            g = new Random();
            int k = g.Next(2, 19);
            masiv[l, k] = "X";
        }

        for (int i = 0; i < 1; i++)
        {
            Random g = new Random();
            int x = g.Next(2, 19);
            g = new Random();
            int y = g.Next(2, 19);
            masiv[x, y] = "0";
        }
        for (int i = 0; i < 1; i++)
        {
            Random g = new Random();
            int x = g.Next(2, 19);
            g = new Random();
            int y = g.Next(2, 19);
            if (masiv[x, y] == "X")
            {
                i--;
            }
            if (masiv[x, y] == "0")
            {
                i--;
            }
            if (masiv[x, y] == ".")
            {
                masiv[x, y] = "A";
                i = i + 100;
            }
        }
        return masiv;
    }
    public static int AppleCount(int a)
    {
        if (a > 0)
        {
            int apple = a;
            return apple;
        }
        return 0;
    }
    public static int Movement1(List<Point> body, string[,] masiv)
    {
        List<Point> apple = Apple(masiv);
        Point head = body[0];
        Point newHead = new Point(head.X, head.Y);
        Point apple1 = apple[0];
        Point apple2 = new Point(apple1.X, apple1.Y);
        int j = 1;
        int s = 0;
        ConsoleKeyInfo left = Console.ReadKey();


        if (left.Key == ConsoleKey.LeftArrow)
        {
            newHead.Y--;
        }
        if (left.Key == ConsoleKey.DownArrow)
        {
            newHead.X++;
        }
        if (left.Key == ConsoleKey.UpArrow)
        {
            newHead.X--;
        }
        if (left.Key == ConsoleKey.RightArrow)
        {
            newHead.Y++;
        }
        else if (left.Key != ConsoleKey.RightArrow && left.Key != ConsoleKey.UpArrow && left.Key != ConsoleKey.DownArrow && left.Key != ConsoleKey.LeftArrow)
        {
            Console.WriteLine("Неверный ввод попробуй снова:");
        }
        int number = 0;
        int X = newHead.X;
        int Y = newHead.Y;
        body.Insert(0, newHead);
        int x = apple2.X;
        int y = apple2.Y;
        if (x == X && y == Y)
        {
            masiv[x, y] = "0";
            for (int i = 0; i < 1; i++)
            {
                number = 1;
                Random g = new Random();
                int a = g.Next(1, 20);
                g = new Random();
                int b = g.Next(1, 20);
                if (masiv[a, b] == "X")
                {
                    i--;
                }
                if (masiv[a, b] == "0")
                {
                    i--;
                }
                if (masiv[a, b] == ".")
                {
                    masiv[a, b] = "A";
                    i = i + 100;
                    apple = Apple(masiv);

                    Сonclusion(masiv);
                    return number;
                }
            }
        }
        if (masiv[X, Y] == "X")
        {
            s = -100;
        }
        if (masiv[X, Y] == "0")
        {
            s = -100;
        }
        if (masiv[X, Y] == "_")
        {
            s = -100;
        }
        if (masiv[X, Y] == "|")
        {
            s = -100;
        }
        else
        {
            Point lastPoint = body.Last();
            int o = lastPoint.X;
            int p = lastPoint.Y;
            masiv[o, p] = ".";
            body.RemoveAt(body.Count - 1);
            masiv[X, Y] = "0";
            Сonclusion(masiv);
        }
        return s;
    }


}