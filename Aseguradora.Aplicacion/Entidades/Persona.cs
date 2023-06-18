using System.ComponentModel.DataAnnotations;
namespace Aseguradora.Aplicacion;

public abstract class Persona
{
    public virtual int Id { get; set; }
    [Required]
    [RegularExpression("([0-9]+)")]
    public string DNI { get; set; } = "00000000";
    [Required]
    public string Nombre { get; set; } = "";
    [Required]
    [RegularExpression("([0-9]+)")]
    public string Telefono { get; set; } = "00000000";

    public override string ToString()
    {
        return $"{Nombre} (Id:{Id})";
    }
}