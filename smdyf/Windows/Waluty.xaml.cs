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
        public Waluty()
        {
            InitializeComponent();
            list.Add(new Waluta("USD", 1));
            list.Add(new Waluta("PLN", 4.39));
            list.Add(new Waluta("CZK", 21.98));

            IList<String> _list = new List<String>();

            for (int i = 0; i < list.Count; i++)
            {
                _list.Add(list[i].name);
            }

            box1.ItemsSource = new CollectionView(_list);
            box2.ItemsSource = new CollectionView(_list);
        }
        private void inpt1_TextChanged(object sender, TextChangedEventArgs e)
        {
            inpt2.Text = (float.Parse(inpt1.Text.ToString()) * (1 / list[box1.SelectedIndex].value) * list[box2.SelectedIndex].value).ToString();
        }

        private void inpt2_TextChanged(object sender, TextChangedEventArgs e)
        {
            inpt1.Text = (float.Parse(inpt2.Text.ToString()) * (1 / list[box2.SelectedIndex].value) * list[box1.SelectedIndex].value).ToString();
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
