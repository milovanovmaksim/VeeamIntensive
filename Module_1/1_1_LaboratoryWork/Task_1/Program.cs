using System;
using System.Diagnostics.Contracts;

namespace Module_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Circl circle1 = new Circl(23);
            Console.WriteLine(circle1);
            Circl circl2 = circle1.NewCircleByArea(60);
            Console.WriteLine(circl2);
        }
    }
    
    class Circl
    {
        
        public double Radius { get; private set; }
        public double Area { get; private set; }

        public Circl(double radius)
        {
            Radius = radius;
            Area = Math.PI * Math.Pow(Radius, 2);
        }

        public Circl NewCirclByRadius(double radius)
        {
            return new Circl(radius);
        }

        public Circl NewCircleByArea(double area)
        {
            double radius = Math.Sqrt(area / Math.PI);
            return new Circl(radius);
        }

        public override string ToString()
        {
            return $"Radius = {Radius} мм;  Area = {Area} мм^2";
        }
    } 
}
