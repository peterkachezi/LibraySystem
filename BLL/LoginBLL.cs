using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public  class LoginBLL
    {
        [Display(Name="Email ID")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        public string EmailID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Display(Name = "Email ID")]
        public bool RememberMe { get; set; }

    }
}
