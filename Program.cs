using System;

namespace TiendaDeBarrio
{
    class Program
    {
        // =================================================================
        // DECLARACIÓN DE DATOS (ARREGLOS Y VARIABLES GLOBALES)
        // =================================================================

        // Arreglo para almacenar usuarios. Límite de 15. 
        // Columnas: 0:Identificación, 1:Nombres, 2:Apellidos, 3:Teléfono, 4:Dirección 
        static string[,] usuarios = new string[15, 5];
        static int cantidadUsuarios = 0;

        // Arreglo para almacenar artículos. Límite de 15. 
        // Columnas: 0:idArticulo, 1:Nombre, 2:Valor Unitario, 3:Cantidad en Stock 
        static object[,] articulos = new object[15, 4];
        static int cantidadArticulos = 0;
        static int proximoIdArticulo = 1; // ID de artículo autoincremental 

        // =================================================================
        // MÉTODO PRINCIPAL (PUNTO DE ENTRADA)
        // =================================================================
        static void Main(string[] args)
        {
            Console.Title = "Sistema de Gestión - Tienda de Barrio";
            // El ciclo principal del programa se basa en la autenticación.
            // Si el usuario sale del menú principal, vuelve a la pantalla de login. 
            while (true)
            {
                if (Autenticacion())
                {
                    MenuPrincipal();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Acceso denegado. Presione una tecla para intentar de nuevo...");
                    Console.ReadKey();
                }
            }
        }

        // =================================================================
        // MÓDULO DE AUTENTICACIÓN
        // =================================================================
        static bool Autenticacion()
        {
            Console.Clear();
            Console.WriteLine("===================================");
            Console.WriteLine("    CONTROL DE ACCESO AL SISTEMA   ");
            Console.WriteLine("===================================");

            // Credenciales por defecto. 
            const string UsuarioPorDefecto = "admin";
            const string ContrasenaPorDefecto = "12345";

            Console.Write("Ingrese su usuario: ");
            string usuarioIngresado = Console.ReadLine();

            Console.Write("Ingrese su contraseña: ");
            string contrasenaIngresada = Console.ReadLine();

            // Compara los datos ingresados con los datos por defecto.
            if (usuarioIngresado == UsuarioPorDefecto && contrasenaIngresada == ContrasenaPorDefecto)
            {
                // Si los datos coinciden, se muestra el Menú Principal. 
                return true;
            }
            return false;
        }

        // =================================================================
        // MENÚ PRINCIPAL
        // =================================================================
        static void MenuPrincipal()
        {
            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("===================================");
                Console.WriteLine("          MENÚ PRINCIPAL           ");
                Console.WriteLine("===================================");
                Console.WriteLine("1. Gestión de usuarios");
                Console.WriteLine("2. Gestión de artículos");
                Console.WriteLine("3. Gestión de ventas");
                Console.WriteLine("4. Salir del programa (Volver a login)");
                Console.Write("\nSeleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        MenuGestionUsuarios();
                        break;
                    case "2":
                        MenuGestionArticulos();
                        break;
                    case "3":
                        MenuGestionVentas();
                        break;
                    case "4":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("\nOpción no válida. Presione una tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // =================================================================
        // MÓDULO DE GESTIÓN DE USUARIOS
        // =================================================================
        static void MenuGestionUsuarios()
        {
            bool volver = false;
            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("===================================");
                Console.WriteLine("       MENÚ GESTIÓN DE USUARIOS      ");
                Console.WriteLine("===================================");
                Console.WriteLine("1. Ver lista de usuarios");
                Console.WriteLine("2. Nuevo usuario");
                Console.WriteLine("3. Editar información de usuario");
                Console.WriteLine("4. Salir de Gestión de usuarios (Menú Principal)");
                Console.Write("\nSeleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        VerListaUsuarios();
                        break;
                    case "2":
                        NuevoUsuario();
                        break;
                    case "3":
                        // Permite editar la información de un usuario. 
                        EditarUsuario();
                        break;
                    case "4":
                        // Si se elige 4, se mostrará el Menú principal. 
                        volver = true;
                        break;
                    default:
                        Console.WriteLine("\nOpción no válida. Presione una tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void VerListaUsuarios()
        {
            Console.Clear();
            Console.WriteLine("===================================");
            Console.WriteLine("        LISTA DE USUARIOS          ");
            Console.WriteLine("===================================");

            if (cantidadUsuarios == 0)
            {
                Console.WriteLine("No hay usuarios registrados.");
            }
            else
            {
                Console.WriteLine("{0,-15} {1,-20} {2,-20} {3,-15} {4,-30}", "Identificación", "Nombres", "Apellidos", "Teléfono", "Dirección");
                Console.WriteLine(new string('-', 100));
                for (int i = 0; i < cantidadUsuarios; i++)
                {
                    Console.WriteLine("{0,-15} {1,-20} {2,-20} {3,-15} {4,-30}", usuarios[i, 0], usuarios[i, 1], usuarios[i, 2], usuarios[i, 3], usuarios[i, 4]);
                }
            }
            Console.WriteLine("\nPresione una tecla para volver al menú de usuarios...");
            Console.ReadKey();
        }

        static void NuevoUsuario()
        {
            Console.Clear();
            Console.WriteLine("===================================");
            Console.WriteLine("          NUEVO USUARIO            ");
            Console.WriteLine("===================================");

            if (cantidadUsuarios >= 15)
            {
                // Mensaje si se intenta ingresar el usuario 16. 
                Console.WriteLine("No se permiten crear usuarios nuevos. Límite de 15 alcanzado.");
            }
            else
            {
                // Pide la información para crear el nuevo usuario. 
                Console.Write("Número de identificación: ");
                string id = Console.ReadLine();
                Console.Write("Nombres: ");
                string nombres = Console.ReadLine();
                Console.Write("Apellidos: ");
                string apellidos = Console.ReadLine();
                Console.Write("Teléfono: ");
                string telefono = Console.ReadLine();
                Console.Write("Dirección: ");
                string direccion = Console.ReadLine();

                // Almacena la información. 
                usuarios[cantidadUsuarios, 0] = id;
                usuarios[cantidadUsuarios, 1] = nombres;
                usuarios[cantidadUsuarios, 2] = apellidos;
                usuarios[cantidadUsuarios, 3] = telefono;
                usuarios[cantidadUsuarios, 4] = direccion;
                cantidadUsuarios++;

                Console.WriteLine("\n¡Usuario creado exitosamente!");
            }
            Console.WriteLine("\nPresione una tecla para volver...");
            Console.ReadKey();
        }

        static void EditarUsuario()
        {
            Console.Clear();
            Console.WriteLine("===================================");
            Console.WriteLine("        EDITAR USUARIO             ");
            Console.WriteLine("===================================");
            Console.Write("Ingrese la identificación del usuario a editar: ");
            string idBusqueda = Console.ReadLine();

            int indiceUsuario = -1;
            // Busca al usuario por su identificación. 
            for (int i = 0; i < cantidadUsuarios; i++)
            {
                if (usuarios[i, 0] == idBusqueda)
                {
                    indiceUsuario = i;
                    break;
                }
            }

            if (indiceUsuario == -1)
            {
                Console.WriteLine("\nUsuario no encontrado.");
            }
            else
            {
                Console.WriteLine("\nUsuario encontrado. ¿Qué dato desea editar?");
                Console.WriteLine("1. Nombres");
                Console.WriteLine("2. Apellidos");
                Console.WriteLine("3. Teléfono");
                Console.WriteLine("4. Dirección");
                Console.WriteLine("El número de identificación no se puede editar. ");
                Console.Write("\nSeleccione el dato a cambiar: ");
                string opcion = Console.ReadLine();

                Console.Write("Ingrese el nuevo valor: ");
                string nuevoValor = Console.ReadLine();

                switch (opcion)
                {
                    case "1": usuarios[indiceUsuario, 1] = nuevoValor; break;
                    case "2": usuarios[indiceUsuario, 2] = nuevoValor; break;
                    case "3": usuarios[indiceUsuario, 3] = nuevoValor; break;
                    case "4": usuarios[indiceUsuario, 4] = nuevoValor; break;
                    default: Console.WriteLine("Opción no válida."); break;
                }
                Console.WriteLine("\n¡Información actualizada!");
            }
            Console.WriteLine("\nPresione una tecla para volver...");
            Console.ReadKey();
        }

        // =================================================================
        // MÓDULO DE GESTIÓN DE ARTÍCULOS
        // =================================================================
        static void MenuGestionArticulos()
        {
            bool volver = false;
            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("===================================");
                Console.WriteLine("      MENÚ GESTIÓN DE ARTÍCULOS    ");
                Console.WriteLine("===================================");
                Console.WriteLine("1. Ver lista de artículos");
                Console.WriteLine("2. Nuevo artículo");
                Console.WriteLine("3. Editar información del artículo");
                Console.WriteLine("4. Salir de Gestión de Artículos (Menú Principal)"); 
                Console.Write("\nSeleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        VerListaArticulos();
                        break;
                    case "2":
                        // Permite crear un nuevo artículo. 
                        NuevoArticulo();
                        break;
                    case "3":
                        // Permite editar la información de un artículo. 
                        EditarArticulo();
                        break;
                    case "4":
                        // Si se elige 4, se mostrará el Menú principal. 
                        volver = true;
                        break;
                    default:
                        Console.WriteLine("\nOpción no válida. Presione una tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void VerListaArticulos()
        {
            Console.Clear();
            Console.WriteLine("===================================");
            Console.WriteLine("        LISTA DE ARTÍCULOS         ");
            Console.WriteLine("===================================");

            if (cantidadArticulos == 0)
            {
                Console.WriteLine("No hay artículos registrados.");
            }
            else
            {
                Console.WriteLine("{0,-10} {1,-30} {2,-15} {3,-10}", "ID", "Nombre", "Valor Unitario", "Stock");
                Console.WriteLine(new string('-', 65));
                for (int i = 0; i < cantidadArticulos; i++)
                {
                    Console.WriteLine("{0,-10} {1,-30} {2,-15:C} {3,-10}", articulos[i, 0], articulos[i, 1], articulos[i, 2], articulos[i, 3]);
                }
            }
            Console.WriteLine("\nPresione una tecla para volver al menú de artículos...");
            Console.ReadKey();
        }

        static void NuevoArticulo()
        {
            Console.Clear();
            Console.WriteLine("===================================");
            Console.WriteLine("          NUEVO ARTÍCULO           ");
            Console.WriteLine("===================================");

            if (cantidadArticulos >= 15)
            {
                // Mensaje si se intenta ingresar el artículo 16. 
                Console.WriteLine("No se permiten crear artículos nuevos. Límite de 15 alcanzado.");
            }
            else
            {
                // Pide la información para el nuevo artículo. 
                Console.Write("Nombre del artículo: ");
                string nombre = Console.ReadLine();
                Console.Write("Valor unitario: ");
                double valor = double.Parse(Console.ReadLine());
                Console.Write("Cantidad en stock: ");
                int stock = int.Parse(Console.ReadLine());

                // Almacena la información del artículo.
                // El ID se genera de forma incremental y automática. 
                articulos[cantidadArticulos, 0] = proximoIdArticulo;
                articulos[cantidadArticulos, 1] = nombre;
                articulos[cantidadArticulos, 2] = valor;
                articulos[cantidadArticulos, 3] = stock;

                cantidadArticulos++;
                proximoIdArticulo++;

                Console.WriteLine("\n¡Artículo creado exitosamente!");
            }
            Console.WriteLine("\nPresione una tecla para volver...");
            Console.ReadKey();
        }

        static void EditarArticulo()
        {
            Console.Clear();
            Console.WriteLine("===================================");
            Console.WriteLine("        EDITAR ARTÍCULO            ");
            Console.WriteLine("===================================");
            Console.Write("Ingrese el ID del artículo a editar: ");
            int idBusqueda = int.Parse(Console.ReadLine());

            int indiceArticulo = -1;
            // Busca el artículo por su ID.
            for (int i = 0; i < cantidadArticulos; i++)
            {
                if ((int)articulos[i, 0] == idBusqueda)
                {
                    indiceArticulo = i;
                    break;
                }
            }

            if (indiceArticulo == -1)
            {
                Console.WriteLine("\nArtículo no encontrado.");
            }
            else
            {
                Console.WriteLine("\nArtículo encontrado. ¿Qué dato desea editar?");
                Console.WriteLine("1. Nombre");
                Console.WriteLine("2. Valor Unitario");
                Console.WriteLine("3. Cantidad en Stock");
                Console.WriteLine("El ID del artículo no se puede editar. ");
                Console.Write("\nSeleccione el dato a cambiar: ");
                string opcion = Console.ReadLine();

                Console.Write("Ingrese el nuevo valor: ");
                string nuevoValor = Console.ReadLine();

                try
                {
                    switch (opcion)
                    {
                        case "1": articulos[indiceArticulo, 1] = nuevoValor; break;
                        case "2": articulos[indiceArticulo, 2] = double.Parse(nuevoValor); break;
                        case "3": articulos[indiceArticulo, 3] = int.Parse(nuevoValor); break;
                        default: Console.WriteLine("Opción no válida."); break;
                    }
                    Console.WriteLine("\n¡Información actualizada!");
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nError: El formato del valor ingresado no es correcto.");
                }
            }
            Console.WriteLine("\nPresione una tecla para volver...");
            Console.ReadKey();
        }

        // =================================================================
        // MÓDULO DE GESTIÓN DE VENTAS
        // =================================================================
        static void MenuGestionVentas()
        {
            bool volver = false;
            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("===================================");
                Console.WriteLine("         MENÚ GESTIÓN VENTAS       ");
                Console.WriteLine("===================================");
                Console.WriteLine("1. Generar factura");
                Console.WriteLine("2. Salir de Gestión Ventas (Menú Principal)");
                Console.Write("\nSeleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        GenerarFactura();
                        break;
                    case "2":
                        volver = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Presione una tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void GenerarFactura()
        {
            Console.Clear();
            Console.WriteLine("===================================");
            Console.WriteLine("         GENERAR FACTURA           ");
            Console.WriteLine("===================================");

            // Selección de usuario comprador
            Console.Write("Ingrese la identificación del comprador: ");
            string idComprador = Console.ReadLine();
            int indiceUsuario = -1;
            for (int i = 0; i < cantidadUsuarios; i++)
            {
                if (usuarios[i, 0] == idComprador)
                {
                    indiceUsuario = i;
                    break;
                }
            }

            if (indiceUsuario == -1)
            {
                Console.WriteLine("Usuario no encontrado. Presione una tecla para volver...");
                Console.ReadKey();
                return;
            }

            // Detalle de compra
            int maxProductos = 10;
            int[,] detalle = new int[maxProductos, 2]; // [0]=idArticulo, [1]=cantidad
            int cantidadProductos = 0;

            while (cantidadProductos < maxProductos)
            {
                Console.Write("\nIngrese ID del artículo a comprar (0 para terminar): ");
                int idArticulo = int.Parse(Console.ReadLine());
                if (idArticulo == 0) break;

                int indiceArticulo = -1;
                for (int i = 0; i < cantidadArticulos; i++)
                {
                    if ((int)articulos[i, 0] == idArticulo)
                    {
                        indiceArticulo = i;
                        break;
                    }
                }

                if (indiceArticulo == -1)
                {
                    Console.WriteLine("Artículo no encontrado.");
                    continue;
                }

                Console.Write("Cantidad a comprar: ");
                int cantidadDeseada = int.Parse(Console.ReadLine());

                int stockDisponible = (int)articulos[indiceArticulo, 3];
                if (cantidadDeseada > stockDisponible)
                {
                    Console.WriteLine("Stock insuficiente. Disponible: " + stockDisponible);
                    continue;
                }

                // Guardar en detalle
                detalle[cantidadProductos, 0] = idArticulo;
                detalle[cantidadProductos, 1] = cantidadDeseada;
                cantidadProductos++;

                // Descontar del stock
                articulos[indiceArticulo, 3] = stockDisponible - cantidadDeseada;

                Console.WriteLine("Artículo agregado.");
            }

            // Mostrar factura
            Console.Clear();
            Console.WriteLine("===================================");
            Console.WriteLine("            FACTURA                ");
            Console.WriteLine("===================================");

            Console.WriteLine("Cliente: {0} - {1} {2}", usuarios[indiceUsuario, 0], usuarios[indiceUsuario, 1], usuarios[indiceUsuario, 2]);
            Console.WriteLine("\n{0,-10} {1,-30} {2,-15} {3,-10} {4,-15}", "ID", "Nombre", "Valor Unitario", "Cantidad", "Subtotal");
            Console.WriteLine(new string('-', 85));

            double total = 0;
            for (int i = 0; i < cantidadProductos; i++)
            {
                int id = detalle[i, 0];
                int cantidad = detalle[i, 1];
                for (int j = 0; j < cantidadArticulos; j++)
                {
                    if ((int)articulos[j, 0] == id)
                    {
                        string nombre = (string)articulos[j, 1];
                        double valor = (double)articulos[j, 2];
                        double subtotal = valor * cantidad;
                        total += subtotal;
                        Console.WriteLine("{0,-10} {1,-30} {2,-15:C} {3,-10} {4,-15:C}", id, nombre, valor, cantidad, subtotal);
                        break;
                    }
                }
            }
            Console.WriteLine("\nTOTAL A PAGAR: {0:C}", total);
            Console.WriteLine("\nPresione una tecla para volver al menú de ventas...");
            Console.ReadKey();
        }
    }
}