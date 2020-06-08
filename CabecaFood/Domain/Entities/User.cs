using Domain.DTO;
using Domain.Entities;
using Domain.FluentValidations.HBSIS.Padawan.Produtos.Domain;
using System.Collections.Generic;

namespace Domain
{
    public class User : BaseEntity
    {
        //Propriedades
        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public bool IsAdmin { get; protected set; }

        public int AddressId { get; protected set; }
        public virtual Address Address { get; protected set; }

        public ICollection<Order> Orders { get; protected set; }

        //Construtores
        public User()
        {

        }

        public User(UserDTO user)
        {
            this.Name = user.Name;
            this.Email = user.Email;
            this.Password = user.Password;
            this.IsAdmin = user.IsAdmin;
            this.AddressId = user.AddressId;
        }

        //Metodos
        public void Update(UserDTO user)
        {
            this.Name = user.Name;
            this.Email = user.Email;
            this.Password = user.Password;
            this.IsAdmin = user.IsAdmin;
            this.AddressId = user.AddressId;
        }

        public override HashSet<Error> GetErrors()
        {
            throw new System.NotImplementedException();
        }

        public override bool IsInvalid()
        {
            throw new System.NotImplementedException();
        }
    }
}
