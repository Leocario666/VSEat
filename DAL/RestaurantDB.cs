using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace DAL
{
    public class RestaurantDB : IRestaurantDB
    {
        private string connectionString = "Server=153.109.124.35;Database=DNVSEatDB;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=true";
        private IConfiguration Configuration { get; }
        public RestaurantDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // ******************************************************* //
        // Method which gets a list of all restaurants
        // ******************************************************* //
        public List<Restaurant> GetRestaurants()
        {
            // Creation of the list 
            List<Restaurant> results = null;
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                // Connexion to the Database
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    // The query
                    string query = "SELECT * FROM restaurant";

                    // Save the command
                    SqlCommand cmd = new SqlCommand(query, cn);

                    // Open the command
                    cn.Open();

                    // Execute the command
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        // The results
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Restaurant>();

                            Restaurant restaurants = new Restaurant();

                            restaurants.restaurant_Id = (int)dr["restaurant_Id"];
                            restaurants.name = (string)dr["name"];
                            restaurants.cityCode = (int)dr["cityCode"];

                            results.Add(restaurants);
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
        // Method which gets a restaurant by his ID
        // ******************************************************* //
        public Restaurant GetRestaurant(int restaurant_Id)
        {
            // Create an object restaurant
            Restaurant restaurant = null;
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                // Connexion to the Database
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    // The query
                    string query = "SELECT * FROM restaurant WHERE restaurant_Id = @restaurant_Id";

                    // Save the command
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@restaurant_Id", restaurant_Id);

                    // Open the command
                    cn.Open();

                    // Execute the command
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            // The results
                            restaurant = new Restaurant();

                            restaurant.restaurant_Id = (int)dr["restaurant_Id"];
                            restaurant.name = (string)dr["name"];
                            restaurant.cityCode = (int)dr["cityCode"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            // Return the restaurant
            return restaurant;
        }

    }
}