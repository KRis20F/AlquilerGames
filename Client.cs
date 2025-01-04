public class Client
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Direction { get; set; }
    public int Phone { get; set; }
    public bool IsActive { get; set; }
    public LinkedList<Game> AllAlquileds { get; set; }
    

    public Client(string name, string surname, string email, string direction, int phone, bool isActive,LinkedList<Game> AllAlquileds){
        this.Name = name;
        this.Surname = surname;
        this.Email = email;
        this.Direction = direction;
        this.Phone = phone;
        this.IsActive = isActive;
        this.AllAlquileds = AllAlquileds;
    }

    public int GetAlquileds() => AllAlquileds.Count;
    public virtual bool Cancelation() => IsActive = true;
    public void AddGame(Game game)
    {
        AllAlquileds.AddLast(game); 
        game.TimesRented++;         
    }

    public virtual string GetAllInfo() {
        var result = $"{Name} - {Surname} - {Email} - {Direction} - {Phone} - El cliente esta activo? {(IsActive ? "No" : "Si")}";
        Console.WriteLine($"Tienes {GetAlquileds()} juegos en tu bliblioteca");
        foreach (var gamesClient in AllAlquileds) result += $"\n{gamesClient}";
        return result;
    }
}