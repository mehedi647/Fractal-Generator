using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using fractal_generator.Database;
using fractal_generator.Model;

namespace fractal_generator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {


            InitializeComponent();
            List<Fractal> fractalList = Fractal.GetFractalList();

            lv.ItemsSource = fractalList;


        }


        private void Lv_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBox listbox = sender as ListBox;
            Fractal fractal = (Fractal) listbox.SelectedItem;
            new DescriptionWindow(fractal).ShowDialog();
        }
    }

}

/*
foreach (var x in fractalList)
{
    Console.WriteLine("ID: "+x.getId());
   Console.WriteLine("Name: "+x.getName());
    Console.WriteLine("Description: "+x.getDescription());
    Console.WriteLine("url: "+x.getThumbUrl());
    Console.WriteLine();
}
*/
//           text.Text = "what is wrong?";
//CreateMandleBot();
/*
DrawPoint(1, 1, 1);
DrawPoint(5, 3, 1);
DrawPoint(8, 4, 0);
DrawPoint(2, 9, 1);
DrawPoint(10, 1, 1);
DrawPoint(1, 100, 1);
DrawPoint(-123, 3, 1);
DrawPoint(-8, 40, 0);
DrawPoint(23, -9, 1);
DrawPoint(101, 1, 1);
*/

//            DrawListIteration(CreateMandleBot());
//            DrawSierpinskiGasket(SierpinskiGasket());

