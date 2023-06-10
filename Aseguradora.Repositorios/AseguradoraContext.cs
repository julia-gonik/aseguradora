using Microsoft.EntityFrameworkCore;
using Aseguradora.Aplicacion;

namespace Aseguradora;

public class AseguradoraContext : DbContext
{
	#nullable disable
    public DbSet<Persona> Personas { get; set; }
    public DbSet<Titular> Titulares { get; set; }
    public DbSet<Tercero> Terceros { get; set; }
    public DbSet<Vehiculo> Vehiculos { get; set; }
    public DbSet<Poliza> Polizas { get; set; }
    public DbSet<Siniestro> Siniestros { get; set; }
	#nullable enable

    protected override void OnConfiguring(DbContextOptionsBuilder
    optionsBuilder)
    {
        optionsBuilder.UseSqlite("data source=Aseguradora.sqlite");
    }
}