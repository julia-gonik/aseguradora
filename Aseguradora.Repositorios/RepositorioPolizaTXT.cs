using Aseguradora.Aplicacion;
namespace Aseguradora.Repositorios;


public class RepositorioPolizaTXT : IRepositorioPoliza
{
	readonly string _nombreArch = "polizas.txt";

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
				Console.WriteLine(db.Polizas.Add(poliza));
				db.SaveChanges();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Ocurrió un error: " + ex);
			}
		}
	}



	public void EliminarPoliza(int id)
	{
		try
		{
			string archivoTemporal = "polizas_temp.txt";
			using var sr = new StreamReader(_nombreArch);
			using var sw = new StreamWriter(archivoTemporal);
			bool found = false;

			while (!sr.EndOfStream)
			{
				int polizaId = int.Parse(sr.ReadLine() ?? "");
				int VehiculoId = int.Parse(sr.ReadLine() ?? "");
				double valorAsegurado = double.Parse(sr.ReadLine() ?? "");
				string franquicia = sr.ReadLine() ?? "";
				TipoCobertura tipoCobertura = (TipoCobertura)Enum.Parse(typeof(TipoCobertura), sr.ReadLine() ?? "");
				DateTime fechaInicioVigencia = DateTime.Parse(sr.ReadLine() ?? "");
				DateTime fechaFinVigencia = DateTime.Parse(sr.ReadLine() ?? "");

				if (polizaId != id)
				{
					sw.WriteLine(polizaId);
					sw.WriteLine(VehiculoId);
					sw.WriteLine(valorAsegurado);
					sw.WriteLine(franquicia);
					sw.WriteLine(tipoCobertura);
					sw.WriteLine(fechaInicioVigencia);
					sw.WriteLine(fechaFinVigencia);
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
				throw new Exception($"No se ha encontrado la poliza con id {id} a eliminar");
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("Ocurrió un error al eliminar la póliza: " + ex.Message);
		}
	}

	public List<Poliza> ListarPolizas()
	{
		var polizas = new List<Poliza>();
		if (File.Exists(_nombreArch))
		{
			using var sr = new StreamReader(_nombreArch);
			while (!sr.EndOfStream)
			{
				var poliza = new Poliza();
				poliza.Id = int.Parse(sr.ReadLine() ?? "");
				poliza.VehiculoId = int.Parse(sr.ReadLine() ?? "");
				poliza.ValorAsegurado = double.Parse(sr.ReadLine() ?? "");
				poliza.Franquicia = sr.ReadLine() ?? "";
				poliza.TipoCobertura = (TipoCobertura)Enum.Parse(typeof(TipoCobertura), sr.ReadLine() ?? "");
				poliza.FechaInicioVigencia = DateTime.Parse(sr.ReadLine() ?? "");
				poliza.FechaFinVigencia = DateTime.Parse(sr.ReadLine() ?? "");

				polizas.Add(poliza);
			}
		}
		return polizas;
	}

	public void ModificarPoliza(Poliza poliza)
	{
		try
		{
			string archivoTemporal = "polizas_temp.txt";
			using var sr = new StreamReader(_nombreArch);
			using var sw = new StreamWriter(archivoTemporal);
			bool found = false;

			while (!sr.EndOfStream)
			{
				int polizaId = int.Parse(sr.ReadLine() ?? "");
				int VehiculoId = int.Parse(sr.ReadLine() ?? "");
				double valorAsegurado = double.Parse(sr.ReadLine() ?? "");
				string franquicia = sr.ReadLine() ?? "";
				TipoCobertura tipoCobertura = (TipoCobertura)Enum.Parse(typeof(TipoCobertura), sr.ReadLine() ?? "");
				DateTime fechaInicioVigencia = DateTime.Parse(sr.ReadLine() ?? "");
				DateTime fechaFinVigencia = DateTime.Parse(sr.ReadLine() ?? "");

				if (polizaId == poliza.Id)
				{
					sw.WriteLine(poliza.Id);
					sw.WriteLine(poliza.VehiculoId);
					sw.WriteLine(poliza.ValorAsegurado);
					sw.WriteLine(poliza.Franquicia);
					sw.WriteLine(poliza.TipoCobertura);
					sw.WriteLine(poliza.FechaInicioVigencia);
					sw.WriteLine(poliza.FechaFinVigencia);
					found = true;
				}
				else
				{
					sw.WriteLine(polizaId);
					sw.WriteLine(VehiculoId);
					sw.WriteLine(valorAsegurado);
					sw.WriteLine(franquicia);
					sw.WriteLine(tipoCobertura);
					sw.WriteLine(fechaInicioVigencia);
					sw.WriteLine(fechaFinVigencia);
				}
			}

			File.Delete(_nombreArch);
			File.Move(archivoTemporal, _nombreArch);
			
			if (!found) 
			{
				throw new Exception($"No se ha encontrado la poliza {poliza} a modificar");
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("Ocurrió un error al modificar la póliza: " + ex.Message);
		}
	}
}
