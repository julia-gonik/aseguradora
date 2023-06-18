using Microsoft.EntityFrameworkCore;
using Aseguradora.Aplicacion;
namespace Aseguradora.Repositorios;


public class RepositorioPoliza : IRepositorioPoliza
{
    public void AgregarPoliza(Poliza poliza)
    {
        using (var db = new AseguradoraContext())
        {
            db.Database.EnsureCreated();
        }
        using (var db = new AseguradoraContext())
        {
            try
            {
                db.Polizas.Add(poliza);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error: " + ex.Message);
            }
        }
    }


    public List<Poliza> ListarPolizas()
    {
        using (var db = new AseguradoraContext())
        {
            db.Database.EnsureCreated();
        }
        using (var db = new AseguradoraContext())
        {
            var polizas = db.Polizas.Include(p => p.Vehiculo).ToList();
            return polizas;
        }
    }

    public void EliminarPoliza(int id)
    {
        using (var db = new AseguradoraContext())
        {
            db.Database.EnsureCreated();
        }
        using (var db = new AseguradoraContext())
        {
            var poliza = db.Polizas.Find(id);

            if (poliza == null)
            {
                throw new Exception($"No se ha encontrado la poloza con id {id} a eliminar");
            }

            db.Remove(poliza);
            db.SaveChanges();
        }
    }

    public void ModificarPoliza(Poliza poliza)
    {
        using (var db = new AseguradoraContext())
        {
            db.Database.EnsureCreated();
        }
        using (var db = new AseguradoraContext())
        {
            var polizadb = db.Polizas.Find(poliza.Id);
            if (polizadb != null)
            {
                polizadb.Id = poliza.Id;
                polizadb.VehiculoId = poliza.VehiculoId;
                polizadb.ValorAsegurado = poliza.ValorAsegurado;
                polizadb.Franquicia = poliza.Franquicia;
                polizadb.TipoCobertura = poliza.TipoCobertura;
                polizadb.FechaInicioVigencia = poliza.FechaInicioVigencia;
                polizadb.FechaFinVigencia = poliza.FechaFinVigencia;
            }
            db.SaveChanges();
        }

    }
    public Poliza? ObtenerPoliza(int id)
    {
        using (var db = new AseguradoraContext())
        {
            return db.Polizas.Find(id);
        }
    }
}
