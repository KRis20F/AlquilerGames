using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

public class Program
{ 
    private static LinkedList<Client> clients = new LinkedList<Client>();
    private static LinkedList<Game> gameCatalog = Game.GetDefaultGames();
    private static LinkedList<Employer> employers = new LinkedList<Employer>();

    public static void Main(string[] args)
    {
        Console.WriteLine($"Welcome to the game alquiler!");
        
        do{      

            SeeOptions();

            int option = Convert.ToInt32(Console.ReadLine()!);

            string result = Options(option);
            
            Console.WriteLine(result);
            
            if (option == 11) break;

        } while (true);


    }

    public static void SeeOptions() {
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("     1   =>     Registration of users");   
        Console.WriteLine("     2   =>     Cancellation of users");   
        Console.WriteLine("     3   =>     Registration of employers");   
        Console.WriteLine("     4   =>     Cancellation of employers");   
        Console.WriteLine("     5   =>     Registration for games");   
        Console.WriteLine("     6   =>     Cancellation for games");
        Console.WriteLine("     7   =>     View videogames available");
        Console.WriteLine("     8   =>     View videogames rented");
        Console.WriteLine("     9   =>     View videogames for users");
        Console.WriteLine("     10  =>     View videogames prested");
        Console.WriteLine("     11  =>     Search Client");
        Console.WriteLine("     12  =>     Salir del Programa"); 
        Console.WriteLine($"");
        Console.WriteLine($"Ingresa un numero para las opciones");
          
    }

    public static string Options(int option) => option switch{
        1 => AddUser(clients),
        2 => DeleteUser(clients),
        3 => AddEmployer(employers),
        4 => DeleteEmployer(employers),
        5 => AddNewGame(),
        6 => DeleteGame(),
        7 => SeeGameAvailable(),
        8 => SeeGameRented(),
        9 => SeeGameForClient(),
        10 => ListUsersWithBorrowedGames(),
        11 => SeeClients(),
        12 => "Hasta luego",
        _ => "Opción no válida" 
    };
    
    public static string AddUser(LinkedList<Client> clients){
        Console.Clear();

        Console.WriteLine("Añadir un nuevo cliente:");
        try
        {
            Console.Write("Nombre: ");
            string name = Console.ReadLine()!;

            Console.Write("Apellido: ");
            string surname = Console.ReadLine()!;

            Console.Write("Email: ");
            string email = Console.ReadLine()!;

            Console.Write("Dirección: ");
            string direction = Console.ReadLine()!;

            Console.Write("Teléfono: ");
            int phone = int.Parse(Console.ReadLine()!);

            LinkedList<Game> gamesAlquileds = new LinkedList<Game> ();

            clients.AddLast(new Client(name, surname, email,direction, phone, true, gamesAlquileds));
        
        }

        catch (FormatException)
        {
            Console.WriteLine("Error: Formato de entrada inválido. Inténtalo de nuevo.");
            return "Cliente no añadido debido a errores de entrada.";
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error inesperado: {ex.Message}");
            return "No se pudo añadir el cliente.";
        }

        return "Añadido cliente";
    }

    public static string DeleteUser(LinkedList<Client> clients){
        Console.Clear();
        Console.WriteLine("¿Quieres eliminar o dar de baja a un cliente? (Eliminar/Baja)");
        string option = Console.ReadLine()!;

        Console.WriteLine("Ingresa el nombre del cliente:");
        string name = Console.ReadLine()!;

        LinkedListNode<Client> current = clients.First;

        while (current != null)
        {
            if (current.Value.Name == name)
            {
                switch (option)
                {
                    case "Eliminar":
                        clients.Remove(current);
                        return $"Cliente '{name}' eliminado correctamente.";
                    case "Baja":
                        current.Value.Cancelation();
                        return $"Cliente '{name}' dado de baja correctamente.";
                    default:
                        return "Opción no válida.";
                }
            }

            current = current.Next!;
        }

        return $"Cliente '{name}' no encontrado.";
    }

    public static string AddEmployer (LinkedList<Employer> employers){
        Console.Clear();

        try
        {
            Console.Write("Nombre: ");
            string name = Console.ReadLine()!;

            Console.Write("Apellido: ");
            string surname = Console.ReadLine()!;

            Console.Write("Email: ");
            string email = Console.ReadLine()!;

            Console.Write("Dirección: ");
            string direction = Console.ReadLine()!;

            Console.Write("Teléfono: ");
            int phone = int.Parse(Console.ReadLine()!);

            LinkedList<Game> gamesAlquileds = new LinkedList<Game> ();

            Console.WriteLine("Cuanto ganara el empleado? ");
            double salary = double.Parse(Console.ReadLine()!);

            Console.WriteLine("Que Categoria trabajara el empleado? ");
            string category = Console.ReadLine()!;

            foreach (var employer in employers)
            {
                if (employer.Email == email && employer.Direction == direction && employer.Phone == phone) Console.WriteLine("El empleado ya existe");
            }
            
            employers.AddLast(new Employer(name, surname, email, direction, phone, false, gamesAlquileds, salary, category));

        }

        catch (FormatException)
        {
            return "Cliente no añadido debido a errores de entrada.";
        }
        catch (Exception ex)
        {
            return $"No se pudo añadir el cliente. {ex.Message}";
        }

        return "Empleado añadido con éxito.";
    }


    public static string DeleteEmployer(LinkedList<Employer> employers){
        Console.Clear();
        
        Console.WriteLine("¿Quieres eliminar o dar de baja al empleado? (Eliminar/Baja)");
        string option = Console.ReadLine()!;

        Console.WriteLine("Ingresa el nombre del empleado:");
        string name = Console.ReadLine()!;

        LinkedListNode<Employer> current = employers.First;

        while (current != null)
        {
            if (current.Value.Name == name)
            {

                switch (option)
                {
                    case "Eliminar":
                        employers.Remove(current);
                        return $"Cliente '{name}' eliminado correctamente.";
                    case "Baja":
                        current.Value.Cancelation();
                        return $"Cliente '{name}' dado de baja correctamente.";
                    default:
                        return "Opción no válida.";
                }
            }

            current = current.Next!;
        }

        return $"Cliente '{name}' no encontrado.";
    }

    public static string AddNewGame() {
        Console.Clear();
        Console.WriteLine($"Deseas agregar un nuevo juego o rentar un juego existente? \n( ingresa los numeros (1) Agregar/ (2) Rentar)");
        try
        {
            int option = Convert.ToInt32( Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.WriteLine($"Nombre del juego:");
                    string nameGame = Console.ReadLine()!;
                    foreach (var item in gameCatalog)
                    {
                        if (item.Title.Equals(nameGame)) throw new Exception("El juego ya esta en el catalogo");
                    }

                    Console.WriteLine($"Que Tematica tiene el juego:");
                    string theme = Console.ReadLine()!;

                    Console.WriteLine($"Año de lanzamiento");
                    int year = Convert.ToInt32(Console.ReadLine()!);
                    
                    Console.WriteLine($"Estudio quien lo desarrollo:");
                    string studio = Console.ReadLine()!;

                    Console.WriteLine($"Cuantas copias quieres agregar? ");
                    int copys = Convert.ToInt32(Console.ReadLine()!);

                    Game newGame = new Game(nameGame, theme, year, studio, 0, copys, true);

                    gameCatalog.AddLast(newGame); 

                    return $"EL juego {newGame.Title} añadido correctamente.";

                case 2:
                    System.Console.WriteLine("Ingresa tu nombre:");
                    string nameClient = Console.ReadLine()!;

                    Client existingClient = clients.FirstOrDefault(c => c.Name.Equals(nameClient, StringComparison.OrdinalIgnoreCase));

                    if (existingClient == null) {
                        Console.WriteLine($"El cliente '{nameClient}' no está registrado.");
                        foreach (var client in clients) {
                            Console.WriteLine($"\nCliente disponible: {client.Name}\n");
                        }
                        throw new Exception($"Cliente no encontrado.");
                    }

                    if (existingClient.IsActive) throw new Exception($"El cliente {nameClient} no esta activo");
                    
                    Console.WriteLine($"Ahora ingresa el nombre del juego que deseas rentar:");
                    string title = Console.ReadLine()!;

                    Game gameToRent = gameCatalog.FirstOrDefault(g => g.Title.Equals(title, StringComparison.OrdinalIgnoreCase))!;
                    if (gameToRent == null) throw new Exception($"El juego '{title}' no está en el catálogo.");
                    if (gameToRent.Copys <= 0) throw new Exception($"No hay copias disponibles de '{title}'.");
                
                    gameToRent.Copys--;
                    gameToRent.TimesRented++;
                    existingClient.AllAlquileds.AddLast(gameToRent);
                
                    

                    return $"El juego '{title}' ha sido rentado correctamente por el cliente '{existingClient.Name}'.";

                default:
                    break;
            }
        }
        catch (System.Exception ex){
            System.Console.WriteLine("Error inesperado "+ ex.Message);
        }
        
        return "Acciones Completadas"; 
    }

    public static string DeleteGame(){
        Console.Clear();
        Console.WriteLine("Deseas eliminar un juego o hacerlo inactivo?");
        Console.WriteLine("(Ingresa los números: (1) Eliminar / (2) Hacer Inactivo)");

        try {
            int option = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingresa el nombre del juego:");
            string gameName = Console.ReadLine()!;

            Game gameToModify = gameCatalog.FirstOrDefault(g => g.Title.Equals(gameName, StringComparison.OrdinalIgnoreCase))!;
            if (gameToModify == null) throw new Exception($"El juego '{gameName}' no está en el catálogo.");

            switch (option) {
                case 1:
                    gameCatalog.Remove(gameToModify);
                    return $"El juego '{gameName}' ha sido eliminado del catálogo.";

                case 2:
                    gameToModify.IsAvailable = false;
                    return $"El juego '{gameName}' ahora está marcado como inactivo.";

                default:
                    return "Opción inválida. No se realizó ninguna acción.";
            }
        } catch (Exception ex) {
            return $"Error inesperado: {ex.Message}";
        }
    }

    

    public static string SeeGameAvailable() {
        string gameResult = "";
        foreach (var games in gameCatalog)
        {
            if (!games.IsAvailable || games.Copys < 0) gameResult += $" El juego {games.Title} no está disponible";
            gameResult += $"{games.GameInfo()}";
        }
        return gameResult;
    }

    public static string SeeGameRented() {
        string gameResult = "";


        foreach (var game in gameCatalog)
        {
            foreach (var client in clients)
            {
                if (game.TimesRented < 0) return $"El juego {game.Title} no ha sido alquilado nunca";
                gameResult += $"El juego {game.Title} ha sido rentado {game.TimesRented} veces\nY Rentado por {client.Name}";
            }
        }

        return gameResult;
    }

    public static string SeeGameForClient() {
        Console.Clear();
        Console.WriteLine($"Ingresa al cliente para mostrar su biblioteca");
        try
        {
            string name = Console.ReadLine()!;

            Client client = clients.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            
            if (client == null) return $"El cliente '{name}' no está registrado.";
            
            if (client.AllAlquileds.Count < 0) return $"El cliente {name} no ha alquilado ningún juego";

            string gameList = "Juegos alquilados por el cliente:\n";

            foreach (var game in client.AllAlquileds) gameList += $"- {game.Title}\n";

            return gameList;

        }
        catch (System.Exception)
        {
            
            throw;
        }
    }

    public static string ListUsersWithBorrowedGames() {
    Console.Clear();
    Console.WriteLine("Usuarios con juegos prestados:\n");

    try {

        var usersWithGames = clients.Where(c => c.AllAlquileds.Count > 0).ToList();

        if (usersWithGames.Count == 0) {
            return "No hay usuarios con juegos prestados.";
        }

        string result = "";

        foreach (var client in usersWithGames) {
            result += $"Cliente: {client.Name}\n";
            result += "Juegos alquilados:\n";

            foreach (var game in client.AllAlquileds) {
                result += $"- {game.Title}\n";
            }

            result += "\n";
        }

        return result;
    } catch (Exception ex) {
        return $"Ocurrió un error al listar los usuarios con juegos prestados: {ex.Message}";
    }
}


    public static string SeeClients() {
        Console.Clear();
        Console.WriteLine("Ingresa el nombre del cliente para ver sus detalles:");
        try{

            string name = Console.ReadLine()!;

            Client client = clients.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (client == null) return $"El cliente '{name}' no está registrado.";

            Console.WriteLine("Detalles del cliente:");
            Console.WriteLine(client.GetAllInfo());

            return "Información mostrada correctamente."; ;
        }
        catch (System.Exception)
        {
            throw;
        }   
    }

    



}

