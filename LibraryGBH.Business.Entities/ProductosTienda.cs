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
    [Table("ProductosTienda")]
    public class ProductosTienda : IIdentifiableEntity, IAuditableEntity, IDeferrableEntity, IConcurrencyEntity
    {
        #region Properties 

        [DataMember]
        [Key]
        [Column("ProductoId")]
        public long Id { get; set; }


        [DataMember]
        [Column("CodigoProducto")]
        public string CodigoProducto { get; set; }

        [DataMember]
        [Column("Precio")]
        public double Precio { get; set; }

        #endregion

        #region Foreign Keys

        [DataMember]
        [ForeignKey("OrdenId")]
        public long? OrdenId { get; set; }

        [DataMember]
        [ForeignKey("InventarioId")]
        public long? InventarioId { get; set; }


        #endregion

        #region Navigations


        [DataMember]
        public virtual Ordenes Ordenes { get; set; }

        [DataMember]
        public virtual Inventario Inventario { get; set; }

        // [DataMember]
        //public virtual Inventario Inventario { get; set; }

        [DataMember]
        public List<ProductosPool> ProductosPool { get; set; }

        [DataMember]
        public List<Ventas> Ventas { get; set; }


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
