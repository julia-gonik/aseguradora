namespace Aseguradora.Aplicacion
{
    public class ObtenerVehiculoUseCase
    {
        private readonly IRepositorioVehiculo _repo;

        public ObtenerVehiculoUseCase(IRepositorioVehiculo repo)
        {
            _repo = repo;
        }

        public Vehiculo? Ejecutar(int id)
        {
            return _repo.ObtenerVehiculo(id);
        }
    }
}