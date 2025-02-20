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
using Microsoft.WindowsAPICodePack.Dialogs;

namespace WpfDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true, // Chỉ chọn thư mục
                Title = "Chọn thư mục chứa ảnh"
            };

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string selectedPath = dialog.FileName;

                // Kiểm tra nếu đường dẫn đã tồn tại
                if (filePathTextBox.Text == selectedPath || filePathTextBox1.Text == selectedPath)
                {
                    MessageBox.Show("Thư mục này đã được chọn rồi!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return; // Thoát ngay nếu thư mục đã có
                }

                // Gán giá trị vào TextBox trống
                if (string.IsNullOrEmpty(filePathTextBox.Text))
                {
                    filePathTextBox.Text = selectedPath;
                }
                else if (string.IsNullOrEmpty(filePathTextBox1.Text))
                {
                    filePathTextBox1.Text = selectedPath;
                }
                else
                {
                    MessageBox.Show("Chỉ có thể chọn tối đa 2 thư mục!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}