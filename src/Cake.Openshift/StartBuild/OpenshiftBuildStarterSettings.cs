namespace Cake.Openshift.StartBuild
{
    /// <summary>
    /// Contains settings used by <see cref="OpenshiftBuildStarter" />.
    /// </summary>
    public class OpenshiftBuildStarterSettings : OpenshiftSettings
    {
        /// <summary>
        /// Gets or sets the source code commit identifier the build should use.
        /// </summary>
        /// <remarks>requires a build based on a Git repository</remarks>
        public string Commit { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to watch its logs until it completes or fails.
        /// </summary>
        public bool Follow { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to wait for a build to complete and exit with a non-zero return code if the build fails.
        /// </summary>
        public bool Wait { get; set; }
    }
}
