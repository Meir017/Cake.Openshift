namespace Cake.Openshift.Login
{
    /// <summary>
    /// Contains settings used by <see cref="OpenshiftLoginner" />.
    /// </summary>
    public sealed class OpenshiftLoginSettings : OpenshiftSettings
    {
        /// <summary>
        /// Gets or sets the username to be used for login
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password to be used for login
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the Bearer token for authentication to the API server
        /// </summary>
        public string Token { get; set; }
    }
}