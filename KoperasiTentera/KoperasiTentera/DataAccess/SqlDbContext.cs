using KoperasiTentera.DataAccess.DTOs;
using Microsoft.EntityFrameworkCore;

namespace KoperasiTentera.DataAccess
{
    public class SqlDbContext: DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options) { }

        public DbSet<CustomerDto> Customers { get; set; }
        public DbSet<UserDto> Users { get; set; }
        public DbSet<OtpRequestDto> OtpRequests { get; set; }
        public DbSet<UserBiometricDto> UserBiometrics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CustomerDto>(entity =>
            {
                entity.HasOne(e => e.User)
                .WithOne(e => e.Customer)
                .HasForeignKey<UserDto>(e => e.CustomerId);
            });
        }
    }
}
