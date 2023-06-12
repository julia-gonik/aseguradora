using Microsoft.EntityFrameworkCore;
using Aseguradora.Aplicacion;

namespace Aseguradora.Repositorios;

public class RepositorioTitularTXT : IRepositorioTitular
{
	readonly string _nombreArch = "titulares.txt";
	// Titular: Id, DNI, apellido, nombre, dirección, teléfono y correo electrónico.
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
		try
		{
			string archivoTemporal = "titulares_temp.txt";

			// Crear un archivo temporal para almacenar los titulares modificados
			using var sw = new StreamWriter(archivoTemporal);

			// Abrir el archivo original para leer los titulares
			using var sr = new StreamReader(_nombreArch);

			bool found = false;

			while (!sr.EndOfStream)
			{
				// Leer el Id y el nombre del titular
				int TitularId = int.Parse(sr.ReadLine() ?? "");
				string TitularNombre = sr.ReadLine() ?? "";
				string TitularTelefono = sr.ReadLine() ?? "";
				string TitularDNI = sr.ReadLine() ?? "";
				string TitularCorreoElectronico = sr.ReadLine() ?? "";
				string TitularDireccion = sr.ReadLine() ?? "";
				// Console.WriteLine("aaaaaaaaa {0}", titular);
				if (TitularDNI == titular.DNI)
				{
					// Escribir el nuevo titular en lugar del titular original
					sw.WriteLine(TitularId);
					sw.WriteLine(titular.Nombre);
					sw.WriteLine(titular.Telefono);
					sw.WriteLine(titular.DNI);
					sw.WriteLine(titular.CorreoElectronico);
					sw.WriteLine(titular.Direccion);
					found = true;
				}
				else
				{
					// Escribir el titular original en el archivo temporal
					sw.WriteLine(TitularId);               //sw.WriteLine(TitularId);
					sw.WriteLine(TitularNombre);
					sw.WriteLine(TitularTelefono);
					sw.WriteLine(TitularDNI);
					sw.WriteLine(TitularCorreoElectronico);
					sw.WriteLine(TitularDireccion);
				}
			}

			// Eliminar el archivo original y renombrar el archivo temporal con el nombre del archivo original
			File.Delete(_nombreArch);
			File.Move(archivoTemporal, _nombreArch);

			if (!found)
			{
				throw new Exception($"No se ha encontrado el titular {titular} a modificar");
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("Ocurrió un error: " + ex.Message);
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