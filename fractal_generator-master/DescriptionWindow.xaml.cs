using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using fractal_generator.Model;

namespace fractal_generator
{
    /// <summary>
    /// Interaction logic for DescriptionWindow.xaml
    /// </summary>
    public partial class DescriptionWindow : Window
    {
        private Fractal fractal;

        public DescriptionWindow(Fractal fParam)
        {
            InitializeComponent();

            this.fractal = fParam;

            title.Text = fractal.Name;
            description.Text = fractal.Description;

            var imageList = Fractal.GetImagesUriList(fractal);

            img1.Source = imageList[0];
            img2.Source = imageList[1];
            img3.Source = imageList[2];



        }


        private void ActionButton_OnClick_(object sender, RoutedEventArgs e)
        {
            new ActionWindow(fractal).ShowDialog();
        }


        private void ActionButton_OnClick3_(object sender, RoutedEventArgs e)
        {
            new MainWindow().ShowDialog();
        }
    }
}
