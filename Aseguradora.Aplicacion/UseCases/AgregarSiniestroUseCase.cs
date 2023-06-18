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
            if (siniestro.PolizaId == 0) return;

            Poliza? poliza = _repoPoliza.ObtenerPoliza(siniestro.PolizaId);

            if (poliza == null) return;

            if (siniestro.FechaOcurrencia >= poliza.FechaInicioVigencia && siniestro.FechaOcurrencia <= poliza.FechaFinVigencia)
            {
                _repoSiniestro.AgregarSiniestro(siniestro);
            }
            else
            {
                throw new SiniestroFueraDeVigenciaException();
            }
        }
    }
}