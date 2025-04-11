using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingProjectA.Models
{
    public class Shop
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*Please fill shop name")]
        [Display(Name ="Shop Name")]
        public string ShopName { get; set; }

        [Required(ErrorMessage = "*Please select business category")]
        [Display(Name = "Business Category")]
        public string BusinessCategory { get; set; }

        [Required(ErrorMessage = "*Please fill no.of employees")]
        [Display(Name = "No.Of Employees")]
        public int NoOfEmployees { get; set; }

        [Required(ErrorMessage = "*Please fill working hrs")]
        [Display(Name = "Working hrs (per day)")]
        public int WrkngHrs { get; set; }

        public string Holiday { get; set; }

        [Required(ErrorMessage = "*Please fill license no.")]
        [Display(Name = "License number")]
        public string LicenseNo { get; set; }

        [Required(ErrorMessage = "*Please fill license expiry date")]
        [Display(Name = "License expiry date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime LicenseExp { get; set; }

        [Required(ErrorMessage = "*Please fill shop owner name")]
        [Display(Name = "Shop Owner Name")]
        public string ShopOwnerName { get; set; }

        [Required(ErrorMessage = "*Please fill contact number")]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "*Please fill email")]
        public string Email { get; set; }

        [Display(Name = "User Id")]
        public string UserId { get; set; }

    }
}