using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingProjectA.Models
{
    public class StoreDetails
    {
        [Required(ErrorMessage ="*Please fill store number")]
        [Display(Name = "Store Number")]
        [Key]
        public string StoreNo { get; set; }

        [Required(ErrorMessage = "*Please fill store size")]
        [Display(Name = "Store Size (eg: 12x12)")]
        public string StoreSize { get; set; }

        [Required(ErrorMessage = "*Please fill store location")]
        [Display(Name = "Store Location (eg: 1st floor)")]
        public string StoreLocation { get; set; }

        [Required(ErrorMessage = "*Please fill store area")]
        [Display(Name = "Area of the store(in sq.feets)")]
        public int Area { get; set; }

        [Required(ErrorMessage = "*Please select the status")]
        [Display(Name = "Occupancy status")]
        public string OccupancyStatus { get; set; }

        [Required(ErrorMessage = "*Please fill store type (rent/lease")]
        [Display(Name ="Type (rent/lease)")]
        public string Type { get; set; }

        [Required(ErrorMessage = "*Please fill the amount")]
        [Display(Name ="Amount (lease/rent per year in rs)")]
        public int Amount { get; set; }

        [Display(Name ="Shop Name")]
        public string ShopName { get; set; }


        [Display(Name ="Business Category")]
        public string BusinessCategory { get; set; }

        [Display(Name ="Agreement Tenure (in years)")]
        public int? AgreementTenure { get; set; }
    }
}