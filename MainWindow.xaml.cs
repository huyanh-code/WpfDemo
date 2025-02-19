using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _currentInput = "";
        private string _operator = "";
        private double _result = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            _currentInput += button.Content.ToString();
            Display.Text = _currentInput;

            UpdateClearButton();
        }


        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            _operator = button.Content.ToString();
            _result = double.Parse(_currentInput);
            _currentInput = "";
            UpdateClearButton();
        }


        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            double secondNumber = double.Parse(_currentInput);

            switch (_operator)
            {
                case "+":
                    _result += secondNumber;
                    break;
                case "-":
                    _result -= secondNumber;
                    break;
                case "*":
                    _result *= secondNumber;
                    break;
                case "/":
                    if (secondNumber != 0)
                        _result /= secondNumber;
                    else
                        MessageBox.Show("Cannot divide by zero");
                    break;
            }
            Display.Text = _result.ToString();
            _currentInput = _result.ToString();
            _operator = "";
            UpdateClearButton();
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
                _currentInput = "";
                _operator = "";
                _result = 0;
                Display.Text = "";
                UpdateClearButton();  
        }
        private void UpdateClearButton()
        {
            if (string.IsNullOrEmpty(_currentInput))
            {
                ClearButton.Content = "AC";
            }
            else
            {
                ClearButton.Content = "C";
            }
        }

        private void PlusMinus_Click(object sender, RoutedEventArgs e)
        {
            if (_currentInput.StartsWith("-"))
            {
                _currentInput = _currentInput.Substring(1);
            }
            else
            {
                _currentInput = "-" + _currentInput;
            }
            Display.Text = _currentInput;
        }

        private void Percent_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(_currentInput, out double number))
            {
                _currentInput = (number / 100).ToString();
                Display.Text = _currentInput;
            }
        }
    }
}