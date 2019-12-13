using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MART391TestApp3
{
    public class DBIO
    {
        string hwConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        SqlConnection hwConnection;

        public DBIO()
        {

        }

        public SqlConnection OpenDB()
        {
            hwConnection = new SqlConnection(hwConnectionString);
            hwConnection.Open();
            return hwConnection;
        }

        public void CloseDB()
        {
            hwConnection.Close();
        }

        public DataSet CreateDataSet(String query, SqlParameter[] parameters)
        {
            OpenDB();

            string dQuery = query;
            DataSet dataSet = new DataSet();
            SqlCommand dCommand = new SqlCommand(dQuery);
            dCommand.Connection = hwConnection;
            dCommand.CommandType = CommandType.StoredProcedure;
            dCommand.Parameters.AddRange(parameters);
            SqlDataAdapter hwAdapter = new SqlDataAdapter(dCommand);
            hwAdapter.Fill(dataSet);

            CloseDB();

            return dataSet;
        }

        public int ExecuteNonQuery(String query, SqlParameter[] parameters)
        {
            OpenDB();

            string nonQuery = query;
            SqlCommand nqCommand = new SqlCommand(nonQuery);
            nqCommand.Connection = hwConnection;
            nqCommand.CommandType = CommandType.StoredProcedure;
            nqCommand.Parameters.AddRange(parameters);
            int rows = nqCommand.ExecuteNonQuery();
            CloseDB();

            return rows;
        }

    }
}
