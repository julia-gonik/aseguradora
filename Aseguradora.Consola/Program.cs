using Aseguradora.Aplicacion;
using Aseguradora.Repositorios;

IRepositorioTitular repoTitular = new RepositorioTitularTXT();
AgregarTitularUseCase agregarTitular = new AgregarTitularUseCase(repoTitular);
ListarTitularesUseCase listarTitulares = new ListarTitularesUseCase(repoTitular);
ModificarTitularUseCase modificarTitular = new ModificarTitularUseCase(repoTitular);
EliminarTitularUseCase eliminarTitular = new EliminarTitularUseCase(repoTitular);


IRepositorioVehiculo repoVehiculo = new RepositorioVehiculoTXT();
AgregarVehiculoUseCase agregarVehiculo = new AgregarVehiculoUseCase(repoVehiculo);
ListarVehiculosUseCase listarVehiculos = new ListarVehiculosUseCase(repoVehiculo);
ModificarVehiculoUseCase modificarVehiculo = new ModificarVehiculoUseCase(repoVehiculo);
EliminarVehiculoUseCase eliminarVehiculo = new EliminarVehiculoUseCase(repoVehiculo);

ListarTitularesConSusVehiculosUseCase ListarTitularesConSusVehiculos = new ListarTitularesConSusVehiculosUseCase(repoVehiculo, repoTitular);

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

Vehiculo vehiculo1 = new Vehiculo 
{ 
		Dominio = "ABC123", 
		Marca = "Toyota", 
		AnioFabricacion = 2010, 
		IdTitular = 1
};

Vehiculo vehiculo2 = new Vehiculo 
{ 
		Dominio = "DEF456", 
		Marca = "Ford", 
		AnioFabricacion = 2015, 
		IdTitular = 1
};

Vehiculo vehiculo3 = new Vehiculo 
{ 
		Dominio = "GHI789", 
		Marca = "Chevrolet", 
		AnioFabricacion = 2020, 
		IdTitular = 1
};

Vehiculo vehiculo4 = new Vehiculo 
{ 
		Dominio = "JKL012", 
		Marca = "Honda", 
		AnioFabricacion = 2012, 
		IdTitular = 1
};

Vehiculo vehiculo5 = new Vehiculo 
{ 
		Dominio = "MNO345", 
		Marca = "BMW", 
		AnioFabricacion = 2018, 
		IdTitular = 1
};

Vehiculo vehiculo6 = new Vehiculo 
{ 
		Dominio = "PQR678", 
		Marca = "Mercedes", 
		AnioFabricacion = 2019, 
		IdTitular = 1
};

Vehiculo vehiculo7 = new Vehiculo 
{ 
		Dominio = "STU901", 
		Marca = "Audi", 
		AnioFabricacion = 2016, 
		IdTitular = 2
};

Vehiculo vehiculo8 = new Vehiculo 
{ 
		Dominio = "VWX234", 
		Marca = "Jeep", 
		AnioFabricacion = 2017, 
		IdTitular = 2
};

Vehiculo vehiculo9 = new Vehiculo 
{ 
		Dominio = "YZA567", 
		Marca = "Nissan", 
		AnioFabricacion = 2014, 
		IdTitular = 2
};

Vehiculo vehiculo10 = new Vehiculo 
{ 
		Dominio = "BCD890", 
		Marca = "Kia", 
		AnioFabricacion = 2013, 
		IdTitular = 3 
};


agregarVehiculo.Ejecutar(vehiculo1);
agregarVehiculo.Ejecutar(vehiculo2);
agregarVehiculo.Ejecutar(vehiculo3);
agregarVehiculo.Ejecutar(vehiculo4);
agregarVehiculo.Ejecutar(vehiculo5);
agregarVehiculo.Ejecutar(vehiculo6);
agregarVehiculo.Ejecutar(vehiculo7);
	
Vehiculo vehiculo5Modificado = new Vehiculo 
{ 
		Id = 5,
		Dominio = "nuevoMNO345", 
		Marca = "otraBMW", 
		AnioFabricacion = 2017, 
		IdTitular = 1 
};

Vehiculo vehiculo6Modificado = new Vehiculo 
{ 
		Id = 6,
		Dominio = "otroPQR678", 
		Marca = "otroMercedes", 
		AnioFabricacion = 2019, 
		IdTitular = 2 
};

Vehiculo vehiculoNoEncontrado = new Vehiculo 
{ 
		Id = 12,
		Dominio = "No", 
		Marca = "Encontrado", 
		AnioFabricacion = 2019, 
		IdTitular = 2 
};

modificarVehiculo.Ejecutar(vehiculo5Modificado);
modificarVehiculo.Ejecutar(vehiculo6Modificado);
modificarVehiculo.Ejecutar(vehiculoNoEncontrado);


eliminarVehiculo.Ejecutar(5);
eliminarVehiculo.Ejecutar(20);


ListarTitularesConSusVehiculos.Ejecutar();