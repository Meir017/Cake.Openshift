namespace Cake.Openshift.Get.Build.Data
{
    /// <summary>
    /// The object returned from <see cref="OpenshiftBuildGetter"/>
    /// </summary>
    public class OpenshiftBuild
    {
        /// <summary>
        /// Gets or sets the api version.
        /// </summary>
        public string ApiVersion { get; set; }

        /// <summary>
        /// Gets or sets the king.
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// Gets or sets the metadata.
        /// </summary>
        public OpenshiftMetadata Metadata { get; set; }

        /// <summary>
        /// Gets or sets spec.
        /// </summary>
        public OpenshiftBuildSpec Spec { get; set; }

        /// <summary>
        /// Gets or sets the current status of the build.
        /// </summary>
        public OpenshiftBuildStatus Status { get; set; }
    }
}