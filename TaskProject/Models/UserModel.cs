using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data;

namespace TaskProject.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        [Required(ErrorMessage = "enter full name please")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "enter email please")]
        [DataType(DataType.EmailAddress, ErrorMessage = "enter valid mail address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "enter password please")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "enter confirm password please")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password not match")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "enter Address please")]
        public string Address { get; set; }
        [Required(ErrorMessage = "enter Contact please")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong mobile")]
        public string Contact { get; set; }
        public string Error { get; set; }
        public string Status { get; set; }

        public DataTable List { get; set; }
        public DataTable ListUser { get; set; }

    }
}