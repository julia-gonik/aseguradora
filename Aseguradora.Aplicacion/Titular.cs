namespace Aseguradora.Aplicacion;

public class Titular : Persona
{
    public string Direccion { get; set; } = "";
    public string CorreoElectronico { get; set; } = "";
    public List<Vehiculo>? Vehiculos { get; set; }
    public override string ToString()
    {
        return $"{Nombre} (Id:{Id}) - Titular";
    }
}