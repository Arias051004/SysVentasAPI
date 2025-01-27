namespace EntitiesInterface.Users
{
    public interface IUser
    {
        int IdUser { get; set; }
        string Name { get; set; }
        string LastName { get; set; }
        string Number { get; set; }
        string Dni { get; set; }
        string Email { get; set; }
        bool IsEnabled { get; set; }
    }
}