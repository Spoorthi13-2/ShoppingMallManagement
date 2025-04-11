using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingProjectA.Models
{
    public class PwReset
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter password.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please re-enter password.")]
        [Compare("Password")]
        public string RePassword { get; set; }

        public string Message { get; set; }
    }
}