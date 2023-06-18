namespace Aseguradora.Aplicacion
{
    public interface IRepositorioSiniestro
    {
        void AgregarSiniestro(Siniestro siniestro);
        void ModificarSiniestro(Siniestro siniestro);
        void EliminarSiniestro(int id);
        List<Siniestro> ListarSiniestro();
        Siniestro? ObtenerSiniestro(int id);
    }
}
