namespace Auth.Domain.Entities;

public class Role
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public List<User> Users { get; set; } = new();
    public Role(string name)
    {
        Id = Guid.NewGuid();
        Name = name.ToUpper();
    }
}