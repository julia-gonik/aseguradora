using Microsoft.EntityFrameworkCore;
using Aseguradora.Aplicacion;

namespace Aseguradora.Repositorios
{
    public class RepositorioTitularTXT : IRepositorioTitular
    {
        readonly string _nombreArch = "titulares.txt";
        
        public void AgregarTitular(Titular titular)
        {
            using (var db = new AseguradoraContext())
            {
                db.Database.EnsureCreated();
            }
            using (var db = new AseguradoraContext())
            {
                try
                {
                    db.Titulares.Add(titular);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrió un error: " + ex.Message);
                }
            }
        }
        
        public List<Titular> ListarTitulares()
        {
            using (var db = new AseguradoraContext())
            {
                db.Database.EnsureCreated();
            }
            using (var db = new AseguradoraContext())
            {
                var titulares = db.Titulares.ToList();
                return titulares;
            }
        }
        
        public void ModificarTitular(Titular titular)
        {
            using (var db = new AseguradoraContext())
            {
                db.Database.EnsureCreated();
            }
            using (var db = new AseguradoraContext())
            {
                var titulardb = db.Titulares.Find(titular.Id);
                if (titulardb != null)
                {
                    // Debería ser una propiedad en la clase "Titular"
                    titulardb.Id = titular.Id;
                    titulardb.DNI = titular.DNI;
                    titulardb.Nombre = titular.Nombre;
                    titulardb.Telefono = titular.Telefono;
					titulardb.CorreoElectronico = titular.CorreoElectronico;
                    titulardb.Direccion = titular.Direccion;
                }
                db.SaveChanges();
            }
        }
        
        public void EliminarTitular(int id)
        {
            using (var db = new AseguradoraContext())
            {
                db.Database.EnsureCreated();
            }
            using (var db = new AseguradoraContext())
            {
                var titular = db.Titulares.Find(id);
                
                if (titular == null)
                {
                    throw new Exception($"No se ha encontrado el titular con id {id} a eliminar");
                }
                
                db.Remove(titular);
                db.SaveChanges();
            }
        }
        
        public Titular ObtenerVehiculosDeTitular(Titular titular, Func<int, List<Vehiculo>> listaVehiculos)
        {
            titular.Vehiculos = listaVehiculos(titular.Id);
            return titular;
        }
    }
}