namespace Aseguradora.Aplicacion
{
    public interface IRepositorioVehiculo
    {
        void AgregarVehiculo(Vehiculo vehiculo);
        void ModificarVehiculo(Vehiculo vehiculo);
        void EliminarVehiculo(int id);
        List<Vehiculo> ListarVehiculosPorTitular(int id); //id del titular
        List<Vehiculo> ListarVehiculos();
        Vehiculo? ObtenerVehiculo(int Id);
    }
}
