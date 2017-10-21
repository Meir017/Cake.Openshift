using Cake.Openshift.Login;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake.Openshift.Tests.Login
{
    public class OpenshiftLoginnerFixture : OpenshiftFixture<OpenshiftLoginSettings>
    {
        protected override void RunTool()
        {
            var loginner = new OpenshiftLoginner(FileSystem, Environment, ProcessRunner, Tools);
            loginner.Run(Settings);
        }
    }
}
