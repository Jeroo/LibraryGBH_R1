using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace LibraryGBH.WEB.Models.ViewModels
{
    [DataContract]
    public class AddEditProductViewModel
    {
        [DataMember]
        public string ProductCode { get; set; }

        [DataMember]
        public double Price { get; set; }

        [DataMember]
        public long? ProductId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public List<IFormFile> Img { get; set; }

        [DataMember]
        public decimal Quantity { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public Guid? user { get; set; }
    }
}
