using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryGBH.WEB.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required, MaxLength(256)]
        public string nombre { get; set; }

        [Required, MaxLength(256)]
        public string apellidos { get; set; }

        [Required, DataType(DataType.Password)]
        public string password { get; set; }

        [DataType(DataType.Password), Compare(nameof(password))]
        public string confirmpassword { get; set; }

        [Required, DataType(DataType.Password)]
        public string email { get; set; }

        [DataType(DataType.Password), Compare(nameof(email))]
        public string emailconfirmacion { get; set; }
    }
}
