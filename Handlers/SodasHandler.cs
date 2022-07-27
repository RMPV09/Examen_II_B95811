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

        public List<SodaModel> GetAllSodas()
        {
            List<SodaModel> mySodas = new List<SodaModel>();
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

        public bool AddSodas(SodaModel mySoda) 
        {
            bool success = false;
            var myQuery = @"INSERT INTO [dbo].[Soda] ([Name], [CansAvailable], [PriceOfCan],
                            [CurrencySymbol]) VALUES (@Name, @Cans, @Price, @Currency) ";
            var queryCommand  = new SqlCommand(myQuery, conexion);
            queryCommand.Parameters.AddWithValue("@Name", mySoda.Name);
            queryCommand.Parameters.AddWithValue("@Cans", mySoda.CansAvailable);
            queryCommand.Parameters.AddWithValue("@Price", mySoda.PriceOfCan);
            queryCommand.Parameters.AddWithValue("@Currency", mySoda.Currency);
            conexion.Open();
            success = queryCommand.ExecuteNonQuery() >= 1;
            conexion.Close();
            return success;
        }

        public bool ModifyInventoryOfSodas(SodaModel mySoda)
        {
            bool success = false;
            var myQuery = @"UPDATE [dbo].[Soda] SET CansAvailable = @Cans
                                                WHERE Name = @Name  ";
            var queryCommand = new SqlCommand(myQuery, conexion);
            queryCommand.Parameters.AddWithValue("@Name", mySoda.Name);
            queryCommand.Parameters.AddWithValue("@Cans", mySoda.CansAvailable);

            conexion.Open();
            success = queryCommand.ExecuteNonQuery() >= 1;
            conexion.Close();
            return success;
        }

        public SodaModel GetAllSodasByName(string myName)
        {
            List<SodaModel> mySodas = new List<SodaModel>();
            string myQuery = "SELECT * FROM dbo.Soda WHERE Name = myName";
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
            return mySodas.FirstOrDefault();
        }
    }
}
