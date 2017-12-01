using CarDealer.DataHelper;
using CarDealer.DataLayer;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealer.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            IRepository rep = new Repository();
            MainPhotos mp = new MainPhotos();
            mp.mainphotos = rep.getAllMainPhotos();
            
            return View(mp);
        }
        
        public ActionResult UsedCarInventory()
        {
            IRepository rep = new Repository();
            UsedCarModel uc = new UsedCarModel();
            DataTable dt = rep.getUsedCarsData("none", "none");
            //for full list:-
            List<CarsData> carsdata = new List<CarsData>();
            carsdata = DBList.CovertDataTableToList<CarsData>(dt);
            uc.carsdata = carsdata;
            //for car years filter:-
            List<CarYear> caryears = new List<CarYear>();
            caryears = DBList.CovertDataTableToList<CarYear>(dt);
            List<string> caryearsstring = new List<string>();
            foreach(var item in caryears)
            {
                string items;
                items = item.Year.ToString();
                caryearsstring.Add(items);
            }
            List<int> caryearsint = new List<int>();
            caryearsint = caryearsstring.Select(int.Parse).ToList();
            List<int> distinctcaryears = new List<int>();
            distinctcaryears = caryearsint.Distinct().ToList();
            distinctcaryears.Sort();
            uc.caryears = new List<SelectListItem>();
            uc.caryears.Add(new SelectListItem() { Text = "None", Value = "none" });
            foreach (var item in distinctcaryears)
            {
                SelectListItem si = new SelectListItem()
                {
                    Value = item.ToString(),
                    Text = item.ToString()
                };
                uc.caryears.Add(si);
            }
            //for makes filter:-
            List<CarMake> carmake = new List<CarMake>();
            carmake = DBList.CovertDataTableToList<CarMake>(dt);
            List<string> carmakestring = new List<string>();
            foreach(var item in carmake)
            {
                string items;
                items = item.Make.ToString();
                carmakestring.Add(items);
            }
            List<string> distinctcarmake = new List<string>();
            distinctcarmake = carmakestring.Distinct().ToList();
            distinctcarmake.Sort();
            uc.carmakes = new List<SelectListItem>();
            uc.carmakes.Add(new SelectListItem() { Text = "None", Value = "none" });
            foreach (var item in distinctcarmake)
            {
                SelectListItem si = new SelectListItem()
                {
                    Value = item,
                    Text = item
                };
                uc.carmakes.Add(si);
                
            }

            return View(uc);
        }

        [HttpPost]
        public ActionResult UsedCarInventory(UsedCarModel uc)
        {
            
            IRepository rep = new Repository();
            DataTable dt = rep.getUsedCarsData(uc.caryearselected, uc.carmakeselected);
            //for full list: -
            List<CarsData> carsdata = new List<CarsData>();
            carsdata = DBList.CovertDataTableToList<CarsData>(dt);
            uc.carsdata = carsdata;
            //for years filter: -
            List<CarYear> caryears = new List<CarYear>();
            caryears = DBList.CovertDataTableToList<CarYear>(dt);
            List<string> caryearsstring = new List<string>();
            foreach (var item in caryears)
            {
                string items;
                items = item.Year.ToString();
                caryearsstring.Add(items);
            }
            List<int> caryearsint = new List<int>();
            caryearsint = caryearsstring.Select(int.Parse).ToList();
            List<int> distinctcaryears = new List<int>();
            distinctcaryears = caryearsint.Distinct().ToList();
            distinctcaryears.Sort();
            uc.caryears = new List<SelectListItem>();
            uc.caryears.Add(new SelectListItem() { Text = "None", Value = "none" });
            foreach (var item in distinctcaryears)
            {
                SelectListItem si = new SelectListItem()
                {
                    Value = item.ToString(),
                    Text = item.ToString()
                };
                uc.caryears.Add(si);
            }
            //for makes filter:-
            List<CarMake> carmake = new List<CarMake>();
            carmake = DBList.CovertDataTableToList<CarMake>(dt);
            List<string> carmakestring = new List<string>();
            foreach (var item in carmake)
            {
                string items;
                items = item.Make.ToString();
                carmakestring.Add(items);
            }
            List<string> distinctcarmake = new List<string>();
            distinctcarmake = carmakestring.Distinct().ToList();
            distinctcarmake.Sort();
            uc.carmakes = new List<SelectListItem>();
            uc.carmakes.Add(new SelectListItem() { Text = "None", Value = "none" });
            foreach (var item in distinctcarmake)
            {
                SelectListItem si = new SelectListItem()
                {
                    Value = item,
                    Text = item
                };
                uc.carmakes.Add(si);
            }

            return View(uc);
        }
        
        public ActionResult NewCarInventory()
        {
            IRepository rep = new Repository();
            NewCarsModel nc = new NewCarsModel();
            DataTable dt = rep.getNewCarsData("none", "none");
            //for full list:-
            List<CarsData> carsdata = new List<CarsData>();
            carsdata = DBList.CovertDataTableToList<CarsData>(dt);
            nc.carsdata = carsdata;
            //for car years filter:-
            List<CarYear> caryears = new List<CarYear>();
            caryears = DBList.CovertDataTableToList<CarYear>(dt);
            List<string> caryearsstring = new List<string>();
            foreach (var item in caryears)
            {
                string items;
                items = item.Year.ToString();
                caryearsstring.Add(items);
            }
            List<int> caryearsint = new List<int>();
            caryearsint = caryearsstring.Select(int.Parse).ToList();
            List<int> distinctcaryears = new List<int>();
            distinctcaryears = caryearsint.Distinct().ToList();
            distinctcaryears.Sort();
            nc.caryear = new List<SelectListItem>();
            nc.caryear.Add(new SelectListItem() { Text = "None", Value = "none" });
            foreach (var item in distinctcaryears)
            {
                SelectListItem si = new SelectListItem()
                {
                    Value = item.ToString(),
                    Text = item.ToString()
                };
                nc.caryear.Add(si);
            }
            //for makes filter:-
            List<CarMake> carmake = new List<CarMake>();
            carmake = DBList.CovertDataTableToList<CarMake>(dt);

            List<string> carmakesstring = new List<string>();
            foreach(var item in carmake)
            {
                string items;
                items = item.Make.ToString();
                carmakesstring.Add(items);
            }
            List<string> distinctcarmakes = new List<string>();
            distinctcarmakes = carmakesstring.Distinct().ToList();
            distinctcarmakes.Sort();

            nc.carmake = new List<SelectListItem>();
            nc.carmake.Add(new SelectListItem() { Text = "None", Value = "none" });
            foreach (var item in distinctcarmakes)
            {
                SelectListItem si = new SelectListItem()
                {
                    Value = item,
                    Text = item
                };
                nc.carmake.Add(si);
            }

            return View(nc);
        }
        [HttpPost]
        public ActionResult NewCarInventory(NewCarsModel nc)
        {
            IRepository rep = new Repository();
            DataTable dt = rep.getNewCarsData(nc.caryearselected, nc.carmakeselected);
            //for full list: -
            List<CarsData> carsdata = new List<CarsData>();
            carsdata = DBList.CovertDataTableToList<CarsData>(dt);
            nc.carsdata = carsdata;
            //for car years filter:-
            List<CarYear> caryears = new List<CarYear>();
            caryears = DBList.CovertDataTableToList<CarYear>(dt);
            List<string> caryearsstring = new List<string>();
            foreach (var item in caryears)
            {
                string items;
                items = item.Year.ToString();
                caryearsstring.Add(items);
            }
            List<int> caryearsint = new List<int>();
            caryearsint = caryearsstring.Select(int.Parse).ToList();
            List<int> distinctcaryears = new List<int>();
            distinctcaryears = caryearsint.Distinct().ToList();
            distinctcaryears.Sort();
            nc.caryear = new List<SelectListItem>();
            nc.caryear.Add(new SelectListItem() { Text = "None", Value = "none" });
            foreach (var item in distinctcaryears)
            {
                SelectListItem si = new SelectListItem()
                {
                    Value = item.ToString(),
                    Text = item.ToString()
                };
                nc.caryear.Add(si);
            }
            //for makes filter:-
            List<CarMake> carmake = new List<CarMake>();
            carmake = DBList.CovertDataTableToList<CarMake>(dt);

            List<string> carmakesstring = new List<string>();
            foreach (var item in carmake)
            {
                string items;
                items = item.Make.ToString();
                carmakesstring.Add(items);
            }
            List<string> distinctcarmakes = new List<string>();
            distinctcarmakes = carmakesstring.Distinct().ToList();
            distinctcarmakes.Sort();

            nc.carmake = new List<SelectListItem>();
            nc.carmake.Add(new SelectListItem() { Text = "None", Value = "none" });
            foreach (var item in distinctcarmakes)
            {
                SelectListItem si = new SelectListItem()
                {
                    Value = item,
                    Text = item
                };
                nc.carmake.Add(si);
            }

            return View(nc);
        }



        public ActionResult PhotoView(string CarId)
        {
            IRepository rep = new Repository();
            PhotoView pv = new PhotoView();
            pv.carsdata = rep.getCarFullData(CarId);

            return View(pv);
        }

        [HttpPost]
        public ActionResult PhotoView(string FirstName, string LastName, string Email, string Phone, bool ContactByPhone, bool ContactByEmail, string CarId)
        {
            IRepository rep = new Repository();
            int dataentered;
            string Date = DateTime.Now.ToString();
            dataentered = rep.enterCustomerdata(FirstName, LastName, Email, Phone, ContactByPhone, ContactByEmail, CarId, Date);
            if(dataentered != 0)
            {
                TempData["Success"] = "Data submited Successfully!";
                return RedirectToAction("PhotoView", new { CarId = CarId });
            }
                
            else
                return RedirectToAction("NewCarInventory");
        }
        
        public ActionResult ServiceAppointment()
        {
            ServiceApointment sa = new ServiceApointment();
            IRepository rep = new Repository();
            sa.locations = rep.showLocations();
            
            //for car years:-
            int[] years = new int[38];
            int start = 1980;
            for(int i = 0; i <= 37; i ++)
            {
                years[i] = start;
                start++;
            }
            List<int> yearslist = years.ToList<int>();
            sa.caryear = new List<SelectListItem>();
            foreach(int year in yearslist)
            {
                SelectListItem si = new SelectListItem
                {
                    Value = year.ToString(),
                    Text = year.ToString()
                };
                sa.caryear.Add(si);
            }
            
            return View(sa);
        }

        [HttpPost]
        public ActionResult ServiceAppointment(ServiceApointment sa, string date)
        {
            IRepository rep = new Repository();
            int saveform = 0;
            saveform = rep.serviceAppointment(sa, date);
            if (saveform != 0)
            {
                TempData["Success"] = "Appointment Booked successfully.";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["Success"] = "Appointment not sucessfull. Please try again later.!";
                return RedirectToAction("Index", "Home");
            }
            
        }

        

        public ActionResult About()
        {
            ViewBag.Message = "Welcome to JB-Dealers";

            return View();
        }

        public ActionResult Contact()
        {
            IRepository rep = new Repository();
            Locations lc = new Locations();
            lc.locationsdata = rep.showLocations();
            
            return View(lc);
        }

    }
}