using CarDealer.DataHelper;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CarDealer.DataLayer
{
    public class Repository:IRepository
    {
        IDataAccess _idac = null;

        public Repository()
        {
            _idac = new DataAccess();
        }
        public Repository(IDataAccess idac)
        {
            _idac = idac;
        }

        public object adminLogIn(string username, string password)
        {
            object logInName;
            try
            {
                string sql = "select @username from LogIn where UserName = @username and Password = @password";
                List<SqlParameter> parmList = new List<SqlParameter>();
                SqlParameter p1 = new SqlParameter("@username", SqlDbType.NVarChar);
                SqlParameter p2 = new SqlParameter("@password", SqlDbType.NVarChar);
                p1.Value = username; parmList.Add(p1);
                p2.Value = password; parmList.Add(p2);

                logInName = _idac.GetSingleAnswer(sql, parmList);

            }
            catch(Exception)
            {
                throw;
            }
            return logInName;
        }

        public List<MainPhotos> getAllMainPhotos()
        {
            List<MainPhotos> mainphotos = new List<MainPhotos>();
            try
            {
                string sql = "select MainPhoto from Cars";
                DataTable dt = new DataTable();
                dt = _idac.GetManyRows(sql, null);
                mainphotos = DBList.CovertDataTableToList<MainPhotos>(dt);
            }
            catch(Exception)
            {
                throw;
            }
            return mainphotos;

        }
        public List<CarsData> getAllCarsData()
        {
            List<CarsData> carsdata = new List<CarsData>();
            try
            {
                string sql = "select * from Cars";
                DataTable dt = new DataTable();
                dt = _idac.GetManyRows(sql, null);
                carsdata = DBList.CovertDataTableToList<CarsData>(dt);
            }
            catch(Exception)
            {
                throw;
            }
            return carsdata;
        }

        public DataTable getUsedCarsData(string caryearselected, string carmakeselected)
        {
            DataTable dt = new DataTable();
            string sql;
            try
            {
                if (caryearselected == "none" && carmakeselected == "none")
                    sql = "select * from Cars where NewOrUsed = 'used'";
                else if (caryearselected != "none" && carmakeselected == "none")
                    sql = "select * from Cars where NewOrUsed = 'used' and Year = " + "'" + caryearselected + "'";
                else if (caryearselected == "none" && carmakeselected != "none")
                    sql = "select * from Cars where NewOrUsed = 'used' and Make = " + "'" + carmakeselected + "'";
                else if (caryearselected != "none" && carmakeselected != "none")
                    sql = "select * from Cars where NewOrUsed = 'used' and Make = " + "'" + carmakeselected + "'" +" and Year = "+"'"+caryearselected+"'";
                else
                    sql = null;
                dt = _idac.GetManyRows(sql, null);
                
            }
            catch (Exception)
            {
                 throw;
            }

            return dt;

        }

        public DataTable getNewCarsData(string caryearselected, string carmakeselected)
        {
            DataTable dt = new DataTable();
            string sql;
            try
            {
                if (caryearselected == "none" && carmakeselected == "none")
                    sql = "select * from Cars where NewOrUsed = 'new'";
                else if (caryearselected != "none" && carmakeselected == "none")
                    sql = "select * from Cars where NewOrUsed = 'new' and Year = " + "'" + caryearselected + "'";
                else if (caryearselected == "none" && carmakeselected != "none")
                    sql = "select * from Cars where NewOrUsed = 'new' and Make = " + "'" + carmakeselected + "'";
                else if (caryearselected != "none" && carmakeselected != "none")
                    sql = "select * from Cars where NewOrUsed = 'new' and Make = " + "'" + carmakeselected + "'" + " and Year = " + "'" + caryearselected + "'";
                else
                    sql = "select * from Cars where NewOrUsed = 'new'";
                dt = _idac.GetManyRows(sql, null);

            }
            catch (Exception)
            {
                throw;
            }

            return dt;

        }


        public List<CarsData> getCarFullData(string CarId)
        {
            List<CarsData> cardata = new List<CarsData>();
            try
            {
                string sql = "select * from cars where CarId = " + "'" + CarId + "'";
                DataTable dt = new DataTable();
                dt = _idac.GetManyRows(sql, null);
                cardata = DBList.CovertDataTableToList<CarsData>(dt);
            }
            catch(Exception)
            {
                throw;
            }
            return cardata;
        }

        public int deleteCarFromDB(string CarId)
        {
            int deletedcar;
            try
            {
                string sql = "delete from Cars where CarId = "+"'"+ CarId + "'";
                deletedcar = _idac.InsertUpdateDelete(sql, null);
            }
            catch(Exception)
            {
                throw;
            }
            return deletedcar;
        }

        public List<CarIds> getAllCarIds()
        {
            List<CarIds> carids = new List<CarIds>();
            try
            {
                string sql = "select CarId from Cars";
                DataTable dt = new DataTable();
                dt = _idac.GetManyRows(sql, null);
                carids = DBList.CovertDataTableToList<CarIds>(dt);
            }
            catch(Exception)
            {
                throw;
            }
            return carids;
        }

        public List<CarMake> getCarMakes()
        {
            List<CarMake> make = new List<CarMake>();
            try
            {
                string sql = "select Make from cars where NewOrUsed = 'new'";

                DataTable dt = new DataTable();
                dt = _idac.GetManyRows(sql, null);
                make = DBList.CovertDataTableToList<CarMake>(dt);
            }
            catch(Exception)
            {
                throw;
            }
            return make;
        }

        public List<CarYear> getcarYears()
        {
            List<CarYear> year = new List<CarYear>();
            try
            {
                string sql = "select Year from cars where NewOrUsed = 'new'";

                DataTable dt = new DataTable();
                dt = _idac.GetManyRows(sql, null);
                year = DBList.CovertDataTableToList<CarYear>(dt);
            }
            catch(Exception)
            {
                throw;
            }
            return year;
        }


        public List<Locations> showLocations()
        {
            List<Locations> loc = new List<Locations>();
            try
            {
                string sql = "select * from Locations";
                DataTable dt = new DataTable();
                dt = _idac.GetManyRows(sql, null);
                loc = DBList.CovertDataTableToList<Locations>(dt);
                
            }
            catch(Exception)
            {
                throw;
            }
            return loc;
        }

        public int addNewCarToDataBase(int Year, string Make, string Model, int Price, string Color, string BodyStyle, int Mpg, string DriveType, int Miles, string NewOrUsed, int Capacity, string CarId, byte[] MainPhoto, byte[] Photo2, byte[] Photo3, byte[] Photo4)
        {
            int noOfCarsAdd;
            try
            {
                string sql = "insert into Cars(Year, Make, Model, Price, Color, BodyStyle, Mpg, DriveType, Miles, NewOrUsed, Capacity, CarId, MainPhoto, Photo2, Photo3, Photo4) select @Year, @Make, @Model, @Price, @Color, @BodyStyle, @Mpg, @DriveType, @Miles, @NewOrUsed, @Capacity, @CarId, @MainPhoto, @Photo2, @Photo3, @Photo4";
                List<SqlParameter> parmList = new List<SqlParameter>();
                SqlParameter p1 = new SqlParameter("@Year", SqlDbType.Int);
                SqlParameter p2 = new SqlParameter("@Make", SqlDbType.NVarChar);
                SqlParameter p3 = new SqlParameter("@Model", SqlDbType.NVarChar);
                SqlParameter p4 = new SqlParameter("@Price", SqlDbType.Int);
                SqlParameter p5 = new SqlParameter("@Color", SqlDbType.NVarChar);
                SqlParameter p6 = new SqlParameter("@BodyStyle", SqlDbType.NVarChar);
                SqlParameter p7 = new SqlParameter("@Mpg", SqlDbType.Int);
                SqlParameter p8 = new SqlParameter("@DriveType", SqlDbType.NVarChar);
                SqlParameter p9 = new SqlParameter("@Miles", SqlDbType.Int);
                SqlParameter p10 = new SqlParameter("@NewOrUsed", SqlDbType.NVarChar);
                SqlParameter p11 = new SqlParameter("@Capacity", SqlDbType.NVarChar);
                SqlParameter p12 = new SqlParameter("@CarId", SqlDbType.NVarChar);
                SqlParameter p13 = new SqlParameter("@MainPhoto", SqlDbType.Binary);
                SqlParameter p14 = new SqlParameter("@Photo2", SqlDbType.Binary);
                SqlParameter p15 = new SqlParameter("@Photo3", SqlDbType.Binary);
                SqlParameter p16 = new SqlParameter("@Photo4", SqlDbType.Binary);

                p1.Value = Year; parmList.Add(p1);
                p2.Value = Make; parmList.Add(p2);
                p3.Value = Model; parmList.Add(p3);
                p4.Value = Price; parmList.Add(p4);
                p5.Value = Color; parmList.Add(p5);
                p6.Value = BodyStyle; parmList.Add(p6);
                p7.Value = Mpg; parmList.Add(p7);
                p8.Value = DriveType; parmList.Add(p8);
                p9.Value = Miles; parmList.Add(p9);
                p10.Value = NewOrUsed; parmList.Add(p10);
                p11.Value = Capacity; parmList.Add(p11);
                p12.Value = CarId; parmList.Add(p12);
                p13.Value = MainPhoto; parmList.Add(p13);
                p14.Value = Photo2; parmList.Add(p14);
                p15.Value = Photo3; parmList.Add(p15);
                p16.Value = Photo4; parmList.Add(p16);
                
                noOfCarsAdd = _idac.InsertUpdateDelete(sql, parmList);
                
            }
            catch (Exception)
            {
                throw;
            }
            return noOfCarsAdd;
        }


        public int updateCarData(int Year, string Make, string Model, int Price, string Color, string BodyStyle, int Mpg, string DriveType, int Miles, string NewOrUsed, int Capacity, string CarId, byte[] MainPhoto, byte[] Photo2, byte[] Photo3, byte[] Photo4)
        {
            int noOfCarsAdd;
            try
            {
                string sql = "update Cars set Year = @Year, Make=@Make, Model=@Model, Price=@Price, Color=@Color, BodyStyle=@BodyStyle, Mpg=@Mpg, DriveType=@DriveType, Miles=@Miles, NewOrUsed=@NewOrUsed, Capacity=@Capacity, MainPhoto=@MainPhoto, Photo2=@Photo2, Photo3=@Photo3, Photo4=@Photo4 where CarId=@CarId";
                List<SqlParameter> parmList = new List<SqlParameter>();
                SqlParameter p1 = new SqlParameter("@Year", SqlDbType.Int);
                SqlParameter p2 = new SqlParameter("@Make", SqlDbType.NVarChar);
                SqlParameter p3 = new SqlParameter("@Model", SqlDbType.NVarChar);
                SqlParameter p4 = new SqlParameter("@Price", SqlDbType.Int);
                SqlParameter p5 = new SqlParameter("@Color", SqlDbType.NVarChar);
                SqlParameter p6 = new SqlParameter("@BodyStyle", SqlDbType.NVarChar);
                SqlParameter p7 = new SqlParameter("@Mpg", SqlDbType.Int);
                SqlParameter p8 = new SqlParameter("@DriveType", SqlDbType.NVarChar);
                SqlParameter p9 = new SqlParameter("@Miles", SqlDbType.Int);
                SqlParameter p10 = new SqlParameter("@NewOrUsed", SqlDbType.NVarChar);
                SqlParameter p11 = new SqlParameter("@Capacity", SqlDbType.NVarChar);
                SqlParameter p12 = new SqlParameter("@CarId", SqlDbType.NVarChar);
                SqlParameter p13 = new SqlParameter("@MainPhoto", SqlDbType.Binary);
                SqlParameter p14 = new SqlParameter("@Photo2", SqlDbType.Binary);
                SqlParameter p15 = new SqlParameter("@Photo3", SqlDbType.Binary);
                SqlParameter p16 = new SqlParameter("@Photo4", SqlDbType.Binary);

                p1.Value = Year; parmList.Add(p1);
                p2.Value = Make; parmList.Add(p2);
                p3.Value = Model; parmList.Add(p3);
                p4.Value = Price; parmList.Add(p4);
                p5.Value = Color; parmList.Add(p5);
                p6.Value = BodyStyle; parmList.Add(p6);
                p7.Value = Mpg; parmList.Add(p7);
                p8.Value = DriveType; parmList.Add(p8);
                p9.Value = Miles; parmList.Add(p9);
                p10.Value = NewOrUsed; parmList.Add(p10);
                p11.Value = Capacity; parmList.Add(p11);
                p12.Value = CarId; parmList.Add(p12);
                p13.Value = MainPhoto; parmList.Add(p13);
                p14.Value = Photo2; parmList.Add(p14);
                p15.Value = Photo3; parmList.Add(p15);
                p16.Value = Photo4; parmList.Add(p16);

                noOfCarsAdd = _idac.InsertUpdateDelete(sql, parmList);

            }
            catch (Exception)
            {
                throw;
            }
            return noOfCarsAdd;
        }


        public int serviceAppointment(ServiceApointment sa, string date)
        {
            int loginstatus;

            try
            {
                string sql = "insert into ServiceAppointments values(@LocationName, @Year, @Make, @Model, @Date, @Time, @FirstName, @LastName, @Email, @Phone, @OilChange, @TyreServices, @BrakeServices, @EmmisionCheckup, @Maintenance, @ElectricalServices, @HeatingCoolingServices, @BatteryServices, @FluidFlush)";
                List<SqlParameter> parmList = new List<SqlParameter>();
                SqlParameter p1 = new SqlParameter("@LocationName", SqlDbType.NVarChar);
                SqlParameter p2 = new SqlParameter("@Year", SqlDbType.Int);
                SqlParameter p3 = new SqlParameter("@Make", SqlDbType.NVarChar);
                SqlParameter p4 = new SqlParameter("@Model", SqlDbType.NVarChar);
                SqlParameter p6 = new SqlParameter("@Date", SqlDbType.NVarChar);
                SqlParameter p7 = new SqlParameter("@Time", SqlDbType.NVarChar);
                SqlParameter p8 = new SqlParameter("@FirstName", SqlDbType.NVarChar);
                SqlParameter p9 = new SqlParameter("@LastName", SqlDbType.NVarChar);
                SqlParameter p10 = new SqlParameter("@Email", SqlDbType.NVarChar);
                SqlParameter p11 = new SqlParameter("@Phone", SqlDbType.Int);
                SqlParameter p12 = new SqlParameter("@OilChange", SqlDbType.NVarChar);
                SqlParameter p13 = new SqlParameter("@TyreServices", SqlDbType.NVarChar);
                SqlParameter p14 = new SqlParameter("@BrakeServices", SqlDbType.NVarChar);
                SqlParameter p15 = new SqlParameter("@EmmisionCheckup", SqlDbType.NVarChar);
                SqlParameter p16 = new SqlParameter("@Maintenance", SqlDbType.NVarChar);
                SqlParameter p17 = new SqlParameter("@ElectricalServices", SqlDbType.NVarChar);
                SqlParameter p18 = new SqlParameter("@HeatingCoolingServices", SqlDbType.NVarChar);
                SqlParameter p19 = new SqlParameter("@BatteryServices", SqlDbType.NVarChar);
                SqlParameter p20 = new SqlParameter("@FluidFlush", SqlDbType.NVarChar);
                p1.Value = sa.locationselected; parmList.Add(p1);
                p2.Value = sa.caryearselected; parmList.Add(p2);
                p3.Value = sa.carmakeselected; parmList.Add(p3);
                p4.Value = sa.carmodelselected; parmList.Add(p4);
                p6.Value = date; parmList.Add(p6);
                p7.Value = sa.timeselected; parmList.Add(p7);
                p8.Value = sa.firstname; parmList.Add(p8);
                p9.Value = sa.lastname; parmList.Add(p9);
                p10.Value = sa.email; parmList.Add(p10);
                p11.Value = sa.phone; parmList.Add(p11);
                p12.Value = sa.oilChange; parmList.Add(p12);
                p13.Value = sa.tyreServices; parmList.Add(p13);
                p14.Value = sa.brakeservices; parmList.Add(p14);
                p15.Value = sa.emmisionCheckup; parmList.Add(p15);
                p16.Value = sa.maintenance; parmList.Add(p16);
                p17.Value = sa.electricalServices; parmList.Add(p17);
                p18.Value = sa.heatingCoolingServices; parmList.Add(p18);
                p19.Value = sa.batteryServices; parmList.Add(p19);
                p20.Value = sa.fluidFlush; parmList.Add(p20);


                loginstatus = _idac.InsertUpdateDelete(sql, parmList);

            }
            catch (Exception)
            {
                throw;
            }
            return loginstatus;
        }


        public int enterCustomerdata(string FirstName, string LastName, string Email, string Phone, bool ContactByPhone, bool ContactByEmail, string CarId, string Date)
        {
            int rowseffected;
            try
            {
                string sql = "insert into CustomerContacts(FirstName, LastName, Email, Phone, ContactByPhone, ContactByEmail, CarId, Date) select " + 
                    "'"+FirstName+"' , '" + LastName+"' , '"+Email+"' , '"+Phone+"' , '"+ContactByPhone+"' , '"+ContactByEmail+"' , '"+CarId+"' , '"+Date+"'";
                rowseffected = _idac.InsertUpdateDelete(sql, null);
            }
            catch (Exception)
            {
                throw;
            }
            return rowseffected;
        }

        public List<CustomersList> getCustomersList()
        {
            List<CustomersList> customerlist = new List<CustomersList>();
            try
            {
                string sql = "select * from CustomerContacts";
                DataTable dt = new DataTable();
                dt = _idac.GetManyRows(sql, null);
                customerlist = DBList.CovertDataTableToList<CustomersList>(dt);
            }
            catch(Exception)
            {
                throw;
            }
            return customerlist;
        }

        public List<AppointmentsList> showAppointments()
        {
            List<AppointmentsList> appointments = new List<AppointmentsList>();

            try
            {
                string sql = "select * from ServiceAppointments";
                DataTable dt = new DataTable();
                dt = _idac.GetManyRows(sql, null);
                appointments = DBList.CovertDataTableToList<AppointmentsList>(dt);
            }
            catch (Exception)
            {
                throw;
            }

            return appointments;
        }

        public int deleteserviceAppointment(int AppointmentID)
        {
            int deleted;
            try
            {
                string sql = "delete from ServiceAppointments where AppointmentID = " + "'" + AppointmentID + "'";
                deleted = _idac.InsertUpdateDelete(sql, null);
            }
            catch(Exception)
            {
                throw;
            }
            return deleted;
        }

    }
}