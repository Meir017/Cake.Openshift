using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Openshift.StartBuild
{
    /// <summary>
    /// The openshift start-build command
    /// </summary>
    public class OpenshiftBuildStarter : OpenshiftTool<OpenshiftBuildStarterSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenshiftBuildStarter"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tools locator.</param>
        public OpenshiftBuildStarter(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        /// <summary>
        /// Run the start-build command
        /// </summary>
        /// <param name="buildConfig">The build config name.</param>
        /// <param name="settings">The settings.</param>
        public void Run(string buildConfig, OpenshiftBuildStarterSettings settings)
        {
            Check.NotNull(settings, nameof(settings));
            Check.NotNullOrEmpty(buildConfig, nameof(buildConfig));

            RunCommand(settings, GetArguments(buildConfig, settings));
        }

        private ProcessArgumentBuilder GetArguments(string buildConfig, OpenshiftBuildStarterSettings settings)
        {
            var builder = new ProcessArgumentBuilder();

            builder.Append("start-build");
            builder.Append(buildConfig);

            if (!string.IsNullOrEmpty(settings.Commit))
            {
                builder.AppendSwitch("--commit", "=", settings.Commit);
            }

            if (settings.Follow)
            {
                builder.Append("--follow");
            }

            if (settings.Wait)
            {
                builder.Append("--wait");
            }

            return builder;
        }
    }
}
