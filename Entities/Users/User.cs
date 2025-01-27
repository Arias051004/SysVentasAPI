using EntitiesInterface.Users;
using System.Runtime.Serialization;

namespace Entities.Users
{
    [Serializable]
    public class User : IUser, ISerializable
    {
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Number { get; set; }
        public string Dni { get; set; }
        public string Email { get; set; }
        public bool IsEnabled { get; set; }

        public User() { }

        public User(IUser client)
        {
            IdUser = client.IdUser;
            Name = client.Name;
            LastName = client.LastName;
            Number = client.Number;
            Dni = client.Dni;
            Email = client.Email;
            IsEnabled = client.IsEnabled;
        }

        public User(SerializationInfo info, StreamingContext context)
        {
            IdUser = info.GetInt32("IdUser");
            Name = info.GetString("Name");
            LastName = info.GetString("LastName");
            Number = info.GetString("Number");
            Dni = info.GetString("Dni");
            Email = info.GetString("Email");
            IsEnabled = info.GetBoolean("IsEnabled");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("IdUser", IdUser);
            info.AddValue("Name", Name);
            info.AddValue("LastName", LastName);
            info.AddValue("Number", Number);
            info.AddValue("Dni", Dni);
            info.AddValue("Email", Email);
            info.AddValue("IsEnabled", IsEnabled);
        }
    }
}
