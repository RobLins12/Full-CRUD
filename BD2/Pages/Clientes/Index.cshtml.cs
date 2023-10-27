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
                                ClientInfo ci = new ClientInfo();
                                if (!reader.IsDBNull(0))
                                {
                                    ci.id = reader.GetString(0);
                                }
                                if (!reader.IsDBNull(1))
                                {
                                    ci.CompanyName = reader.GetString(1);
                                }
                                if (!reader.IsDBNull(2))
                                {
                                    ci.ContactName = reader.GetString(2);
                                }
                                if (!reader.IsDBNull(3))
                                {
                                    ci.ContactTitle = reader.GetString(3);
                                }
                                if (!reader.IsDBNull(4))
                                {
                                    ci.Address = reader.GetString(4);
                                }
                                if (!reader.IsDBNull(5))
                                {
                                    ci.City = reader.GetString(5);
                                }
                                if (!reader.IsDBNull(6))
                                {
                                    ci.Region = reader.GetString(6);
                                }
                                if (!reader.IsDBNull(7))
                                {
                                    ci.PostalCode = reader.GetString(7);
                                }
                                if (!reader.IsDBNull(8))
                                {
                                    ci.Country = reader.GetString(8);
                                }
                                if (!reader.IsDBNull(9))
                                {
                                    ci.Phone = reader.GetString(9);
                                }
                                if (!reader.IsDBNull(10))
                                {
                                    ci.Fax = reader.GetString(10);
                                }


                                listOfClientes.Add(ci);
                                
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
