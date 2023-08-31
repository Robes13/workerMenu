using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace workerMenu.Dahl
{
    internal class Database
    {
        readonly private string connectionString = @"Data Source=(local);Initial Catalog=McDonalds;Integrated Security=True";
        /// <summary>
        /// This method returns the string[,] array of orderNumbers from the database, with 60 as the max amount of order numbers. 
        /// if there is more orders they will not be printed, nor put in the Array. 
        /// </summary>
        /// <returns></returns>
        public string[,] GetOrders()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT orderID FROM Orders;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<string> orderNumber = new List<string>();
                        while (reader.Read())
                        {
                            orderNumber.Add(reader["orderID"].ToString());
                        }
                        int rows = (orderNumber.Count / 6) + 1;
                        if(rows > 11)
                        {
                            rows = 11;
                        }
                        string[,] orders = new string[rows, 6];
                        int count = 0;
                        for (int i = 0; i < orders.GetLength(0); i++)
                        {
                            for (int j = 0; j < orders.GetLength(1); j++)
                            {
                                if (count > orderNumber.Count - 1)
                                {
                                    break;
                                }
                                if(count >= 66)
                                {
                                    break;
                                }
                                    orders[i, j] = orderNumber[count];
                                count++;
                            }
                        }
                        return orders;
                    }
                }
            }
        }
        /// <summary>
        /// This method is not done yet.
        /// 
        /// When its done it will take the selected orderID, and an array with the product name, and the quantity.
        /// like this {"Cheeseburger", "2", "Big Mac", "1"} and so on.
        /// </summary>
        /// <param name="productType"></param>
        /// <returns></returns>
        public string[,] GetProducts(string productType)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand($"{productType}", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        List<string> productName = new List<string>();
                        List<string> itemQuantity = new List<string>();
                        while (reader.Read())
                        {
                            productName.Add(reader["itemName"].ToString());
                            itemQuantity.Add(reader["itemQuantity"].ToString());
                        }
                        string[,] customerOrder = new string[productName.Count, 2];
                        for (int i = 0; i < productName.Count; i++)
                        {
                            customerOrder[i, 0] = productName[i];
                            customerOrder[i, 1] = itemQuantity[i];
                        }
                        return customerOrder;
                    }
                }
            }
        }
    }
}
