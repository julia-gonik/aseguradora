using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Aseguradora.Aplicacion;

public class Titular : Persona
{
    [Required]
    public string Direccion { get; set; } = "";
    [Required]
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