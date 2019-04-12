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
    [Table("Pages")]
    public class Pages : IIdentifiableEntity, IAuditableEntity, IDeferrableEntity, IConcurrencyEntity
    {
        #region Properties 

        [DataMember]
        [Key]
        [Column("PageId")]
        public long Id { get; set; }

        [DataMember]
        [Column("Name")]
        public string Text { get; set; }

        [DataMember]
        [Column("Description")]
        public string Description { get; set; }

        [DataMember]
        [Column("PageNumber")]
        public long PageNumber { get; set; }

        #endregion

        #region Foreign Keys

        //[DataMember]
        //[Column("BookId")]
        //public long BookId { get; set; }

        #endregion

        #region Navigations

        [DataMember]
        public virtual Books Books { get; set; }


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
