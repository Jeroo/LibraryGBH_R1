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
    [Table("Inventario")]
    public class Inventario : IIdentifiableEntity, IAuditableEntity, IDeferrableEntity, IConcurrencyEntity
    {
        #region Properties 

        [DataMember]
        [Key]
        [Column("InventarioId")]
        public long Id { get; set; }

        [DataMember]
        [Column("CantidadEnStock")]
        public decimal CantidadEnStock { get; set; }

        [DataMember]
        [Column("FechaReposicion")]
        public DateTime FechaReposicion { get; set; }

        [DataMember]
        [Column("UsuarioReposicion")]
        public Guid? UsuarioReposicion { get; set; }

        #endregion

        #region Foreign Keys

        //[DataMember]
        //[ForeignKey("ProductoId")]
        //public long? ProductoId { get; set; }

        #endregion

        #region Navigations

        //[DataMember]
        //public virtual ProductosTienda ProductosTienda { get; set; }

        [DataMember]
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
