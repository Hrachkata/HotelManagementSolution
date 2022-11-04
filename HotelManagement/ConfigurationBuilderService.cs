namespace HotelManagement
{
    public class ConfigurationBuilderService
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddUserSecrets<Program>()
            .Build();

        public string GetSendGridApiKey()
        {
            return configuration["SendGridApiKey"];
        }

    }
}
