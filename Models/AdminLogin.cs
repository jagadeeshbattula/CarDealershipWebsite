using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealer.Models
{
    public class AdminLogin
    {
        [DisplayName("User Name")]
        [Required(ErrorMessage ="User Name is required.")]
        public string  Username { get; set;}


        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Password is required")]
        public string Password { get; set;}


        public string ErrorMessage { get; set; }
    }
}