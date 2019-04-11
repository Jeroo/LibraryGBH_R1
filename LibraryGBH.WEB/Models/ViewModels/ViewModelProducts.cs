using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using LibraryGBH.Business.Entities.DTOs;

namespace LibraryGBH.WEB.Models.ViewModels
{
    [DataContract]
    public class ViewModelProducts
    {
        [DataMember]
        public string ProductCode { get; set; }

        [DataMember]
        public double Price { get; set; }

        [DataMember]
        public string ProductId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public byte[] Img { get; set; }

        [DataMember]
        public decimal Quantity { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public Guid? user { get; set; }
    }
}
