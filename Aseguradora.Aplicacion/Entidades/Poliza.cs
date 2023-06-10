namespace Aseguradora.Aplicacion;

public class Poliza
{
	public int Id { get; set; }
	public int VehiculoId { get; set; }
	public double ValorAsegurado { get; set; }
	public string Franquicia { get; set; } = "";
	public TipoCobertura TipoCobertura { get; set; }
	public DateTime FechaInicioVigencia { get; set; }
	public DateTime FechaFinVigencia { get; set; }

	public override string ToString() 
	{
		return $"Poliza {Id} con franquicia {Franquicia}";
	}
}


public enum TipoCobertura
{
	ResponsabilidadCivil,
	TodoRiesgo
}
