using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingProjectA.Models
{
    public class ReviewT
    {
        public int Id { get; set; }
        

        [Required(ErrorMessage = "Required UserId!")]
        [Display(Name = "User Id")]
        public string UserId { get; set; }

        [Required(ErrorMessage ="*Please rate the field")]
        [Display(Name ="How would you describe your overall satisfaction?")]
        public string Answer1 { get; set; }

        [Required(ErrorMessage = "*Please rate the field")]
        [Display(Name = "How would you rate the service?")]
        public string Answer2 { get; set; }

        [Required(ErrorMessage = "*Please rate the field")]
        [Display(Name = "How would you rate your willingness to recommend this site?")]
        public string Answer3 { get; set; }

        [Required(ErrorMessage = "*Please enter the feedback, If not enter 'NA'.")]
        [Display(Name = "Additional Feedback:")]
        public string Answer4 { get; set; }

        public string Status { get; set; }
    }
}