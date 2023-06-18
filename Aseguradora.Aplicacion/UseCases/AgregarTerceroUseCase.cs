namespace Aseguradora.Aplicacion
{
    public class AgregarTerceroUseCase   
    {
        private readonly IRepositorioTercero _repo;
        
        public AgregarTerceroUseCase(IRepositorioTercero repo)
        {
            _repo = repo;
        }
        
        public void Ejecutar(Tercero tercero)
        {
            _repo.AgregarTercero(tercero);
        }
    }
}