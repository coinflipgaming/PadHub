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
    /// Logika interakcji dla klasy MemoCardsDialog.xaml
    /// </summary>
    public partial class MemoCardsDialog : Window
    {
        public MemoCards a;
        public MemoCardsDialog(MemoCards _a)
        {
            InitializeComponent();
            a = _a;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            a.new_game(int.Parse(rows.Text.ToString()), int.Parse(columns.Text.ToString()));
            this.Close();
        }
    }
}
