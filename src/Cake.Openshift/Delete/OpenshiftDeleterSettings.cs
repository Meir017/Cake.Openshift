namespace Cake.Openshift.Delete
{
    /// <summary>
    /// Contains settings used by <see cref="OpenshiftDeleter" />.
    /// </summary>
    public class OpenshiftDeleterSettings : OpenshiftSettings
    {
        /// <summary>
        /// Gets or sets the object type to delete.
        /// </summary>
        /// <remarks>
        /// Can represent multiple object types by using a comma separated list
        /// </remarks>
        public string ObjectType { get; set; }

        /// <summary>
        /// Gets or sets the name of the object to delete.
        /// </summary>
        public string ObjectName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to select all resources in the namespace of the specified resource types.
        /// </summary>
        /// <c>true</c> to select all resources in the namespace of the specified resource types; otherwise, <c>false</c>.
        public bool All { get; set; }

        /// <summary>
        /// Gets or sets the selector (label query) to filter on.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to treat "resource not found" as a successful delete. Defaults to "true" when <see cref="All"/> is specified.
        /// </summary>
        /// <c>true</c> to treat "resource not found" as a successful delete; otherwise, <c>false</c>.
        public bool IgnoreNotFound { get; set; }
    }
}