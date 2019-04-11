using Core.Common.Contracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace LibraryGBH.Business.Entities
{
    [DataContract]
    [Table("Users")]
    public class Users : IIdentifiableEntity, IAuditableEntity, IDeferrableEntity, IConcurrencyEntity //, IdentityUser<>
    {
        #region Properties 

        [DataMember]
        [Key]
        [Column("UserId")]
        public Guid Id { get; set; }

        [DataMember]
        [Column("UserName")]
        public string UserName { get; set; }

        [DataMember]
        [Column("NormalizedUserName")]
        public string NormalizedUserName { get; set; }

        [DataMember]
        [Column("PasswordHash")]
        public string PasswordHash { get; set; }

        #endregion

        #region Foreign Keys


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
        public long EntityId { get; set; }

        #endregion
    }
}
