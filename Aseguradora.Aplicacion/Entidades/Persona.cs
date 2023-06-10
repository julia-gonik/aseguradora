namespace Aseguradora.Aplicacion;

public abstract class Persona
{
    public virtual int Id { get; set; }
    public string DNI { get; set;} = "00000000";
    public string Nombre { get; set; } = "";
    public string Telefono { get; set; } = "00000000";
    
    public override string ToString()
    {
        return $"{Nombre} (Id:{Id})";
    }
}