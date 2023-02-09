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

        public List<Waluta> cos;
        public List<string> nazwy;

        public Waluty()
        {
            InitializeComponent();
            cos = new List<Waluta>();
            cos.Add(new Waluta("USD", 1));
            cos.Add(new Waluta("PLN", 4.39));
            cos.Add(new Waluta("CZK", 21.98));

            for(int i = 0; i > cos.Count-1; i++)
            {
                nazwy.Add(cos[i].Name);
            }
        }        
    }
    public class Waluta
    {
        string name;
        double value;

        public Waluta(string v1, double v2)
        {
            this.name = v1;
            this.value = v2;
        }

        public string Name { get => name; set => name = value; };
    }
}
