using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace fractal_generator.Fractals
{
    class FractalPixelGenerator
    {
        public static List<List<int>> CreateMandleBot() //methods starting with create means it give the pixelList
        {
            int Width = 640; //(int)canvas.Width; //FIXME: how to get the canvas size?
            int Height = 480; //(int)canvas.Height;

            var tupleList = new List<List<int>> { }; //list for saving the co-ordinates and color code 


            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    double a = (double)(x - (Width / 2)) / (double)(Width / 4);
                    double b = (double)(y - (Height / 2)) / (double)(Height / 4);

                    Complex c = new Complex(a, b);
                    Complex z = new Complex(0, 0);

                    int it = 0;
                    do
                    {
                        it++;
                        z.Square();
                        z.Add(c);
                        if (z.Magnitude() > 4.0) break;

                    } while (it < 900);

                    // bm.SetPixel(x, y, it < 100 ? Color.Black : Color.White);
                    int color_code = ((it < 100 ? 1 : 0));
                    tupleList.Add(new List<int> { x, y, color_code });

                }
            }

            return tupleList;
        }

        public static List<List<int>> CreateSierpinskiGasket()
        {
            int WIDTH = 768;
            int HEIGHT = 768;

            List<List<int>> tupleList = new List<List<int>> { };
            for (int y = 0; y < WIDTH; y++)
            {
                for (int x = 0; x < HEIGHT; x++)
                {
                    if ((x & (y - x)) == 0)
                    {
                        //DrawPoint(x+158-y/2, y+30, 1);
                        tupleList.Add(new List<int> { x + ((WIDTH / 2) + 30) - y / 2, y + 30, 1 });
                    }
                }
            }

            return tupleList;
        }


        public static List<List<int>> CreateJuliaSet()
        {
            List<List<int>> pixelList = new List<List<int>>();
            int left = 20;
            int w = 300;
            int s = w / 3;
            int orig = left + w / 2;
            double xc = -1;
            double yc = 0.1;


            //    drawLine(1);
            // //    drawline(2);

            double xn = 0.25;
            double yn = 0;

            for (int i = 0; i < 5000; i++)
            {
                double a = xn - xc;
                double b = yn - yc;
                if (a == 0)
                {
                    xn = Math.Sqrt(Math.Abs(b) / 2);
                    if (xn > 0)
                    {
                        yn = b / (2 * xn);
                    }
                    else
                    {
                        yn = 0;
                    }
                }
                else if (a > 0)
                {
                    xn = Math.Sqrt((Math.Sqrt(a * a + b * b) + a) / 2);
                    yn = b / (2 * xn);
                }
                else
                {
                    xn = Math.Sqrt((Math.Sqrt(a * a + b * b) - a) / 2);
                    yn = b / (2 * yn);
                }

                if (i == 0)
                {
                    xn += .5;
                }

                if (new Random().Next() >= 0.5) //TODO: need to check the range of the random in java and c#
                {
                    xn = -xn;
                    yn = -yn;
                }

                Console.WriteLine((int)xn * s + orig + "  " + (int)-yn * xn + orig);
                pixelList.Add(new List<int> { (int)(xn * s + orig), (int)(-yn * xn + orig), 1 });
            }

            return pixelList;
        }


        public static List<List<int>> Fern()
        {
            List<List<int>> fernPixelList = new List<List<int>>();
            int imax = 10000;
            int left = 30;
            int w = 300;
            int wl = w + left;

            double e1 = 0.5 * w;
            double e2 = 0.57 * w;
            double e3 = 0.408 * w;
            double e4 = 0.1075 * w;
            double f1 = 0 * w;
            double f2 = -0.036 * w;
            double f3 = 0.0893 * w;
            double f4 = 0.27 * w;


            double x = e1;
            double y = 0;
            for (int i = 0; i < imax; i++)
            {
                double r = new Random().NextDouble();
                double xn, yn;
                if (r < 0.02)
                {
                    xn = 0 * x + 0 * y + e1;
                    yn = 0 * x + 0.27 * y + f1;
                }
                else if (r < 0.17)
                {
                    xn = -0.139 * x + 0.263 * y + e2;
                    yn = 0.246 * x + 0.224 * y + f2;
                }
                else if (r < 0.3)
                {
                    xn = 0.17 * x - 0.215 * y + e3;
                    yn = 0.222 * x + 0.176 * y + f3;
                }
                else
                {
                    xn = 0.781 * x + 0.034 * y + e4;
                    yn = -0.032 * x + 0.739 * y + f4;
                }

                fernPixelList.Add(new List<int>() { left + (int)xn, wl - (int)yn });
                x = xn;
                y = yn;
            }

            return fernPixelList;
        }

        public class CantorSet
        {
            private List<List<int>> cantorList = new List<List<int>>();
            private int n = 7;
            private double r = (double)(1 / 3);
            private Boolean devil = true;
            private int left = 30;
            private int w = 600;


            public List<List<int>> CreateCantor()
            {

                Cantor(1, left, left + (1 + (devil ? 1 : 0)) * w / 2, left + w, left + (1 - (devil ? 1 : 0)) * w / 2);
                double d = r < 1 ? Math.Log(2) / Math.Log(2 / (1 - r)) : 0;
                Console.WriteLine("Dimension of Cantor set: " + d, 10, 20);

                return cantorList;
            }

            public void Cantor(int level, double x1, double y1, double x2, double y2)
            {
                if (level < n) //fix variable name 
                {
                    double x = ((1 + r) * x1 + (1 - r) * x2) / 2;
                    double y = (y1 + y2) / 2;

                    Cantor(level + 1, x1, y1, x, y);
                    double xx = ((1 - r) * x1 + (1 + r) * x2) / 2;

                    if (devil)
                    {
                        cantorList.Add(new List<int>() { (int)x, (int)y, (int)xx, (int)y });
                    }

                    Cantor(level + 1, xx, y, x2, y2);
                }
                else
                {
                    cantorList.Add(new List<int>() { (int)x1, (int)y1, (int)x2, (int)y2 });
                }
            }

        }

        public static List<List<int>> CelularAutomata()
        {
            List<List<int>> pixelList = new List<List<int>>();
            int left = 30;
            int w = 300;
            int n = 2;

            int[] c = new int[1 + w / 2];
            int[] lut = { 1, 0, 0, 1 };

            for (int x = 1; x <= w / 2; x++)
            {
                c[x] = 0;
            }
            c[7] = 1; c[15] = 1; c[45] = 1;
            for (int x = 1; x <= w / 2; x++)
            {
                if (c[x] != 0)
                {
                    pixelList.Add(new List<int>() { 2 * x + left, 2 + left });
                }
            }
            if (n >= 2)
            {
                for (int y = 2; y <= w / 2; y++)
                {
                    int c0 = 0;
                    for (int x = 1; x <= w / 2; x++)
                    {
                        int c1 = c[x];
                        c[x] = (c0 + c1) % n;
                        c0 = c1;
                        if (c[x] != 0)
                        {
                            pixelList.Add(new List<int>() { 2 * x + left, 2 * y + left });
                        }
                    }
                }
            }
            else
            {
                for (int y = 2; y <= w / 2; y++)
                {
                    int c0 = 0;
                    for (int x = 1; x <= w / 2; x++)
                    {
                        int c1 = c[x];
                        c[x] = lut[2 * c0 + c1];
                        c0 = c1;
                        if (c[x] != 0)
                        {
                            pixelList.Add(new List<int>() { 2 * x + left, 2 * y + left });
                        }
                    }
                }
            }

            return pixelList;
        }
        public static double DegToRad(double pfDeg)
        {
            return pfDeg / 180.0 * Math.PI;
        }

        public double RadToDeg(double pfRad)
        {
            return pfRad * 180.0 / Math.PI;
        }
        public static List<List<int>> GenerateLorrentz()
        {
            List<List<int>> pixelList = new List<List<int>>();
            int iWidth = 600;
            int iHeight = 400;
            int iDim = 3;

            double rho, sigma, beta;
            double iterations;
            double x, y, z, d0_x, d0_y, d0_z, d1_x, d1_y, d1_z, d2_x, d2_y, d2_z;
            double d3_x, d3_y, d3_z, xt, yt, zt, dt, dt2, x_angle, y_angle, z_angle;
            double sx, sy, sz, cx, cy, cz, temp_x, temp_y, old_y;
            int i, row, col, old_row, old_col;
            int color = 0;

            iterations = 8000;
            rho = 28;
            sigma = 10;
            beta = 8.0 / 3.0;

            x_angle = 45;
            y_angle = 0;
            z_angle = 90;
            x_angle = DegToRad(x_angle);
            sx = Math.Sin(x_angle);
            cx = Math.Cos(x_angle);
            y_angle = DegToRad(y_angle);
            sy = Math.Sin(y_angle);
            cy = Math.Cos(y_angle);
            z_angle = DegToRad(z_angle);
            sz = Math.Sin(z_angle);
            cz = Math.Cos(z_angle);


            x = 0;
            y = 1;
            z = 0;

            if (iDim == 3)
            {
                old_col = (int)Math.Round(y * 9.0);
                old_row = (int)Math.Round(350.0 - 6.56 * z);
                // g.DrawLine(new Pen(oColor[0]), 0, 348, 638, 348);
                // g.DrawLine(new Pen(oColor[0]), 320, 2, 320, 348);
                // g.DrawLine(new Pen(oColor[0]), 320, 348, 648, 140);
            }
            else
            {
                old_col = (int)Math.Round(y * 9.0 + 320.0);
                old_row = (int)Math.Round(350.0 - 6.56 * z);
                pixelList.Add(new List<int>() { 0, 348, 639, 348 });
                pixelList.Add(new List<int>() { 320, 2, 320, 348 });
            }
            dt = 0.01;
            dt2 = dt / 2.0;
            for (i = 0; i <= iterations; i++)
            {
                d0_x = sigma * (y - x) * dt2;
                d0_y = (-x * z + rho * x - y) * dt2;
                d0_z = (x * y - beta * z) * dt2;
                xt = x + d0_x;
                yt = y + d0_y;
                zt = z + d0_z;
                d1_x = (sigma * (yt - xt)) * dt2;
                d1_y = (-xt * zt + rho * xt - yt) * dt2;
                d1_z = (xt * yt - beta * zt) * dt2;
                xt = x + d1_x;
                yt = y + d1_y;
                zt = z + d1_z;
                d2_x = (sigma * (yt - xt)) * dt;
                d2_y = (-xt * zt + rho * xt - yt) * dt;
                d2_z = (xt * yt - beta * zt) * dt;
                xt = x + d2_x;
                yt = y + d2_y;
                zt = z + d2_z;
                d3_x = (sigma * (yt - xt)) * dt2;
                d3_y = (-xt * zt + rho * xt - yt) * dt2;
                d3_z = (xt * yt - beta * zt / 3) * dt2;
                old_y = y;
                x = x + (d0_x + d1_x + d1_x + d2_x + d3_x) * 0.33333333;
                y = y + (d0_y + d1_y + d1_y + d2_y + d3_y) * 0.33333333;
                z = z + (d0_z + d1_z + d1_z + d2_z + d3_z) * 0.33333333;

                if (iDim == 3)
                {
                    temp_x = x * cx + y * cy + z * cz;
                    temp_y = x * sx + y * sy + z * sz;
                    col = (int)Math.Round(temp_x * 8.0 + 320.0);
                    row = (int)Math.Round(350.0 - temp_y * 5.0);
                }
                else
                {
                    col = (int)Math.Round(y * 9.0 + 320.0);
                    row = (int)Math.Round(350 - 6.56 * z);
                }
                if (col < 320)
                {
                    if (old_col >= 320)
                    {
                        color++;
                        color = color % 16;
                    }
                }
                if (col > 320)
                {
                    if (old_col <= 320)
                    {
                        color++;
                        color = color % 16;
                    }
                }
                pixelList.Add(new List<int>() { old_col, old_row, col, row });
                old_row = row;
                old_col = col;
            }

            return pixelList;
        }

        public static List<List<int>> GenerateKoch()
        {
            List<List<int>> pixelList = new List<List<int>>();

            double r = 0.29;
            int n = 5;

            koch(1, 30, 190, 30 + 300, 190);

            void koch(int level, double x1, double y1, double x2, double y2)
            {
                if (level < n)
                {
                    double nx = (2 * x1 + x2) / 3;
                    double ny = (2 * y1 + y2) / 3;
                    koch(level + 1, x1, y1, nx, ny);
                    double ox = nx;
                    double oy = ny;
                    nx = (x1 + x2) / 2 - r * (y1 - y2);
                    ny = (y1 + y2) / 2 + r * (x1 - x2);
                    koch(level + 1, ox, oy, nx, ny);
                    ox = nx;
                    oy = ny;
                    nx = (x1 + 2 * x2) / 3;
                    ny = (y1 + 2 * y2) / 3;
                    koch(level + 1, ox, oy, nx, ny);
                    koch(level + 1, nx, ny, x2, y2);
                }
                else
                {
                    pixelList.Add(new List<int>() { (int)x1, (int)y1, (int)x2, (int)y2 });
                }
            }

            return pixelList;
        }


    }

}




