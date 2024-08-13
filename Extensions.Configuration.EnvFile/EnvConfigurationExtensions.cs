using Extensions.Configuration.EnvFile;
using Microsoft.Extensions.FileProviders;
using System;

namespace Microsoft.Extensions.Configuration
{
    public static class EnvConfigurationExtensions
    {
        public static IConfigurationBuilder AddEnvFile(
            this IConfigurationBuilder builder,
            string path = ".env",
            bool optional = false,
            bool reloadOnChange = true)
        {
            return AddEnvFile(builder, path: path, optional: optional, reloadOnChange: reloadOnChange, provider: null);
        }

        public static IConfigurationBuilder AddEnvFile(
            this IConfigurationBuilder builder,
            IFileProvider provider,
            string path,
            bool optional,
            bool reloadOnChange)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            if (string.IsNullOrEmpty(path))
                throw new ArgumentException("invalid path", nameof(path));

            return builder.AddEnvFile(s =>
            {
                s.FileProvider = provider;
                s.Path = path;
                s.Optional = optional;
                s.ReloadOnChange = reloadOnChange;
                s.ResolveFileProvider();
            });
        }

        public static IConfigurationBuilder AddEnvFile(
            this IConfigurationBuilder builder,
            Action<EnvConfigurationSource> configureSource)
            => builder.Add(configureSource);
    }
}
