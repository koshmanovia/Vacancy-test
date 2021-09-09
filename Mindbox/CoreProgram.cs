using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mindbox
{
   public abstract class Shape
    {
        public abstract double CalculateSquare();
    }
    public class Triangle : Shape
    {
        private double a;
        private double b;
        private double c;
        private double p;
        private bool rectangular;

        public double A
        {
            get { return a; }
            set { a = A; }
        }
        public double B
        {
            get { return b; }
            set { b = B; }
        }
        public double C
        {
            get { return c; }
            set { c = C; }
        }

        public bool Rectangular
        {
            get { return rectangular; }
        }

        public Triangle()
        {
            A = 0; B = 0; C = 0;
        }
        public Triangle(double a, double b, double c)
        {
            if (TriangleReally(a, b, c))
            {
                this.a = a;
                this.b = b;
                this.c = c;
                rectangular = checkRectangular(a, b, c);
            }
        }

        public override double CalculateSquare()
        {
            //TriangleReally(a, b, c);
            p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
        private bool TriangleReally(double a, double b, double c)
        {
            if ((a >= b + c) || (b >= a + c) || (c >= a + b))
            {
                throw new Exception("Triangle is not really"); 
            }
            else
            {
                return true;
            }
        }
        private bool checkRectangular(double a, double b, double c)
        {
            double max = default;
            double min = default;
            double medium = default;
            if ((a > b) && (a > c))
            {
                max = a;
            }
            else
            {
                if (b > c)
                {
                    max = b;
                }
                else
                {
                    max = c;
                }
            }
            if ((a < b) && (a < c))
            {
                min = a;
            }
            else
            {
                if (b < c)
                {
                    min = b;
                }
                else
                {
                    min = c;
                }
            }

            medium = a + b + c - min - max;
            if (((min * min) + (medium * medium)) == (max * max))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString() => $"Triangle. Side A = {a}, Side B = {b}, Side C = {c}, rectangular = {rectangular}";
    }

   public class Circle : Shape
    {
        private double r;

        public double R
        {
            get { return r; }
            set {r = R; }
        }
        public Circle(double r)
        {
            this.r = r;
        }
        public override double CalculateSquare()
        {
            return (Math.PI * r) / 2; 
        }
        public override string ToString() => $"Circle. Radius = {r}";
    }
}
