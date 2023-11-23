using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data;

public partial class DbAppContext : DbContext
{
    public DbAppContext()
    {
    }

    public DbAppContext(DbContextOptions<DbAppContext> options)
        : base(options)
    {
    }
    //JWT
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
    public virtual DbSet<UserRole> UsersRoles { get; set; }
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
    

        OnModelCreatingPartial(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
