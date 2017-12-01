using CarDealer.DataLayer;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CarDealer.Controllers
{
    
    public class AdminController : Controller
    {
        
        [Authorize]
        public ActionResult Index()
        {
            ViewData["uname"] = User.Identity.Name;
            return View();
        }

        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(AdminLogin al, string ReturnUrl)
        {
            IRepository rep = new Repository();
            
            object loginStatus = rep.adminLogIn(al.Username, al.Password);
            if (loginStatus == null)
            {
                al.ErrorMessage = "User Name or Password do not match !";
                return View("AdminLogin", al);
            }
            else
            {
                FormsAuthentication.SetAuthCookie(al.Username, false);
                return Redirect(ReturnUrl);
            }
            
        }
        [Authorize]
        public ActionResult AdminLogout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Home/Index");
        }
        [Authorize]
        public ActionResult AddVehicelToDatabase()
        {
            
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddVehicelToDatabase(int Year, string Make, string Model, int Price, string Color, string BodyStyle, int Mpg, string DriveType, int Miles, string NewOrUsed, int Capacity, string CarId, HttpPostedFileBase MainPhoto, HttpPostedFileBase Photo2, HttpPostedFileBase Photo3, HttpPostedFileBase Photo4)
        {
            IRepository rep = new Repository();

            byte[] mainphotopath = new byte[MainPhoto.ContentLength];
            byte[] photo2path = new byte[Photo2.ContentLength];
            byte[] photo3path = new byte[Photo3.ContentLength];
            byte[] photo4path = new byte[Photo4.ContentLength];
            if (MainPhoto != null)
                MainPhoto.InputStream.Read(mainphotopath, 0, MainPhoto.ContentLength);
            if (Photo2 != null)
                Photo2.InputStream.Read(photo2path, 0, Photo2.ContentLength);
            if (Photo3 != null)
                Photo3.InputStream.Read(photo3path, 0, Photo3.ContentLength);
            if (Photo4 != null)
                Photo4.InputStream.Read(photo4path, 0, Photo4.ContentLength);


            int noOfCarsEntered = rep.addNewCarToDataBase(Year, Make, Model, Price, Color, BodyStyle, Mpg, DriveType, Miles, NewOrUsed, Capacity, CarId, mainphotopath, photo2path, photo3path, photo4path);
            if(noOfCarsEntered != 0)
            {
                TempData["Success"] = "New Vehicel added sucessfully.";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Success"] = "Adding new vehicel failed. Please try again later. !";
                return RedirectToAction("About");
            }
            
        }

        [Authorize]
        public ActionResult PhotoViewAdmin(string CarId)
        {
            IRepository rep = new Repository();
            CarsData cd = new CarsData();
            cd.data = rep.getCarFullData(CarId);

            return View(cd);
        }
        [Authorize]
        public ActionResult ViewVehicelsFromDB()
        {
            IRepository rep = new Repository();
            CarsData cd = new CarsData();
            cd.data = rep.getAllCarsData();
            return View(cd);
        }

        [Authorize]
        public ActionResult Deletevehicel(string CarId)
        {
            IRepository rep = new Repository();
            int deleted = rep.deleteCarFromDB(CarId);
            if (deleted != 0)
            {
                TempData["Success"] = "Vehicel deleted sucessfully.";
                return RedirectToAction("ViewVehicelsFromDB");
            }   
            else
            {
                TempData["Success"] = "Deleting unsuccessfull. Please try again later.!";
                return RedirectToAction("ViewVehicelsFromDB");
            }
        }


        [HttpGet]
        [Authorize]
        public ActionResult EditVehicelInfo(int Year, string Make, string Model, int Price, string Color, string BodyStyle, int Mpg, string DriveType, int Miles, string NewOrUsed, int Capacity, string CarId)
        {
            IRepository rep = new Repository();
            CarsData cd = new CarsData();

            cd.data = rep.getCarFullData(CarId);

            return View(cd);
        }

        [HttpPost]
        [Authorize]
        public ActionResult EditVehicelInfo(int Year, string Make, string Model, int Price, string Color, string BodyStyle, int Mpg, string DriveType, int Miles, string NewOrUsed, int Capacity, string CarId, HttpPostedFileBase MainPhoto, HttpPostedFileBase Photo2, HttpPostedFileBase Photo3, HttpPostedFileBase Photo4)
        {
            IRepository rep = new Repository();
            

            byte[] mainphotopath = new byte[MainPhoto.ContentLength];
            byte[] photo2path = new byte[Photo2.ContentLength];
            byte[] photo3path = new byte[Photo3.ContentLength];
            byte[] photo4path = new byte[Photo4.ContentLength];
            if (MainPhoto != null)
                MainPhoto.InputStream.Read(mainphotopath, 0, MainPhoto.ContentLength);
            if (Photo2 != null)
                Photo2.InputStream.Read(photo2path, 0, Photo2.ContentLength);
            if (Photo3 != null)
                Photo3.InputStream.Read(photo3path, 0, Photo3.ContentLength);
            if (Photo4 != null)
                Photo4.InputStream.Read(photo4path, 0, Photo4.ContentLength);

            int carsupdated = rep.updateCarData(Year, Make, Model, Price, Color, BodyStyle, Mpg, DriveType, Miles, NewOrUsed, Capacity, CarId, mainphotopath, photo2path, photo3path, photo4path);

            if (carsupdated != 0)
            {
                TempData["Success"] = "Vehicel updated sucessfully.";
                return RedirectToAction("ViewVehicelsFromDB");
            }
                
            else
            {
                TempData["Success"] = "Updating vehicel failed. Please try again later.!";
                return RedirectToAction("ViewVehicelsFromDB");
            }
                
            
        }
        [Authorize]
        public ActionResult ViewCustomersDetails()
        {
            IRepository rep = new Repository();
            CustomersList cs = new CustomersList();
            cs.customerlist = rep.getCustomersList();
            return View(cs);
        }

        
        [Authorize]
        public ActionResult ViewServiceApointemnts()
        {
            IRepository rep = new Repository();
            ViewAppointments va = new ViewAppointments();
            va.appointmnetsList = rep.showAppointments();
            
            return View(va);
        }
        [Authorize]
        public ActionResult DeleteServiceAppointments(int AppointmentID)
        {
            IRepository rep = new Repository();
            int deleted = 0;
            deleted = rep.deleteserviceAppointment(AppointmentID);
            if (deleted != 0)
            {
                TempData["Success"] = "Service Appointment Deleted sucessfully.";
                return RedirectToAction("ViewServiceApointemnts");
            }
            else
            {
                TempData["Success"] = "Failed to Delete Appointment. Please try again later.!";
                return RedirectToAction("ViewServiceApointemnts");
            }
        }

        
    }
}