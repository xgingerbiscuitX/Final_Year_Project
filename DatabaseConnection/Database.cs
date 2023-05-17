using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection
{
   public class Database : IDatabase
    {
        private SqlConnection connect;
        DataSet ds;
        SqlDataAdapter dataAdapter;
        SqlCommandBuilder commandBuilder;


        private static SqlDataReader reader;

        private static IDatabase dataLayerSingletonInstance;
        static readonly object padlock = new object();

        //Closes the connection
        public void closeConnection()
        {
            connect.Close();
        }

        public SqlConnection getConnection()
        {
            return connect;
        }

        public static IDatabase GetInstance()
        {
            lock (padlock)
            {
                if (dataLayerSingletonInstance == null)
                {
                    dataLayerSingletonInstance = new Database();
                }
                return dataLayerSingletonInstance;
            }

        }
        public Database()
        {
            openConnection();
        }
        public void openConnection()
        {
            connect = new SqlConnection();
            connect.ConnectionString = @"Data Source=localhost;Initial Catalog=myNFCdb;Integrated Security=True";
            try
            {
                connect.Open();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Failer to connect", ex.ToString());
                connect.Close();
                Environment.Exit(0); // Force application to close after failer
            }
        }

        public void saveUID(string getUID, string getTType)
        {
            string query = "INSERT INTO [myNFCdb].[dbo].[TagType](tagtype,tagUID) VALUES('" + getUID +"','"+ getTType + "')";

            SqlCommand sqlCommand = new SqlCommand(query, connect);
            sqlCommand.CommandTimeout = 60;
            try
            {
                reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                }
                reader.Close();
                
            }

            catch (Exception ex)
            {

                reader.Close();
                //   error(ex.Message.ToString());
               // MessageBox.Show(ex.ToString());
           
            }

        }
    }
}
