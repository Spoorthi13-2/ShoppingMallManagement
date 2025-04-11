using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingProjectA.Models
{
    public class RequestTable
    {
        [Key]
        public int RequestId { get; set; }

        [Display(Name = "Store Number")]
        [Required(ErrorMessage ="*Please fill the store no.")]
        public string StoreNo { get; set; }

        [Display(Name = "Store Location")]
        [Required(ErrorMessage = "*Please fill the store location")]
        public string StoreLoc { get; set; }

        [Required(ErrorMessage = "*Please select the store type")]
        public string Type { get; set; }

        [Display(Name = "Shop Owner Name")]
        [Required(ErrorMessage = "*Please fill your name")]
        public string ShopOwnerName { get; set; }

        [Display(Name = "Contact Number")]
        [Required(ErrorMessage = "*Please fill your contact no.")]
        public string ContactNumber { get; set; }

        [Display(Name = "Business Category")]
        [Required(ErrorMessage = "*Please select the category")]
        public string BusinessCategory { get; set; }

        [Display(Name = "Agreement Tenure")]
        [Required(ErrorMessage = "*Please fill the tenure in years")]
        public int AgreementTenure { get; set; }

        [Required(ErrorMessage = "*Please fill the Remarks. "+"'NA'"+" if not")]
        [MaxLength(250)]
        public string Remarks { get; set; }

        public string Status { get; set; }

        public string Message { get; set; }
    }
}