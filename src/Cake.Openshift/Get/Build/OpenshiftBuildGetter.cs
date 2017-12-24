using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.Openshift.Get.Build.Data;

namespace Cake.Openshift.Get.Build
{
    /// <summary>
    /// The openshift get build command
    /// </summary>
    public sealed class OpenshiftBuildGetter : OpenshiftTool<OpenshiftBuildGetterSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenshiftBuildGetter"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        public OpenshiftBuildGetter(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        /// <summary>
        /// Runs the get build command
        /// </summary>
        /// <param name="buildName">The build name.</param>
        /// <param name="settings">The settings</param>
        /// <returns>The build.</returns>
        public OpenshiftBuild Run(string buildName, OpenshiftBuildGetterSettings settings)
        {
            Check.NotNullOrEmpty(buildName, nameof(buildName));
            Check.NotNull(settings, nameof(settings));

            return RunCommandAndParseJson<OpenshiftBuild>(settings, GetArguments(buildName));
        }

        private ProcessArgumentBuilder GetArguments(string buildName)
        {
            var builder = new ProcessArgumentBuilder();

            builder.Append("get");
            builder.Append("build");
            builder.Append(buildName);
            builder.AppendSwitch("--output", "=", "json");

            return builder;
        }
    }
}
