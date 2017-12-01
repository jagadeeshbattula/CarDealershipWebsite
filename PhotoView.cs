using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealer.Models
{
    public class PhotoView
    {
        public IList<CarsData> carsdata { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone is required.")]
        public int Phone { get; set; }
        public bool ContactByPhone { get; set; }
        public bool ContactByEmail { get; set; }


    }
}