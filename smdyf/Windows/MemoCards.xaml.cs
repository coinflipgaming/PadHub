using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace smdyf.Windows
{
    public partial class MemoCards : Window
    {
        public List<card> Deck = new List<card>();
        public List<card> clicked = new List<card>();
        public int moves = 0;
        public int pts = 0;
        public int _rows = 3;
        public int _columns = 3;
        public MemoCards()
        {
            InitializeComponent();
            new_game_button.Click += (s, e) =>
            {
                MemoCardsDialog window = new MemoCardsDialog(this);
                window.rows.Text = _rows.ToString();
                window.columns.Text = _columns.ToString();
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
            if (Rows!=0) { _rows = Rows; }
            if (Columns != 0) { _columns = Columns; }
            moves = 0;
            clicked.Clear();
            Deck.Clear();
            container.Children.Clear();
            container.RowDefinitions.Clear();
            container.ColumnDefinitions.Clear();
            Random rnd = new();
            for (int i = Rows; i > 0; i--)
            {
                container.RowDefinitions.Add(new RowDefinition());
            }
            for (int j = Columns; j > 0; j--)
            {
                container.ColumnDefinitions.Add(new ColumnDefinition());
            }
            List<int> unassigned = new List<int>();
            for (int i = 0; (Columns*Rows/2) > i; i++)
            {
                unassigned.Add(i+1);
                unassigned.Add(i+1);
            }
            if (Columns*Rows%2!=0) { unassigned.Add(0); }
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    card _card = new();
                    _card.id = Deck.Count();
                    _card.x = i;
                    _card.y = j;
                    Button _button = new();
                    int _index = rnd.Next(unassigned.Count()-1);
                    _card.pair_id = unassigned[_index];
                    unassigned.RemoveAt(_index);
                    _button.Click += (s, e) =>
                    {
                        moves += 1;
                        clicked.Add(_card);
                        _button.Content = _card.pair_id.ToString();
                        _button.IsEnabled = false;
                        if (clicked.Count() == 2)
                        {
                            if (clicked[0].pair_id == clicked[1].pair_id)
                            {
                                Deck.Remove(clicked[0]);
                                Deck.Remove(clicked[1]);
                                clicked.Clear();
                                pts += 10;
                            }
                        }
                        else if (clicked.Count() == 3)
                        {
                            clicked[0].button.IsEnabled = true;
                            clicked[0].button.Content = "";
                            clicked.RemoveAt(0);
                            clicked[0].button.IsEnabled = true;
                            clicked[0].button.Content = "";
                            clicked.RemoveAt(0);
                            pts -= 1;
                        }
                        points.Content = "ruchy: " + moves.ToString() + " punkty: " + pts.ToString();
                        if (Deck.Count() == 0)
                        {
                            MessageBox.Show("Wygrałeś! " + " ruchy: " + moves.ToString() + " punkty: " + pts.ToString());
                            new_game();
                        }
                    };
                    _card.button = _button;
                    Deck.Add(_card);
                    Grid.SetRow(_button, i);
                    Grid.SetColumn(_button, j);
                    container.Children.Add(_button);
                }
            }
            if (Columns * Rows % 2 != 0) { Deck.RemoveAt(Deck.Count() - 1); container.Children.RemoveAt(Deck.Count()); }
        }
}
    public class card
    {   
        public int id { get; set; }
        public int pair_id { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public Button button { get; set; }
    }
}
