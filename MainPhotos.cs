using CarDealer.DataHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CarDealer.Models
{
    public class MainPhotos : IPopulateRow
    {
        public byte[] MainPhoto { get; set; }
        public IList<MainPhotos> mainphotos { get; set; }

        public void PopulateRow(DataRow dr)
        {
            this.MainPhoto = (byte[])dr["MainPhoto"];
        }
    }
        
}