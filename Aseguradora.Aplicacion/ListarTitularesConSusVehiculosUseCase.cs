namespace Aseguradora.Aplicacion

{
      public class ListarTitularesConSusVehiculosUseCase
    {
        private readonly IRepositorioPoliza _repo;

        public ListarTitularesConSusVehiculosUseCase(IRepositorioPoliza repo)
        {
            _repo = repo;
        }

        public List<Tutlares> Ejecutar()
        {
            //agarro una lista de titulares
            //Por cada titular busco los autos con ese titular
            return _repo.ListarTitularesCOnSusVehiculos();
        }
    }
}