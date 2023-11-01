using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace BD2.Pages.Clientes
{
    public class CreateModel : PageModel
    {
        public ClientInfo clientInfo = new ClientInfo();
        public string errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
        }

        public void OnPost() {
            clientInfo.id = Request.Form["id"];
            clientInfo.ContactName = Request.Form["ContactName"];
            clientInfo.CompanyName = Request.Form["CompanyName"];
            clientInfo.ContactTitle = Request.Form["ContactTitle"];
            clientInfo.Address = Request.Form["Address"];
            clientInfo.City = Request.Form["City"];
            clientInfo.Region = Request.Form["Region"];
            clientInfo.PostalCode  = Request.Form["PostalCode"];
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
                    String sql = "INSERT INTO Customers" +
                        "(CustomerID, ContactName, CompanyName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax) VALUES" +
                        "(@id, @ContactName, @CompanyName, @ContactTitle, @Address, @City, @Region, @PostalCode, @Country, @Phone, @Fax);";
                    
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
            }catch (Exception ex) 
            {
                errorMessage = ex.Message; return;
            }

            clientInfo.id = "";
            clientInfo.ContactName = "";
            clientInfo.CompanyName = "";
            clientInfo.ContactTitle = ""    ;
            clientInfo.Address = "";
            clientInfo.City = "";
            clientInfo.Region = "";
            clientInfo.PostalCode = "";
            clientInfo.Country = "";
            clientInfo.Phone = "";
            clientInfo.Fax = "";

            successMessage = "Novo Cliente adicionado com sucesso";

            Response.Redirect("/Clientes/Index");
        }
    }
}
