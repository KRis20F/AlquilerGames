public class Game
{
    public string Title { get; set; }
    public string Tematic {get; set;}
    public int YearLanz { get; set; }
    public string Studio { get; set; }
    public int TimesRented { get; set; }
    public int Copys { get; set; }
    public bool IsAvailable { get; set; }

    public Game(string title, string tematic, int yearLanz , string studio , int timesRented, int copys, bool isAvailable)
    {
        this.Title = title;
        this.Tematic = tematic;
        this.YearLanz = yearLanz;
        this.Studio = studio;
        this.TimesRented = timesRented;
        this.Copys = copys;  
        this.IsAvailable = isAvailable; 
    }

     public static LinkedList<Game> GetDefaultGames()
    {
        return new LinkedList<Game>(new List<Game>
        {
            new Game("The Legend of Zelda: Breath of the Wild", "Aventura", 2017, "Nintendo", 0, 20, true),
            new Game("Super Mario Odyssey", "Plataformas", 2017, "Nintendo", 0, 15, true),
            new Game("Red Dead Redemption 2", "Acción/Aventura", 2018, "Rockstar Games", 0, 18, true),
            new Game("The Witcher 3: Wild Hunt", "RPG", 2015, "CD Projekt Red", 0, 22, true),
            new Game("Grand Theft Auto V", "Acción", 2013, "Rockstar Games", 0, 25, true),
            new Game("Dark Souls III", "RPG/Acción", 2016, "FromSoftware", 0, 30, true),
            new Game("Elden Ring", "RPG/Acción", 2022, "FromSoftware", 0, 50, true),
            new Game("Minecraft", "Sandbox", 2011, "Mojang Studios", 0, 100, true),
            new Game("Fortnite", "Battle Royale", 2017, "Epic Games", 0, 40, true),
            new Game("Hollow Knight", "Metroidvania", 2017, "Team Cherry", 0, 10, true),
            new Game("Resident Evil 4 Remake", "Terror/Acción", 2023, "Capcom", 0, 8, true),
            new Game("Cyberpunk 2077", "RPG", 2020, "CD Projekt Red", 0, 35, true),
            new Game("Assassin's Creed Valhalla", "Acción/Aventura", 2020, "Ubisoft", 0, 45, true),
            new Game("Horizon Zero Dawn", "Acción/Aventura", 2017, "Guerrilla Games", 0, 28, true),
            new Game("God of War Ragnarok", "Acción/Aventura", 2022, "Santa Monica Studio", 0, 38, true),
            new Game("Call of Duty: Modern Warfare II", "FPS", 2022, "Infinity Ward", 0, 60, true),
            new Game("Overwatch 2", "Shooter", 2022, "Blizzard Entertainment", 0, 55, true),
            new Game("Stardew Valley", "Simulación", 2016, "ConcernedApe", 0, 80, true),
            new Game("Pokemon Scarlet and Violet", "RPG", 2022, "Game Freak", 0, 65, true),
            new Game("Animal Crossing: New Horizons", "Simulación", 2020, "Nintendo", 0, 90, true)
        });
    }

    public string GameInfo()
    {
        return $"\n{Title} ({YearLanz}) - {Tematic} - {Studio} - Alquilado {TimesRented} veces - Copias disponibles: {Copys} - Disponible: {(IsAvailable ? "Sí" : "No")}\n";
    }
    
}