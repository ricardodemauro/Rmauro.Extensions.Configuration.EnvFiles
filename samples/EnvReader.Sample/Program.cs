// Load environment variables from .env file
using EnvReaderLoader;

EnvReader.Load(".env");

// Access the environment variables
string apiKey = Environment.GetEnvironmentVariable("API_KEY") ?? throw new ArgumentException("Missing API_KEY env variable");
string databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL") ?? throw new ArgumentException("Missing DATABASE_URL env variable");
string debug = Environment.GetEnvironmentVariable("DEBUG") ?? throw new ArgumentException("Missing DEBUG env variable");

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