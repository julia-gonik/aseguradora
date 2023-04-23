namespace Aseguradora.Aplicacion;

public class Vehiculo
{
    public int Id { get; set; }
    public string Dominio { get; set; } = "";
    public string Marca { get; set; } = "";
    public int AnioFabricacion { get; set; }
    public int IdTitular { get; set; }
}
