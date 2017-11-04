using Cake.Openshift.Delete;

namespace Cake.Openshift.Tests.Delete
{
    public class OpenshiftDeleterFixture : OpenshiftFixture<OpenshiftDeleterSettings>
    {
        protected override void RunTool()
        {
            var deleter = new OpenshiftDeleter(FileSystem, Environment, ProcessRunner, Tools);
            deleter.Run(Settings);
        }
    }
}
