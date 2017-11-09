using Cake.Core;
using Cake.Openshift.Delete;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Cake.Openshift.Tests.Delete
{
    public sealed class OpenshiftDeleterTests
    {
        [TestClass]
        public sealed class TheRunMethod
        {
            [TestMethod]
            public void Should_Throw_If_Settings_Are_Null() => ToolTests.The_Run_Method_Should_Throw_If_Settings_Are_Null(new OpenshiftDeleterFixture());

            [TestMethod]
            public void Should_Add_ObjectType_And_ObjectName()
            {
                // Given
                var fixture = new OpenshiftDeleterFixture();
                fixture.Settings.ObjectType = "pod";
                fixture.Settings.ObjectName = "node-1-vsjnm";

                // When
                var result = fixture.Run();

                // Then
                result.Args.Should().Be($"delete {fixture.Settings.ObjectType} {fixture.Settings.ObjectName}");
            }

            [TestMethod]
            public void Should_Not_Add_IgnoreNotFound_If_All_Option_Set()
            {
                // Given
                var fixture = new OpenshiftDeleterFixture();
                fixture.Settings.All = true;
                fixture.Settings.Label = "app=appName";
                fixture.Settings.IgnoreNotFound = true;
                
                // When
                var result = fixture.Run();

                // Then
                result.Args.Should().Be($"delete --selector={fixture.Settings.Label.Quote()} --all");
            }

            [TestMethod]
            public void Should_Add_IgnoreNotFound_If_All_Option_Not_Set()
            {
                // Given
                var fixture = new OpenshiftDeleterFixture();
                fixture.Settings.IgnoreNotFound = true;
                fixture.Settings.Label = "app=appName";

                // When
                var result = fixture.Run();

                // Then
                result.Args.Should().Be($"delete --selector={fixture.Settings.Label.Quote()} --ignore-not-found");
            }
        }

        [TestClass]
        public sealed class TheAliases
        {
            [TestMethod]
            public void Should_Throw_If_Context_Is_Null()
            {
                // Given
                ICakeContext context = null;

                // When
                Action action = () => OpenshiftAliases.OpenshiftDelete(context, new OpenshiftDeleterSettings());

                // Then
                action.Should().Throw<ArgumentNullException>()
                    .Which.ParamName.Should().Be("context");
            }

            [TestMethod]
            public void Should_Throw_If_Settings_Is_Null()
            {
                // Given
                ICakeContext context = Mock.Of<ICakeContext>();

                // When
                Action action = () => OpenshiftAliases.OpenshiftDelete(context, null);

                // Then
                action.Should().Throw<ArgumentNullException>()
                    .Which.ParamName.Should().Be("settings");
            }
        }
    }
}
