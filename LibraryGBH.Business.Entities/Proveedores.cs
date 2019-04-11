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
    [Table("Proveedores")]
    public class Proveedores : IIdentifiableEntity, IAuditableEntity, IDeferrableEntity, IConcurrencyEntity
    {
        #region Properties 

        [DataMember]
        [Key]
        [Column("ProveedorId")]
        public long Id { get; set; }

        [DataMember]
        [Column("Nombre")]
        public string Nombre { get; set; }

        [DataMember]
        [Column("CIF")]
        public string CIF { get; set; }

        [DataMember]
        [Column("Direccion")]
        public string Direccion { get; set; }

        [DataMember]
        [Column("Telefono")]
        public string Telefono { get; set; }

        #endregion

        #region Foreign Keys
        
        #endregion

        #region Navigations

        [DataMember]
        public List<ProductosProveedores> ProductosProveedores { get; set; }

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
