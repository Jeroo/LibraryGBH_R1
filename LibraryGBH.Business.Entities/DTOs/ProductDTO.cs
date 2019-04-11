using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace LibraryGBH.Business.Entities.DTOs
{
    [DataContract]
    public class ProductDTO
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
        public byte[] Img { get; set; }

        [DataMember]
        public decimal Quantity { get; set; }
        
        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public Guid? user { get; set; }


    }
}
