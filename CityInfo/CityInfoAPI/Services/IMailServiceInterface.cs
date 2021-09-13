namespace CityInfoAPI.Services
{
    public interface IMailServiceInterface
    {
        void Send(string subject, string message);
    }
}
