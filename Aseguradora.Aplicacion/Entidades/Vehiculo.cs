using System.ComponentModel.DataAnnotations;
namespace Aseguradora.Aplicacion;

public class Vehiculo
{
    public int Id { get; set; }
    [Required(ErrorMessage = "El campo es requerido")]
    public string Dominio { get; set; } = "";
    [Required(ErrorMessage = "El campo es requerido")]
    public string Marca { get; set; } = "";
    [Required(ErrorMessage = "El campo es requerido")]
    [RegularExpression("([0-9]+)", ErrorMessage = "El campo debe contener solo numeros")]
    public string AnioFabricacion { get; set; } = "";
    public Titular? Titular { get; set; }
    [Required(ErrorMessage = "El campo es requerido")]
    public int TitularId { get; set; }

    public override string ToString()
    {
        return $"Vehiculo con dominio: {Dominio}  y marca {Marca}";
    }
}




