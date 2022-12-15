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
using System.Windows.Shapes;

namespace smdyf.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy TicTacToe.xaml
    /// </summary>
    public partial class TicTacToe : Window
    {
        public TicTacToe()
        {
            InitializeComponent();
        }
        private void Button_Powrot(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
