using FluentValidator;
using FluentValidator.Validation;

namespace LeleStore.Domain.StoreContext.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(FirstName, 3, "FirstName", "First Name must have at least 3 characteres")
                .HasMaxLen(FirstName, 40, "FirstName", "First Name must have less than 40 characteres")
                .HasMinLen(LastName, 3, "LastName", "Last Name must have at least 3 characteres")
                .HasMaxLen(LastName, 40, "LastName", "Last Name must have less than 40 characteres")
            );


        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}