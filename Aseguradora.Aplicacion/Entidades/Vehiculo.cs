using System.ComponentModel.DataAnnotations;
namespace Aseguradora.Aplicacion;

public class Vehiculo
{
    public int Id { get; set; }
    [Required]
    public string Dominio { get; set; } = "";
    [Required]
    public string Marca { get; set; } = "";
    [Required]
    public string AnioFabricacion { get; set; } = "";
    public Titular? Titular { get; set; }
    [Required]
    public int TitularId { get; set; }

    public override string ToString()
    {
        return $"Vehiculo con dominio: {Dominio}  y marca {Marca}";
    }
}




