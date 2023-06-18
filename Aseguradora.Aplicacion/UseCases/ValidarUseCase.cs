    namespace Aseguradora.Aplicacion
    {
        public class ValidarUseCase
        {
            private readonly IRepositorioPoliza _repo;

            public ValidarUseCase(IRepositorioPoliza repo)
            {
                _repo = repo;
            }

            public bool Ejecutar(int Id, DateTime fechaSiniestro)
            {
                List<Poliza> lista = _repo.ListarPolizas();
                var poliza = lista.FirstOrDefault(p => p.Id == Id);
                if(poliza != null)
                    return fechaSiniestro >= poliza.FechaInicioVigencia && fechaSiniestro <= poliza.FechaFinVigencia;
                else return false;
            }
        }
    }