using Skupti.Database_Classes;
using Skupti.Helper_Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Skupti.CRUD_Classes
{
    public class Read
    {
        public static double ReadTotal()
        {
            SqlConnection conn = new SqlConnection(DatabaseConnector.GetConnectionString());

            conn.Open();

            var readSum = new SqlCommand
            {
                Connection = conn,
                CommandText = ($"SELECT SUM(Price) as 'Samlet pris' FROM Products; ")
            };

            SqlDataReader reader = readSum.ExecuteReader();

            double sum = 0;

            while (reader.Read())
            {
                sum = Convert.ToDouble(reader[0]);
            }

            conn.Close();

            return sum;
        }
        




        public static Product ReadOneProduct(int productId)
        {
            SqlConnection conn = new SqlConnection(DatabaseConnector.GetConnectionString());

            conn.Open();

            var readOneProduct = new SqlCommand
            {
                Connection = conn,
                CommandText = ($"SELECT * FROM Products Where ProductId = {productId}")
            };

            SqlDataReader reader = readOneProduct.ExecuteReader();

            Product tempProduct = new Product();

            while (reader.Read())
            {
                tempProduct.ProductId = Convert.ToInt32(reader[0]);
                tempProduct.ProductName = Convert.ToString(reader[1]);
                tempProduct.Price = Convert.ToDouble(reader[2]);
                tempProduct.BrandId = Convert.ToInt32(reader[3]);
                tempProduct.SubCategoryId = Convert.ToInt32(reader[4]);
            }

            conn.Close();

            return tempProduct;
        }
        public static List<Product> ReadAllProducts()
        {
            SqlConnection conn = new SqlConnection(DatabaseConnector.GetConnectionString());

            conn.Open();

            var readAllProducts = new SqlCommand
            {
                Connection = conn,
                CommandText = ($"SELECT * FROM Products")
            };

            SqlDataReader reader = readAllProducts.ExecuteReader();

            List<Product> returnList = new List<Product>();

            while (reader.Read())
            {
                Product tempProduct = new Product
                {
                    ProductId = Convert.ToInt32(reader[0]),
                    ProductName = Convert.ToString(reader[1]),
                    Price = Convert.ToDouble(reader[2]),
                    BrandId = Convert.ToInt32(reader[3]),
                    SubCategoryId = Convert.ToInt32(reader[4])
                };

                returnList.Add(tempProduct);
            }

            conn.Close();

            return returnList;
        }
        public static List<JoinedProduct> ReadAllProductsAndTheirCategories()
        {
            SqlConnection conn = new SqlConnection(DatabaseConnector.GetConnectionString());

            conn.Open();

            var readAllProductsAndTheirCategories = new SqlCommand
            {
                Connection = conn,
                CommandText = ($@"SELECT Game.GameID, Player.PlayerName FROM Game JOIN Winner ON Game.GameID=Winner.GameID JOIN Player ON Winner.PlayerID=Player.PlayerID")
            };

            SqlDataReader reader = readAllProductsAndTheirCategories.ExecuteReader();

            List<JoinedProduct> returnList = new List<JoinedProduct>();


            while (reader.Read())
            {

                JoinedProduct tempProduct = new JoinedProduct()
                {
                    ProductId = Convert.ToInt32(reader[0]),
                    ProductName = Convert.ToString(reader[1]),
                    Price = Convert.ToDouble(reader[2]),
                    BrandName = Convert.ToString(reader[3]),
                    BrandId = Convert.ToInt32(reader[4]),
                    SubCategoryName = Convert.ToString(reader[5]),
                    SubCategoryId = Convert.ToInt32(reader[6]),
                    CategoryName = Convert.ToString(reader[7]),
                    CategoryId = Convert.ToInt32(reader[8]),
                };


                returnList.Add(tempProduct);
            }

            conn.Close();

            return returnList;
        }
    }
}
