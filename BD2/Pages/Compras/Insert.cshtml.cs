using BD2.Pages.Compras;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using static BD2.Pages.Compras.IndexModel;

namespace BD2.Pages.Compras
{
    public class InsertModel : PageModel
    {
        public Orders order = new Orders();
        public string errorMessage = "";
        public String successMessage = "";
        public int OrderID = 0;
        public void OnGet()
        {
            try
            {
               String connectionString = "Data Source=localhost;Initial Catalog=Northwind;Integrated Security=True";

                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    String sql = "INSERT INTO Orders" +
                         "(CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate, ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry) VALUES" +
                         "(NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);" +
                         " SELECT SCOPE_IDENTITY() AS OrderID;";

                    using (SqlCommand command = new SqlCommand(sql, sqlConnection))
                    {
                        OrderID = Convert.ToInt32(command.ExecuteScalar()); // Armazene o OrderID na variável de membro
                        order.OrderID = OrderID.ToString(); // Atualize a propriedade OrderID do objeto order
                        Console.WriteLine("OrderID = " + OrderID);
                        command.ExecuteNonQuery();
                    }
                }
            }catch(Exception ex) 
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void OnPost() 
        {
            order.OrderID = Request.Form["OrderID"];
            Console.WriteLine(order.OrderID);
            order.CustomerID = Request.Form["CustomerID"];
            order.EmployeeID = Request.Form["EmployeeID"];
            order.ProductID = Request.Form["ProductID"];
            order.Quantity = Request.Form["Quantity"];
            order.UnitPrice = Request.Form["UnitPrice"];
            order.Discount = Request.Form["Discount"];

            if (order.CustomerID.Length == 0 || order.EmployeeID.Length == 0
            || order.ProductID.Length == 0 || order.Quantity.Length == 0 || order.UnitPrice.Length == 0)
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
                    String sql = "UPDATE Orders SET CustomerID = @CustomerID, EmployeeID = @EmployeeID WHERE OrderID = @ID;" +
                        " INSERT INTO [Order Details](OrderID, ProductID, UnitPrice, Quantity, Discount) VALUES" +
                        "(@OrderID, @ProductID, @UnitPrice, @Quantity, @Discount)";
              
                    using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@ID", order.OrderID);
                        sqlCommand.Parameters.AddWithValue("@OrderID", order.OrderID);
                        sqlCommand.Parameters.AddWithValue("@CustomerID", order.CustomerID);
                        sqlCommand.Parameters.AddWithValue("@EmployeeID", order.EmployeeID);
                        sqlCommand.Parameters.AddWithValue("@ProductID", order.ProductID);
                        sqlCommand.Parameters.AddWithValue("@Quantity", order.Quantity);
                        sqlCommand.Parameters.AddWithValue("@UnitPrice", order.UnitPrice);
                        sqlCommand.Parameters.AddWithValue("@Discount", order.Discount);

                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message; return;
            }

            successMessage = "Novo Compra adicionado com sucesso";

        }
    }
}
