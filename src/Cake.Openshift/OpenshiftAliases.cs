using Cake.Core;
using Cake.Core.Annotations;
using Cake.Openshift.Delete;
using Cake.Openshift.Login;
using Cake.Openshift.StartBuild;

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
        /// <example>
        /// <code>
        /// <para>Cake task:</para>
        /// <![CDATA[
        ///     Task("Openshift-Login-With-Username-And-Password")
        ///         .Does(() =>
        ///         {
        ///             var username = "admin";
        ///             var password = "Password1";
        ///
        ///             OpenshiftLogin(username, password);
        ///         });
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Login")]
        [CakeNamespaceImport("Cake.Openshift.Login")]
        public static void OpenshiftLogin(this ICakeContext context, string username, string password)
        {
            Check.NotNull(context, nameof(context));
            Check.NotNullOrEmpty(username, nameof(username));
            Check.NotNullOrEmpty(password, nameof(password));

            var loginner = new OpenshiftLoginner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            loginner.Run(new OpenshiftLoginSettings { Username = username, Password = password });
        }

        /// <summary>
        /// Logins to Openshift using Bearer token.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="token">The Bearer token.</param>
        /// <example>
        /// <code>
        /// <para>Cake task:</para>
        /// <![CDATA[
        ///     Task("Openshift-Login-With-Bearer-Token")
        ///         .Does(() =>
        ///         {
        ///             var token = "token";
        ///
        ///             OpenshiftLogin(token);
        ///         });
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Login")]
        [CakeNamespaceImport("Cake.Openshift.Login")]
        public static void OpenshiftLogin(this ICakeContext context, string token)
        {
            Check.NotNull(context, nameof(context));
            Check.NotNullOrEmpty(token, nameof(token));

            var loginner = new OpenshiftLoginner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            loginner.Run(new OpenshiftLoginSettings { Token = token });
        }

        /// <summary>
        /// Starts a new openshift build for the provided build config.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="buildConfig">The build config.</param>
        /// <example>
        /// <code>
        /// <para>Cake task:</para>
        /// <![CDATA[
        ///     Task("Openshift-StartBuild")
        ///         .Does(() =>
        ///         {
        ///             var buildConfig = "hello-world";
        ///
        ///             OpenshiftStartBuild(buildConfig);
        ///         });
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Build")]
        [CakeNamespaceImport("Cake.Openshift.StartBuild")]
        public static void OpenshiftStartBuild(this ICakeContext context, string buildConfig) => OpenshiftStartBuild(context, buildConfig, new OpenshiftBuildStarterSettings());

        /// <summary>
        /// Starts a new openshift build for the provided build config with additional options.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="buildConfig">The build config.</param>
        /// <param name="settings">The settings</param>
        /// <example>
        /// <code>
        /// <para>Cake task:</para>
        /// <![CDATA[
        ///     Task("Openshift-StartBuild")
        ///         .Does(() =>
        ///         {
        ///             var buildConfig = "hello-world";
        ///
        ///             OpenshiftStartBuild(buildConfig, new OpenshiftBuildStarterSettings
        ///             {
        ///                 Follow = true,
        ///                 Wait = true
        ///             });
        ///         });
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Build")]
        [CakeNamespaceImport("Cake.Openshift.StartBuild")]
        public static void OpenshiftStartBuild(this ICakeContext context, string buildConfig, OpenshiftBuildStarterSettings settings)
        {
            Check.NotNull(context, nameof(context));
            Check.NotNullOrEmpty(buildConfig, nameof(buildConfig));
            Check.NotNull(settings, nameof(settings));

            var buildStarter = new OpenshiftBuildStarter(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            buildStarter.Run(buildConfig, settings);
        }

        /// <summary>
        /// Deletes an openshift resource.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings</param>
        /// <example>
        /// <code>
        /// <para>Cake task:</para>
        /// <![CDATA[
        ///     Task("Openshift-Delete")
        ///         .Does(() =>
        ///         {
        ///             OpenshiftDelete(buildConfig, new OpenshiftDeleterSettings
        ///             {
        ///                 ObjectType = "pod",
        ///                 ObjectName = "node-1-vsjnm",
        ///                 All = true,
        ///                 Label = "app=appName",
        ///                 IgnoreNotFound = true
        ///             });
        ///         });
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Build")]
        [CakeNamespaceImport("Cake.Openshift.Delete")]
        public static void OpenshiftDelete(this ICakeContext context, OpenshiftDeleterSettings settings)
        {
            Check.NotNull(context, nameof(context));
            Check.NotNull(settings, nameof(settings));

            var deleter = new OpenshiftDeleter(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            deleter.Run(settings);
        }
    }
}
