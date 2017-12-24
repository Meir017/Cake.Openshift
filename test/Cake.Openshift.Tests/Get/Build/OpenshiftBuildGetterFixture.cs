using System.Collections.Generic;
using Cake.Openshift.Get.Build;
using Cake.Openshift.Get.Build.Data;

namespace Cake.Openshift.Tests.Get.Build
{
    public sealed class OpenshiftBuildGetterFixture : OpenshiftFixture<OpenshiftBuildGetterSettings>
    {
        public string BuildName { get; set; }

        public OpenshiftBuildGetterFixture(ICollection<string> standardOutput = null)
        {
            if (standardOutput == null)
            {
                standardOutput = new[] { "{}" };
            }

            ProcessRunner.Process.SetStandardOutput(standardOutput);
        }

        protected override void RunTool()
        {
            RunOcGetBuild();
        }

        public OpenshiftBuild RunOcGetBuild()
        {
            var tool = new OpenshiftBuildGetter(FileSystem, Environment, ProcessRunner, Tools);
            return tool.Run(BuildName, Settings);
        }
    }
}
