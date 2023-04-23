namespace Aseguradora.Aplicacion;

public abstract class Persona
{
    public int Id { get; set; }
    public int DNI { get; set;}
    public string Nombre { get; set; } = "";
    public int telefono { get; set; }
    
    public override string ToString()
    {
        return $"{Nombre} (Id:{Id})";
    }
}