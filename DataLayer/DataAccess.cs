using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CarDealer.DataLayer
{
    public class DataAccess : IDataAccess
    {
        public static string CONNSTR = ConfigurationManager.ConnectionStrings["CARDEALERDB"].ConnectionString;
        public DataAccess()
        {

        }

        public DataTable GetManyRows(string sql, List<SqlParameter> PmList)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(CONNSTR);
            try
            {
                
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand(sql, conn);
                if(PmList != null)
                {
                    foreach (SqlParameter p in PmList)
                        cmd.Parameters.Add(p);
                }
                da.SelectCommand = cmd;
                da.Fill(dt);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }

        public object GetSingleAnswer(string sql, List<SqlParameter> PmList)
        {
            object obj = null;
            SqlConnection conn = new SqlConnection(CONNSTR);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                if(PmList != null)
                {
                    foreach (SqlParameter p in PmList)
                        cmd.Parameters.Add(p);
                }
                obj = cmd.ExecuteScalar();
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return obj;
        }

        public int InsertUpdateDelete(string sql, List<SqlParameter> PmList)
        {
            int rows = 0;
            SqlConnection conn = new SqlConnection(CONNSTR);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                if(PmList != null)
                {
                    foreach (SqlParameter p in PmList)
                        cmd.Parameters.Add(p);
                }
                rows = cmd.ExecuteNonQuery();
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return rows;
        }
    }
}