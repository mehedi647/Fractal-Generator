using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fractal_generator.Fractals
{
    public class Complex
    {
        public double a; //real part
        public double b; //imaginary part

        public Complex(double a, double b)
        {
            this.a = a;
            this.b = b;
        }
        public void Square()
        {
            double temp = (a * a) - (b * b);
            b = 2.0 * a * b;
            a = temp;
        }

        public double Magnitude()
        {
            return Math.Sqrt((a * a) + (b * b));
        }

        public void Add(Complex c)
        {
            a += c.a;
            b += c.b;
        }
    }
}