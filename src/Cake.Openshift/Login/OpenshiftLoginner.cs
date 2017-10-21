using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Openshift.Login
{
    /// <summary>
    /// The openshift login command
    /// </summary>
    public class OpenshiftLoginner : OpenshiftTool<OpenshiftLoginSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenshiftLoginner"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tools locator.</param>
        public OpenshiftLoginner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        /// <summary>
        /// Run the login command
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Run(OpenshiftLoginSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            RunCommand(settings, GetArguments(settings));
        }

        private ProcessArgumentBuilder GetArguments(OpenshiftLoginSettings settings)
        {
            var builder = new ProcessArgumentBuilder();

            builder.Append("login");

            if (!string.IsNullOrEmpty(settings.Username) && !string.IsNullOrEmpty(settings.Password))
            {
                builder.AppendSwitchQuoted("--username", "=", settings.Username);

                builder.AppendSwitchQuotedSecret("--password", "=", settings.Password);
            }
            else if (!string.IsNullOrEmpty(settings.Token))
            {
                builder.AppendSwitchQuotedSecret("--token", "=", settings.Token);
            }

            return builder;
        }
    }
}
