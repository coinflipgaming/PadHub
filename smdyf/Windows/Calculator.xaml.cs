using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace smdyf.Windows
{
    public partial class Calculator : Window
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private void Button_Powrot(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        private void Button_Pressed(object sender, RoutedEventArgs e)
        {
            try
            {
                Button clicked_button = (Button)sender;
                String? inpt = clicked_button.Content.ToString();
                
                switch (inpt)
                {
                    case "→":
                        textbox.Text = textbox.Text.Substring(0, textbox.Text.Length - 1);
                        break;
                    case "+/-":
                        textbox.Text += "*(-1)";
                        break;
                    case "√":
                        textbox.Text = Math.Sqrt(float.Parse(textbox.Text)).ToString();
                        break;
                    case "=":
                        string math = textbox.Text.ToString();
                        string value = new DataTable().Compute(math, null).ToString();
                        textbox.Text = value.Replace(",", "."); ;
                        break;
                    case "AC":
                        textbox.Text = "";
                        break;
                    default:
                        if (textbox.Text.ToString() == "0") { textbox.Text = inpt; break; }
                        textbox.Text += inpt;
                        break;
                }
            }
            catch
            {
                MessageBox.Show(e.ToString());
            }
            
        }
    }
}
