using System.Collections.Generic;
using System.IO;

namespace Extensions.Configuration.EnvFile
{
    internal static class EnvReader
{
    public static IEnumerable<KeyValuePair<string, string>> Load(Stream stream)
    {
        StreamReader reader = new StreamReader(stream);

        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();

            if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                continue; // Skip empty lines and comments

            var parts = line.Split('=', 2);
            if (parts.Length != 2)
                continue; // Skip lines that are not key-value pairs

            var key = parts[0].Trim();
            var value = parts[1].Trim();

            yield return new KeyValuePair<string, string>(key, value);
        }
    }
}
}