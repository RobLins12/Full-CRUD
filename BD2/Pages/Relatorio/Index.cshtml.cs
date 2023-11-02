using BD2.Pages.Clientes;
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
        List<Relatorio> Relatorios = new List<Relatorio>();

        public void ProcedureRelatorio() 
        {

        try
        {
            String connectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=Northwind;Integrated Security=True";

                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    String sql = "EXECUTE GetCategorySalesReport";
                    using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                    {
                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Relatorio relatorio = new Relatorio();
                                relatorio.Categoria = "" + reader.GetString(0);
                                relatorio.QuantidadeVendida = "" + reader.GetInt32(1);
                                relatorio.TotalDasVendas = "" + reader.GetSqlDouble(2);
                                relatorio.MaiorComprador = "" + reader.GetString(3);
                                relatorio.PaísComMaisCompras = "" + reader.GetString(4);
                                relatorio.CidadeComMaisCompras = "" + reader.GetString(5);

                                Relatorios.Add(relatorio);
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
    public class Relatorio
    {
        public String Categoria;
        public String QuantidadeVendida;
        public String TotalDasVendas;
        public String MaiorComprador;
        public String PaísComMaisCompras;
        public String CidadeComMaisCompras;
    }
}
