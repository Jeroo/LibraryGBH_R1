using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace LibraryGBH.Business.Entities.DTOs
{
    [DataContract]
    public class KeyValueDTO
    {

        [DataMember]
        public long key { get; set; }

        [DataMember]
        public string value { get; set; }



    }
}
