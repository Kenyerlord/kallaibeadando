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
    
    public partial class BeerDatabase : Window
    {
        private string connectionString = "server=localhost;database=testbeer;uid=root;pwd=root";
        public BeerDatabase()
        {
            InitializeComponent();
            LoadData();
        }
        private void beerdata_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (beerdata.SelectedItem is Beer selectedBeer)
            {
                editname.Text = selectedBeer.Name;
                edittype.Text = selectedBeer.Type.ToString();
                editcountry.Text = selectedBeer.CountryOfOrigin.ToString();
                editalcohollv.Text = selectedBeer.AlcoholLevel.ToString();
                editvolume.Text = selectedBeer.BottleVolume.ToString();
                editbottletype.Text = selectedBeer.BottleType.ToString();
                editprice.Text = selectedBeer.Price.ToString();
            }
        }
        public class Beer
        {
            public int Id { get; set; }               
            public string Name { get; set; }          
            public int Type { get; set; }         
            public int CountryOfOrigin { get; set; }       
            public decimal AlcoholLevel { get; set; } 
            public int BottleVolume { get; set; }        
            public int BottleType { get; set; }    
            public decimal Price { get; set; }
        }

        private void return_Click(object sender, RoutedEventArgs e)
        {
            Editor editorWindow = new Editor();
            editorWindow.Show();
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            
            string name = addname.Text.Trim();
            string typeText = addtype.Text.Trim();
            string countryText = addcountry.Text.Trim();
            string alcoholLevelText = addalcohollv.Text.Trim();
            string volumeText = addvolume.Text.Trim();
            string bottleTypeText = addbottletype.Text.Trim();
            string priceText = addprice.Text.Trim();

            
            if (string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(typeText) ||
                string.IsNullOrEmpty(countryText) ||
                string.IsNullOrEmpty(alcoholLevelText) ||
                string.IsNullOrEmpty(volumeText) ||
                string.IsNullOrEmpty(bottleTypeText) ||
                string.IsNullOrEmpty(priceText))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            
            if (!int.TryParse(typeText, out int type))
            {
                MessageBox.Show("Type must be an integer.");
                return;
            }

            if (!int.TryParse(countryText, out int country))
            {
                MessageBox.Show("Country must be an integer.");
                return;
            }

            if (!decimal.TryParse(alcoholLevelText, out decimal alcoholLevel))
            {
                MessageBox.Show("Alcohol Level must be a decimal.");
                return;
            }

            if (!int.TryParse(volumeText, out int volume))
            {
                MessageBox.Show("Volume must be an integer.");
                return;
            }

            if (!int.TryParse(bottleTypeText, out int bottleType))
            {
                MessageBox.Show("Bottle Type must be an integer.");
                return;
            }

            if (!decimal.TryParse(priceText, out decimal price))
            {
                MessageBox.Show("Price must be a decimal.");
                return;
            }

            
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string insertQuery = "INSERT INTO beer_database (Name, Type, CountryOfOrigin, AlcoholLevel, BottleVolume, BottleType, Price) VALUES (@name, @type, @country, @alcoholLevel, @volume, @bottleType, @price)";
                    MySqlCommand command = new MySqlCommand(insertQuery, connection);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@type", type);
                    command.Parameters.AddWithValue("@country", country);
                    command.Parameters.AddWithValue("@alcoholLevel", alcoholLevel);
                    command.Parameters.AddWithValue("@volume", volume);
                    command.Parameters.AddWithValue("@bottleType", bottleType);
                    command.Parameters.AddWithValue("@price", price);
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

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            string typeText = edittype.Text.Trim();
            string countryText = editcountry.Text.Trim();
            string alcoholLevelText = editalcohollv.Text.Trim();
            string volumeText = editvolume.Text.Trim();
            string bottleTypeText = editbottletype.Text.Trim();
            string priceText = editprice.Text.Trim();

           
            MessageBox.Show($"Type: {typeText}, Country: {countryText}, Alcohol Level: {alcoholLevelText}, Volume: {volumeText}, Bottle Type: {bottleTypeText}, Price: {priceText}");

            

            if (string.IsNullOrWhiteSpace(typeText) ||
                string.IsNullOrWhiteSpace(countryText) ||
                string.IsNullOrWhiteSpace(alcoholLevelText) ||
                string.IsNullOrWhiteSpace(volumeText) ||
                string.IsNullOrWhiteSpace(bottleTypeText) ||
                string.IsNullOrWhiteSpace(priceText))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (!int.TryParse(typeText, out int type))
            {
                MessageBox.Show("Type must be an integer.");
                return;
            }

            if (!int.TryParse(countryText, out int country))
            {
                MessageBox.Show("Country must be an integer.");
                return;
            }

            if (!decimal.TryParse(alcoholLevelText, out decimal alcoholLevel))
            {
                MessageBox.Show("Alcohol Level must be a decimal.");
                return;
            }

            if (!int.TryParse(volumeText, out int volume))
            {
                MessageBox.Show("Volume must be an integer.");
                return;
            }

            if (!int.TryParse(bottleTypeText, out int bottleType))
            {
                MessageBox.Show("Bottle Type must be an integer.");
                return;
            }

            if (!decimal.TryParse(priceText, out decimal price))
            {
                MessageBox.Show("Price must be a decimal.");
                return;
            }

            
            if (beerdata.SelectedItem is Beer selectedBeer)
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        string updateQuery = "UPDATE beer_database SET Name = @name, Type = @type, CountryOfOrigin = @country, AlcoholLevel = @alcoholLevel, BottleVolume = @volume, BottleType = @bottleType, Price = @price WHERE Id = @id";
                        MySqlCommand command = new MySqlCommand(updateQuery, connection);
                        command.Parameters.AddWithValue("@name", editname.Text.Trim());
                        command.Parameters.AddWithValue("@type", type);
                        command.Parameters.AddWithValue("@country", country);
                        command.Parameters.AddWithValue("@alcoholLevel", alcoholLevel);
                        command.Parameters.AddWithValue("@volume", volume);
                        command.Parameters.AddWithValue("@bottleType", bottleType);
                        command.Parameters.AddWithValue("@price", price);
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

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
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
                    string deleteQuery = "DELETE FROM beer_database WHERE Id = @id";
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

        private void LoadData()
        {
            List<Beer> beers = new List<Beer>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM beer_database";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        
                        Beer beer = new Beer
                        {
                            Id = reader.GetInt32(0), 
                            Name = reader.GetString(1), 
                            Type = reader.GetInt32(2), 
                            CountryOfOrigin = reader.GetInt32(3), 
                            AlcoholLevel = reader.GetDecimal(4), 
                            BottleVolume = reader.GetInt32(5), 
                            BottleType = reader.GetInt32(6), 
                            Price = reader.GetDecimal(7) 
                        };

                        beers.Add(beer);
                    }
                }

                
                beerdata.ItemsSource = beers; 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
