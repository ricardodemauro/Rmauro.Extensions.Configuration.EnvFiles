using Microsoft.Extensions.Configuration;

namespace Extensions.Configuration.EnvFile
{
public class EnvConfigurationSource : FileConfigurationSource
{
    public override IConfigurationProvider Build(IConfigurationBuilder builder)
    {
        EnsureDefaults(builder);

        return new EnvConfigurationProvider(this);
    }
}
}
