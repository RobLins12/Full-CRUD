using BD2.Pages.Clientes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NPOI.SS.Formula.Functions;
using System.Data.SqlClient;

namespace BD2.Pages.Compras
{
    public class IndexModel : PageModel
    {
        public List<T> ListOfOrders = new List<T>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=Northwind;Integrated Security=True";

                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    String sql = "SELECT * FROM Customers";
                    using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                    {
                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ClientInfo clientInfo = new ClientInfo();
                                if (!reader.IsDBNull(0))
                                {
                                    clientInfo.id = reader.GetString(0);
                                }
                                


                                ListOfOrders.Add(null);

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

        }
    }
    
}
