using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingProjectA.Models
{
    public class Registration
    {

        [Display(Name = "First Name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "*First Name must be between 3 and 50 character in length.")]
        [Required(ErrorMessage = "*First Name is Required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "*Last Name must be between 3 and 50 character in length.")]
        [Required(ErrorMessage = "*Last Name is Required")]
        public string LastName { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "*Date Of Birth Required")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "*Please choose the Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "*Please provide your contact number")]
        [Display(Name = "Contact Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string ContactNumber { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Required(ErrorMessage = "*Please provide your email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*Please choose which category you are")]
        public string Category { get; set; }

        
        [Required(ErrorMessage = "*Please enter your id here!")]
        [Display(Name = "User Id")]
        [Key]
        public string UserId { get; set; }

        [Required(ErrorMessage = "*Please enter the password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [Required(ErrorMessage = "Password didn't matched")]
        [Display(Name = "Confirm password")]
        [DataType(DataType.Password)]
        public string RePassword { get; set; }

        [Display(Name = "Where is your birth city?")]
        [Required(ErrorMessage ="This field is required!")]
        public string BirthCity { get; set; }

        [Display(Name = "Who is your best friend?")]
        [Required(ErrorMessage = "This field is required!")]
        public string BestFriendName { get; set; }

        [Display(Name = "What is your strength?")]
        [Required(ErrorMessage = "This field is required!")]
        public string Strength { get; set; }

        [Display(Name = "Error Message: ")]
        public string ErrorMesssage { get; set; }
    }
}