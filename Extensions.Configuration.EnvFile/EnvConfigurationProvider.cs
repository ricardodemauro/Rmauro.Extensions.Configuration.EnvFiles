using Microsoft.Extensions.Configuration;
using System.IO;

namespace Extensions.Configuration.EnvFile
{
    internal class EnvConfigurationProvider : FileConfigurationProvider
    {
        public EnvConfigurationProvider(FileConfigurationSource source) : base(source)
        {
        }

        public override void Load(Stream stream)
        {
            foreach (var item in EnvReader.Load(stream))
            {
                Data[item.Key] = item.Value;
            }
        }
    }
}
