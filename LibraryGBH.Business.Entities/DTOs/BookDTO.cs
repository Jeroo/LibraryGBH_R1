using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace LibraryGBH.Business.Entities.DTOs
{
    [DataContract]
    public class BookDTO
    {

        [DataMember]
        public long BookId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }        

        [DataMember]
        public string Author { get; set; }

        [DataMember]
        public byte[] CoverPageImg { get; set; }

        [DataMember]
        public int TotalPages { get; set; }

        [DataMember]
        public long BooksTypesId  { get; set; }

        [DataMember]
        public List<Pages> pages { get; set; }

    }
}
