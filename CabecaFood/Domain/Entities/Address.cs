using Domain.DTO;

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
        }
        public Address(string state, string city, string neighborhood, string street, string number)
        {
            State = state.FormatProps();
            City = city.FormatProps();
            Neighborhood = neighborhood.FormatProps();
            Street = street.FormatProps();
            Number = number.FormatProps();
        }

        //Metodos
        public void Update(AddressDTO address)
        {
            State = address.State.FormatProps();
            City = address.City.FormatProps();
            Neighborhood = address.Neighborhood.FormatProps();
            Street = address.Street.FormatProps();
            Number = address.Number.FormatProps();
        }
        public void Update(string state, string city, string neighborhood, string street, string number)
        {
            State = state.FormatProps();
            City = city.FormatProps();
            Neighborhood = neighborhood.FormatProps();
            Street = street.FormatProps();
            Number = number.FormatProps();
        }
    }
}
