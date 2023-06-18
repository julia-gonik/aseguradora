using Aseguradora.Aplicacion;
namespace Aseguradora.Repositorios;


public class RepositorioSiniestro : IRepositorioSiniestro
{
	readonly string _nombreArch = "siniestros.txt";

	public void AgregarSiniestro(Siniestro siniestro)
	{
		using (var db = new AseguradoraContext())
		{
			db.Database.EnsureCreated();
		}
		using (var db = new AseguradoraContext())
		{
			try
			{
				db.Siniestros.Add(siniestro);
				db.SaveChanges();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Ocurrió un error: " + ex.Message);
			}
		}
	}


	public List<Siniestro> ListarSiniestro()
	{
		using(var db = new AseguradoraContext()){
			db.Database.EnsureCreated();
		}
		using(var db = new AseguradoraContext()){
			var siniestros =  db.Siniestros.ToList();
			return siniestros;
		}
	}


	public void EliminarSiniestro(int id)
	{
		using(var db = new AseguradoraContext()){
			db.Database.EnsureCreated();
		}
		using(var db = new AseguradoraContext()){
			var siniestro = db.Siniestros.Find(id);

			if(siniestro == null){
				throw new Exception($"No se ha encontrado la poloza con id {id} a eliminar");
			}

			db.Remove(siniestro);
			db.SaveChanges();
		}
	}

	public void ModificarSiniestro(Siniestro siniestro)
	{
		using(var db = new AseguradoraContext()){
			db.Database.EnsureCreated();
		}
		using(var db= new AseguradoraContext()){
			var siniestrodb = db.Siniestros.Find(siniestro.Id);
			if(siniestrodb != null){	
				siniestrodb.Id=siniestro.Id;
				siniestrodb.PolizaId=siniestro.PolizaId;
				siniestrodb.Poliza=siniestro.Poliza;
				siniestrodb.FechaIngreso=siniestro.FechaIngreso;
				siniestrodb.FechaOcurrencia=siniestro.FechaOcurrencia;
				siniestrodb.Direccion=siniestro.Direccion;
				siniestrodb.Descripcion=siniestro.Descripcion;
			}
			db.SaveChanges();
		}
	}
}
