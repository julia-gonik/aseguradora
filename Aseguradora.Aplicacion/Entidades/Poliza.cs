using System.ComponentModel.DataAnnotations;
namespace Aseguradora.Aplicacion;

public class Poliza
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Vehiculo es necesario")]
    public int VehiculoId { get; set; }
    [Required]
    public Vehiculo? Vehiculo { get; set; }
    [Required]
    public double ValorAsegurado { get; set; }
    [Required]
    public string Franquicia { get; set; } = "";
    [Required]
    public TipoCobertura TipoCobertura { get; set; }
    [Required]
    public DateTime FechaInicioVigencia { get; set; }
    [Required]
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
