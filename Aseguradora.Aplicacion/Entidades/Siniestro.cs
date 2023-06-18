namespace Aseguradora.Aplicacion;

public class Siniestro
{
    public int Id { get; set; }
    public int PolizaId { get; set; }
    public Poliza? Poliza { get; set; }
    public DateTime FechaIngreso { get; set; }
    public DateTime FechaOcurrencia { get; set; }
    public string Direccion { get; set; } = "";
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
