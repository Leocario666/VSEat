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
        public List<Dish> GetDishes(int idRestaurant)
        {
            List<Dish> results = null;
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * FROM dish WHERE restaurant_Id=@idRestaurant";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@idRestaurant", idRestaurant);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
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

            return results;

        }

        public Dish GetDish(int id)
        {
            Dish dish = null;
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM dish WHERE dish_Id = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
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

            return dish;
        }

    }
}
