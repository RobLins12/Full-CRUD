using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace BD2.Pages.Clientes
{
    public class EditModel : PageModel
    {
        public ClientInfo clientInfo = new ClientInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
            String id = Request.Query["id"];

            try 
            {
                String connectionString = "Data Source=localhost;Initial Catalog=Northwind;Integrated Security=True";

                using (SqlConnection sqlConnection = new SqlConnection(connectionString)) 
                {
                    sqlConnection.Open();
                    String sql = "SELECT * FROM Customers WHERE CustomerID = @id";
                    using (SqlCommand command = new SqlCommand(sql, sqlConnection)) 
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader()) {

                            if (reader.Read())
                            {
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

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }

        public void OnPost() 
        {
            clientInfo.id = Request.Form["id"];
            clientInfo.ContactName = Request.Form["ContactName"];
            clientInfo.CompanyName = Request.Form["CompanyName"];
            clientInfo.ContactTitle = Request.Form["ContactTitle"];
            clientInfo.Address = Request.Form["Address"];
            clientInfo.City = Request.Form["City"];
            clientInfo.Region = Request.Form["Region"];
            clientInfo.PostalCode = Request.Form["PostalCode"];
            clientInfo.Country = Request.Form["Country"];
            clientInfo.Phone = Request.Form["Phone"];
            clientInfo.Fax = Request.Form["Fax"];

            if (clientInfo.id.Length == 0 || clientInfo.ContactName.Length == 0 || clientInfo.CompanyName.Length == 0
                || clientInfo.ContactTitle.Length == 0 || clientInfo.Address.Length == 0 || clientInfo.City.Length == 0
                || clientInfo.Region.Length == 0 || clientInfo.PostalCode.Length == 0 || clientInfo.Country.Length == 0
                || clientInfo.Phone.Length == 0 || clientInfo.Fax.Length == 0)
            {
                errorMessage = "Todos os campos são necessários";
                return;
            }

            try
            {
                String connectionString = "Data Source=localhost;Initial Catalog=Northwind;Integrated Security=True";

                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    String sql = "UPDATE Customers " +              
                        "SET ContactName = @ContactName, " +
                        "CustomerID = @id, " +
                        "CompanyName = @CompanyName, " +
                        "ContactTitle = @ContactTitle, " +
                        "Address = @Address, " +
                        "City = @City, " +
                        "Region = @Region, " +
                        "PostalCode = @PostalCode, " +
                        "Country = @Country, " +
                        "Phone = @Phone, " +
                        "Fax = @Fax " +
                        "WHERE CustomerID = @id";
                        

                    using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@id", clientInfo.id);
                        sqlCommand.Parameters.AddWithValue("@ContactName", clientInfo.ContactName);
                        sqlCommand.Parameters.AddWithValue("@CompanyName", clientInfo.CompanyName);
                        sqlCommand.Parameters.AddWithValue("@ContactTitle", clientInfo.ContactTitle);
                        sqlCommand.Parameters.AddWithValue("@Address", clientInfo.Address);
                        sqlCommand.Parameters.AddWithValue("@City", clientInfo.City);
                        sqlCommand.Parameters.AddWithValue("@Region", clientInfo.Region);
                        sqlCommand.Parameters.AddWithValue("@PostalCode", clientInfo.PostalCode);
                        sqlCommand.Parameters.AddWithValue("@Country", clientInfo.Country);
                        sqlCommand.Parameters.AddWithValue("@Phone", clientInfo.Phone);
                        sqlCommand.Parameters.AddWithValue("@Fax", clientInfo.Fax);

                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                errorMessage = ex.Message; return;
            }

            Response.Redirect("/Clientes/Index");
        }
    }
}
