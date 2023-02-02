using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Linq;

namespace smdyf.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy Calculator.xaml
    /// </summary>
    public partial class Calculator : Window
    {
        String num1 = "";
        String num2 = "";
        String current_symbol = "";
        bool newcalc = true;
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

                    case "-":
                        change_symbol(inpt);
                        break;
                    case "+":
                        change_symbol(inpt);
                        break;
                    case "*":
                        change_symbol(inpt);
                        break;
                    case "/":
                        change_symbol(inpt);
                        break;
                    case "%":
                        change_symbol(inpt);
                        break;
                    case "+/-":
                        if (textbox.Text.StartsWith("-")) { textbox.Text = textbox.Text.Substring(1); break; }
                        textbox.Text = "-" + textbox.Text;
                        break;
                    case "√":
                        if (textbox.Text.StartsWith("-")) { break; }
                        textbox.Text = Math.Sqrt(float.Parse(textbox.Text)).ToString();
                        break;
                    case "=":
                        if(current_symbol == ""){break;}
                        if(num1 == ""){break;}
                        num2 = textbox.Text.ToString();
                        if(num2 == ""){break;}

                        string math = num1+current_symbol+num2;
                        string value = new DataTable().Compute(math, null).ToString();

                        textbox.Text = value;
                        num1 = value;
                        num2 = "";
                        newcalc = true;
                        break;
                    case "AC":
                        textbox.Text = "0";
                        num1 = "0";
                        num2 = "0";
                        current_symbol = "";
                        newcalc = true;
                        break;
                    default:
                        if (newcalc) { newcalc = false; textbox.Text = ""; }
                        if(textbox.Text == "0")
                        {
                            textbox.Text = inpt;
                            break;
                        }
                        textbox.Text += inpt;
                        break;
                }
                void change_symbol(String symbol)
                {
                    if (textbox.Text.ToString() == "")
                    {
                        return;
                    }
                    if (num1 == "")
                    {
                        num1 = textbox.Text.ToString();
                        textbox.Text = "";
                    }
                    current_symbol = symbol;
                }
            }
            catch
            {
                MessageBox.Show(e.ToString());
            }
            
        }
    }
}
