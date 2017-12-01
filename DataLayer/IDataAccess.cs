using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CarDealer.DataLayer
{
    public interface IDataAccess
    {
        object GetSingleAnswer(string sql, List<SqlParameter> PmList);
        DataTable GetManyRows(string sql, List<SqlParameter> PmList);
        int InsertUpdateDelete(string sql, List<SqlParameter> PmList);
    }
}