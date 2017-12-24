using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Newtonsoft.Json;

namespace Cake.Openshift
{
    /// <summary>
    /// Base class for all Openshift related tools.
    /// </summary>
    /// <typeparam name="TSettings">The settings type.</typeparam>
    public abstract class OpenshiftTool<TSettings> : Tool<TSettings> where TSettings : OpenshiftSettings
    {
        private static readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenshiftTool{TSettings}"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        protected OpenshiftTool(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools) : base(fileSystem, environment, processRunner, tools)
        {
        }

        /// <summary>
        /// Gets the name of the tool.
        /// </summary>
        /// <returns>The name of the tool.</returns>
        protected sealed override string GetToolName() => "Openshift CLI";

        /// <summary>
        /// Gets the possible names of the tool executable.
        /// </summary>
        /// <returns>The tool executable name.</returns>
        protected sealed override IEnumerable<string> GetToolExecutableNames() => new[] { "oc.exe", "oc" };

        /// <summary>
        /// Runs the openshift cli command using the specified settings and arguments.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="builder">The arguments.</param>
        protected void RunCommand(TSettings settings, ProcessArgumentBuilder builder)
        {
            AppendCommonArguments(builder, settings);

            Run(settings, builder);
        }

        /// <summary>
        /// Runs the openshift cli command using the specified settings and arguments.
        /// </summary>
        /// <typeparam name="T">The type to parse the output text as.</typeparam>
        /// <param name="settings">The settings.</param>
        /// <param name="builder">The arguments.</param>
        /// <returns>The parsed output text.</returns>
        protected T RunCommandAndParseJson<T>(TSettings settings, ProcessArgumentBuilder builder)
        {
            AppendCommonArguments(builder, settings);

            var jsonString = string.Empty;
            Run(settings, builder, new ProcessSettings { RedirectStandardOutput = true },
                process => jsonString = string.Join("\n", process.GetStandardOutput()));

            return JsonConvert.DeserializeObject<T>(jsonString, _jsonSerializerSettings);
        }

        /// <summary>
        /// Adds common commandline arguments.
        /// </summary>
        /// <param name="builder">Process argument builder to update.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>Returns <see cref="ProcessArgumentBuilder"/> updated with common commandline arguments.</returns>
        private ProcessArgumentBuilder AppendCommonArguments(ProcessArgumentBuilder builder, TSettings settings)
        {
            if (!string.IsNullOrEmpty(settings.Namespace))
            {
                builder.AppendSwitch("--namespace", "=", settings.Namespace);
            }

            return builder;
        }
    }
}
