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
    [Table("Ordenes")]
    public class Ordenes : IIdentifiableEntity, IAuditableEntity, IDeferrableEntity, IConcurrencyEntity
    {
        #region Properties 

        [DataMember]
        [Key]
        [Column("OrdenId")]
        public long Id { get; set; }

        [DataMember]
        [Column("OrdenDate")]
        public DateTime OrdenDate { get; set; }

        [DataMember]
        [Column("Total")]
        public int Total { get; set; }

        [DataMember]
        [Column("Impuesto")]
        public int Impuesto { get; set; }

        [DataMember]
        [Column("Subtotal")]
        public int Subtotal { get; set; }

        [DataMember]
        [Column("Envio")]
        public int Envio { get; set; }

        [DataMember]
        [Column("PayPalReference")]
        public string PayPalReference { get; set; }

        #endregion

        #region Foreign Keys

  

        #endregion

        #region Navigations

        //[DataMember]
        //public virtual OtherSample ElucidateType { get; set; }

        public List<ProductosTienda> ProductosTienda { get; set; }

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
