using Happy_company.Model.Domain;
using Happy_company.Model.Domain.Lookup;
using Microsoft.EntityFrameworkCore;


namespace Happy_company.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<RequestLog> RequestLogs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure User entity
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Name)
                .IsUnique();
            modelBuilder.Entity<User>()
                .Property(u => u.Active)
                .HasDefaultValue(false);
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.RoleId);

            // Seed initial Role data
            var adminRoleId = Guid.Parse("8f8d1d70-f81d-4e65-9c3d-1b7f1b7e5c1a");
            var managementRoleId = Guid.Parse("d9b1e9d8-7d58-4a6f-9ef5-ccbd7eab16a7");
            var auditorRoleId = Guid.Parse("e4e0b1c4-9624-4e27-8c1b-2d9a9e8e54a0");

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = adminRoleId,
                    Type = "Admin"
                },
                new Role
                {
                    Id = managementRoleId,
                    Type = "Management"
                },
                new Role
                {
                    Id = auditorRoleId,
                    Type = "Auditor"
                }
            );

            // Seed initial User data
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.Parse("3d748d79-cd2d-4d67-9d4e-c0ea6e66e44e"),
                    Name = "admin",
                    Email = "admin@happywarehouse.com",
                    Password = "P@ssw0rd",
                    Active = true,
                    RoleId = adminRoleId
                }
            );

            // Configure Country entity
            modelBuilder.Entity<Country>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = Guid.Parse("f5c3e4b7-6d3b-4c7a-9c79-59c0c73c1d50"),
                    Name = "Palestine",
                    Code = "PS"
                },
                new Country
                {
                    Id = Guid.Parse("f5a3e4b7-6d3b-4a7a-9c79-59a0c73c1d50"),
                    Name = "Jordan",
                    Code = "JO"
                },
                new Country
                {
                    Id = Guid.Parse("5d3b9e2e-7423-4cb7-a3e5-d73a67e39d29"),
                    Name = "Egypt",
                    Code = "EG"
                },
                new Country
                {
                    Id = Guid.Parse("7e3c6f56-963b-4f43-a08c-d6c52c9b37d4"),
                    Name = "Saudi Arabia",
                    Code = "SA"
                },
                new Country
                {
                    Id = Guid.Parse("f2f59b45-885c-4a0b-a76e-5b9146d88f26"),
                    Name = "Syria",
                    Code = "SY"
                }
            );

            // Configure Warehouse entity
            modelBuilder.Entity<Warehouse>()
                .HasKey(w => w.Id);

            modelBuilder.Entity<Warehouse>()
                .HasIndex(w => w.Name)
                .IsUnique();

            modelBuilder.Entity<Warehouse>()
                .HasOne(w => w.Country)
                .WithMany() 
                .HasForeignKey(w => w.CountryID); 

            // Configure Items entity
            modelBuilder.Entity<Items>()
                .HasKey(i => i.Id);
            modelBuilder.Entity<Items>()
                .HasIndex(i => i.Name)
                .IsUnique();
            modelBuilder.Entity<Items>()
                .HasOne<Warehouse>()
                .WithMany()
                .HasForeignKey(i => i.WarehouseId);

            //  Configure log entity
            modelBuilder.Entity<RequestLog>()
            .ToTable("RequestLogs")
            .HasKey(r => r.Id);
        }

    }
}












