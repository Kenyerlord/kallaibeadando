using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;

namespace databaseeditor
{
    public partial class MainMenu : Window
    {
        private DispatcherTimer _timer;
        private List<string> _imagePaths;
        private int _currentImageIndex;

        public MainMenu()
        {
            InitializeComponent();
            
        }

        
        private void userchangeclick(object sender, RoutedEventArgs e)
        {
            MainWindow loginWindow = new MainWindow();
            loginWindow.Show();
            Window.GetWindow(this).Close();
        }

        private void editorclick(object sender, RoutedEventArgs e)
        {
            Editor editorWindow = new Editor();
            editorWindow.Show();
            Window.GetWindow(this).Close();
        }

        private void orderclick(object sender, RoutedEventArgs e)
        {
            Order orderWindow = new Order();
            orderWindow.Show();
            Window.GetWindow(this).Close();
        }
    }
}
