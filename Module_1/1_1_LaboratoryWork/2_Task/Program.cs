using System;
using System.Collections.Generic;

namespace _2_Task
{
    interface IShape2D
    {
        int CoorX { get; set; }
        int CoorY { get; set; }
        public virtual void Draw()
        {
            Console.WriteLine("Draw a shape");
        }
    }
    
    public struct Point2D
    {
        public int X, Y;
        public string PointName;
        public Point2D(int x, int y, string point_name)
        {
            X = x;
            Y = y;
            PointName = point_name;
        }

        public override string ToString()
        {
            return $"Point({PointName}) (X={X}; Y={Y})";
        }
    }

    struct Triangle : IShape2D
    {
        public List<Point2D> Points;
        
        public int CoorX { get; set; }
        public int CoorY { get; set; }
        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Draw a triangle at position with coordinates: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"(X = {CoorX}; Y = {CoorY})\n");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nCoordinates triangle points:");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Points[0]}\n{Points[1]}\n{Points[2]}\n", ConsoleColor.Green);
            Console.ResetColor();
        }

        public Triangle(int X, int Y, List<Point2D> points)
        {
            CoorX = X;
            CoorY = Y; 
            Points = points; 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Point2D> points = new List<Point2D> { 
                new Point2D {X = 6, Y = 5, PointName="A"},
                new Point2D {X = 8, Y = 2, PointName="B"},
                new Point2D {X = 5, Y = 25, PointName="C"}};
            Triangle triangle = new Triangle(10, 52, points);
            triangle.Draw();

            IShape2D triangle2 = new Triangle(10, 245, points);
            triangle2.Draw();
        }
    }
}
