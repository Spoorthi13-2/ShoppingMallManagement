using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingProjectA.Models
{
    public class Help
    {
        [Display(Name ="Request Id")]
        [Key]
        public int RequestId { get; set; }

        [Display(Name ="User Id")]
        public string UserId { get; set; }

        [Required(ErrorMessage ="*Please select the issue")]
        public string Issue { get; set; }

        [Required(ErrorMessage ="*Please enter description")]
        public string Description { get; set; }

        
        [Display(Name = "Date Of Ticket")]
        public string DateOfTicket { get; set; }

        public string Status { get; set; }

        public string Solution { get; set; }


    }
}