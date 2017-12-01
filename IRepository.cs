
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CarDealer.DataLayer
{
    public interface IRepository
    {
        object adminLogIn(string username, string password);
        List<MainPhotos> getAllMainPhotos();
        List<CarsData> getAllCarsData();
        DataTable getUsedCarsData(string caryearselected, string carmakeselected);
        DataTable getNewCarsData(string caryearselected, string carmakeselected);
        List<CarsData> getCarFullData(string CarId);
        int deleteCarFromDB(string CarId);
        List<CarIds> getAllCarIds();

        int updateCarData(int Year, string Make, string Model, int Price, string Color, string BodyStyle, int Mpg, string DriveType, int Miles, string NewOrUsed, int Capacity, string CarId, byte[] MainPhoto, byte[] Photo2, byte[] Photo3, byte[] Photo4);
        List<CustomersList> getCustomersList();
        int enterCustomerdata(string FirstName, string LastName, string Email, string Phone, bool ContactByPhone, bool ContactByEmail, string CarId, string Date);
        List<Locations> showLocations();
        
        List<CarMake> getCarMakes();
        List<CarYear> getcarYears();
        int serviceAppointment(ServiceApointment sa, string date);
        List<AppointmentsList> showAppointments();
        int deleteserviceAppointment(int AppointmentID);

        int addNewCarToDataBase(int Year, string Make, string Model, int Price, string Color, string BodyStyle, int Mpg, string DriveType, int Miles, string NewOrUsed, int Capacity, string CarId, byte[] MainPhoto, byte[] Photo2, byte[] Photo3, byte[] Photo4);


    }
}