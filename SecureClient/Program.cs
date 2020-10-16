using System;

namespace SecureClient
{
    class Program
    {
        static void Main(string[] args)
        {
            AuthConfig config = AuthConfig.ReadFromJsonFile("appsettings.json");

            Console.WriteLine($"Authority: {config.Authority}");
        }
    }
}
