using Microsoft.Extensions.Configuration;

namespace Rmauro.Extensions.Configuration.Env
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
