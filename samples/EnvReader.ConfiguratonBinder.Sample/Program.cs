// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;

Console.WriteLine("Hello, World!");

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true)
    .AddEnvFile()
    .Build();

// Access the environment variables
string apiKey = configuration["API_KEY"] ?? throw new ArgumentException("Missing API_KEY env variable");
string databaseUrl = configuration["DATABASE_URL"] ?? throw new ArgumentException("Missing DATABASE_URL env variable");
string debug = configuration["DEBUG"] ?? throw new ArgumentException("Missing DEBUG env variable");

// Output the values
Console.WriteLine($"API Key: {apiKey}");
Console.WriteLine($"Database URL: {databaseUrl}");
Console.WriteLine($"Debug Mode: {debug}");

// Check if debug mode is enabled
if (bool.TryParse(debug, out bool isDebug) && isDebug)
{
    Console.WriteLine("Debug mode is enabled.");
}
else
{
    Console.WriteLine("Debug mode is not enabled.");
}