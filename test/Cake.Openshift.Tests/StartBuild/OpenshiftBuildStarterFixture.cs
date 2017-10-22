using Cake.Openshift.StartBuild;

namespace Cake.Openshift.Tests.StartBuild
{
    public class OpenshiftBuildStarterFixture : OpenshiftFixture<OpenshiftBuildStarterSettings>
    {
        public string BuildConfig { get; set; }

        protected override void RunTool()
        {
            var buildStarter = new OpenshiftBuildStarter(FileSystem, Environment, ProcessRunner, Tools);
            buildStarter.Run(BuildConfig, Settings);
        }
    }
}
