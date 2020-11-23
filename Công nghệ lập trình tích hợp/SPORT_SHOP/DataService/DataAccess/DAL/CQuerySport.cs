using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DataService.DataAccess.DAL
{
    public class CQuerySport
    {
        private static CQuerySport instance;

        public static CQuerySport Instance
        {
            get { if (instance == null) instance = new CQuerySport(); return CQuerySport.instance; }
            private set { CQuerySport.instance = value; }
        }

        private CQuerySport() { }


        private string str = @"Data Source=HUNG247\SQLEXPRESS01;Initial Catalog=SPORT_SHOP;Integrated Security=True";

        public DataTable ExecuteQuery(string query)
        {
            DataTable data = new DataTable();

            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();

                SqlCommand command = new SqlCommand(query, conn);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                data.Clear();
                adapter.Fill(data);

                conn.Close();
            }

            return data;
        }

        public int ExecuteNonQuery(string query)
        {
            int data = 0;

            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();

                SqlCommand command = new SqlCommand(query, conn);

                data = command.ExecuteNonQuery();

                conn.Close();
            }

            return data;
        }

        public object ExecuteScalar(string query)
        {
            object data;

            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();

                SqlCommand command = new SqlCommand(query, conn);

                data = command.ExecuteScalar();

                conn.Close();
            }

            return data;
        }


    }
}