namespace Aseguradora.Aplicacion
{
    public class AgregarSiniestroUseCase   
    {
        private readonly IRepositorioSiniestro _repoSiniestro;
        private readonly IRepositorioPoliza _repoPoliza;
        
        public AgregarSiniestroUseCase(IRepositorioSiniestro repoSiniestro, IRepositorioPoliza repoPoliza)
        {
            _repoSiniestro = repoSiniestro;
            _repoPoliza = repoPoliza;
        }
        
        public void Ejecutar(Siniestro siniestro)
        {
            List<Poliza> lista = _repoPoliza.ListarPolizas();
            bool valido = false;
            var polizas = lista.Where(p => p.Id == siniestro.Id).ToList();
            foreach(Poliza p in polizas){
                if( siniestro.FechaOcurrencia >= p.FechaInicioVigencia && siniestro.FechaOcurrencia <= p.FechaFinVigencia)
                {
                    _repoSiniestro.AgregarSiniestro(siniestro);
                    valido = true;
                    break;
                }
            }
            if(valido == false){
                throw new SiniestroFueraDeVigenciaException();
            }
                
            
        }
    }
}