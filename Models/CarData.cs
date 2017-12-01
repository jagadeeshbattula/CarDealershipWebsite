using CarDealer.DataHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace CarDealer.Models
{
    public class CarsData : IPopulateRow
    {
        public string Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public float Price { get; set; }
        public string Color { get; set; }
        public string BodyStyle { get; set; }
        public int Mpg { get; set; }
        public string DriveType { get; set; }
        public int Miles { get; set; }
        public string NewOrUsed { get; set; }
        public int Capacity { get; set; }
        public string CarId { get; set; }

        public byte[] MainPhoto { get; set; }
        public byte[] Photo2 { get; set; }
        public byte[] Photo3 { get; set; }
        public byte[] Photo4 { get; set; }
        
        public List<CarsData> data { get; set; }
        

        public void PopulateRow(DataRow dr)
        {
            this.Year = (string)dr["Year"];
            this.Make = (string)dr["Make"];
            this.Model = (string)dr["Model"];
            this.Price = (int)dr["Price"];
            this.Color = (string)dr["Color"];
            this.BodyStyle = (string)dr["BodyStyle"];
            this.Mpg = (int)dr["Mpg"];
            this.DriveType = (string)dr["DriveType"];
            this.Miles = (int)dr["Miles"];
            this.NewOrUsed = (string)dr["NewOrUsed"];
            this.Capacity = (int)dr["Capacity"];
            this.CarId = (string)dr["CarId"];
            this.MainPhoto = (byte[])dr["MainPhoto"];
            this.Photo2 = (byte[])dr["Photo2"];
            this.Photo3 = (byte[])dr["Photo3"];
            this.Photo4 = (byte[])dr["Photo4"];
            
        }
    }
}