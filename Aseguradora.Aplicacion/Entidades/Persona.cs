using System.ComponentModel.DataAnnotations;
namespace Aseguradora.Aplicacion;

public abstract class Persona
{
    public virtual int Id { get; set; }
    [Required(ErrorMessage = "El campo es requerido")]
    [RegularExpression("([0-9]+)", ErrorMessage = "El campo debe contener solo numeros")]
    public string DNI { get; set; } = "00000000";
    [Required(ErrorMessage = "El campo es requerido")]

    public string Nombre { get; set; } = "";
    [Required(ErrorMessage = "El campo es requerido")]
    [RegularExpression("([0-9]+)", ErrorMessage = "El campo debe contener solo numeros")]
    public string Telefono { get; set; } = "00000000";

    public override string ToString()
    {
        return $"{Nombre} (Id:{Id})";
    }
}