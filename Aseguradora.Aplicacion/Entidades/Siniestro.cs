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

    public Siniestro(ValidarUseCase validarUseCase, int polizaId)
    {
        FechaIngreso = DateTime.Now;

        // Llamar al delegado para verificar si es válido
        bool esValido = validarUseCase.Ejecutar(polizaId, FechaIngreso);

        if (!esValido)
        {
            throw new SiniestroFueraDeVigenciaException("No es posible registrar el siniestro");
        }
        PolizaId = polizaId;
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
