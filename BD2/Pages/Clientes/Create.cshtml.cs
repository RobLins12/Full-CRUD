using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace BD2.Pages.Clientes
{
    public class CreateModel : PageModel
    {
        public ClientInfo client = new ClientInfo();
        public string errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
        }

        public void OnPost() { 
            client.id = Request.Form["id"];
            client.ContactName = Request.Form["ContactName"];
            client.CompanyName = Request.Form["CompanyName"];
            client.ContactTitle = Request.Form["ContactTitle"];
            client.Address = Request.Form["Address"];
            client.City = Request.Form["City"];
            client.Region = Request.Form["Region"];
            client.PostalCode  = Request.Form["PostalCode"];
            client.Country = Request.Form["Country"];
            client.Phone = Request.Form["Phone"];
            client.Fax = Request.Form["Fax"];

            if (client.id.Length == 0 || client.ContactName.Length == 0 || client.CompanyName.Length == 0
                || client.ContactTitle.Length == 0 || client.Address.Length == 0 || client.City.Length == 0
                || client.Region.Length == 0 || client.PostalCode.Length == 0 || client.Country.Length == 0
                || client.Phone.Length == 0 || client.Fax.Length == 0)
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
                        sqlCommand.Parameters.AddWithValue("@id", client.id);
                        sqlCommand.Parameters.AddWithValue("@ContactName", client.ContactName);
                        sqlCommand.Parameters.AddWithValue("@CompanyName", client.CompanyName);
                        sqlCommand.Parameters.AddWithValue("@ContactTitle", client.ContactTitle);
                        sqlCommand.Parameters.AddWithValue("@Address", client.Address);
                        sqlCommand.Parameters.AddWithValue("@City", client.City);
                        sqlCommand.Parameters.AddWithValue("@Region", client.Region);
                        sqlCommand.Parameters.AddWithValue("@PostalCode", client.PostalCode);
                        sqlCommand.Parameters.AddWithValue("@Country", client.Country);
                        sqlCommand.Parameters.AddWithValue("@Phone", client.Phone);
                        sqlCommand.Parameters.AddWithValue("@Fax", client.Fax);

                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }catch (Exception ex) 
            {
                errorMessage = ex.Message; return;
            }


            // Adiciona o cliente na base de dados
            client.id = "";
            client.ContactName = "";
            client.CompanyName = "";
            client.ContactTitle = "";
            client.Address = "";
            client.City = "";
            client.Region = "";
            client.PostalCode = "";
            client.Country = "";
            client.Phone = "";
            client.Fax = "";

            successMessage = "Novo Cliente adicionado com sucesso";

            Response.Redirect("/Clientes/Index");
        }
    }
}
