using Core.Common.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace LibraryGBH.Business.Entities
{
    [DataContract]
    [Table("CODE_BooksTypes")]
    public class BooksTypes : IIdentifiableEntity, IAuditableEntity, IDeferrableEntity, IConcurrencyEntity
    {
        #region Properties 

        [DataMember]
        [Key]
        [Column("BookTypeId")]
        public long Id { get; set; }

        [DataMember]
        [Column("Name")]
        public string Name { get; set; }

        [DataMember]
        [Column("Description")]
        public string Description { get; set; }

        #endregion

        #region Foreign Keys

        #endregion

        #region Navigations

        [DataMember]
        public List<Books> Books { get; set; }


        #endregion

        #region Interface Implentations

        [DataMember]
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }

        [DataMember]
        [Required]
        public Guid CreatedById { get; set; }

        [DataMember]
        [Column(TypeName = "datetime2")]
        public DateTime UpdatedDate { get; set; }

        [DataMember]
        public Guid UpdatedById { get; set; }

        [DataMember]
        [Required]
        [Column("DeleteFlag")]
        public bool Deferred { get; set; }

        [Timestamp]
        [Required]
        public byte[] RowVersion { get; set; }

        [IgnoreDataMember]
        [NotMapped]
        public long EntityId
        {
            get { return Id; }
            set { Id = value; }
        }

        #endregion
    }
}
