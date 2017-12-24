using System;
using System.Collections.Generic;

namespace Cake.Openshift.Get.Build.Data
{

    public enum OpenshiftBuildStatusPhase
    {
        New,
        Pending,
        Running,
        Complete,
        Failed,
        Error,
        Cancelled
    }
}