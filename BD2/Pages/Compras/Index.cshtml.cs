using BD2.Pages.Clientes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NPOI.SS.Formula.Functions;
using System.Data.SqlClient;

namespace BD2.Pages.Compras
{
    public class IndexModel : PageModel
    {
        public List<Orders> ListOfOrders = new List<Orders>();

        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=localhost;Initial Catalog=Northwind;Integrated Security=True";

                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    String sql = "SELECT o.OrderID, o.CustomerID, o.EmployeeID, od.ProductID, od.Quantity, od.UnitPrice FROM Orders o JOIN [Order Details] od ON od.OrderID = o.OrderID";
                    
                    using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                    {
                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Orders order = new Orders();

                                order.OrdersID = reader.GetInt32(0);
                                order.CustomerID = reader.GetString(1);
                                order.EmployeeID = reader.GetInt32(2);
                                order.ProductID = reader.GetInt32(3);
                                order.Quantity = reader.GetInt16(4);
                                order.UnitPrice = reader.GetDecimal(5);

                                ListOfOrders.Add(order);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:  " + ex.ToString());
            }
        }

        public class Orders 
        {
            public int OrdersID;
            public String CustomerID;
            public int EmployeeID;
            public int ProductID;
            public int Quantity;
            public decimal UnitPrice;
        }
    }
    
}
