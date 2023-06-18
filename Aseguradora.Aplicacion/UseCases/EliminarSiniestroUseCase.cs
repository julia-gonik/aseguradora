namespace Aseguradora.Aplicacion
{
    public class EliminarSiniestroUseCase
    {
        private readonly IRepositorioSiniestro _repo;

        public EliminarSiniestroUseCase(IRepositorioSiniestro repo)
        {
            _repo = repo;
        }

        public void Ejecutar(int id)
        {
            _repo.EliminarSiniestro(id);
        }
    }
}