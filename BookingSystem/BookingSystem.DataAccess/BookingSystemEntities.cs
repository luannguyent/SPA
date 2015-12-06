using System;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BookingSystem.Core.Helper;
using BookingSystem.Core.Infrastructure;
using BookingSystem.DataAccess.Contracts;
using BookingSystem.DataAccess.UserManager;
using BookingSystem.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using Type = BookingSystem.Entities.Type;

namespace BookingSystem.DataAccess
{
    public class ApplicationUser : IdentityUser
    {
    }
    public class BookingSystemEntities : IdentityDbContext<ApplicationUser>,IDataContext
    {
        public BookingSystemEntities()
            : base("BookingSys")
        {
            
        }
        public override int SaveChanges()
        {
            var username = HttpContext.Current.User.Identity.Name;
            var modifiedEntries = ChangeTracker.Entries()
             .Where(x => x.Entity is IAuditableEntity
                 && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in modifiedEntries)
            {
                var entity = entry.Entity as IAuditableEntity;
                if (entity != null)
                {
                    DateTime now = DateTime.UtcNow;

                    if (entry.State == EntityState.Added)
                    {
                        entity.CreateBy = username;
                        entity.UpdateBy = username;
                        entity.UpdateAt = now;
                        entity.CreateAt = now;
                    }
                    else
                    {
                        Entry(entity).Property(x => x.UpdateBy).IsModified = false;
                        Entry(entity).Property(x => x.UpdateAt).IsModified = false;
                    }

                    entity.UpdateBy = username;
                    entity.UpdateAt = now;
                }
            }
            return base.SaveChanges();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var reservationTable = modelBuilder.Entity<Reservation>().ToTable("Reservation");
            reservationTable.HasKey(c=>c.Id);
            reservationTable.Property(c => c.CreateBy).HasMaxLength(50);
            reservationTable.Property(c => c.UpdateBy).HasMaxLength(50);

            var propertyTable = modelBuilder.Entity<Property>().ToTable("Property");
            propertyTable.HasKey(c => c.Id);
            propertyTable.Property(c => c.UpdateBy).HasMaxLength(50);
            propertyTable.Property(c => c.CreateBy).HasMaxLength(50);

            var typeTable = modelBuilder.Entity<Type>().ToTable("Type").HasKey(c => c.Id);
            typeTable.HasKey(c => c.Id);
            typeTable.Property(c => c.UpdateBy).HasMaxLength(50);
            typeTable.Property(c => c.CreateBy).HasMaxLength(50);
        }

        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Property> Properties { get; set; }
        public void SyncObjectState<TEntity>(TEntity entity) where TEntity : class, IObjectState
        {
            Entry(entity).State = StateHelper.ConvertState(entity.ObjectState);
        }

        public void SyncObjectsStatePostCommit()
        {
            foreach (var dbEntityEntry in ChangeTracker.Entries())
            {
                ((IObjectState)dbEntityEntry.Entity).ObjectState = StateHelper.ConvertState(dbEntityEntry.State);
            }
        }
    }
}
