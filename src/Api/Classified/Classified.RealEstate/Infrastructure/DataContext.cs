using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Classified.Common.AppSettings;
using Classified.RealEstate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Classified.RealEstate.Infrastructure
{
    public class DataContext : DbContext
    {
        #region overides
        public AppSettings AppSettings { get; set; }
        public DataContext()
        {
        }
            public DataContext(IOptionsSnapshot<AppSettings> options)
        {
            this.AppSettings = options.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MicroShopCatalog;Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var clrType = entity.ClrType;
                if (clrType.IsClass && clrType.BaseType.Name.Contains(nameof(BaseEntity)))
                {
                    var method = SetGlobalQueryMethod.MakeGenericMethod(clrType);
                    method.Invoke(this, new object[] { modelBuilder });

                }
            }
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.DetectChanges();

            foreach (var entry in ChangeTracker.Entries())
            {
                var entity = entry.Entity as BaseEntity;
                if (entity != null)
                {
                    if (entry.State == EntityState.Deleted)
                    {
                        entry.State = EntityState.Modified;
                    }

                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedAt = DateTime.UtcNow;
                    }

                    if (entry.State == EntityState.Modified)
                    {
                        entity.ModifiedAt = DateTime.UtcNow;
                    }
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }


        static readonly MethodInfo SetGlobalQueryMethod = typeof(DataContext).GetMethods(BindingFlags.Public | BindingFlags.Instance)
                                                        .Single(t => t.IsGenericMethod && t.Name == "SetGlobalQuery");

        public void SetGlobalQuery<T>(ModelBuilder builder) where T : BaseEntity
        {

            builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }

        #endregion

        public DbSet<Property> Properties { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Builder> Builders { get; set; }
    }
}
