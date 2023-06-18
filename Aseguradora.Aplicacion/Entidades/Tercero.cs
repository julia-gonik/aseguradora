using System.ComponentModel.DataAnnotations;
namespace Aseguradora.Aplicacion;

public class Tercero : Persona
{
    [Required]
    public string NombreAseguradora { get; set; } = "";
    [Required]
    public int SiniestroId { get; set; }
    public Siniestro? Siniestro { get; set; }

    public override string ToString()
    {
        return $"{Nombre} (Id:{Id}) - Tercero";
    }
}
