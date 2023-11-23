using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data;

public partial class DbAppContext : DbContext
{
    public IQueryable<PhaseVerbalTense> PhaseVerbalTenses;
    public IQueryable<Wordtype> WordTypes;

    public DbAppContext()
    {
    }

    public DbAppContext(DbContextOptions<DbAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Phase> Phases { get; set; }

    public virtual DbSet<Phasestructure> Phasestructures { get; set; }

    public virtual DbSet<Phasetype> Phasetypes { get; set; }

    public virtual DbSet<Phaseverbaltense> Phaseverbaltenses { get; set; }

    public virtual DbSet<Verbaltense> Verbaltenses { get; set; }

    public virtual DbSet<Word> Words { get; set; }

    public virtual DbSet<Wordtype> Wordtypes { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        var roles = new[]
        {
            new Role { Id = 1, Description = "Administrador" },
            new Role { Id = 2, Description = "Empleado" },
            // Agrega otros roles según tus necesidades
        };

        modelBuilder.Entity<Role>().HasData(roles);
        OnModelCreatingPartial(modelBuilder);
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
