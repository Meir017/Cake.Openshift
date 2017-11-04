using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Openshift.Delete
{
    /// <summary>
    /// The openshift delete command
    /// </summary>
    public class OpenshiftDeleter : OpenshiftTool<OpenshiftDeleterSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenshiftDeleter"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        public OpenshiftDeleter(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        /// <summary>
        /// Run the delete command
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Run(OpenshiftDeleterSettings settings)
        {
            Check.NotNull(settings, nameof(settings));

            RunCommand(settings, GetArguments(settings));
        }

        private ProcessArgumentBuilder GetArguments(OpenshiftDeleterSettings settings)
        {
            var builder = new ProcessArgumentBuilder();

            builder.Append("delete");

            if (!string.IsNullOrEmpty(settings.ObjectType))
            {
                builder.Append(settings.ObjectType);
            }

            if (!string.IsNullOrEmpty(settings.ObjectName))
            {
                builder.Append(settings.ObjectName);
            }

            if (!string.IsNullOrEmpty(settings.Label))
            {
                builder.AppendSwitchQuoted("--selector", "=", settings.Label);
            }

            if (settings.All)
            {
                builder.Append("--all");
            }

            // no need to specify "ignore-not-found" when the all option is set
            if (settings.IgnoreNotFound && !settings.All)
            {
                builder.Append("--ignore-not-found");
            }

            return builder;
        }
    }
}
