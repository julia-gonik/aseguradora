namespace Aseguradora.Aplicacion
{
    public class ModificarPolizaUseCase
    {
        private readonly IRepositorioPoliza _repo;

        public ModificarPolizaUseCase(IRepositorioPoliza repo)
        {
            _repo = repo;
        }

        public void Ejecutar(Poliza poliza)
        {
            _repo.ModificarPoliza(poliza);
        }
    }
}
