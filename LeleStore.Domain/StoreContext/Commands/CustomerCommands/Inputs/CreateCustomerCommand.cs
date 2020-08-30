using FluentValidator;
using FluentValidator.Validation;
using LeleStore.Shared.Commands;

namespace LeleStore.Domain.StoreContext.Commands.CustomerCommands.Inputs
{
    public class CreateCustomerCommand : Notifiable, ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(FirstName, 3, "FirstName", "First Name must have at least 3 characteres")
                .HasMaxLen(FirstName, 40, "FirstName", "First Name must have length less than 40 characteres")
                .HasMinLen(LastName, 3, "LastName", "Last Name must have at least 3 characteres")
                .HasMaxLen(LastName, 40, "LastName", "Last Name must have length less than 40 characteres")
                .IsEmail(Email, "Email", $"{Email} isn't a valid email")
                .HasLen(Document, 11, "Document", "Document must have 11 characteres")
            );

            return IsValid;
        }
    }
}