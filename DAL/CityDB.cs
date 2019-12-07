using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace DAL
{
    public class CityDB : ICityDB
    {
        private string connectionString = "Server=153.109.124.35;Database=DNVSEatDB;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=true";
        private IConfiguration Configuration { get; }

        public CityDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // ******************************************************* //
        // Method which gets a list of all cities
        // ******************************************************* //
        public List<City> GetCities()
        {
            // Creation of the list
            List<City> results = null;
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                // Connexion to the Database
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    // The query
                    string query = "SELECT * FROM city";
                   
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
                                results = new List<City>();

                            City city = new City();

                            city.cityCode = (int)dr["code"];
                            city.name = (string)dr["name"];

                            results.Add(city);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            // Return The list
            return results;
        }

    }
}