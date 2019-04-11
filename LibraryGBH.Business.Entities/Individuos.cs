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
    [Table("Individuos")]
    public class Individuos : IIdentifiableEntity, IAuditableEntity, IDeferrableEntity, IConcurrencyEntity
    {
        #region Properties 

        [DataMember]
        [Key]
        [Column("IndividuoId")]
        public long Id { get; set; }

        [DataMember]
        [Column("Nombre")]
        public string Nombre { get; set; }

        [DataMember]
        [Column("Apellidos")]
        public string Apellidos { get; set; }

        [DataMember]
        [Column("UserId")]
        public Guid? UserId { get; set; }

        #endregion

        #region Foreign Keys

        [DataMember]
        [ForeignKey("TicketId")]
        public long? TicketId { get; set; }

        #endregion

        #region Navigations

        [DataMember]
        public virtual Tickets Tickets { get; set; }

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
