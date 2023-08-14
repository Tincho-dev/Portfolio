using Microsoft.EntityFrameworkCore;
using Models;

namespace Data;

public class EntropiaContext : DbContext
{
    public EntropiaContext(DbContextOptions<EntropiaContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Fuente>().HasData(
            new Fuente { CadenaFuente = "Esta es una fuente ya en memoria" },
            new Fuente { CadenaFuente = "Este texto representa el libro del quijote de la mancha" }
        );
    }
    public DbSet<Fuente> Fuentes => Set<Fuente>();
}

