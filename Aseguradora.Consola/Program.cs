using Aseguradora.Aplicacion;
using Aseguradora.Repositorios;

IRepositorioSiniestro repoSiniestro = new RepositorioSiniestro();
AgregarSiniestroUseCase agregarSiniestro = new AgregarSiniestroUseCase(repoSiniestro);
ListarSiniestrosUseCase listarSiniestros = new ListarSiniestrosUseCase(repoSiniestro);
ModificarSiniestroUseCase modificarSiniestro = new ModificarSiniestroUseCase(repoSiniestro);
EliminarSiniestroUseCase eliminarSiniestro = new EliminarSiniestroUseCase(repoSiniestro);

IRepositorioTercero repoTercero = new RepositorioTercero();
AgregarTerceroUseCase agregarTercero = new AgregarTerceroUseCase(repoTercero);
ListarTercerosUseCase listarTerceros = new ListarTercerosUseCase(repoTercero);
ModificarTerceroUseCase modificarTercero = new ModificarTerceroUseCase(repoTercero);
EliminarTerceroUseCase eliminarTercero = new EliminarTerceroUseCase(repoTercero);


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

ListarTitularesConSusVehiculosUseCase ListarTitularesConSusVehiculos =
    new ListarTitularesConSusVehiculosUseCase(repoVehiculo, repoTitular);

IRepositorioPoliza repoPoliza = new RepositorioPolizaTXT();
AgregarPolizaUseCase agregarPoliza = new AgregarPolizaUseCase(repoPoliza);
ListarPolizasUseCase listarPolizas = new ListarPolizasUseCase(repoPoliza);
ModificarPolizaUseCase modificarPoliza = new ModificarPolizaUseCase(repoPoliza);
EliminarPolizaUseCase eliminarPoliza = new EliminarPolizaUseCase(repoPoliza);

ValidarUseCase validarUseCase = new ValidarUseCase(repoPoliza);

// Crear titulares
List<Titular> titulares = new List<Titular>();

for (int i = 1; i <= 4; i++)
{
    Titular titular = new Titular
    {
        Id = i,
        DNI = $"{i}",
        Nombre = $"Nombre titular {i}",
        Telefono = $"Telefono titular {i}",
        Direccion = $"Direccion titular {i}",
        CorreoElectronico = $"Correo electrónico titular {i}"
    };

    //titulares.Add(titular);
    agregarTitular.Ejecutar(titular);


}

// Crear vehículos
List<Vehiculo> vehiculos = new List<Vehiculo>();

for (int i = 1; i <= 5; i++)
{
    Vehiculo vehiculo = new Vehiculo
    {
        Id = i,
        Dominio = $"Dominio vehiculo {i}",
        Marca = $"Marca vehiculo {i}",
        AnioFabricacion = $"202{i}",
        TitularId = i
    };

	agregarVehiculo.Ejecutar(vehiculo);
	//vehiculos.Add(vehiculo);
}


// Crear pólizas
List<Poliza> polizas = new List<Poliza>();

for (int i = 1; i <= 5; i++)
{
    Poliza poliza = new Poliza
    {
        Id = i,
        VehiculoId = i,
        ValorAsegurado = i * 1000,
        Franquicia = $"Franquicia poliza {i}",
        TipoCobertura = TipoCobertura.TodoRiesgo,
        FechaInicioVigencia = DateTime.Now,
        FechaFinVigencia = DateTime.Now.AddYears(1)
    };

    agregarPoliza.Ejecutar(poliza);
    //polizas.Add(poliza);
}

List<Siniestro> siniestros = new List<Siniestro>();

for (int i = 1; i <= 5; i++)
{
    Siniestro siniestro = new Siniestro(validarUseCase,i);
    siniestro.Id = i;
    siniestro.Poliza = new Poliza { Id = i, /* Agregar propiedades de la poliza */ };
    siniestro.FechaOcurrencia = DateTime.Now;
    siniestro.Direccion = "Dirección del siniestro";
    siniestro.Descripcion = "Descripción del siniestro";

    // Imprimir el siniestro
    agregarSiniestro.Ejecutar(siniestro);
    Console.WriteLine(siniestro.ToString());
}

// Crear terceros
List<Tercero> terceros = new List<Tercero>();

for (int i = 81; i <= 83; i++)
{
    Tercero tercero = new Tercero
    {
        Id = i,
        DNI = $"{i}",
        Nombre = $"Nombre tercero {i}",
        Telefono = $"Telefono tercero {i}",
        NombreAseguradora = $"Aseguradora tercero {i}",
        SiniestroId = i-80
    };

    agregarTercero.Ejecutar(tercero);
    //terceros.Add(tercero);
}


modificarTercero.Ejecutar(new Tercero
    {
        DNI = $"{82}",
        Nombre = $"Nombre tercero {1000}",
        Telefono = $"Telefono tercero {5}",
        NombreAseguradora = $"Aseguradora tercero {6}",
        SiniestroId = 82-80
    });



// modificarSiniestro.Ejecutar(new Siniestro
//     {
//         Id = 3,
//         PolizaId = 3,
//         FechaIngreso = DateTime.Now,
//         FechaOcurrencia = DateTime.Now.AddDays(-3),
//         Direccion = $"Dirección siniestro {3}",
//         Descripcion = $"Descripción {3}"
//     });

listarPolizas.Ejecutar().ForEach(poliza => Console.WriteLine(poliza));
listarSiniestros.Ejecutar().ForEach(s => Console.WriteLine(s));
listarTerceros.Ejecutar().ForEach(tercero => Console.WriteLine(tercero));




// Titular titular4 = new Titular {
// 	Nombre = "Ana García",
// 	DNI = "90403849",
// 	Direccion = "52 nro. 115",
// 	Telefono = "221-423904",
// 	CorreoElectronico = "otroemail@gmail.com"
// };


// Console.WriteLine($"Agregando titular {titular2.DNI}");
// agregarTitular.Ejecutar(titular2);

// Console.WriteLine($"Agregando titular {titular.DNI}");
// agregarTitular.Ejecutar(titular);


// Console.WriteLine($"Agregando titular {titular3.DNI}");
// agregarTitular.Ejecutar(titular3);


listarTitulares.Ejecutar().ForEach(titular => Console.WriteLine(titular));

// Console.WriteLine($"Agregando titular {titular4.DNI}");
// agregarTitular.Ejecutar(titular4);

// Console.WriteLine("Lista de titulares");
// listarTitulares.Ejecutar().ForEach(titular => Console.WriteLine(titular));

// Titular titularModificado = new Titular {
// 	Id = 2,
// 	Nombre = "Alicia Raquel",
// 	DNI = "42342345",
// 	Direccion = "13 nro. 12",
// 	Telefono = "221-904234",
// 	CorreoElectronico = "otroemail@gmail.com"
// };

// Titular titularModificadoNoExiste = new Titular {
// 	Id = 2,
// 	Nombre = "Maria Rodriguez",
// 	DNI = "87654321",
// 	Direccion = "55 nro. 204",
// 	Telefono = "221-555567",
// 	CorreoElectronico = "otroemail@gmail.com"
// };

// Console.WriteLine($"Modificando titular con DNI {titularModificado.Id}");
// modificarTitular.Ejecutar(titularModificado);

// Console.WriteLine($"Modificando titular con DNI {titularModificadoNoExiste.Id}");
// modificarTitular.Ejecutar(titularModificadoNoExiste);

// Console.WriteLine("Eliminando Vehiculo con Id 1");
// eliminarTitular.Ejecutar(1);

// Console.WriteLine("Eliminando Vehiculo con Id 16");
// eliminarTitular.Ejecutar(16);

// Console.WriteLine("Lista de titulares con los autos");
// ListarTitularesConSusVehiculos.Ejecutar().ForEach(titular => Console.WriteLine(titular));



// Vehiculo vehiculo4 = new Vehiculo 
// { 
// 	Dominio = "JKL012", 
// 	Marca = "Honda", 
// 	AnioFabricacion = "2012", 
// 	TitularId = 1
// };

// Vehiculo vehiculo5 = new Vehiculo 
// { 
// 	Dominio = "MNO345", 
// 	Marca = "BMW", 
// 	AnioFabricacion = "2018", 
// 	TitularId = 1
// };

// Vehiculo vehiculo6 = new Vehiculo 
// { 
// 	Dominio = "PQR678", 
// 	Marca = "Mercedes", 
// 	AnioFabricacion = "2019", 
// 	TitularId = 1
// };

// Vehiculo vehiculo7 = new Vehiculo 
// { 
// 	Dominio = "STU901", 
// 	Marca = "Audi", 
// 	AnioFabricacion = "2016", 
// 	TitularId = 2
// };

// Vehiculo vehiculo8 = new Vehiculo 
// { 
// 	Dominio = "VWX234", 
// 	Marca = "Jeep", 
// 	AnioFabricacion = "2017", 
// 	TitularId = 2
// };

// Vehiculo vehiculo9 = new Vehiculo 
// { 
// 	Dominio = "YZA567", 
// 	Marca = "Nissan", 
// 	AnioFabricacion = "2014", 
// 	TitularId = 2
// };

// Vehiculo vehiculo10 = new Vehiculo 
// { 
// 	Dominio = "BCD890", 
// 	Marca = "Kia", 
// 	AnioFabricacion = "2013", 
// 	TitularId = 3 
// };


//agregarVehiculo.Ejecutar(vehiculo1);
//Console.WriteLine($"Agregando Vehiculo {vehiculo1}");
//
//
//agregarVehiculo.Ejecutar(vehiculo2);
//Console.WriteLine($"Agregando Vehiculo {vehiculo2}");

//agregarTitular.Ejecutar(titular);

// agregarVehiculo.Ejecutar(vehiculo2);
// Console.WriteLine($"Agregando Vehiculo {vehiculo2}");

// agregarVehiculo.Ejecutar(vehiculo3);
// Console.WriteLine($"Agregando Vehiculo {vehiculo3}");


// Console.WriteLine("Lista de titulares");
// listarTitulares.Ejecutar().ForEach(titular => Console.WriteLine(titular));


// agregarVehiculo.Ejecutar(vehiculo4);
// Console.WriteLine($"Agregando Vehiculo {vehiculo4}");

// agregarVehiculo.Ejecutar(vehiculo5);
// Console.WriteLine($"Agregando Vehiculo {vehiculo5}");

// agregarVehiculo.Ejecutar(vehiculo6);
// Console.WriteLine($"Agregando Vehiculo {vehiculo6}");

// agregarVehiculo.Ejecutar(vehiculo7);
// Console.WriteLine($"Agregando Vehiculo {vehiculo7}");


// // agregarVehiculo.Ejecutar(new Vehiculo 
// // { 
// // 		Id = 5,
// // 		Dominio = "Agregando", 
// // 		Marca = "Ya existente", 
// // 		AnioFabricacion = "2017", 
// // 		TitularId = 1 
// // });


// // Vehiculo vehiculo5Modificado = new Vehiculo 
// // { 
// // 		Id = 5,
// // 		Dominio = "nuevoMNO345", 
// // 		Marca = "otraBMW", 
// // 		AnioFabricacion = "2017", 
// // 		TitularId = 1 
// // };

// // Vehiculo vehiculo6Modificado = new Vehiculo 
// // { 
// // 		Id = 6,
// // 		Dominio = "otroPQR678", 
// // 		Marca = "otroMercedes", 
// // 		AnioFabricacion = "2019", 
// // 		TitularId = 2 
// // };

// // Vehiculo vehiculoNoEncontrado = new Vehiculo 
// // { 
// // 		Id = 12,
// // 		Dominio = "No", 
// // 		Marca = "Encontrado", 
// // 		AnioFabricacion = "2019", 
// // 		TitularId = 2 
// // };


// // Console.WriteLine($"Modificando vehiculo con Id {vehiculo5Modificado.Id}");
// // modificarVehiculo.Ejecutar(vehiculo5Modificado);

// // Console.WriteLine($"Modificando vehiculo con Id {vehiculo6Modificado.Id}");
// // modificarVehiculo.Ejecutar(vehiculo6Modificado);

// // Console.WriteLine($"Modificando vehiculo con Id {vehiculoNoEncontrado.Id}");
// // modificarVehiculo.Ejecutar(vehiculoNoEncontrado);


// // Console.WriteLine("Eliminando Vehiculo con Id 5");
// // eliminarVehiculo.Ejecutar(5);
// // Console.WriteLine("Eliminando Vehiculo con Id 20");
// // eliminarVehiculo.Ejecutar(20);


// // Console.WriteLine("Lista de vehiculos");
// // listarVehiculos.Ejecutar().ForEach(vehiculo => Console.WriteLine(vehiculo));

// // Console.WriteLine("Lista de titulares con sus vehiculos");
// // ListarTitularesConSusVehiculos.Ejecutar().ForEach(titular => Console.WriteLine(titular));;


// Poliza poliza1 = new Poliza
// {
// 	VehiculoId = 2,
// 	ValorAsegurado = 5000,
// 	Franquicia = "1000",
// 	TipoCobertura = TipoCobertura.TodoRiesgo,
// 	FechaInicioVigencia = new DateTime(2023, 5, 8),
// 	FechaFinVigencia = new DateTime(2023, 6, 8)
// };

// Poliza poliza2 = new Poliza
// {
// 	VehiculoId = 2,
// 	ValorAsegurado = 7000,
// 	Franquicia = "1500",
// 	TipoCobertura = TipoCobertura.ResponsabilidadCivil,
// 	FechaInicioVigencia = new DateTime(2023, 5, 8),
// 	FechaFinVigencia = new DateTime(2023, 7, 8)
// };

// Poliza poliza3 = new Poliza
// {
// 	VehiculoId = 2,
// 	ValorAsegurado = 10000,
// 	Franquicia = "2000",
// 	TipoCobertura = TipoCobertura.TodoRiesgo,
// 	FechaInicioVigencia = new DateTime(2023, 5, 8),
// 	FechaFinVigencia = new DateTime(2023, 8, 8)
// };

// Poliza poliza4 = new Poliza
// {
// 	VehiculoId = 2,
// 	ValorAsegurado = 8000,
// 	Franquicia = "1200",
// 	TipoCobertura = TipoCobertura.ResponsabilidadCivil,
// 	FechaInicioVigencia = new DateTime(2023, 5, 8),
// 	FechaFinVigencia = new DateTime(2023, 9, 8)
// };

// Poliza poliza5 = new Poliza
// {
// 	VehiculoId = 2,
// 	ValorAsegurado = 6000,
// 	Franquicia = "1000",
// 	TipoCobertura = TipoCobertura.TodoRiesgo,
// 	FechaInicioVigencia = new DateTime(2023, 5, 8),
// 	FechaFinVigencia = new DateTime(2023, 10, 8)
// };

// Poliza poliza6 = new Poliza
// {
// 	VehiculoId = 2,
// 	ValorAsegurado = 12000,
// 	Franquicia = "2500",
// 	TipoCobertura = TipoCobertura.TodoRiesgo,
// 	FechaInicioVigencia = new DateTime(2023, 5, 8),
// 	FechaFinVigencia = new DateTime(2023, 11, 8)
// };

// Poliza poliza7 = new Poliza
// {
// 	VehiculoId = 2,
// 	ValorAsegurado = 9000,
// 	Franquicia = "1800",
// 	TipoCobertura = TipoCobertura.ResponsabilidadCivil,
// 	FechaInicioVigencia = new DateTime(2023, 5, 8),
// 	FechaFinVigencia = new DateTime(2023, 12, 8)
// };


// Poliza poliza8 = new Poliza
// {
// 	VehiculoId = 111,
// 	ValorAsegurado = 9000,
// 	Franquicia = "1800",
// 	TipoCobertura = TipoCobertura.ResponsabilidadCivil,
// 	FechaInicioVigencia = new DateTime(2023, 5, 8),
// 	FechaFinVigencia = new DateTime(2023, 12, 8)
// };

// agregarPoliza.Ejecutar(poliza8);
// Console.WriteLine($"Agregando Poliza {poliza8}");

// agregarPoliza.Ejecutar(poliza2);
// Console.WriteLine($"Agregando Poliza {poliza2}");

// agregarPoliza.Ejecutar(poliza3);
// Console.WriteLine($"Agregando Poliza {poliza3}");

// agregarPoliza.Ejecutar(poliza4);
// Console.WriteLine($"Agregando Poliza {poliza4}");

// agregarPoliza.Ejecutar(poliza5);
// Console.WriteLine($"Agregando Poliza {poliza5}");

// agregarPoliza.Ejecutar(poliza6);
// Console.WriteLine($"Agregando Poliza {poliza6}");

// agregarPoliza.Ejecutar(poliza7);
// Console.WriteLine($"Agregando Poliza {poliza7}");

// Console.WriteLine($"Agregando Poliza existente");

// agregarPoliza.Ejecutar(new Poliza 
// { 
// 	Id = 5,
// 	VehiculoId = 2,
// 	ValorAsegurado = 9000,
// 	Franquicia = "1800",
// 	TipoCobertura = TipoCobertura.ResponsabilidadCivil,
// 	FechaInicioVigencia = new DateTime(2023, 5, 8),
// 	FechaFinVigencia = new DateTime(2023, 12, 8)
// });


// Poliza poliza5Modificado = new Poliza 
// { 
// 	Id = 5,
// 	VehiculoId = 2,
// 	ValorAsegurado = 9000,
// 	Franquicia = "1800",
// 	TipoCobertura = TipoCobertura.ResponsabilidadCivil,
// 	FechaInicioVigencia = new DateTime(2023, 5, 8),
// 	FechaFinVigencia = new DateTime(2023, 12, 8)
// };

// Poliza poliza6Modificado = new Poliza 
// { 
// 	Id = 6, 
// 	VehiculoId = 2,
// 	ValorAsegurado = 9000,
// 	Franquicia = "1800",
// 	TipoCobertura = TipoCobertura.ResponsabilidadCivil,
// 	FechaInicioVigencia = new DateTime(2023, 5, 8),
// 	FechaFinVigencia = new DateTime(2023, 12, 8) 
// };

// Poliza polizaNoEncontrada = new Poliza 
// { 
// 	Id = 100,
// 	VehiculoId = 2,
// 	ValorAsegurado = 9000,
// 	Franquicia = "1800",
// 	TipoCobertura = TipoCobertura.ResponsabilidadCivil,
// 	FechaInicioVigencia = new DateTime(2023, 5, 8),
// 	FechaFinVigencia = new DateTime(2023, 12, 8) 
// };

// Console.WriteLine($"Modificando poliza con Id {poliza5Modificado.Id}");
// modificarPoliza.Ejecutar(poliza5Modificado);

// Console.WriteLine($"Modificando poliza con Id {poliza6Modificado.Id}");
// modificarPoliza.Ejecutar(poliza6Modificado);

// Console.WriteLine($"Modificando poliza con Id {polizaNoEncontrada.Id}");
// modificarPoliza.Ejecutar(polizaNoEncontrada);


// int idPoliza = 3;
// int idPolizaNoEncontrado = 100;

// Console.WriteLine($"Eliminando Poliza con Id {idPoliza}");
// eliminarPoliza.Ejecutar(idPoliza);

// Console.WriteLine($"Eliminando Poliza con Id {idPolizaNoEncontrado}");
// eliminarPoliza.Ejecutar(idPolizaNoEncontrado);

// Console.WriteLine("Lista de polizas");
// listarPolizas.Ejecutar().ForEach(poliza => Console.WriteLine(poliza));
