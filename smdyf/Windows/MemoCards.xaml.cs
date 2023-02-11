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
    public partial class MemoCards : Window
    {
        public IList<card> Deck = new List<card>();
        public int cards_flipped = 0;
        public MemoCards()
        {
            InitializeComponent();
            new_game_button.Click += (s, e) =>
            {
                MemoCardsDialog window = new MemoCardsDialog(this);
                window.Show();
            };
        }
        private void Button_Powrot(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        public void new_game(int Rows = 0,int Columns = 0)
        {
            Deck.Clear();
            container.Children.Clear();
            container.RowDefinitions.Clear();
            container.ColumnDefinitions.Clear();
            for (int i = Rows; i > 0; i--)
            {
                container.RowDefinitions.Add(new RowDefinition());
            }
            for (int j = Columns; j > 0; j--)
            {
                container.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = Rows; i >= 0; i--)
            {
                for (int j = Columns; j >= 0; j--)
                {
                    card _card = new card();
                    _card.x = i;
                    _card.y = j;
                    Button _button = new Button();
                    _button.Content = "x: " + i.ToString() + " y: " + j.ToString();
                    _card.button = _button;
                    Deck.Add(_card);
                    Grid.SetRow(_button, i);
                    Grid.SetColumn(_button, j);
                    container.Children.Add(_button);
                }
            }
            int n = 0;
            while (2 < Deck.Count())
            {
                n += 1;
                Random rand = new();
                int a = rand.Next(0, Deck.Count()-1);
                Deck[a].pair_id = n;
                Deck[a].button.Content = n.ToString();
                Deck.RemoveAt(a);
                int b = rand.Next(0, Deck.Count()-1);
                Deck[b].pair_id = n;
                Deck[b].button.Content = n.ToString();
                Deck.RemoveAt(b);

            }
        }
    }
    public class card
    {
        public int pair_id { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public Button button { get; set; }
    }
}
