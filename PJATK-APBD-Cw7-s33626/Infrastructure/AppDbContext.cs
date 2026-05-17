using Microsoft.EntityFrameworkCore;
using PJATK_APBD_Cw7_s33626.Models;

namespace PJATK_APBD_Cw7_s33626.Infrastructure;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<PC> PCs { get; set; }
    public DbSet<Component> Components { get; set; }
    public DbSet<ComponentType> ComponentTypes { get; set; }
    public DbSet<ComponentManufacturer> ComponentManufacturers { get; set; }
    public DbSet<PCComponent> PCComponents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ComponentType>().HasData([
            new ComponentType { Id = 1, Abbreviation = "CPU", Name = "Processor" },
            new ComponentType { Id = 2, Abbreviation = "GPU", Name = "Graphics Card" },
            new ComponentType { Id = 3, Abbreviation = "RAM", Name = "Memory" }
        ]);

        modelBuilder.Entity<ComponentManufacturer>().HasData([
            new ComponentManufacturer { Id = 1, Abbreviation = "AMD", FullName = "Advanced Micro Devices", FoundationDate = new DateTime(1969, 5, 1) },
            new ComponentManufacturer { Id = 2, Abbreviation = "NV", FullName = "NVIDIA Corporation", FoundationDate = new DateTime(1993, 4, 5) },
            new ComponentManufacturer { Id = 3, Abbreviation = "COR", FullName = "Corsair Gaming Inc.", FoundationDate = new DateTime(1994, 1, 01) }
        ]);

        modelBuilder.Entity<Component>().HasData([
            new Component { Code = "CPU0000001", Name = "Ryzen 7 7800X3D", Description = "8-core gaming processor", ComponentTypesId = 1, ComponentManufacturersId = 1 },
            new Component { Code = "GPU0000001", Name = "RTX 4080 Super", Description = "High-end gaming graphics card", ComponentTypesId = 2, ComponentManufacturersId = 2 },
            new Component { Code = "RAM0000001", Name = "Corsair Vengeance DDR5 16GB", Description = "DDR5 RAM module 16GB", ComponentTypesId = 3, ComponentManufacturersId = 3 }
        ]);

        modelBuilder.Entity<PC>().HasData([
            new PC { Id = 1, Name = "Gaming Beast X", Weight = 12.5f, Warranty = 36, CreatedAt = new DateTime(2026, 5, 8, 9, 0, 0), Stock = 5 },
            new PC { Id = 2, Name = "Office Mini Pro", Weight = 4.2f, Warranty = 24, CreatedAt = new DateTime(2026, 4, 15, 13, 30, 0), Stock = 12 },
            new PC { Id = 3, Name = "Budget Starter", Weight = 7.1f, Warranty = 12, CreatedAt = new DateTime(2026, 2, 10, 10, 0, 0), Stock = 8 }
        ]);

        modelBuilder.Entity<PCComponent>().HasData([
            new PCComponent { PCid = 1, ComponentCode = "CPU0000001", Amount = 1 },
            new PCComponent { PCid = 1, ComponentCode = "GPU0000001", Amount = 1 },
            new PCComponent { PCid = 1, ComponentCode = "RAM0000001", Amount = 2 }
        ]);
    }
}