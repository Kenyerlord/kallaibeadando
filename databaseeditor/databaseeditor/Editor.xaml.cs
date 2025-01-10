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
using MySql.Data.MySqlClient;

namespace databaseeditor
{
    public partial class Editor : Window
    {
        private string connectionString = "server=localhost;database=testbeer;uid=root;pwd=root";
        private string currentTable;
        private string currentColumn;
        private string currentId;
        public Editor()
        {
            InitializeComponent();
        }


        private void BeerDatabase_Click(object sender, RoutedEventArgs e)
        {

            BeerDatabase beerDatabaseWindow = new BeerDatabase();
            beerDatabaseWindow.Show();
            this.Close();
        }

        private void Type_Click(object sender, RoutedEventArgs e)
        {
            currentId = "TID";
            currentTable = "type";
            currentColumn = "Type";
            LoadData(currentTable);

        }

        private void Volume_Click(object sender, RoutedEventArgs e)
        {
            currentId = "VID";
            currentColumn = "Volume";
            currentTable = "volume";
            LoadData(currentTable);
        }

        private void Country_Click(object sender, RoutedEventArgs e)
        {
            currentId = "CID";
            currentColumn = "Country";
            currentTable = "country";
            LoadData(currentTable);
        }

        private void Bottle_Click(object sender, RoutedEventArgs e)
        {
            currentId = "BID";
            currentColumn = "Bottle";
            currentTable = "bottle";
            LoadData(currentTable);
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            MainMenu loginWindow = new MainMenu();
            loginWindow.Show();
            Window.GetWindow(this).Close();
        }
        private void LoadData(string tableName)
        {
            Databox.Items.Clear();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $"SELECT * FROM {tableName}";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        
                        int id = reader.GetInt32(0); 
                        string displayValue = reader.GetString(1); 

                        
                        Databox.Items.Add(new Tuple<int, string>(id, displayValue));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (Databox.SelectedItem == null)
            {
                MessageBox.Show("Please select an item to delete.");
                return;
            }

           
            var selectedItem = (Tuple<int, string>)Databox.SelectedItem;
            int idToDelete = selectedItem.Item1;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    
                    string deleteQuery = $"DELETE FROM {currentTable} WHERE ({currentId}) = @id"; 
                    MySqlCommand command = new MySqlCommand(deleteQuery, connection);
                    command.Parameters.AddWithValue("@id", idToDelete);
                    command.ExecuteNonQuery();
                }

                LoadData(currentTable);
                MessageBox.Show("Item deleted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string newItem = addbox.Text.Trim();

            if (string.IsNullOrEmpty(newItem))
            {
                MessageBox.Show("Please enter a value to add.");
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    
                    string insertQuery = $"INSERT INTO {currentTable} ({currentColumn}) VALUES (@value)";
                    MySqlCommand command = new MySqlCommand(insertQuery, connection);
                    command.Parameters.AddWithValue("@value", newItem);
                    command.ExecuteNonQuery();
                }

                LoadData(currentTable);
                MessageBox.Show("Item added successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private void Databox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Databox.SelectedItem != null)
            {
                var selectedItem = (Tuple<int, string>)Databox.SelectedItem;
                editbox.Text = selectedItem.Item2;
            }
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (Databox.SelectedItem == null)
            {
                MessageBox.Show("Please select an item to edit.");
                return;
            }

            string updatedValue = editbox.Text.Trim();

            if (string.IsNullOrEmpty(updatedValue))
            {
                MessageBox.Show("Please enter a new value to update.");
                return;
            }

            
            var selectedItem = (Tuple<int, string>)Databox.SelectedItem;
            int idToEdit = selectedItem.Item1; 

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    
                    string updateQuery = $"UPDATE {currentTable} SET {currentColumn} = @value WHERE {currentId} = @id";
                    MySqlCommand command = new MySqlCommand(updateQuery, connection);
                    command.Parameters.AddWithValue("@value", updatedValue);
                    command.Parameters.AddWithValue("@id", idToEdit);
                    int rowsAffected = command.ExecuteNonQuery();

                   
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Item updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("No item was updated. Please check if the ID is correct.");
                    }
                }

                LoadData(currentTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
