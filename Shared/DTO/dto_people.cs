namespace SharedProject.DTO;

public class dto_people
{
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public int Age { get; set; }

    public string GetFullname()
    {
        if (Firstname == null || Lastname == null)
            return "Not a valid person";
        if (Firstname == "" || Lastname == "")
            return "Not a valid person";
        return Firstname + " " + Lastname;
    }
}
