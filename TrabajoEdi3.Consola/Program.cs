using ConsoleTables;
using Microsoft.Extensions.DependencyInjection;
using System.Numerics;
using TrabajoEdi3.Datos.Repositorio;
using TrabajoEdi3.Datos.UnitOfWork;
using TrabajoEdi3.Entidades;
using TrabajoEdi3.Entidades.Dto;
using TrabajoEdi3.Entidades.Enums;
using TrabajoEdi3.Loc;
using TrabajoEdi3.Servicios.Interfaces;
using TrabajoEdi3.Servicios.Servicios;
using TrabajoEdi3.Shared;

internal class Program
{
    private static IServiceProvider? servicioProvider;
        static int pageSize = 15;  
    static void Main(string[] args)
    {
        servicioProvider = DI.ConfigurarServicios();
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Menú Principal:");
            Console.WriteLine("1. Listado de Marca ");
            Console.WriteLine("2. Ingresar una Marca ");
            Console.WriteLine("3. Borrar una Marca ");
            Console.WriteLine("4. Editar una Marca ");

            Console.WriteLine("===============================");
           
            Console.WriteLine("5. Listado de Deporte");
            Console.WriteLine("6. Ingreso de Deporte");
            Console.WriteLine("7. Eliminar Deporte");
            Console.WriteLine("8. Editar Deporte");
           
            Console.WriteLine("===============================");

            Console.WriteLine("9. Listado de Color");
            Console.WriteLine("10. Ingreso de Color");
            Console.WriteLine("11. Eliminar Color");
            Console.WriteLine("12. Editar Color");

            Console.WriteLine("===============================");

            Console.WriteLine("13. Listado de Genero");
            Console.WriteLine("14. Ingreso de Genero");
            Console.WriteLine("15. Eliminar Genero");
            Console.WriteLine("16. Editar Genero");

            Console.WriteLine("===============================");

            Console.WriteLine("17. Listado de Zapatilla");
            Console.WriteLine("18. Listado de Zapatilla Paginado");
            Console.WriteLine("20. Listado de Zapatilla Ordenado por Precio");
            Console.WriteLine("21. Listado de Zapatilla (con Dto)");
            Console.WriteLine("22. Agregar Zapatilla");
            Console.WriteLine("23 Eliminar Zapatilla");
            Console.WriteLine("24. Editar Zapatilla");
           
            Console.WriteLine("25. Listado Talles");

            Console.WriteLine("29. Asignar zapatilla por Talles");
            Console.WriteLine("30. Asignar Talles por Zapatilla");



            Console.WriteLine("x. Salir");

            Console.Write("Por favor, seleccione una opción: ");
            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Clear();
                    ListaDeMarca();
                    ConsoleExtension.EsperaEnter();
                    break;
                case "2":
                    InsertarMarca();
                    break;
                case "3":
                    BorrarMarca();
                    break;
                case "4":
                    EditarMarca();
                    break;

                case "5":
                    Console.Clear();
                    ListaDeDeporte();
                    ConsoleExtension.EsperaEnter();
                    break;
                case "6":
                    InsertarDeporte();
                    break;
                case "7":
                    BorrarDeporte();
                    break;
                case "8":
                    EditarDeporte();
                    break;

                case "9":
                    Console.Clear();
                    ListaDeColor();
                    ConsoleExtension.EsperaEnter();
                    break;
                case "10":
                    InsertarColor();
                    break;
                case "11":
                    BorrarColor();
                    break;
                case "12":
                    EditarColor();
                    break;

                case "13":
                    Console.Clear();
                    ListaDeGenero();
                    ConsoleExtension.EsperaEnter();
                    break;
                case "14":
                    InsertarGenero();
                    break;
                case "15":
                    BorrarGenero();
                    break;
                case "16":
                    EditarGenero();
                    break;

                    case "17":
                    ListadoZapatilla();
                    break;
                case "18":
                    ListadoZapatillaPaginado();
                    break;
               
                case "20":
                    ListadoZapatillaOrdenadoPorPrecio();
                    break;
                case "21":
                    ListadoZapatillaDto();
                    break;
                case "22":
                    AgregarZapatillasinTalles();
                    break;
                case "23":
                    EliminarZapatilla();
                    break;
                case "24":
                    EditarZapatilla();
                    break;

                case "25":
                    Console.Clear();
                    ListaDeTalles();
                    ConsoleExtension.EsperaEnter();
                    break;
            

                case "29":
                    CrearZapatillaconTalles();
                    break;
                case "30":
                    AsignarTalles();
                    break;





                case "x":
                    exit = true;
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                    break;
            }

            Console.WriteLine(); // Añade una línea en blanco para mejorar la legibilidad
        }

    }

    private static void AsignarTalles()
    {
        int stock = 0;
        
        // Inicializar el servicio y el talle
        var ZapatillaServicio = servicioProvider?.GetService<IServicioZapatilla>();
        var TallesServicio = servicioProvider?.GetService<ITallesServicio>();

        if (ZapatillaServicio == null || TallesServicio == null)
        {
            Console.WriteLine("Servicios no disponibles.");
            return;
        }

        // Obtener las zapatilla sin talle asignado
        var MostrarZapatilla = ZapatillaServicio.GetListaDto();
        if (MostrarZapatilla.Count > 0)
        {
            MostrarListaZapatilla(MostrarZapatilla);
            // Solicitar al usuario seleccionar una zapatilla de la lista
            var opcionzapatilla = ConsoleExtension.GetValidOptions("Seleccione una zapatilla:",
                MostrarZapatilla.Select(x => x.ZapatillaId.ToString()).ToList());
            AgregarTalles(ZapatillaServicio, TallesServicio, ZapatillaServicio.GetZapatillaPorId(int.Parse(opcionzapatilla)));
           

        }
        else
        {
            
        }
        ConsoleExtension.EsperaEnter();
    }

    private static void MostrarListaZapatilla(List<ZapatillaListDto> lista)
    {
        var tabla = new ConsoleTable("ID", "Descripcion", "Modelo", "Precio", "Marca","Deporte","Genero","Color");
        if (lista != null)
        {
            foreach (var item in lista)
            {
                tabla.AddRow(item.ZapatillaId, item.Description, item.Modelo, item.Precio, item.Marca,item.Deporte,item.Genero,item.Colores);
            }
            tabla.Options.EnableCount = false;
            tabla.Write();
            ConsoleExtension.EsperaEnter();
        }
    }

    private static void CrearZapatillaconTalles()
    {
        var servicioZapatilla = servicioProvider?.GetService<IServicioZapatilla>();
        var servicioTalles = servicioProvider?.GetService<ITallesServicio>();

        if (servicioZapatilla == null || servicioTalles == null)
        {
            Console.WriteLine("Servicios no disponibles.");
            return;
        }

        Zapatilla zapatilla = CrearZapatilla();
        AgregarTalles(servicioZapatilla, servicioTalles, zapatilla);
        var VALIDACION = ConsoleExtension.ReadBool("Quieres ingresar mas talles? (SI/NO) ");
        if (VALIDACION)
        {
            int talles = ConsoleExtension.ReadInt("Cuantos talles deseas ingresar ");
            for (int i = 0; i < talles; i++)
            {
                AgregarTalles(servicioZapatilla, servicioTalles, zapatilla);
            }

        }
        Console.WriteLine("Se Agrego las zapatilla con sus talles ");

       
    }

    private static void AgregarTalles(IServicioZapatilla? servicioZapatilla, ITallesServicio? servicioTalles, Zapatilla zapatilla)
    {
        int Stock = ConsoleExtension.ReadInt("Ingrese el Stock de la zapatilla: ");

        ListaDeTalles();
        var listaChar = servicioTalles
            .GetLista()
            .Select(x => x.TallesId.ToString()).ToList();
        var talleId = ConsoleExtension
            .GetValidOptions("Ingrese un ID de talle (N para nuevo):", listaChar);

        if (talleId == "N")
        {
            var numerotalle = ConsoleExtension.ReadInt("Talles:");


            Talles nuevotalle = new Talles
            {
                TallesNumbero = numerotalle,

            };
            servicioZapatilla.AsignarTalleAZapatilla(zapatilla, nuevotalle, Stock);
            
            
        }
        else
        {
            int talleIdInt = Convert.ToInt32(talleId);
            Talles? tallesExistente = servicioTalles
                .GetTallesPorId(talleIdInt, true);
            if (tallesExistente != null)
            {
                servicioZapatilla.AsignarTalleAZapatilla(zapatilla, tallesExistente, Stock);
               
            }
            else
            {
                Console.WriteLine("Talle no encontrado.");
            }
        }
    }

    private static void ListaDeTalles()
    {
        Console.Clear();
        Console.WriteLine("Listado de Talles");

        var servicio = servicioProvider?.GetService<ITallesServicio>();
        var lista = servicio?.GetLista();
        var tabla = new ConsoleTable("ID", "Talle");
        if (lista != null)
        {
            foreach (var item in lista)
            {
                tabla.AddRow(item.TallesId,
                    item.TallesNumbero);

            }
            tabla.Options.EnableCount = false;
            tabla.Write();

        }
    }
    //zapatilla/////////////
  

    private static void EditarZapatilla()
    {
        Console.Clear();
        var servicioZapatilla = servicioProvider?.GetService<IServicioZapatilla>();
        var servicioTalles = servicioProvider?.GetService<ITallesServicio>();

        // Obtener la zapatilla a editar
        var ZapatillaId = ConsoleExtension.ReadInt("Ingrese el ID de la zapatilla a editar:");
        var zapatilla = servicioZapatilla?.GetZapatillaPorId(ZapatillaId);

        if (zapatilla == null)
        {
            Console.WriteLine("zapatilla no encontrada.");
            return;
        }
        Console.WriteLine($"Zapatilla: {zapatilla.Description}");
        Console.WriteLine($"Marca: {zapatilla.Marca.MarcaNombre}");
        Console.WriteLine($"Color: {zapatilla.Colores.ColorName}");
        Console.WriteLine($"Deporte: {zapatilla.Deporte.NombreDeporte}");
        Console.WriteLine($"Genero: {zapatilla.Genero.GeneroNombre}");
        Console.WriteLine($"Precio: {zapatilla.Precio}");
        Console.WriteLine($"Modelo: {zapatilla.Modelo}");
        // Editar los detalles de la Zapatilla
        zapatilla.Description = ConsoleExtension.ReadString("Ingrese la nueva descripción:");
        zapatilla.Precio = ConsoleExtension.ReadDecimal("Ingrese el nuevo precio de costo:");
        zapatilla.Modelo = ConsoleExtension.ReadString("Ingrese el nuevo Modelo:");
        

        // Listar Talles existentes
        var listaTalles = servicioTalles?.GetLista();
        Console.WriteLine("Talle disponibles:");
        foreach (var talle in listaTalles)
        {
            Console.WriteLine($"ID: {talle.TallesId}, Numero: {talle.TallesNumbero}");
        }

        // Asignar un nuevo talle
        var tallesId = ConsoleExtension
            .ReadInt("Ingrese el ID del nuevo talle (0 para omitir):");

        try
        {
            if (tallesId == 0)
            {
                servicioZapatilla?.Editar(zapatilla, null);
            }
            else
            {
                servicioZapatilla?.Editar(zapatilla, tallesId);
            }

            Console.WriteLine("Zapatilla actualizada exitosamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

    }

    private static void EliminarZapatilla()
    {
        var servicio = servicioProvider?.GetService<IServicioZapatilla>();
        Console.Clear();
        Console.WriteLine("Ingreso Zapatilla a borrar");
        ListadoZapatilla();
        var listaChar = servicio?
                .GetLista()
                .Select(x => x.ZapatillaId.ToString()).ToList();
        var zapatillaId = ConsoleExtension
            .GetValidOptions("Ingrese un ID de Zapatilla:", listaChar);


        try
        {
            var zapatilla = servicio?.GetZapatillaPorId(Convert.ToInt32(zapatillaId));
            if (zapatilla != null)
            {
                if (servicio != null)
                {

                    servicio.Borrar(zapatilla.ZapatillaId);
                    Console.WriteLine("Registro borrado!!!");

                }

                else
                {
                    throw new Exception("Servicio no disponible");
                }
            }
            else
            {
                Console.WriteLine("zapatilla inexistente!!!");
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message); ;
        }
        Thread.Sleep(5000);
    }

    private static void AgregarZapatillasinTalles()
    {
        Console.Clear();
        var servicioZapatilla = servicioProvider?.GetService<IServicioZapatilla>();
        var zapatilla = CrearZapatilla();
        if (servicioZapatilla != null)
        {
            if (!servicioZapatilla.Existe(zapatilla))
            {
                servicioZapatilla.Guardar(zapatilla,null);
                Console.WriteLine("Zapatilla agregada!!!");
            }
            else
            {
                Console.WriteLine("Registro Duplicado!!!");
            }
        }
        else
        {
            Console.WriteLine("Error: El servicio de zapatilla es nulo.");
        }
        Thread.Sleep(2000);
    }

    private static Zapatilla CrearZapatilla()
    {
        var servicioMarca = servicioProvider?.GetService<IServicioMarca>();
        var servicioDeporte = servicioProvider?.GetService<IServicioDeporte>();
        var servicioGenero = servicioProvider?.GetService<IServicioGenero>();
        var servicioColor = servicioProvider?.GetService<IServicioColor>();


        Marca? marca;
        Deporte? deporte;
        Genero? genero;
        Color? color;

        Console.WriteLine("Agregar Zapatilla");
        var descripcion = ConsoleExtension.ReadString("Descripción:");

        ListaDeMarca();
        var listaChar = servicioMarca?.GetLista()
            .Select(x => x.MarcaId.ToString()).ToList();
        var marcaId = ConsoleExtension
            .GetValidOptions("Seleccione una Marca (N para nuevo):", listaChar);
        if (marcaId == "N")
        {
            marcaId = "0";
            Console.WriteLine("Ingreso de nuevo una Marca");
            var nombre = ConsoleExtension.ReadString("Ingrese descripción de Marca:");

            marca = new Marca()
            {
                MarcaId = 0,
                MarcaNombre = nombre
            };

        }
        else
        {
            marca = servicioMarca?
                .GetMarcaPorId(Convert.ToInt32(marcaId));

        }

        ListaDeDeporte();
        var listaDeporteChar = servicioDeporte?.GetLista()
            .Select(x => x.DeporteId.ToString()).ToList();
        var deporteId = ConsoleExtension.GetValidOptions("Seleccione un Deporte (N para nuevo):",
            listaDeporteChar);

        if (deporteId == "N")
        {
            deporteId = "0";
            Console.WriteLine("Ingreso de nuevo Deporte");
            var nombre = ConsoleExtension.ReadString("Ingrese descripción de Deporte:");

            deporte = new Deporte()
            {
                DeporteId = 0,
                NombreDeporte = nombre
            };

        }
        else
        {
           deporte = servicioDeporte?
                .GetDeportePorId(Convert.ToInt32(deporteId));
        }
        ListaDeGenero();
        var listaGeneroChar = servicioGenero?.GetLista()
           .Select(x => x.GeneroId.ToString()).ToList();
        var generoId = ConsoleExtension.GetValidOptions("Seleccione un Genero (N para nuevo):",
            listaDeporteChar);

        if (generoId == "N")
        {
            deporteId = "0";
            Console.WriteLine("Ingreso de nuevo Genero");
            var nombre = ConsoleExtension.ReadString("Ingrese descripción de Genero:");

            genero = new Genero()
            {
                GeneroId = 0,
                GeneroNombre = nombre
            };

        }
        else
        {
            genero = servicioGenero?
                 .GetGeneroPorId(Convert.ToInt32(generoId));
        }
        ListaDeColor();
        var listaColorChar = servicioColor?.GetLista()
           .Select(x => x.ColorId.ToString()).ToList();
        var colorId = ConsoleExtension.GetValidOptions("Seleccione un Color (N para nuevo):",
            listaColorChar);

        if (colorId == "N")
        {
            colorId = "0";
            Console.WriteLine("Ingreso de nuevo Color");
            var nombre = ConsoleExtension.ReadString("Ingrese descripción de Color:");

            color = new Color()
            {
                ColorId = 0,
                ColorName = nombre
            };

        }
        else
        {
          color = servicioColor?
                 .GetColorPorId(Convert.ToInt32(colorId));
        }



        var modelo = ConsoleExtension.ReadString("Ingrese un Modelo: ");
        var precio = ConsoleExtension
            .ReadDecimal("Ingrese un precio :", 1, 10000);
       

        var zapatilla = new Zapatilla()
        {
            Description = descripcion,
            MarcaId = Convert.ToInt32(marcaId),
            DeporteId = Convert.ToInt32(deporteId),
            GeneroId = Convert.ToInt32(generoId),
            ColoresId = Convert.ToInt32(colorId),


            Marca = marca,
            Deporte = deporte,
            Genero=genero,
            Colores=color,
            Modelo=modelo,
            Precio = precio,
            

        };
        return zapatilla;
    }

    private static void ListadoZapatillaDto()
    {
        Console.Clear();
        Console.WriteLine("Listado de Zapatilla");

        var servicio = servicioProvider?.GetService<IServicioZapatilla>();
        var lista = servicio?.GetListaDto();
        var tabla = new ConsoleTable("ID", "Marca", "Deporte", "Genero", "Color", "Descripcion", "Modelo", "Precio");
        if (lista != null)
        {
            foreach (var item in lista)
            {
                tabla.AddRow(item.ZapatillaId,
                    item.Marca,
                    item.Deporte,
                    item.Colores,
                    item.Genero,
                    item.Description,
                    item.Modelo,
                    item.Precio);
                    
            }
            tabla.Options.EnableCount = false;
            tabla.Write();
            Console.Read();



        }
    }

    private static void ListadoZapatillaOrdenadoPorPrecio()
    {
        Console.Clear();
        Console.WriteLine("Listado de Zapatilla Ordenada Por Precio");

        // Obtener la opción de ordenamiento del usuario
        var orden = ConsoleExtension.GetValidOptions("(A)Z (Z)A (1)2 (2)1:", new List<string> { "A", "Z", "1", "2" });


        // Obtener los servicios necesarios
        var servicio = servicioProvider?.GetService<IServicioZapatilla>();
        var servicioDeporte = servicioProvider?.GetService<IServicioDeporte>();
        var servicioColor = servicioProvider?.GetService<IServicioColor>();
        var servicioGenero = servicioProvider?.GetService<IServicioGenero>();
        var servicioMarca = servicioProvider?.GetService<IServicioMarca>();


        // Configurar paginación
        pageSize = ConsoleExtension.ReadInt("Ingrese la cantidad por página:", 10, 20);
        var recordCount = servicio?.GetCantidad() ?? 0;
        var pageCount = CalcularCantidadPaginas(recordCount, pageSize);

        // Inicializar filtros
        Deporte? deporte = null;
        Marca? marca = null;
        Color? color = null;
        Genero? genero = null;
        Console.WriteLine("Filtros");

        Console.WriteLine("Seleccione los filtros que desea aplicar (puede elegir varios separados por coma):");
        Console.WriteLine("(1) Deporte");
        Console.WriteLine("(2) Marca");
        Console.WriteLine("(3) Color");
        Console.WriteLine("(4) Genero");

        var filtrosSeleccionados = Console.ReadLine()?.Split(',').Select(f => f.Trim()).ToList();

        if (filtrosSeleccionados.Contains("1"))
        {
            var deporteId = ConsoleExtension.ReadInt("Ingrese el Id de Deporte:");
            deporte = servicioDeporte?.GetDeportePorId(deporteId);
        }

        if (filtrosSeleccionados.Contains("2"))
        {
            var marcaId = ConsoleExtension.ReadInt("Ingrese el Id de Marca:");
            marca = servicioMarca?.GetMarcaPorId(marcaId);
        }

        if (filtrosSeleccionados.Contains("3"))
        {
            var colorId = ConsoleExtension.ReadInt("Ingrese el Id de Color:");
            color = servicioColor?.GetColorPorId(colorId);
        }

        if (filtrosSeleccionados.Contains("4"))
        {
            var generoId = ConsoleExtension.ReadInt("Ingrese el Id de Genero:");
            genero = servicioGenero?.GetGeneroPorId(generoId);
        }

        for (int page = 0; page < pageCount; page++)
        {
            switch (orden)
            {
                case "A":
                    MostrarListaZapatillas(servicio?.GetListaPaginadaOrdenadaFiltrada(page, pageSize, Orden.AZ,deporte,marca,color,genero ));
                    break;
                case "Z":
                    MostrarListaZapatillas(servicio?.GetListaPaginadaOrdenadaFiltrada(page, pageSize, Orden.ZA, deporte, marca, color, genero));
                    break;
                case "1":
                    MostrarListaZapatillas(servicio?.GetListaPaginadaOrdenadaFiltrada(page, pageSize, Orden.MenorPrecio, deporte, marca, color, genero));
                    break;
                default:
                    MostrarListaZapatillas(servicio?.GetListaPaginadaOrdenadaFiltrada(page, pageSize, Orden.MayorPrecio, deporte, marca, color, genero));
                    break;
                    

            }

        }
    }

    private static void ListadoZapatillaPaginado()
    {
        Console.Clear();
        var servicio = servicioProvider?.GetService<IServicioZapatilla>();
        pageSize = ConsoleExtension.ReadInt("Ingrese la cantidad por página:", 10, 20);
        var recordCount = servicio?.GetCantidad() ?? 0;
        var pageCount = CalcularCantidadPaginas(recordCount, pageSize);

        for (int page = 0; page < pageCount; page++)
        {
            Console.Clear();
            Console.WriteLine("Listado Paginado");
            Console.WriteLine($"Página: {page + 1}");
            var listaPaginada = servicio?
                .GetListaPaginadaOrdenadaFiltrada(page, pageSize);
            MostrarListaZapatillas(listaPaginada);

        }
        Console.WriteLine("Fin del Listado");
    }

    private static void ListadoZapatilla()
    {
        Console.Clear();
        Console.WriteLine("Listado de Zapatillas");

        var servicio = servicioProvider?.GetService<IServicioZapatilla>();
        var recordCount = servicio?.GetCantidad() ?? 0;
        var pageCount = CalcularCantidadPaginas(recordCount, pageSize);
        for (int page = 0; page < pageCount; page++)
        {
            Console.Clear();
            Console.WriteLine("Listado de Zapatillas");
            Console.WriteLine($"Página: {page + 1}");
            var listaPaginada = servicio?
                .GetListaPaginadaOrdenadaFiltrada(page, pageSize);
            MostrarListaZapatillas(listaPaginada);
        }
    }

    private static void MostrarListaZapatillas(List<ZapatillaListDto>? lista)
    {
        var tabla = new ConsoleTable("ID", "Marca","Deporte","Genero","Color", "Descripcion", "Modelo", "Precio" );
        if (lista != null)
        {
            foreach (var item in lista)
            {
                tabla.AddRow(item.ZapatillaId, item.Marca, item.Deporte, item.Genero, item.Colores,item.Description,item.Modelo,item.Precio);
            }
            tabla.Options.EnableCount = false;
            tabla.Write();
            ConsoleExtension.EsperaEnter();
        }
    }

    private static int CalcularCantidadPaginas(int cantidadRegistros, int cantidadPorPagina)
    {
        if (cantidadRegistros < cantidadPorPagina)
        {
            return 1;
        }
        else if (cantidadRegistros % cantidadPorPagina == 0)
        {
            return cantidadRegistros / cantidadPorPagina;
        }
        else
        {
            return cantidadRegistros / cantidadPorPagina + 1;
        }
    }

    ///Aca emepieza genero////
    private static void EditarGenero()
    {
        Console.Clear();
        var servicio = servicioProvider?
            .GetService<IServicioGenero>();
        Console.WriteLine("Editar Genero");
        ListaDeGenero();
        var idEditar = ConsoleExtension.ReadInt("Ingrese el ID a editar:");
        var generoEnDb = servicio?.GetGeneroPorId(idEditar);
        if (generoEnDb != null)
        {
            Console.WriteLine($"Nombre anterior: {generoEnDb.GeneroNombre}");
            var nuevaDesc = ConsoleExtension.ReadString("Ingrese el nuevo nombre:");
            generoEnDb.GeneroNombre = nuevaDesc;
            servicio?.Guardar(generoEnDb);
            Console.WriteLine("genero editado!!!");
        }
        else
        {
            Console.WriteLine("genero inexistente!!!");
        }
        Thread.Sleep(2000);
    }

    private static void BorrarGenero()
    {
        Console.Clear();
        Console.WriteLine("Eliminar Genero");
        ListaDeGenero();
        var generoId = ConsoleExtension.ReadInt("Ingrese ID de Genero:");
        try
        {
            var servicio = servicioProvider?
                .GetService<IServicioGenero>();
            var genero = servicio?.GetGeneroPorId(generoId);
            if (genero != null)
            {
                if (servicio != null)
                {
                    if (!servicio.EstaRelacionado(genero))
                    {
                        servicio.Borrar(genero);
                        Console.WriteLine("Registro borrado!!!");

                    }
                    else
                    {
                        Console.WriteLine("Genero relacionado!!!\n Baja denegada");
                    }

                }
                else
                {
                    throw new Exception("Servicio no disponible");
                }
            }
            else
            {
                Console.WriteLine("Registro inexistente!!!");
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message); ;
        }
        Thread.Sleep(5000);
    }

    private static void InsertarGenero()
    {
        var servicio = servicioProvider?
            .GetService<IServicioGenero>();
        Console.Clear();
        Console.WriteLine("Tipos de Genero");
        var GeneroDescripcion = ConsoleExtension
            .ReadString("Ingrese una nueva Genero:");
        var genero = new Genero
        {
            GeneroNombre = GeneroDescripcion
        };
        if (servicio != null)
        {
            if (!servicio.Existe(genero))
            {
                servicio.Guardar(genero);
                Console.WriteLine("Genero agregado!!!");
            }
            else
            {
                Console.WriteLine("Genero existente!!!");
            }

        }
        else
        {
            Console.WriteLine("Servicio no disponible");
        }
        Thread.Sleep(2000);
    }

    private static void ListaDeGenero()
    {
        Console.WriteLine("Listado de Genero");
        var servicio = servicioProvider?
            .GetService<IServicioGenero>();
        var lista = servicio?.GetLista();
        var tabla = new ConsoleTable("ID", "GeneroNombre");
        if (lista != null)
        {
            foreach (var item in lista)
            {
                tabla.AddRow(item.GeneroId, item.GeneroNombre);
            }

        }
        tabla.Options.EnableCount = false;
        tabla.Write();
    }

    ///////////////////////////////////////////////////// ACA EMPIEZA Color ////////////////////////////

    private static void EditarColor()
    {
        Console.Clear();
        var servicio = servicioProvider?
            .GetService<IServicioColor>();
        Console.WriteLine("Editar Color");
        ListaDeColor();
        var idEditar = ConsoleExtension.ReadInt("Ingrese el ID a editar:");
        var colorEnDb = servicio?.GetColorPorId(idEditar);
        if (colorEnDb != null)
        {
            Console.WriteLine($"Nombre anterior: {colorEnDb.ColorName}");
            var nuevaDesc = ConsoleExtension.ReadString("Ingrese el nuevo nombre:");
            colorEnDb.ColorName = nuevaDesc;
            servicio?.Guardar(colorEnDb);
            Console.WriteLine("color editado!!!");
        }
        else
        {
            Console.WriteLine("color inexistente!!!");
        }
        Thread.Sleep(2000);
    }

    private static void BorrarColor()
    {
        Console.Clear();
        Console.WriteLine("Eliminar Color");
        ListaDeColor();
        var colorId = ConsoleExtension.ReadInt("Ingrese ID de Color:");
        try
        {
            var servicio = servicioProvider?
                .GetService<IServicioColor>();
            var color = servicio?.GetColorPorId(colorId);
            if (color != null)
            {
                if (servicio != null)
                {
                    if (!servicio.EstaRelacionado(color))
                    {
                        servicio.Borrar(color);
                        Console.WriteLine("Registro borrado!!!");

                    }
                    else
                    {
                        Console.WriteLine("Color relacionado!!!\n Baja denegada");
                    }

                }
                else
                {
                    throw new Exception("Servicio no disponible");
                }
            }
            else
            {
                Console.WriteLine("Registro inexistente!!!");
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message); ;
        }
        Thread.Sleep(5000);
    }

    private static void InsertarColor()
    {
        var servicio = servicioProvider?
              .GetService<IServicioColor>();
        Console.Clear();
        Console.WriteLine("Tipos de Color");
        var ColorDescripcion = ConsoleExtension
            .ReadString("Ingrese una nueva Color:");
        var color = new Color
        {
            ColorName = ColorDescripcion
        };
        if (servicio != null)
        {
            if (!servicio.Existe(color))
            {
                servicio.Guardar(color);
                Console.WriteLine("Color agregado!!!");
            }
            else
            {
                Console.WriteLine("Color existente!!!");
            }

        }
        else
        {
            Console.WriteLine("Servicio no disponible");
        }
        Thread.Sleep(2000);
    }

    private static void ListaDeColor()
    {
        Console.WriteLine("Listado de Color");
        var servicio = servicioProvider?
            .GetService<IServicioColor>();
        var lista = servicio?.GetLista();
        var tabla = new ConsoleTable("ID", "ColorNombre");
        if (lista != null)
        {
            foreach (var item in lista)
            {
                tabla.AddRow(item.ColorId, item.ColorName);
            }

        }
        tabla.Options.EnableCount = false;
        tabla.Write();
    }

    //////////////////////////////////////////777//aca empieza Marca////////////////////////////////////////////////////////////////////////////////
    private static void ListaDeMarca()
    {
        Console.WriteLine("Listado de Marca");
        var servicio = servicioProvider?
            .GetService<IServicioMarca>();
        var lista = servicio?.GetLista();
        var tabla = new ConsoleTable("ID", "MarcaNombre");
        if (lista != null)
        {
            foreach (var item in lista)
            {
                tabla.AddRow(item.MarcaId, item.MarcaNombre);
            }

        }
        tabla.Options.EnableCount = false;
        tabla.Write();
    }
    private static void EditarMarca()
    {
        Console.Clear();
        var servicio = servicioProvider?
            .GetService<IServicioMarca>();
        Console.WriteLine("Editar Marca");
        ListaDeMarca();
        var idEditar = ConsoleExtension.ReadInt("Ingrese el ID a editar:");
        var marcaEnDb = servicio?.GetMarcaPorId(idEditar);
        if (marcaEnDb != null)
        {
            Console.WriteLine($"Nombre anterior: {marcaEnDb.MarcaNombre}");
            var nuevaDesc = ConsoleExtension.ReadString("Ingrese el nuevo nombre:");
            marcaEnDb.MarcaNombre = nuevaDesc;
            servicio?.Guardar(marcaEnDb);
            Console.WriteLine("marca editado!!!");
        }
        else
        {
            Console.WriteLine("marca inexistente!!!");
        }
        Thread.Sleep(2000);
    }

    private static void BorrarMarca()
    {
        Console.Clear();
        Console.WriteLine("Eliminar Marca");
        ListaDeMarca();
        var marcaId = ConsoleExtension.ReadInt("Ingrese ID de Marca:");
        try
        {
            var servicio = servicioProvider?
                .GetService<IServicioMarca>();
            var marca = servicio?.GetMarcaPorId(marcaId);
            if (marca != null)
            {
                if (servicio != null)
                {
                    if (!servicio.EstaRelacionado(marca))
                    {
                        servicio.Borrar(marca);
                        Console.WriteLine("Registro borrado!!!");

                    }
                    else
                    {
                        Console.WriteLine("Marca relacionado!!!\n Baja denegada");
                    }

                }
                else
                {
                    throw new Exception("Servicio no disponible");
                }
            }
            else
            {
                Console.WriteLine("Registro inexistente!!!");
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message); ;
        }
        Thread.Sleep(5000);
    }

    private static void InsertarMarca()
    {
        var servicio = servicioProvider?
               .GetService<IServicioMarca>();
        Console.Clear();
        Console.WriteLine("Tipos de Marca");
        var MarcaDescripcion = ConsoleExtension
            .ReadString("Ingrese una nueva Marca:");
        var marca= new Marca
        {
            MarcaNombre = MarcaDescripcion
        };
        if (servicio != null)
        {
            if (!servicio.Existe(marca))
            {
                servicio.Guardar(marca);
                Console.WriteLine("Marca agregado!!!");
            }
            else
            {
                Console.WriteLine("Marca existente!!!");
            }

        }
        else
        {
            Console.WriteLine("Servicio no disponible");
        }
        Thread.Sleep(2000);
    }

    //////////////////////////////////////////////7//Aca es para Deporte/////////////////////////////////////////////////////////////

    private static void ListaDeDeporte()
    {
        Console.WriteLine("Listado de Deporte");
        var servicio = servicioProvider?
            .GetService<IServicioDeporte>();
        var lista = servicio?.GetLista();
        var tabla = new ConsoleTable("ID", "DeporteNombre");
        if (lista != null)
        {
            foreach (var item in lista)
            {
                tabla.AddRow(item.DeporteId, item.NombreDeporte);
            }

        }
        tabla.Options.EnableCount = false;
        tabla.Write();
    }

    private static void InsertarDeporte()
    {

        var servicio = servicioProvider?
               .GetService<IServicioDeporte>();
        Console.Clear();
        Console.WriteLine("Tipos de Deporte");
        var DeporteDescripcion = ConsoleExtension
            .ReadString("Ingrese una nueva Deporte:");
        var deporte = new Deporte
        {
            NombreDeporte = DeporteDescripcion
        };
        if (servicio != null)
        {
            if (!servicio.Existe(deporte))
            {
                servicio.Guardar(deporte);
                Console.WriteLine("Deporte agregado!!!");
            }
            else
            {
                Console.WriteLine("Deporte existente!!!");
            }

        }
        else
        {
            Console.WriteLine("Servicio no disponible");
        }
        Thread.Sleep(2000);
    }

    private static void EditarDeporte()
    {
        Console.Clear();
        var servicio = servicioProvider?
            .GetService<IServicioDeporte>();
        Console.WriteLine("Editar Deporte");
        ListaDeDeporte();
        var idEditar = ConsoleExtension.ReadInt("Ingrese el ID a editar:");
        var deporteEnDb = servicio?.GetDeportePorId(idEditar);
        if (deporteEnDb != null)
        {
            Console.WriteLine($"Nombre anterior: {deporteEnDb.NombreDeporte}");
            var nuevaDesc = ConsoleExtension.ReadString("Ingrese el nuevo nombre:");
            deporteEnDb.NombreDeporte = nuevaDesc;
            servicio?.Guardar(deporteEnDb);
            Console.WriteLine("deporte editado!!!");
        }
        else
        {
            Console.WriteLine("deporte inexistente!!!");
        }
        Thread.Sleep(2000);
    }

    private static void BorrarDeporte()
    {
        Console.Clear();
        Console.WriteLine("Eliminar Deporte");
        ListaDeDeporte();
        var deporteId = ConsoleExtension.ReadInt("Ingrese ID de Deporte:");
        try
        {
            var servicio = servicioProvider?
                .GetService<IServicioDeporte>();
            var deporte = servicio?.GetDeportePorId(deporteId);
            if (deporte != null)
            {
                if (servicio != null)
                {
                    if (!servicio.EstaRelacionado(deporte))
                    {
                        servicio.Borrar(deporte);
                        Console.WriteLine("Registro borrado!!!");

                    }
                    else
                    {
                        Console.WriteLine("Deporte relacionado!!!\n Baja denegada");
                    }

                }
                else
                {
                    throw new Exception("Servicio no disponible");
                }
            }
            else
            {
                Console.WriteLine("Registro inexistente!!!");
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message); ;
        }
     
    }
}