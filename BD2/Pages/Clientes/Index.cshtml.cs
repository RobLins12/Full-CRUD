using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Win32;
using System.Data.SqlClient;
using System.Xml;

namespace BD2.Pages.Clientes
{
    public class IndexModel : PageModel
    {
        public List<ClientInfo> listOfClientes = new List<ClientInfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=localhost;Initial Catalog=Northwind;Integrated Security=True";

                using (SqlConnection sqlConnection = new SqlConnection(connectionString)) 
                {
                    sqlConnection.Open();
                    String sql = "SELECT * FROM Customers";
                    using(SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection)) 
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
                                if (!reader.IsDBNull(1))
                                {
                                    clientInfo.CompanyName = reader.GetString(1);
                                }
                                if (!reader.IsDBNull(2))
                                {
                                    clientInfo.ContactName = reader.GetString(2);
                                }
                                if (!reader.IsDBNull(3))
                                {
                                    clientInfo.ContactTitle = reader.GetString(3);
                                }
                                if (!reader.IsDBNull(4))
                                {
                                    clientInfo.Address = reader.GetString(4);
                                }
                                if (!reader.IsDBNull(5))
                                {
                                    clientInfo.City = reader.GetString(5);
                                }
                                if (!reader.IsDBNull(6))
                                {
                                    clientInfo.Region = reader.GetString(6);
                                }
                                if (!reader.IsDBNull(7))
                                {
                                    clientInfo.PostalCode = reader.GetString(7);
                                }
                                if (!reader.IsDBNull(8))
                                {
                                    clientInfo.Country = reader.GetString(8);
                                }
                                if (!reader.IsDBNull(9))
                                {
                                    clientInfo.Phone = reader.GetString(9);
                                }
                                if (!reader.IsDBNull(10))
                                {
                                    clientInfo.Fax = reader.GetString(10);
                                }


                                listOfClientes.Add(clientInfo);
                                
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
    }

    public class ClientInfo 
    {
        public string id;
        public string CompanyName;
        public string ContactName;
        public string ContactTitle;
        public string Address;
        public string City;
        public string Region;
        public string PostalCode;
        public string Country;
        public string Phone;
        public string Fax;
    }
}
