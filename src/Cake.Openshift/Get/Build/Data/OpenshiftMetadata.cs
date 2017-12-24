using System;
using System.Collections.Generic;

namespace Cake.Openshift.Get.Build.Data
{

    public class OpenshiftMetadata
    {
        /// <summary>
        /// Gets or sets 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets 
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// Gets or sets 
        /// </summary>
        public OpenshiftMetadataLabels Labels { get; set; }

        /// <summary>
        /// Gets or sets 
        /// </summary>
        public OpenshiftMetadataAnnotations Annotations { get; set; }

        /// <summary>
        /// Gets or sets the server time when this object was created.
        /// </summary>
        public DateTime CreationTimestamp { get; set; }

        /// <summary>
        /// Gets or sets the date and time at which this resource will be deleted
        /// </summary>
        /// <remarks>
        /// This field is set by the server when a graceful deletion is requested by the user, and is not directly settable by a client.
        /// The resource is expected to be deleted (no longer visible from resource lists, and not reachable by name) after the time in this field.
        /// </remarks>
        public DateTime DeletionTimestamp { get; set; }
    }
}