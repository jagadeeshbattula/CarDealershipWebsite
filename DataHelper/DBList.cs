using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CarDealer.DataHelper
{
    public class DBList
    {
        public static List<T> CovertDataTableToList<T>(DataTable dt)
            where T : IPopulateRow, new()
        {
            
                List<T> TList = new List<T>();
                try
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        T row = new T();
                        row.PopulateRow(dr);
                        TList.Add(row);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return TList;
            
        }
    }
}