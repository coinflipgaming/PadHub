using System;
using System.Collections;
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
using System.Xml.Linq;

namespace smdyf
{
    public partial class Waluty : Window
    {
        public IList<Waluta> list = new List<Waluta>();

        public string[] currencyNames = {"USD", "PLN", "CZK", "EUR", "GBP", "JPY", "CHF", "CAD", "AUD", "HKD", "BRL", "INR", "MXN" };
        public double[] currencyValues = {1.00, 4.39, 21.98, 0.88, 0.76, 109.86, 0.89, 1.29, 1.35, 7.75, 5.64, 73.14, 20.77 };

        public Waluty()
        {
            InitializeComponent();
            for (int i = 0; i < currencyNames.Length; i++)
            {
                list.Add(new Waluta(currencyNames[i], currencyValues[i]));
            }

            IList<String> _list = new List<String>();
            box1.ItemsSource = new CollectionView(currencyNames);
            box2.ItemsSource = new CollectionView(currencyNames);
        }
        private void inpt1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (inpt1.IsFocused)
            {
                inpt2.Text = (float.Parse(inpt1.Text.ToString()) * (1 / list[box1.SelectedIndex].value) * list[box2.SelectedIndex].value).ToString();
            }
            
        }
        private void inpt2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (inpt2.IsFocused)
            {
                inpt1.Text = (float.Parse(inpt2.Text.ToString()) * (1 / list[box2.SelectedIndex].value) * list[box1.SelectedIndex].value).ToString();
            }
        }

        private void Button_Powrot(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
    public class Waluta
    {
        public string name { get; set; }
        public double value { get; set; }

        public Waluta(string v1, double v2)
        {
            this.name = v1;
            this.value = v2;
        }
    }
}
