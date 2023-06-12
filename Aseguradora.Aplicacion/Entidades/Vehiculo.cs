namespace Aseguradora.Aplicacion;

public class Vehiculo
{
	public int Id { get; set; }
	public string Dominio { get; set; } = "";
	public string Marca { get; set; } = "";
	public string AnioFabricacion { get; set; } = "";
	public Titular? Titular { get; set; }
	public int TitularId { get; set; }
	
	public override string ToString() 
	{
		return $"Vehiculo con dominio: {Dominio}  y marca {Marca}";
	}
}

