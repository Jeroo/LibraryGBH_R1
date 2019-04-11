using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryGBH.WEB.Models.ViewModels
{
    public class LoginViewModel
    {
        public string username { get; set; }

        [DataType(DataType.Password)]
        public string password { get; set; }

        [Display(Name = "Remember Me")]
        public bool rememberMe { get; set; }
        public string returnUrl { get; set; }
    }
}
