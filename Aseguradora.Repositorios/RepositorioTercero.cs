using Aseguradora.Aplicacion;

namespace Aseguradora.Repositorios
{
    public class RepositorioTercero : IRepositorioTercero
    {
        public void AgregarTercero(Tercero tercero)
        {
            using (var db = new AseguradoraContext())
            {
                db.Database.EnsureCreated();
            }
            using (var db = new AseguradoraContext())
            {
                try
                {
                    db.Terceros.Add(tercero);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrió un error: " + ex.Message);
                }
            }
        }

        public List<Tercero> ListarTercero()
        {
            using (var db = new AseguradoraContext())
            {
                db.Database.EnsureCreated();
            }
            using (var db = new AseguradoraContext())
            {
                var terceros = db.Terceros.ToList();
                return terceros;
            }
        }

        public void EliminarTercero(int id)
        {
            using (var db = new AseguradoraContext())
            {
                db.Database.EnsureCreated();
            }
            using (var db = new AseguradoraContext())
            {
                var tercero = db.Terceros.Find(id);

                if (tercero == null)
                {
                    throw new Exception($"No se ha encontrado el titular con id {id} a eliminar");
                }

                db.Remove(tercero);
                db.SaveChanges();
            }
        }

        public void ModificarTercero(Tercero tercero)
        {
            using (var db = new AseguradoraContext())
            {
                db.Database.EnsureCreated();
            }
            using (var db = new AseguradoraContext())
            {
                var tercerodb = db.Terceros.Find(tercero.Id);
                if (tercerodb != null)
                {
                    // Debería ser una propiedad en la clase "Tercero"
                    tercerodb.Id = tercero.Id;
                    tercerodb.DNI = tercero.DNI;
                    tercerodb.Nombre = tercero.Nombre;
                    tercerodb.Telefono = tercero.Telefono;
                    tercerodb.NombreAseguradora = tercero.NombreAseguradora;
                    tercerodb.SiniestroId = tercero.SiniestroId;
                    tercerodb.Siniestro = tercero.Siniestro;
                }
                db.SaveChanges();
            }
        }
    }
}
