namespace Aseguradora.Aplicacion;

public class Tercero : Persona
{
    public string NombreAseguradora { get; set; } = "";
    public int IdSiniestro { get; set; }

    public override string ToString()
    {
        return $"{Nombre} (Id:{Id}) - Tercero";
    }
}
