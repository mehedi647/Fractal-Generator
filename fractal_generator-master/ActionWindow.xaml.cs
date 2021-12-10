using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using fractal_generator.Model;
using fractal_generator.Fractals;

namespace fractal_generator
{
    /// <summary>
    /// Interaction logic for ActionWindow.xaml
    /// </summary>
    public partial class ActionWindow : Window
    {
        private Fractal fractal;
        public ActionWindow(Fractal fractal)
        {
            this.fractal = fractal;
            InitializeComponent();
            ExecuteAssociatedFunction(fractal.Id);
        }

        private void ExecuteAssociatedFunction(int id)
        {
            if (id == 1)
            {
                DrawListRandom(FractalPixelGenerator.CreateMandleBot());
            }

            if (id == 2)
            {
                DrawSierpinskiGasket(FractalPixelGenerator.CreateSierpinskiGasket());
            }
            if (id == 3)
            {
                //FractalPixelGenerator.CreateJuliaSet(); FIXME: for the time being it being tested for CreateCantor(), needs to changed;L
                DrawLorrentz(FractalPixelGenerator.GenerateLorrentz());


            }

            if (id == 4)
            {
                DrawFern(FractalPixelGenerator.Fern());// FERN IS DONE!
            }

            if (id == 5)
            {
                DrawCellularAutomata(FractalPixelGenerator.CelularAutomata());

            }

            if (id == 6)
            {
                DrawKoch(FractalPixelGenerator.GenerateKoch());

            }

        }
        void DrawPoint(int x, int y, int choice) //blue background, yellow middle purple dots
        {
            Task.Run(() =>
              {
                  this.Dispatcher.Invoke(() =>

                   {
                       Console.WriteLine("DrawPoint() EXECUTE");
                       int dotSize = 2;

                       Ellipse currentDot = new Ellipse();

                       if (choice == 0)
                       {
                           int random = new Random().Next(1);
                           if (random == 0)
                           {
                               currentDot.Stroke = new SolidColorBrush(Colors.DarkOrange);
                               currentDot.Fill = new SolidColorBrush(Colors.DarkOrange);
                           }
                           else
                           {
                               currentDot.Stroke = new SolidColorBrush(Colors.OrangeRed);
                               currentDot.Fill = new SolidColorBrush(Colors.OrangeRed);
                           }
                       }
                       else
                       {
                           int random = new Random().Next(1);
                           if (random == 0)
                           {
                               currentDot.Stroke = new SolidColorBrush(Colors.DarkBlue);
                               currentDot.Fill = new SolidColorBrush(Colors.DarkBlue);
                           }
                           else
                           {
                               currentDot.Stroke = new SolidColorBrush(Colors.Blue);
                               currentDot.Fill = new SolidColorBrush(Colors.Blue);
                           }
                       }
                       currentDot.StrokeThickness = 1;
                       //   Canvas.SetZIndex(currentDot, 3);
                       currentDot.Height = dotSize;
                       currentDot.Width = dotSize;
                       currentDot.Margin = new Thickness(x, y, 0, 0); // Sets the position.
                       canvas.Children.Add(currentDot);
                       Console.WriteLine(x + " " + y);
                   });
              });
        }

        void DrawLine(int x1, int y1, int x2, int y2)
        {
            Line line = new Line();
            line.Stroke = Brushes.Blue;

            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;

            line.StrokeThickness = 1;
            canvas.Children.Add(line);
        }


        void DrawSierpinskiGasket(List<List<int>> pixelList)
        {
            DispatcherTimer t = new DispatcherTimer();
            t.Tick += t_drawPoints;
            t.Interval = new TimeSpan(0, 0, 0, 0, 1);
            t.Start();

            void t_drawPoints(object sender, EventArgs e)
            {
                try
                {
                    for (int i = 0; i < 10; i++)
                    {
                        var firstElement = pixelList[0];
                        DrawPoint(firstElement[0], firstElement[1], firstElement[2]);
                        pixelList.RemoveAt(0);
                    }
                }
                catch (Exception)
                {
                    t.Stop();
                }


            }
        }
        void DrawListRandom(List<List<int>> pixelList)
        {
            DispatcherTimer t = new DispatcherTimer();
            pixelList = ShuffleList(pixelList);

            t.Tick += t_drawPoints;
            t.Interval = new TimeSpan(0, 0, 0, 0, 1);
            t.Start();


            void t_drawPoints(object sender, EventArgs e)
            {
                for (int i = 0; i < 1000; i++)
                {
                    var randomElement = pixelList[0];
                    DrawPoint(randomElement[0], randomElement[1], randomElement[2]);
                    pixelList.RemoveAt(0);
                }

            }
        }
        private List<E> ShuffleList<E>(List<E> inputList)
        {
            List<E> randomList = new List<E>();

            Random r = new Random();
            int randomIndex = 0;
            while (inputList.Count > 0)
            {
                randomIndex = r.Next(0, inputList.Count); //Choose a random object in the list
                randomList.Add(inputList[randomIndex]); //add it to the new, random list
                inputList.RemoveAt(randomIndex); //remove to avoid duplicates
            }

            return randomList;
        }

        void DrawListIteration(List<List<int>> pixelList)
        {
            DispatcherTimer t = new DispatcherTimer();

            Console.WriteLine("LENGTH: " + pixelList.Count);
            t.Tick += t_drawPoints;
            t.Interval = new TimeSpan(0, 0, 0, 0, 1);
            t.Start();

            void t_drawPoints(object sender, EventArgs e)
            {
                for (int i = 0; i < 10; i++) //need separate function for mandlebot
                {
                    try
                    {
                        var firstElement = pixelList[0];
                        DrawPoint(firstElement[0], firstElement[1], firstElement[2]);
                        pixelList.RemoveAt(0);
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
            }

        }

        public void DrawCantorSet(List<List<int>> pixelList) //these are actually lines co-ordinates
        {
            foreach (var x in pixelList)
            {
                DrawLine(x[0], x[1], x[2], x[3]);
                Console.WriteLine(x[0] + "+" + x[1] + "+" + x[2] + "+" + x[3]);
            }
        }

        // public void DrawFern(List<List<int>> pixelsList)
        //{
        //   foreach (var x in pixelsList)
        //  {
        //     DrawPoint(x[0], x[1], 1);
        //}
        // }


        void DrawFern(List<List<int>> pixelList)
        {
            DispatcherTimer t = new DispatcherTimer();
            t.Tick += t_drawPoints;
            t.Interval = new TimeSpan(0, 0, 0, 0, 1);
            t.Start();

            void t_drawPoints(object sender, EventArgs e)
            {
                try
                {
                    var firstElement = pixelList[0];
                    DrawPoint(firstElement[0], firstElement[1], 1);
                    pixelList.RemoveAt(0);
                }
                catch (Exception)
                {
                    t.Stop();
                }


            }
        }

        void DrawCellularAutomata(List<List<int>> pixelList)
        {
            DispatcherTimer t = new DispatcherTimer();
            t.Tick += t_drawPoints;
            t.Interval = new TimeSpan(0, 0, 0, 0, 1);
            t.Start();

            void t_drawPoints(object sender, EventArgs e)
            {
                try
                {
                    var firstElement = pixelList[0];
                    DrawPoint(firstElement[0], firstElement[1], 1);
                    pixelList.RemoveAt(0);
                }
                catch (Exception)
                {
                    t.Stop();
                }


            }
        }

        void DrawLorrentz(List<List<int>> pixelList)
        {
            DispatcherTimer t = new DispatcherTimer();
            t.Tick += t_drawPoints;
            t.Interval = new TimeSpan(0, 0, 0, 0, 1);
            t.Start();

            void t_drawPoints(object sender, EventArgs e)
            {
                try
                {
                    var firstElement = pixelList[0];
                    DrawLine(firstElement[0], firstElement[1], firstElement[2], firstElement[3]);
                    Console.WriteLine(firstElement[0] + " " + firstElement[1] + " " + firstElement[2] + " " + firstElement[3]);
                    pixelList.RemoveAt(0);
                }
                catch (Exception)
                {
                    t.Stop();
                }


            }
        }

        void DrawKoch(List<List<int>> pixelList)
        {
            DispatcherTimer t = new DispatcherTimer();
            t.Tick += t_drawPoints;
            t.Interval = new TimeSpan(0, 0, 0, 0, 10);
            t.Start();

            void t_drawPoints(object sender, EventArgs e)
            {
                try
                {
                    var firstElement = pixelList[0];
                    DrawLine(firstElement[0], firstElement[1], firstElement[2], firstElement[3]);
                    Console.WriteLine(firstElement[0] + " " + firstElement[1] + " " + firstElement[2] + " " + firstElement[3]);
                    pixelList.RemoveAt(0);
                }
                catch (Exception)
                {
                    t.Stop();
                }


            }
        }



    }
}



