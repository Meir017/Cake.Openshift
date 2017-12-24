using System;
using System.Collections.Generic;

namespace Cake.Openshift.Get.Build.Data
{

    public class OpenshiftBuildStatus
    {
        /// <summary>
        /// Gets the point in the build lifecycle.
        /// </summary>
        public OpenshiftBuildStatusPhase Phase { get; set; }
    }
}