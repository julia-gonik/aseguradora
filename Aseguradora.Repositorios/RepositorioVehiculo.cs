using Microsoft.EntityFrameworkCore;
using Aseguradora.Aplicacion;
namespace Aseguradora.Repositorios;

public class RepositorioVehiculo : IRepositorioVehiculo
{
    public void AgregarVehiculo(Vehiculo vehiculo)
    {
        using (var db = new AseguradoraContext())
        {
            db.Database.EnsureCreated();
        }
        using (var db = new AseguradoraContext())
        {
            try
            {
                db.Vehiculos.Add(vehiculo);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error: " + ex.Message);
            }
        }
    }


    public void EliminarVehiculo(int id)
    {
        try
        {
            using (var db = new AseguradoraContext())
            {
                db.Database.EnsureCreated();
            }

            using (var db = new AseguradoraContext())
            {
                var vehiculo = db.Vehiculos.Find(id);

                if (vehiculo == null)
                {
                    throw new Exception($"No se ha encontrado el vehiculo con id {id} a eliminar");
                }

                db.Remove(vehiculo);
                db.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocurrió un error: " + ex.Message);
        }
    }


    public List<Vehiculo> ListarVehiculos()
    {

        using (var db = new AseguradoraContext())
        {
            db.Database.EnsureCreated();
        }
        using (var db = new AseguradoraContext())
        {
            var vehiculos = db.Vehiculos.Include(t => t.Titular).ToList();

            return vehiculos;
        }
    }

    public void ModificarVehiculo(Vehiculo vehiculo)
    {

        using (var db = new AseguradoraContext())
        {
            db.Database.EnsureCreated();
        }
        using (var db = new AseguradoraContext())
        {
            var vehiculodb = db.Vehiculos.Find(vehiculo.Id);
            if (vehiculodb != null)
            {
                vehiculodb.Id = vehiculo.Id;
                vehiculodb.TitularId = vehiculo.TitularId;
                vehiculodb.Dominio = vehiculo.Dominio;
                vehiculodb.Marca = vehiculo.Marca;
                vehiculodb.AnioFabricacion = vehiculo.AnioFabricacion;
            }
            db.SaveChanges();
        }
    }

    public Vehiculo? ObtenerVehiculo(int id)
    {
        using (var db = new AseguradoraContext())
        {
            return db.Vehiculos.Find(id);
        }
    }
}