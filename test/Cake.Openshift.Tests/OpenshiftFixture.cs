using Cake.Testing.Fixtures;
using Cake.Core.IO;

namespace Cake.Openshift.Tests
{
    public abstract class OpenshiftFixture<TSettings> : OpenshiftFixture<TSettings, ToolFixtureResult>
        where TSettings : OpenshiftSettings, new()
    {
        protected override ToolFixtureResult CreateResult(FilePath path, ProcessSettings process)
        {
            return new ToolFixtureResult(path, process);
        }
    }

    public abstract class OpenshiftFixture<TSettings, TFixtureResult> : ToolFixture<TSettings, TFixtureResult>
        where TSettings : OpenshiftSettings, new()
        where TFixtureResult : ToolFixtureResult
    {
        protected OpenshiftFixture() : base("oc.exe")
        {
        }
    }
}
