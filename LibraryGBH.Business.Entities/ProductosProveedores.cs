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
    [Table("ProductosProveedores")]
    public class ProductosProveedores : IIdentifiableEntity, IAuditableEntity, IDeferrableEntity, IConcurrencyEntity
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

        

        [DataMember]
        [Column("Nombre")]
        public string Nombre { get; set; }

        [DataMember]
        [Column("Cantidad")]
        public string Cantidad { get; set; }


        [DataMember]
        [Column("FechaEntrada")]
        public string FechaEntrada { get; set; }
        #endregion

        #region Foreign Keys   

        [DataMember]
        [ForeignKey("Proveedores")]
        public long ProveedorId { get; set; }

        #endregion

        #region Navigations

        [DataMember]
        public virtual Proveedores Proveedores { get; set; }


        #endregion

        #region Navigations



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
