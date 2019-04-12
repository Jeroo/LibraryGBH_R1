using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Runtime.Serialization;
using Core.Common.Contracts;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using LibraryGBH.Business.Entities;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace LibraryGBH.Data
{
    public class LibraryGBHDataContext : IdentityDbContext
    {
        private readonly IHttpContextAccessor _HttpContextAccessor;

        private bool CanUseSessionContext { get; set; }

        #region Constructors

        public LibraryGBHDataContext()
        {
            CanUseSessionContext = true;
        }

        public LibraryGBHDataContext(DbContextOptions<LibraryGBHDataContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _HttpContextAccessor = httpContextAccessor;

            CanUseSessionContext = true;

           // this.Database.
        }

        #endregion

        #region Tables
        //public virtual DbSet<Sample> Sample { get; set; }

        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<BooksFormat> BooksFormat { get; set; }
        public virtual DbSet<Pages> Pages { get; set; }
        public virtual DbSet<Individuos> Individuos { get; set; }
        public virtual DbSet<BooksPages> BooksPages { get; set; }
        public virtual DbSet<BooksTypes> BooksTypes { get; set; }
        public virtual DbSet<Tickets> Tickets { get; set; }

        #endregion

        #region Fluent API

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Users>().ToTable("Users");

            modelBuilder.Entity<IdentityRole<string>>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
        }

        #endregion

        #region Save Changes
        public override int SaveChanges()
        {
            // Get the entries that are auditable
            var auditableEntitySet = ChangeTracker.Entries<IAuditableEntity>();

            if (auditableEntitySet != null)
            {
                //Get the username that is saving the data
               // Guid userId = Guid.Parse(_HttpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                DateTime currentDate = DateTime.Now;

                // Audit set the audit information foreach record
                foreach (var auditableEntity in auditableEntitySet.Where(c => c.State == EntityState.Added || c.State == EntityState.Modified))
                {
                    if (auditableEntity.State == EntityState.Added)
                    {
                        auditableEntity.Entity.CreatedDate = currentDate;
                       // auditableEntity.Entity.CreatedById = userId;
                    }

                    auditableEntity.Entity.UpdatedDate = currentDate;
                    //auditableEntity.Entity.UpdatedById = userId;
                }
            }

            return base.SaveChanges();
        }

        #endregion

        #region Connection String for testing and Migrations

        protected override void OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
        {
            var extConfiguration = optionsBuilder.Options.Extensions.OfType<SqlServerOptionsExtension>().FirstOrDefault();

            if (extConfiguration != null)
                extConfiguration.Connection.StateChange += Connection_StateChange;

            //Connection string for migrations
            //optionsBuilder.UseSqlServer("Server=LAPTOP-1OVSP5MD\\SQLEXPRESS;Database=LibraryGBH_R1;Persist Security Info=False;User ID=adminUser;Password=DB_PASS01@;Trusted_Connection=False;");
        }

        #endregion

        #region Session Context

        private void Connection_StateChange(object sender, System.Data.StateChangeEventArgs e)
        {
            //if (CanUseSessionContext && e.CurrentState == ConnectionState.Open && _HttpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            //{
            //    //Get the username from his claims
            //    Guid userId = Guid.Parse(_HttpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            //    var connection = sender as SqlConnection;

            //    var cmd = connection.CreateCommand();
            //    cmd.CommandText = @"exec sp_set_session_context @key=N'UserId', @value=@UserId";
            //    cmd.Parameters.AddWithValue("@UserId", userId);

            //    try
            //    {
            //        cmd.ExecuteNonQuery();
            //    }
            //    catch //This is because the dev server is working with Sql Server 2014 and we need SQL Server 2016
            //    {
            //        CanUseSessionContext = false;
            //    }
            //}
        }

        #endregion
    }
}
