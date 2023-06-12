using System.Text;

namespace Aseguradora.Aplicacion;

public class Titular : Persona
{
	public string Direccion { get; set; } = "";
	public string CorreoElectronico { get; set; } = "";
	public virtual List<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
	
	public override string ToString()
	{
		var sb = new StringBuilder();
		sb.AppendLine($"{Nombre} (Id:{Id}) - Titular");
		sb.AppendLine($"Dirección: {Direccion}");
		sb.AppendLine($"Correo electrónico: {CorreoElectronico}");

		if (Vehiculos != null && Vehiculos.Count > 0)
		{
			sb.AppendLine("Vehículos:");

			foreach (var vehiculo in Vehiculos)
			{
				sb.AppendLine($"- {vehiculo.ToString()}");
			}
		}
		return sb.ToString();
	}
}