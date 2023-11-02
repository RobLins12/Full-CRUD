using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Win32;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace BD2.Pages.Relatorio
{
    public class IndexModel : PageModel
    { 
        public DataTable ProcedureRelatorio()
    {
        var dt = new DataTable();

        try
        {
            String connectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=Northwind;Integrated Security=True";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                using (SqlDataAdapter sqlCommand = new SqlDataAdapter(null, sqlConnection))
                {
                    sqlCommand.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.SelectCommand.CommandText = "GetCategorySalesReport";

                    sqlCommand.Fill(dt);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception:  " + ex.ToString());
        }
        return dt;
    }
}
    
}
