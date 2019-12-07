using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class DishDB:IDishDB
    {
        private string connectionString = "Server=153.109.124.35;Database=DNVSEatDB;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=true";
        private IConfiguration Configuration { get; }
        public DishDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // ******************************************************* //
        // Method which gets a list of all Dishes
        // ******************************************************* //
        public List<Dish> GetDishes(int idRestaurant)
        {
            // Creation of the list
            List<Dish> results = null;
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                // Connexion to the Database
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    // The query
                    string query = "Select * FROM dish WHERE restaurant_Id=@idRestaurant";
                   
                    // Save the command
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@idRestaurant", idRestaurant);

                    // Open the command
                    cn.Open();

                    // Execute the command
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        // The results
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Dish>();


                            Dish dish = new Dish();

                            dish.dish_Id = (int)dr["dish_Id"];
                            dish.name = (string)dr["name"];
                            dish.price = Convert.ToSingle(dr["price"]);
                            dish.restaurant_Id = (int)dr["restaurant_Id"];
                           


                            results.Add(dish);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            // Return the list
            return results;

        }
        // ******************************************************* //
        // Method which gets a dish by his Id
        // ******************************************************* //
        public Dish GetDish(int id)
        {
            // Create a new object dish
            Dish dish = null;
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                // Connexion to the Database
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    // The query
                    string query = "SELECT * FROM dish WHERE dish_Id = @id";
                   
                    // Save the command
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    // Open the command
                    cn.Open();

                    // Execute the command 
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        // The result
                        if (dr.Read())
                        {
                            dish = new Dish();

                            dish.dish_Id = (int)dr["dish_Id"];
                            dish.name = (string)dr["name"];
                            dish.price = (float)dr["price"];
                            dish.restaurant_Id = (int)dr["restaurant_Id"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            // Return the dish
            return dish;
        }

    }
}
