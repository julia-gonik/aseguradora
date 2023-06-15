namespace Aseguradora.Aplicacion
{
    public class ObtenerTitularUseCase
    {
        private readonly IRepositorioTitular _repo;

        public ObtenerTitularUseCase(IRepositorioTitular repo)
        {
            _repo = repo;
        }

        public Titular? Ejecutar(int id)
        {
            return _repo.ObtenerTitular(id);
        }
    }
}