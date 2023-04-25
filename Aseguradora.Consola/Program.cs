using Aseguradora.Aplicacion;
using Aseguradora.Repositorios;

// IRepositorioTitular repoTitular = new RepositorioTitularTXT();

// AgregarTitularUseCase agregarTitular = new AgregarTitularUseCase(repoTitular);

// agregarTitular.Ejecutar(new Titular {Nombre =  "Titular", CorreoElectronico="correo", DNI = "489", Direccion="Aaa", Telefono="9538945"});

// ListarTitularesUseCase listarTitular = new ListarTitularesUseCase(repoTitular);

// var res = listarTitular.Ejecutar();

// for(int i=0; i<res.Count; i++)
// {
//   Console.WriteLine(res[i]);
// }

//creamos los casos de uso inyectando dependencias
IRepositorioTitular repoTitular = new RepositorioTitularTXT();
AgregarTitularUseCase agregarTitular = new AgregarTitularUseCase(repoTitular);
ListarTitularesUseCase listarTitulares = new ListarTitularesUseCase(repoTitular);
ModificarTitularUseCase modificarTitular = new ModificarTitularUseCase(repoTitular);
EliminarTitularUseCase eliminarTitular = new EliminarTitularUseCase(repoTitular);
//Instanciamos un titular
Titular titular = new Titular {
	Nombre = "García Juan",
	DNI = "33123456",
	Direccion = "13 nro. 546",
	Telefono = "221-456456",
	CorreoElectronico = "joseGarcia@gmail.com"
};

Console.WriteLine($"Id del titular recién instanciado: {titular.Id}");
//agregamos el titular utilizando un método local
agregarTitular.Ejecutar(titular);
// //el id que corresponde al titular es establecido por el repositorio
// Console.WriteLine($"Id del titular una vez persistido: {titular.Id}");
// //agregamos unos titulares más
// agregarTitular.Ejecutar(new Titular("20654987", "Rodriguez", "Ana", ));
// agregarTitular.Ejecutar(new Titular("31456444", "Alconada", "Fermín", ));
// agregarTitular.Ejecutar(new Titular("12345654", "Perez", "Cecilia", ));
// //listamos los titulares utilizando un método local
listarTitulares.Ejecutar();
// //no debe ser posible agregar un titular con igual DNI que uno existente
// Console.WriteLine("Intentando agregar un titular con DNI 20654987");
// titular = new Titular(20654987, "Alvarez", "Alvaro");
// PersistirTitular(titular); //este titular no pudo persistirse
// //Entonces vamos a modificar el titular existente
// Console.WriteLine("Modificando el titular con DNI 20654987");
modificarTitular.Ejecutar(titular);
Console.WriteLine(listarTitulares.Ejecutar());
// //Eliminando un titular
// Console.WriteLine("Eliminando al titular con id 1");
eliminarTitular.Ejecutar(1);
