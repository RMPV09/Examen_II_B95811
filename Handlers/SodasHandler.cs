using Examen_II_B95811.Models;
using System.Data;
using System.Data.SqlClient;


namespace Examen_II_B95811.Handlers
{
    public class SodasHandler
    {
        private SqlConnection conexion;
        private string conexionRoute;

        public SodasHandler()
        {
            var builder = WebApplication.CreateBuilder();
            conexionRoute = builder.Configuration.GetConnectionString("DefaultConnection");
            conexion = new SqlConnection(conexionRoute);
        }

        private DataTable CreateQueryTable(string myQuery)
        {
            SqlCommand queryCommand = new SqlCommand(myQuery, conexion);
            SqlDataAdapter tableAdapter = new SqlDataAdapter(queryCommand);
            DataTable formatedQuery = new DataTable();
            conexion.Open();
            tableAdapter.Fill(formatedQuery);
            conexion.Close();
            return formatedQuery;
        }

        public IList<SodaModel> GetAllSodas()
        {
            IList<SodaModel> mySodas = new List<SodaModel>();
            string myQuery = "SELECT * FROM dbo.Soda ";
            DataTable resultTable = CreateQueryTable(myQuery);
            foreach (DataRow row in resultTable.Rows)
            {
                mySodas.Add(
                new SodaModel
                {
                    Name = Convert.ToString(row["Name"]),
                    CansAvailable = Convert.ToInt32(row["CansAvailable"]),
                    PriceOfCan = Convert.ToInt32(row["PriceOfCan"]),
                    Currency = Convert.ToString(row["CurrencySymbol"]),
                });
            }
            return mySodas;
        }
    }
}
