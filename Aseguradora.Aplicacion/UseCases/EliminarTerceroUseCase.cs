namespace Aseguradora.Aplicacion
{
    public class EliminarTerceroUseCase
    {
        private readonly IRepositorioTercero _repo;

        public EliminarTerceroUseCase(IRepositorioTercero repo)
        {
            _repo = repo;
        }

        public void Ejecutar(int id)
        {
            _repo.EliminarTercero(id);
        }
    }
}