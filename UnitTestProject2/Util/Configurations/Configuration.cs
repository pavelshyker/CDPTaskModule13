using System.Configuration;

namespace TestWebProject.Webdriver
{
    public class Configuration
    {
        public static string GetEnviromentVar(string var, string defaultValue)
        {
            return ConfigurationManager.AppSettings[var] ?? defaultValue;
        }

        public static string ElementTimeout => GetEnviromentVar("ElementTimeout", "30");

        public static string Browser => GetEnviromentVar("Browser", "Chrome");

        public static string BaseUrl => GetEnviromentVar("BaseUrl", "https://www.mail.ru");

        public static string RandomEmailServiceUrl
        => GetEnviromentVar("RandomEmailServiceUrl", "https://10minutemail.net/");
    }
}

