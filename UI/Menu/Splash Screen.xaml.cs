using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace UI.Menu
{
    /// <summary>
    /// Interaction logic for Splash_Screen.xaml
    /// </summary>
    public partial class Splash_Screen : UserControl
    {
        public Splash_Screen()
        {
            InitializeComponent();
        }

        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.splashProgressBar.Value = e.NewValue;
            this.progressStatusLabel.Content = this.splashProgressBar.Value;
        }


    }
}
