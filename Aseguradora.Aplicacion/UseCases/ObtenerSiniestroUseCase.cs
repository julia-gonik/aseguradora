namespace Aseguradora.Aplicacion
{
    public class ObtenerSiniestroUseCase
    {
        private readonly IRepositorioSiniestro _repo;

        public ObtenerSiniestroUseCase(IRepositorioSiniestro repo)
        {
            _repo = repo;
        }

        public Siniestro? Ejecutar(int id)
        {
            return _repo.ObtenerSiniestro(id);
        }
    }
}