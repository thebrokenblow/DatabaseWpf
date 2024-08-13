namespace DatabaseWpf.Model;

public class User
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string Patronymic { get; set; }
    public required string Email { get; set; }
}