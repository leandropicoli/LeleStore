using LeleStore.Domain.StoreContext.Services;

namespace LeleStore.Tests.Fakes
{
    public class FakeEmailService : IEmailService
    {
        public void Send(string to, string from, string subject, string body)
        {

        }
    }
}