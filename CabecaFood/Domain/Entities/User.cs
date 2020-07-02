using Domain.DTO;
using Domain.Entities;
using Domain.FluentValidations;
using Domain.FluentValidations.HBSIS.Padawan.Produtos.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class User : BaseEntity
    {
        //Propriedades
        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public bool IsAdmin { get; protected set; }

        public int? AddressId { get; protected set; }
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
            return new UserValidation().CustomValidate(this);
        }

        public override bool IsInvalid()
        {
            return new UserValidation().CustomValidate(this).Any();
        }
    }
}
