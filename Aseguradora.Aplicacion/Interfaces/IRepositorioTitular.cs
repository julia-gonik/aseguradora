namespace Aseguradora.Aplicacion;

public interface IRepositorioTitular
{
	public void AgregarTitular(Titular titular);
	public List<Titular> ListarTitulares();
	public void ModificarTitular(Titular titular);
	public void EliminarTitular(int id);
	public Titular ObtenerVehiculosDeTitular(Titular titular, Func<int, List<Vehiculo>> listaVehiculos);
}