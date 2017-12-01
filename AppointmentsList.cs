using CarDealer.DataHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CarDealer.Models
{
    public class AppointmentsList : IPopulateRow
    {
        public int AppointmentID { get; set; }
        public string LocationName { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }

        public bool OilChange { get; set; }
        public bool TyreServices { get; set; }
        public bool BrakeServices { get; set; }
        public bool EmmisionCheckup { get; set; }
        public bool Maintenance { get; set; }
        public bool ElectricalServices { get; set; }
        public bool HeatingCoolingServices { get; set; }
        public bool BatteryServices { get; set; }
        public bool FluidFlush { get; set; }

        public void PopulateRow(DataRow dr)
        {
            this.AppointmentID = (int)dr["AppointmentID"];
            this.LocationName = (string)dr["LocationName"];
            this.Year = (int)dr["Year"];
            this.Make = (string)dr["Make"];
            this.Model = (string)dr["Model"];
            this.Date = (string)dr["Date"];
            this.Time = (string)dr["Time"];
            this.FirstName = (string)dr["FirstName"];
            this.LastName = (string)dr["LastName"];
            this.Email = (string)dr["Email"];
            this.Phone = (int)dr["Phone"];
            this.OilChange = (bool)dr["OilChange"];
            this.TyreServices = (bool)dr["TyreServices"];
            this.BrakeServices = (bool)dr["BrakeServices"];
            this.EmmisionCheckup = (bool)dr["EmmisionCheckup"];
            this.Maintenance = (bool)dr["Maintenance"];
            this.ElectricalServices = (bool)dr["ElectricalServices"];
            this.HeatingCoolingServices = (bool)dr["HeatingCoolingServices"];
            this.BatteryServices = (bool)dr["BatteryServices"];
            this.FluidFlush = (bool)dr["FluidFlush"];
            
        }

    }
}