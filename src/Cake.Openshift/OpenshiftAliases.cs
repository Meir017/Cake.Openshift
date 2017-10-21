using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Openshift.Login;

namespace Cake.Openshift
{
    /// <summary>
    /// <para>Contains functionality related to running <see href="https://github.com/openshift/origin">openshift</see> cli commands.</para>
    /// <para>
    /// In order to use the commands for this alias, include the following in your build.cake file to download and
    /// install from NuGet.org, or specify the ToolPath within the <see cref="OpenshiftSettings" /> class:
    /// <code>
    /// #tool "nuget:?package=Openshift"
    /// </code>
    /// </para>
    /// </summary>
    [CakeAliasCategory("Openshift")]
    public static class OpenshiftAliases
    {
        /// <summary>
        /// Logins to Openshift using username and password.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <code>
        ///     OpenshiftLogin("Admin", "Password1");
        /// </code>
        [CakeMethodAlias]
        public static void OpenshiftLogin(this ICakeContext context, string username, string password)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(nameof(username));
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password));
            }

            var loginner = new OpenshiftLoginner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            loginner.Run(new OpenshiftLoginSettings { Username = username, Password = password });
        }

        /// <summary>
        /// Logins to Openshift using Bearer token.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="token">The Bearer token.</param>
        /// <code>
        ///     OpenshiftLogin("Bearer Token");
        /// </code>
        [CakeMethodAlias]
        public static void OpenshiftLogin(this ICakeContext context, string token)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentNullException(nameof(token));
            }

            var loginner = new OpenshiftLoginner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            loginner.Run(new OpenshiftLoginSettings { Token = token });
        }
    }
}
