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
			var listarTitulares = _repoTitular.ListarTitulares();

			return listarTitulares.Select(titular => _repoTitular.ObtenerVehiculosDeTitular(titular, (int Id) => _repoVehiculo.ListarVehiculosPorTitular(Id))).ToList();
		}
	}
}