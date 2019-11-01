using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace DAL
{
    public class RestaurantsDB : IRestaurantsDB
    {
        public IConfiguration Configuration { get; }
        public RestaurantsDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Restaurants> GetRestaurants()
        {
            List<Restaurants> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM restaurants";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Restaurants>();

                            Restaurants restaurants = new Restaurants();

                            restaurants.id = (int)dr["id"];
                            restaurants.name = (string)dr["name"];
                            restaurants.created_at = (DateTime)dr["created_at"];
                            restaurants.city_code = (int)dr["city_code"];

                            results.Add(restaurants);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return results;
        }

        public Restaurants GetRestaurant(int id)
        {
            Restaurants restaurant = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM restaurants WHERE id = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            restaurant = new Restaurants();

                            restaurant.id = (int)dr["id"];
                            restaurant.name = (string)dr["name"];
                            restaurant.created_at = (DateTime)dr["created_at"];
                            restaurant.city_code = (int)dr["city_code"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return restaurant;
        }

    }
}