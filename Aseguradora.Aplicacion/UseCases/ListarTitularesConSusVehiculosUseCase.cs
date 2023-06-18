namespace Aseguradora.Aplicacion

{
	public class ListarTitularesConSusVehiculosUseCase
	{
		private readonly IRepositorioTitular _repoTitular;

		public ListarTitularesConSusVehiculosUseCase(IRepositorioTitular repoTitular)
		{
			_repoTitular = repoTitular;
		}

		public List<Titular> Ejecutar()
		{
			// var listarTitulares = _repoTitular.ListarTitulares();
			return _repoTitular.ListarTitularesConSusVehiculos();

			// return listarTitulares.Select(titular => _repoTitular.ObtenerVehiculosDeTitular(titular, (int Id) => _repoVehiculo.ListarVehiculosPorTitular(Id))).ToList();
		}
	}
}