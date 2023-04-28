using Aseguradora.Aplicacion;
using Aseguradora.Repositorios;

IRepositorioTitular repoTitular = new RepositorioTitularTXT();
AgregarTitularUseCase agregarTitular = new AgregarTitularUseCase(repoTitular);
ListarTitularesUseCase listarTitulares = new ListarTitularesUseCase(repoTitular);
ModificarTitularUseCase modificarTitular = new ModificarTitularUseCase(repoTitular);
EliminarTitularUseCase eliminarTitular = new EliminarTitularUseCase(repoTitular);

//Instanciamos titulares
Titular titular = new Titular {
	Nombre = "García Juan",
	DNI = "33123456",
	Direccion = "13 nro. 546",
	Telefono = "221-456456",
	CorreoElectronico = "joseGarcia@gmail.com"
};

Titular titular2 = new Titular {
	Nombre = "Celeste",
	DNI = "90403849",
	Direccion = "13 nro. 12",
	Telefono = "221-904234",
	CorreoElectronico = "otroemail@gmail.com"
};

Titular titular3 = new Titular {
	Nombre = "Alicia Raquel",
	DNI = "42342345",
	Direccion = "13 nro. 12",
	Telefono = "221-904234",
	CorreoElectronico = "otroemail@gmail.com"
};

	agregarTitular.Ejecutar(titular);
	agregarTitular.Ejecutar(titular2);
	agregarTitular.Ejecutar(titular3);
	
	Titular titularModificado = new Titular {
	Id = 2,
	Nombre = "Alicia Raquel",
	DNI = "42342345",
	Direccion = "13 nro. 12",
	Telefono = "221-904234",
	CorreoElectronico = "otroemail@gmail.com"
};

	modificarTitular.Ejecutar(titularModificado);
	
	eliminarTitular.Ejecutar(3);
