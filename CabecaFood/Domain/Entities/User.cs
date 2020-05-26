using Domain.DTO;
using Domain.Entities;

namespace Domain
{
    public class User : BaseEntity
    {
        //Propriedades
        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public bool IsAdmin { get; protected set; }

        //Construtores
        public User()
        {

        }

        public User(string name, string email, string password, bool isAdmin)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.IsAdmin = isAdmin;
        }

        public User(UserDTO user)
        {
            this.Name = user.Name;
            this.Email = user.Email;
            this.Password = user.Password;
            this.IsAdmin = user.IsAdmin;
        }

        //Metodos
        public void Update(string name, string email, string password, bool IsAdmin)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.IsAdmin = IsAdmin;
        }
        public void Update(UserDTO user)
        {
            this.Name = user.Name;
            this.Email = user.Email;
            this.Password = user.Password;
            this.IsAdmin = user.IsAdmin;
        }
    }
}
