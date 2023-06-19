using System.ComponentModel.DataAnnotations;
namespace Aseguradora.Aplicacion;

public class Siniestro
{
    public int Id { get; set; }
    [Required(ErrorMessage = "El campo es requerido")]
    public int PolizaId { get; set; }
    public Poliza? Poliza { get; set; }
    public DateTime FechaIngreso { get; set; }
    [Required(ErrorMessage = "El campo es requerido")]
    public DateTime FechaOcurrencia { get; set; }
    [Required(ErrorMessage = "El campo es requerido")]
    public string Direccion { get; set; } = "";
    [Required(ErrorMessage = "El campo es requerido")]
    public string Descripcion { get; set; } = "";

    public Siniestro()
    {
        FechaIngreso = DateTime.Now;
    }

    public override string ToString()
    {
        return $"Siniestro Id: {Id}\n" +
               $"PolizaId: {PolizaId}\n" +
               $"Poliza: {Poliza?.ToString() ?? "N/A"}\n" +
               $"Fecha de Ingreso: {FechaIngreso}\n" +
               $"Fecha de Ocurrencia: {FechaOcurrencia}\n" +
               $"Dirección: {Direccion}\n" +
               $"Descripción: {Descripcion}";
    }

}
