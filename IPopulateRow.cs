using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CarDealer.DataHelper
{
    public interface IPopulateRow
    {
        void PopulateRow(DataRow dr);
    }
}