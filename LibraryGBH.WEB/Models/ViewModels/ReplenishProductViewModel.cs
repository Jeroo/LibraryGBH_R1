using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryGBH.WEB.Models.ViewModels
{
    public class ReplenishProductViewModel
    {
        public long Quantity { get; set; }
        public string ProductCode { get; set; }
    }
}
