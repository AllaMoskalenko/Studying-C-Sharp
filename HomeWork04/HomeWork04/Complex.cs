using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork04
{
    public class Complex
    {
        public double r, i;

        public Complex(double r, double i)
        {
            this.r = r;
            this.i = i;
        }

        public Complex()
        {
            this.r = 0;
            this.i = 0;
        }

        //addition
        public static Complex Add (Complex x, Complex y )
        {
            return new Complex(x.r + y.r, x.i + y.i);
        }

        //subtraction
        public static Complex Sub (Complex x, Complex y) 
        {
            return new Complex(x.r - y.r, x.i - y.i);
        }

        //multiplication
        public static Complex Mul (Complex x, Complex y)
        {
            return new Complex (x.r * y.r - x.i * y.i, x.i * y.r + x.r * y.i);
        }

        //division
        public static Complex Div (Complex x, Complex y)
        {
            double divr, divi;
            divr = (x.r * y.r + x.i * y.i) / (y.r * y.r + y.i * y.i);
            divi = (x.i * y.r - x.r * y.i) / (y.r * y.r + y.i * y.i);
            return new Complex (divr, divi);
        }
    }
}
