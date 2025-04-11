using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingProjectA.Models
{
    public class ForgotPw
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*Please provide your userid")]
        [Display(Name = "User Id")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "*Please provide your answer")]
        [Display(Name = "Where is your birthcity?")]
        public string BirthCity { get; set; }

        [Required(ErrorMessage = "*Please provide your answer")]
        [Display(Name = "Who is your best friend?")]
        public string BestFriend { get; set; }

        [Required(ErrorMessage = "*Please provide your answer")]
        [Display(Name = "What is your strength?")]
        public string Strength { get; set; }

        public string Message { get; set; }


    }
}