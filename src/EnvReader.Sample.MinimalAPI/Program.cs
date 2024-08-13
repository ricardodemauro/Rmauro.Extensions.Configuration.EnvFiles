var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvFile();

var app = builder.Build();

app.MapGet("/", (IConfiguration configuration) =>
{
    // Access the environment variables
    string apiKey = configuration["API_KEY"] ?? throw new ArgumentException("Missing API_KEY env variable");
    string databaseUrl = configuration["DATABASE_URL"] ?? throw new ArgumentException("Missing DATABASE_URL env variable");
    string debug = configuration["DEBUG"] ?? throw new ArgumentException("Missing DEBUG env variable");

    // Output the values
    Console.WriteLine($"API Key: {apiKey}");
    Console.WriteLine($"Database URL: {databaseUrl}");
    Console.WriteLine($"Debug Mode: {debug}");

    return new { apiKey, databaseUrl, debug };
});

app.Run();
