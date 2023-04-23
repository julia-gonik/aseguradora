namespace Aseguradora.Aplicacion
{
    public interface IRepositorioPoliza
    {
        void AgregarPoliza(Poliza poliza);
        void ModificarPoliza(Poliza poliza);
        void EliminarPoliza(int id);
        List<Poliza> ListarPolizas();
    }
}
