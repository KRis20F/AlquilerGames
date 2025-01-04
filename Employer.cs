public class Employer : Client 
{
    public double Salary { get; set; }
    public string Category { get; set; }
    public Employer(string name, string surname, string email, string direction, int phone, bool isActive, LinkedList<Game> AllAlquileds, double salary, string category) 
    : base(name, surname, email, direction, phone, isActive, AllAlquileds){
        this.Salary = salary;
        this.Category = category;
    }

    public override bool Cancelation() => base.Cancelation();
    public override string GetAllInfo()
    {
        string result = base.GetAllInfo();
        return result += $"Category: {Category}, Salary: {Salary}";
    }
}