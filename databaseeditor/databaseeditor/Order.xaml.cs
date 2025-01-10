using MySql.Data.MySqlClient;
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
using static databaseeditor.BeerDatabase;

namespace databaseeditor
{
    public partial class Order : Window
    {
        public class Beer
        {
            public int Id { get; set; }
            public int orderid { get; set; }
            public int beerid { get; set; }
            public int buyerid { get; set; }
            public int numbers { get; set; }
        }
        private string connectionString = "server=localhost;database=testbeer;uid=root;pwd=root";
        public Order()
        {
            InitializeComponent();
            LoadData();
        }

        private void addbutton_Click(object sender, RoutedEventArgs e)
        {
            string order = addorderid.Text.Trim();
            string beer = addbeerid.Text.Trim();
            string buyer = addbuyerid.Text.Trim();
            string number = addnumber.Text.Trim();


            if (string.IsNullOrEmpty(order) ||
                string.IsNullOrEmpty(beer) ||
                string.IsNullOrEmpty(buyer) ||
                string.IsNullOrEmpty(number)
                )
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }


            if (!int.TryParse(order, out int orderid))
            {
                MessageBox.Show("Orderid must be an integer.");
                return;
            }

            if (!int.TryParse(beer, out int beerid))
            {
                MessageBox.Show("Beerid must be an integer.");
                return;
            }

            if (!int.TryParse(buyer, out int buyerid))
            {
                MessageBox.Show("Buyerid must be an integer.");
                return;
            }

            if (!int.TryParse(number, out int numbers))
            {
                MessageBox.Show("Numberid Type must be an integer.");
                return;
            }


            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string insertQuery = "INSERT INTO buyerbeer (bid,beerid1,buyerid,number) VALUES (@bid, @beerid, @buyerid, @number)";
                    MySqlCommand command = new MySqlCommand(insertQuery, connection);
                    command.Parameters.AddWithValue("@bid", orderid);
                    command.Parameters.AddWithValue("@beerid", beerid);
                    command.Parameters.AddWithValue("@buyerid", buyerid);
                    command.Parameters.AddWithValue("@number", numbers);
                    command.ExecuteNonQuery();
                }


                LoadData();
                MessageBox.Show("Item added successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void editbutton_Click(object sender, RoutedEventArgs e)
        {
            string order = updateorderid.Text.Trim();
            string beer = updatebeerid.Text.Trim();
            string buyer = updatebuyerid.Text.Trim();
            string number = updatenumber.Text.Trim();


            if (string.IsNullOrEmpty(order) ||
                string.IsNullOrEmpty(beer) ||
                string.IsNullOrEmpty(buyer) ||
                string.IsNullOrEmpty(number)
                )
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }


            if (!int.TryParse(order, out int orderid))
            {
                MessageBox.Show("Orderid must be an integer.");
                return;
            }

            if (!int.TryParse(beer, out int beerid))
            {
                MessageBox.Show("Beerid must be an integer.");
                return;
            }

            if (!int.TryParse(buyer, out int buyerid))
            {
                MessageBox.Show("Buyerid must be an integer.");
                return;
            }

            if (!int.TryParse(number, out int numbers))
            {
                MessageBox.Show("Numberid Type must be an integer.");
                return;
            }


            if (list.SelectedItem is Beer selectedBeer)
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        string updateQuery = "UPDATE buyerbeer SET bid = @bid, beerid1 = @beerid, buyerid = @buyerid, number = @number WHERE primkey = @id";
                        MySqlCommand command = new MySqlCommand(updateQuery, connection);
                        command.Parameters.AddWithValue("@bid", orderid);
                        command.Parameters.AddWithValue("@beerid", beerid);
                        command.Parameters.AddWithValue("@buyerid", buyerid);
                        command.Parameters.AddWithValue("@number", numbers);
                        command.Parameters.AddWithValue("@id", selectedBeer.Id);
                        command.ExecuteNonQuery();
                    }


                    LoadData();
                    MessageBox.Show("Item updated successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select a beer to edit.");
            }
        }

        private void deletebutton_Click(object sender, RoutedEventArgs e)
        {
            string idText = deleteid.Text.Trim();


            if (string.IsNullOrEmpty(idText))
            {
                MessageBox.Show("Please enter an ID to delete.");
                return;
            }

            if (!int.TryParse(idText, out int idToDelete))
            {
                MessageBox.Show("ID must be an integer.");
                return;
            }


            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string deleteQuery = "DELETE FROM buyerbeer WHERE primkey = @id";
                    MySqlCommand command = new MySqlCommand(deleteQuery, connection);
                    command.Parameters.AddWithValue("@id", idToDelete);
                    int rowsAffected = command.ExecuteNonQuery();


                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Item deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("No item found with the specified ID.");
                    }
                }


                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void returnbutton_Click(object sender, RoutedEventArgs e)
        {
            MainMenu loginWindow = new MainMenu();
            loginWindow.Show();
            Window.GetWindow(this).Close();
        }
        private void beerdata_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (list.SelectedItem is Beer selectedBeer)
            {
                updatebuyerid.Text = selectedBeer.buyerid.ToString();
                updateorderid.Text = selectedBeer.orderid.ToString();
                updatebeerid.Text = selectedBeer.beerid.ToString();
                updatenumber.Text = selectedBeer.numbers.ToString();
            }
        }
        private void LoadData()
        {
            List<Beer> beers = new List<Beer>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM buyerbeer";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {

                        Beer beer = new Beer
                        {
                            Id = reader.GetInt32(0),
                            orderid = reader.GetInt32(1),
                            beerid = reader.GetInt32(2),
                            buyerid = reader.GetInt32(3),
                            numbers = reader.GetInt32(4)
                        };

                        beers.Add(beer);
                    }
                }


                list.ItemsSource = beers;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
