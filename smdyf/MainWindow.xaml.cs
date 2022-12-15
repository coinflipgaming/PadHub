using smdyf.Windows;
using System.Windows;

namespace smdyf
{
    /// <summary>
    /// Logika interakcji dla klasy LoginWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Calculator(object sender, RoutedEventArgs e)
        {
            Calculator calculator = new Calculator();
            calculator.Show();
            this.Close();
        }

        private void Button_Click_TicTacToe(object sender, RoutedEventArgs e)
        {

            TicTacToe TicTacToe = new TicTacToe();
            TicTacToe.Show();
            this.Close();
        }

        private void Button_Click_MemoCards(object sender, RoutedEventArgs e)
        {
            MemoCards memoCards = new MemoCards();
            memoCards.Show();
            this.Close();
        }
    }
}
