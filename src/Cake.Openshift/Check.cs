// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;

namespace Cake.Openshift
{
    [DebuggerStepThrough]
    internal static class Check
    {
        [ContractAnnotation("value:null => halt")]
        public static T NotNull<T>([NoEnumeration] T value, [InvokerParameterName] [NotNull] string parameterName)
        {
            if (ReferenceEquals(value, null))
            {
                NotNullOrEmpty(parameterName, nameof(parameterName));

                throw new ArgumentNullException(parameterName);
            }

            return value;
        }

        [ContractAnnotation("value:null => halt")]
        public static T NotNull<T>(
            [NoEnumeration] T value,
            [InvokerParameterName] [NotNull] string parameterName,
            [NotNull] string propertyName)
        {
            if (ReferenceEquals(value, null))
            {
                NotNullOrEmpty(parameterName, nameof(parameterName));
                NotNullOrEmpty(propertyName, nameof(propertyName));

                throw new ArgumentException($"The property '{parameterName}' of the argument '{propertyName}' cannot be null.");
            }

            return value;
        }

        [ContractAnnotation("value:null => halt")]
        public static IReadOnlyList<T> NotEmpty<T>(IReadOnlyList<T> value, [InvokerParameterName] [NotNull] string parameterName)
        {
            NotNull(value, parameterName);

            if (value.Count == 0)
            {
                NotNullOrEmpty(parameterName, nameof(parameterName));

                throw new ArgumentException($"The collection argument '{parameterName}' must contain at least one element.");
            }

            return value;
        }

        [ContractAnnotation("value:null => halt")]
        public static string NotNullOrEmpty(string value, [InvokerParameterName] [NotNull] string parameterName)
        {
            if (string.IsNullOrEmpty(value))
            {
                NotNullOrEmpty(parameterName, nameof(parameterName));
                throw new ArgumentNullException(parameterName);
            }

            return value;
        }

        public static string NullButNotEmpty(string value, [InvokerParameterName] [NotNull] string parameterName)
        {
            if (!ReferenceEquals(value, null) && value.Length == 0)
            {
                NotNullOrEmpty(parameterName, nameof(parameterName));

                throw new ArgumentException($"The string argument '{parameterName}' cannot be empty.", parameterName);
            }

            return value;
        }

        public static IReadOnlyList<T> HasNoNulls<T>(IReadOnlyList<T> value, [InvokerParameterName] [NotNull] string parameterName)
            where T : class
        {
            NotNull(value, parameterName);

            if (value.Any(e => e == null))
            {
                NotNullOrEmpty(parameterName, nameof(parameterName));

                throw new ArgumentException(parameterName);
            }

            return value;
        }

        public static Type ValidEntityType(Type value, [InvokerParameterName] [NotNull] string parameterName)
        {
            if (!value.GetTypeInfo().IsClass)
            {
                NotNullOrEmpty(parameterName, nameof(parameterName));

                throw new ArgumentException($"The entity type '{value}' provided for the argument '{parameterName}' must be a reference type.");
            }

            return value;
        }
    }
}