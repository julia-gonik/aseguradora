namespace Aseguradora.Aplicacion
{
    public class ObtenerTerceroUseCase
    {
        private readonly IRepositorioTercero _repo;

        public ObtenerTerceroUseCase(IRepositorioTercero repo)
        {
            _repo = repo;
        }

        public Tercero? Ejecutar(int id)
        {
            return _repo.ObtenerTercero(id);
        }
    }
}