using System;
using System.Collections.Generic;

namespace Cake.Openshift.Get.Build.Data
{

    public class OpenshiftBuildSpec
    {
        /// <summary>
        /// Gets the information from the source for a specific repo snapshot
        /// </summary>
        public OpenshiftBuildSpecRevision Revision { get; set; }
    }
}