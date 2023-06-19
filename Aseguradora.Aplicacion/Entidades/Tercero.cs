using System.ComponentModel.DataAnnotations;
namespace Aseguradora.Aplicacion;

public class Tercero : Persona
{
    [Required(ErrorMessage = "El campo es requerido")]
    public string NombreAseguradora { get; set; } = "";
    [Required(ErrorMessage = "El campo es requerido")]
    public int SiniestroId { get; set; }
    public Siniestro? Siniestro { get; set; }

    public override string ToString()
    {
        return $"{Nombre} (Id:{Id}) - Tercero";
    }
}
