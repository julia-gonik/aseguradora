namespace Aseguradora.Aplicacion;

public class Poliza
{
    public int Id { get; set; }
    public int IdVehiculoAsegurado { get; set; }
    public double ValorAsegurado { get; set; }
    public string Franquicia { get; set; } = "";
    public TipoCobertura TipoCobertura { get; set; }
    public DateTime FechaInicioVigencia { get; set; }
    public DateTime FechaFinVigencia { get; set; }
}

public enum TipoCobertura
{
    ResponsabilidadCivil,
    TodoRiesgo
}
