using Cake.Core.Tooling;

namespace Cake.Openshift
{
    /// <summary>
    /// Contains common settings used by <see cref="OpenshiftTool{TSettings}" />.
    /// </summary>
    public class OpenshiftSettings : ToolSettings
    {
        /// <summary>
        /// Gets or sets the namespace scope for this CLI request
        /// </summary>
        public string Namespace { get; set; }
    }
}
