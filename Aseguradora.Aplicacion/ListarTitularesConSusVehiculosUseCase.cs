namespace Aseguradora.Aplicacion

{
      public class ListarTitularesConSusVehiculosUseCase
    {
        private readonly IRepositorioVehiculo _repoVehiculo;
        private readonly IRepositorioTitular _repoTitular;

        public ListarTitularesConSusVehiculosUseCase(IRepositorioVehiculo repoVehiculo, IRepositorioTitular repoTitular)
        {
            _repoVehiculo = repoVehiculo;
            _repoTitular = repoTitular;
        }

        public List<Titular> Ejecutar()
        {
            var listaTitutal = _repoTitular.ListarTitulares();
            //Puedo por cada titular recorrer todos los autos y buscar cual tiene este titular
            //Hacer en el repo un metodo: autos de un Titular -> me parece que esta es la opcion
            return listaTitutal;
        }
    }
}