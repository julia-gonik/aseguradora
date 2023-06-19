using System.ComponentModel.DataAnnotations;
namespace Aseguradora.Aplicacion;

public class Poliza
{
    public int Id { get; set; }
    public int VehiculoId { get; set; }
    public Vehiculo? Vehiculo { get; set; }
    [Required(ErrorMessage = "El campo es requerido")]
    public double ValorAsegurado { get; set; }
    [Required(ErrorMessage = "El campo es requerido")]
    public string Franquicia { get; set; } = "";
    [Required(ErrorMessage = "El campo es requerido")]
    public TipoCobertura TipoCobertura { get; set; }
    [Required(ErrorMessage = "El campo es requerido")]
    public DateTime FechaInicioVigencia { get; set; }
    [Required(ErrorMessage = "El campo es requerido")]
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
