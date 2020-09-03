using LeleStore.Domain.StoreContext.Enums;
using LeleStore.Shared.Entities;

namespace LeleStore.Domain.StoreContext.Entities
{
    public class Address : Entity
    {
        public Address(string street, string number, string complement, string city, string district, string state, string country, string zipCode, EAddressType type)
        {
            Street = street;
            Number = number;
            Complement = complement;
            City = city;
            District = district;
            State = state;
            Country = country;
            ZipCode = zipCode;
            Type = type;
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string City { get; private set; }
        public string District { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
        public EAddressType Type { get; private set; }

        public override string ToString()
        {
            return $"{Street}, {Number} - {City}/{State}";
        }
    }
}