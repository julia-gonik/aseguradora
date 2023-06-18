namespace Aseguradora.Aplicacion
{
    public class ObtenerPolizaUseCase
    {
        private readonly IRepositorioPoliza _repo;

        public ObtenerPolizaUseCase(IRepositorioPoliza repo)
        {
            _repo = repo;
        }

        public Poliza? Ejecutar(int id)
        {
            return _repo.ObtenerPoliza(id);
        }
    }
}