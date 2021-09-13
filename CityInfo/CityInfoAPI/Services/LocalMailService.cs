using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace CityInfoAPI.Services
{
    public class LocalMailService : IMailServiceInterface 
    {
        private readonly IConfiguration configuration;

        public LocalMailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void Send(string subject, string message)
        {
            Debug.WriteLine($"Mail from {configuration["mailSettings:mailfromAddress"]} to {configuration["mailSettings:mailToAddress"]}, with LocalMailService.");
            Debug.WriteLine($"Subject: {subject}");
            Debug.WriteLine($"Message: {message}");
        }
    }
}
