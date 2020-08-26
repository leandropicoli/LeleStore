using FluentValidator;
using FluentValidator.Validation;

namespace LeleStore.Domain.StoreContext.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string address)
        {
            Address = address;

            AddNotifications(new ValidationContract()
                .Requires()
                .IsEmail(Address, "Email", $"{Address} isn't a valid email")
            );
        }
        public string Address { get; private set; }

        public override string ToString()
        {
            return Address;
        }

    }
}