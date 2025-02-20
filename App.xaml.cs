using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace WpfDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {   
        // Xóa đường dẫn đến thư mục
        private void TrashButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button trashButton)
            {
                if(trashButton.Tag is TextBox textBox)
                {
                    textBox.Text = string.Empty;
                }
            }
        }
    }

}
