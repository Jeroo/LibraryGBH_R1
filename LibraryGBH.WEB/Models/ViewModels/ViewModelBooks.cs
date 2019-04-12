using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using LibraryGBH.Business.Entities;
using LibraryGBH.Business.Entities.DTOs;

namespace LibraryGBH.WEB.Models.ViewModels
{
    [DataContract]
    public class ViewModelBooks
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
        public long BooksTypesId { get; set; }

        [DataMember]
        public List<Pages> pages { get; set; }
    }
}
