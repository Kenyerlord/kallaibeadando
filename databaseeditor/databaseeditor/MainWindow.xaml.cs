using System.IO;
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
using System.Windows.Threading;
using MySql.Data.MySqlClient;

namespace databaseeditor
{

    public partial class MainWindow : Window
    {
       
        private const string ConnectionString = "host=localhost;database=testbeer;user=root;password=root;";
        private DispatcherTimer _timer;
        private List<string> _imagePaths;
        private int _currentImageIndex;
        public MainWindow()
        {
            InitializeComponent();
            //Hogy működjön stimmelni kell az elhelyezkedássel
            string imageFolderPath = @"C:\Users\13d\Desktop\databaseeditor2.0\databaseeditor\databaseeditor\Images";

            _imagePaths = Directory.GetFiles(imageFolderPath, "*.jpg")
              .Concat(Directory.GetFiles(imageFolderPath, "*.png"))
              .ToList();

            _currentImageIndex = 0;
            UpdateImage();

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(5);
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            _currentImageIndex = (_currentImageIndex + 1) % _imagePaths.Count;
            UpdateImage();
        }

        private void UpdateImage()
        {
            RotatingImage.Source = new BitmapImage(new Uri(_imagePaths[_currentImageIndex]));
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            if (AuthenticateUser(username, password, out int userLevel))
            {
                ErrorMessageLabel.Content = ""; 

                if (userLevel == 1)
                {
                    MessageBox.Show("Welcome Admin!");
                    
                }
                else if (userLevel == 2)
                {
                    MessageBox.Show("Welcome Secretary!");
                    
                }
                MainMenu ujablak = new MainMenu();
                ujablak.Show();
                this.Close();

            }
            else
            {
                ErrorMessageLabel.Content = "Invalid username or password.";
            }
        }

        private bool AuthenticateUser(string username, string password, out int userLevel)
        {
            userLevel = 0;

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT Level FROM moderation WHERE Username = @username AND Password = @password"; 
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password); 

                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        userLevel = Convert.ToInt32(result);
                        return true;
                    }
                }
            }
            return false;
        }

        private void ShowPasswordCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            
            var passwordTextBox = new TextBox
            {
                Text = PasswordBox.Password,
                Width = PasswordBox.Width,
                Margin = PasswordBox.Margin,
                HorizontalAlignment = PasswordBox.HorizontalAlignment,
                VerticalAlignment = PasswordBox.VerticalAlignment
            };

            
            passwordTextBox.TextChanged += (s, args) => PasswordBox.Password = passwordTextBox.Text;

            
            MainGrid.Children.Remove(PasswordBox); 
            MainGrid.Children.Add(passwordTextBox);
        }

        private void ShowPasswordCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            
            var passwordBox = new PasswordBox
            {
                Width = PasswordBox.Width,
                Margin = PasswordBox.Margin,
                HorizontalAlignment = PasswordBox.HorizontalAlignment,
                VerticalAlignment = PasswordBox.VerticalAlignment
            };

            
            passwordBox.PasswordChanged += (s, args) => PasswordBox.Password = passwordBox.Password;

            
            MainGrid.Children.RemoveAt(MainGrid.Children.Count - 1); 
            MainGrid.Children.Add(passwordBox);
            passwordBox.Password = PasswordBox.Password; 
        }
    }
}