using Aseguradora.Aplicacion;
namespace Aseguradora.Repositorios;

public class RepositorioVehiculoTXT : IRepositorioVehiculo
{
	readonly string _nombreArch = "vehiculos.txt";

	public void AgregarVehiculo(Vehiculo vehiculo)
	{
		try
		{
			int ultimoId = 0;

			if (File.Exists(_nombreArch))
			{
				using var sr = new StreamReader(_nombreArch);
				while (!sr.EndOfStream)
				{
					// Leer el Id del vehículo
					int vehiculoId = int.Parse(sr.ReadLine() ?? "");
					// Leer el dominio del vehículo y descartarlo
					sr.ReadLine(); // dominio
					sr.ReadLine(); // marca
					sr.ReadLine(); // año de fabricación
					sr.ReadLine(); // Id del titular
					// Almacenar el Id del vehículo leído
					ultimoId = vehiculoId;
				}
			}

			vehiculo.Id = ultimoId + 1;
			using var sw = new StreamWriter(_nombreArch, true);
			sw.WriteLine(vehiculo.Id);
			sw.WriteLine(vehiculo.Dominio);
			sw.WriteLine(vehiculo.Marca);
			sw.WriteLine(vehiculo.AnioFabricacion);
			sw.WriteLine(vehiculo.IdTitular);
		}
		catch (Exception ex)
		{
			Console.WriteLine("Ocurrió un error: " + ex.Message);
		}
	}


	public void EliminarVehiculo(int id)
	{
		try
		{
			string archivoTemporal = "vehiculos_temp.txt";
			using var sr = new StreamReader(_nombreArch);
			using var sw = new StreamWriter(archivoTemporal);
			bool found = false;

			while (!sr.EndOfStream)
			{
				// Leer el Id y los datos del vehículo
				int vehiculoId = int.Parse(sr.ReadLine() ?? "");
				string dominio = sr.ReadLine() ?? "";
				string marca = sr.ReadLine() ?? "";
				int anioFabricacion = int.Parse(sr.ReadLine() ?? "");
				int idTitular = int.Parse(sr.ReadLine() ?? "");

				if (vehiculoId != id)
				{
					// Escribir el vehículo en el archivo temporal si su Id no coincide con el Id del vehículo que se va a eliminar
					sw.WriteLine(vehiculoId);
					sw.WriteLine(dominio);
					sw.WriteLine(marca);
					sw.WriteLine(anioFabricacion);
					sw.WriteLine(idTitular);
				} 
				else
				{
					found = true;						
				}
			}
			
			File.Delete(_nombreArch);
			File.Move(archivoTemporal, _nombreArch);
			
			if (!found) 
			{
				throw new Exception($"No se ha encontrado el vehiculo con id {id} a eliminar");
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("Ocurrió un error: " + ex.Message);
		}
	}


	public List<Vehiculo> ListarVehiculos()
	{
		var resultado = new List<Vehiculo>();
		using var sr = new StreamReader(_nombreArch);
		while (!sr.EndOfStream)
		{
			var vehiculo = new Vehiculo();
			vehiculo.Id = int.Parse(sr.ReadLine() ?? "");
			vehiculo.Dominio = sr.ReadLine() ?? "";
			vehiculo.Marca = sr.ReadLine() ?? "";
			vehiculo.AnioFabricacion = int.Parse(sr.ReadLine() ?? "");
			vehiculo.IdTitular = int.Parse(sr.ReadLine() ?? "");

			resultado.Add(vehiculo);
		}
		return resultado;
	}

	public List<Vehiculo> ListarVehiculosPorTitular(int idTitular)
	{
		var vehiculosTitular = new List<Vehiculo>();
		using var sr = new StreamReader(_nombreArch);
		while (!sr.EndOfStream)
		{
			var vehiculo = new Vehiculo();
			vehiculo.Id = int.Parse(sr.ReadLine() ?? "");
			vehiculo.Dominio = sr.ReadLine() ?? "";
			vehiculo.Marca = sr.ReadLine() ?? "";
			vehiculo.AnioFabricacion = int.Parse(sr.ReadLine() ?? "");
			vehiculo.IdTitular = int.Parse(sr.ReadLine() ?? "");

			if (vehiculo.IdTitular == idTitular)
			{
				vehiculosTitular.Add(vehiculo);
			}
		}
		return vehiculosTitular;
	}


	public void ModificarVehiculo(Vehiculo vehiculo)
	{
		string archivoTemporal = "vehiculos_temp.txt";

		try {
			// Crear un archivo temporal para almacenar los vehículos modificados
			using var sw = new StreamWriter(archivoTemporal);

			// Abrir el archivo original para leer los vehículos
			using var sr = new StreamReader(_nombreArch);
			bool found = false;

			while (!sr.EndOfStream)
			{
				// Leer el Id y los datos del vehículo
				int VehiculoId = int.Parse(sr.ReadLine() ?? "");
				string VehiculoDominio = sr.ReadLine() ?? "";
				string VehiculoMarca = sr.ReadLine() ?? "";
				int VehiculoAnioFabricacion = int.Parse(sr.ReadLine() ?? "");
				int VehiculoIdTitular = int.Parse(sr.ReadLine() ?? "");

				if (VehiculoId == vehiculo.Id)
				{
					// Escribir el nuevo vehículo en lugar del vehículo original
					sw.WriteLine(vehiculo.Id);
					sw.WriteLine(vehiculo.Dominio);
					sw.WriteLine(vehiculo.Marca);
					sw.WriteLine(vehiculo.AnioFabricacion);
					sw.WriteLine(vehiculo.IdTitular);
					found = true;
				}
				else
				{
					// Escribir el vehículo original en el archivo temporal
					sw.WriteLine(VehiculoId);
					sw.WriteLine(VehiculoDominio);
					sw.WriteLine(VehiculoMarca);
					sw.WriteLine(VehiculoAnioFabricacion);
					sw.WriteLine(VehiculoIdTitular);
				}
			}
			
			File.Delete(_nombreArch);
			File.Move(archivoTemporal, _nombreArch);

			if (!found) 
			{
				throw new Exception($"No se ha encontrado el vehiculo {vehiculo} a modificar");
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("Ocurrió un error: " + ex.Message);
		}
	}
}