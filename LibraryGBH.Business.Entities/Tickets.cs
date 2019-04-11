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
    [Table("Tickets")]
    public class Tickets : IIdentifiableEntity, IAuditableEntity, IDeferrableEntity, IConcurrencyEntity
    {
        #region Properties 

        [DataMember]
        [Key]
        [Column("TicketId")]
        public long Id { get; set; }

        [DataMember]
        [Column("CompraDate")]
        public DateTime CompraDate { get; set; }

        [DataMember]
        [Column("PaypalReference")]
        public string PaypalReference { get; set; }

        #endregion

        #region Foreign Keys

        //[DataMember]
        //[ForeignKey("OtherSample")]
        //public long? OtherSampleId { get; set; }

        #endregion

        #region Navigations

        //[DataMember]
        //public virtual OtherSample ElucidateType { get; set; }

        public List<Individuos> Individuos { get; set; }

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
