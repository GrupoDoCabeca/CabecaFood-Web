using Domain.DTO;
using Domain.FluentValidations.HBSIS.Padawan.Produtos.Domain;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Address : BaseEntity
    {
        //Propriedades
        public string State { get; protected set; }
        public string City { get; protected set; }
        public string Neighborhood { get; protected set; }
        public string Street { get; protected set; }
        public string Number { get; protected set; }

        public int UserId { get; protected set; }
        public virtual User User { get; protected set; }

        //Construtores
        public Address()
        {

        }
        public Address(AddressDTO address)
        {
            State = address.State.FormatProps();
            City = address.City.FormatProps();
            Neighborhood = address.Neighborhood.FormatProps();
            Street = address.Street.FormatProps();
            Number = address.Number.FormatProps();
            UserId = address.UserId;
        }

        //Metodos
        public void Update(AddressDTO address)
        {
            State = address.State.FormatProps();
            City = address.City.FormatProps();
            Neighborhood = address.Neighborhood.FormatProps();
            Street = address.Street.FormatProps();
            Number = address.Number.FormatProps();
            UserId = address.UserId;
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
