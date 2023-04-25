using Aseguradora.Aplicacion;
namespace Aseguradora.Repositorios;

public class RepositorioTitularTXT : IRepositorioTitular
{
	readonly string _nombreArch = "titulares.txt";
	// Titular: Id, DNI, apellido, nombre, dirección, teléfono y correo electrónico.
	public void AgregarTitular(Titular titular)
	{
		try
		{
			 if (ListarTitulares().Any(t => t.DNI == titular.DNI))
			{
				throw new Exception($"Titular con DNI {titular.DNI} ya existe");
			}

			int ultimoId = 0;

			if (File.Exists(_nombreArch))
			{
				using var sr = new StreamReader(_nombreArch);
				while (!sr.EndOfStream)
				{
					// Leer el Id del titular
					int titularId = int.Parse(sr.ReadLine() ?? "");
					// Leer el nombre del titular y descartarlo
					sr.ReadLine(); // nombre
					sr.ReadLine(); // telefono
					string titularDNI = sr.ReadLine() ?? "";
					sr.ReadLine();
					sr.ReadLine();
					// Almacenar el Id del titular leído
					ultimoId = titularId;
				}
			}

			titular.Id = ultimoId+1;
			using var sw = new StreamWriter(_nombreArch, true);
			sw.WriteLine(titular.Id);
			sw.WriteLine(titular.Nombre);
			sw.WriteLine(titular.Telefono);
			sw.WriteLine(titular.DNI);
			sw.WriteLine(titular.CorreoElectronico);
			sw.WriteLine(titular.Direccion);
		}
		catch (Exception ex)
		{
			Console.WriteLine("Ocurrió un error: " + ex.Message);
		}
	}
	public List<Titular> ListarTitulares()
	{
		var resultado = new List<Titular>();
		using var sr = new StreamReader(_nombreArch);
		while (!sr.EndOfStream)
		{
			var titular = new Titular();
			titular.Id = int.Parse(sr.ReadLine() ?? "");
			titular.Nombre = sr.ReadLine() ?? "";
			titular.Telefono = sr.ReadLine() ?? "";
			titular.DNI = sr.ReadLine() ?? "";
			titular.CorreoElectronico = sr.ReadLine() ?? "";
			titular.Direccion = sr.ReadLine() ?? "";
			
			resultado.Add(titular);
		}
		return resultado;
	}

	public void ModificarTitular(Titular titular)
	{
		string archivoTemporal = "titulares_temp.txt";

		// Crear un archivo temporal para almacenar los titulares modificados
		using var sw = new StreamWriter(archivoTemporal);

		// Abrir el archivo original para leer los titulares
		using var sr = new StreamReader(_nombreArch);
		while (!sr.EndOfStream)
		{
			// Leer el Id y el nombre del titular
			int Id = int.Parse(sr.ReadLine() ?? "");
			string Nombre = sr.ReadLine() ?? "";
			string Telefono = sr.ReadLine() ?? "";
			string DNI = sr.ReadLine() ?? "";
			string CorreoElectronico = sr.ReadLine() ?? "";
			string Direccion = sr.ReadLine() ?? "";

			if (Id == titular.Id)
			{
				// Escribir el nuevo titular en lugar del titular original
				sw.WriteLine(titular.Id);
				sw.WriteLine(titular.Nombre);
				sw.WriteLine(titular.Telefono);
				sw.WriteLine(titular.DNI);
				sw.WriteLine(titular.CorreoElectronico);
				sw.WriteLine(titular.Direccion);
			}
			else
			{
				// Escribir el titular original en el archivo temporal
				sw.WriteLine(titular.Id);
				sw.WriteLine(titular.Nombre);
				sw.WriteLine(titular.Telefono);
				sw.WriteLine(titular.DNI);
				sw.WriteLine(titular.CorreoElectronico);
				sw.WriteLine(titular.Direccion);
			}
		}

		// Eliminar el archivo original y renombrar el archivo temporal con el nombre del archivo original
		File.Delete(_nombreArch);
		File.Move(archivoTemporal, _nombreArch);
	}

	public void EliminarTitular(int id)
	{
		try
		{
			string archivoTemporal = "titulares_temp.txt";
			using var sr = new StreamReader(_nombreArch);
			using var sw = new StreamWriter(archivoTemporal); //hay uno para cosas temp pero ningans de usar
			
			while (!sr.EndOfStream)
			{
				// Leer el Id y el nombre del producto
				int Id = int.Parse(sr.ReadLine() ?? "");
				string Nombre = sr.ReadLine() ?? "";
				string Telefono = sr.ReadLine() ?? "";
				string DNI = sr.ReadLine() ?? "";
				string CorreoElectronico = sr.ReadLine() ?? "";
				string Direccion = sr.ReadLine() ?? "";

				if (Id != id)
				{
					// Escribir el titular en el archivo temporal si su Id no coincide con el Id del titular que se va a eliminar
					sw.WriteLine(Id);
					sw.WriteLine(Nombre);
					sw.WriteLine(Telefono);
					sw.WriteLine(DNI);
					sw.WriteLine(CorreoElectronico);
					sw.WriteLine(Direccion);
				}
			}

			File.Delete(_nombreArch);
			File.Move(archivoTemporal, _nombreArch);
		}
		catch (Exception ex)
		{
			Console.WriteLine("Ocurrió un error: " + ex.Message);
		}
	}
}