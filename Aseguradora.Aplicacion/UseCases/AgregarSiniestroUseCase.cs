namespace Aseguradora.Aplicacion
{
    public class AgregarSiniestroUseCase   
    {
        private readonly IRepositorioSiniestro _repo;
        
        public AgregarSiniestroUseCase(IRepositorioSiniestro repo)
        {
            _repo = repo;
        }
        
        public void Ejecutar(Siniestro siniestro)
        {
            _repo.AgregarSiniestro(siniestro);
        }
    }
}