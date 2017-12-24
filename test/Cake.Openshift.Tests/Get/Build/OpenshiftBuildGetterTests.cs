using Cake.Core;
using Cake.Openshift.Get.Build;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Cake.Openshift.Tests.Get.Build
{

    public sealed class OpenshiftBuildGetterTests
    {
        [TestClass]
        public sealed class TheRunMethod
        {
            [TestMethod]
            public void Should_Thorw_If_BuildName_Is_Null()
            {
                // Given
                var fixture = new OpenshiftBuildGetterFixture();

                // When
                Action action = () => fixture.Run();

                // Then
                action.Should().Throw<ArgumentNullException>().Which.ParamName.Should().Be("buildName");
            }

            [TestMethod]
            public void Should_Throw_If_Settings_Are_Null() => ToolTests.The_Run_Method_Should_Throw_If_Settings_Are_Null(new OpenshiftBuildGetterFixture { BuildName = "my-build" });

            [TestMethod]
            public void Should_Add_Build_Name()
            {
                // Given
                var fixture = new OpenshiftBuildGetterFixture();
                fixture.BuildName = "my-build";

                // When
                var result = fixture.Run();

                // Then
                result.Args.Should().Be($"get build {fixture.BuildName} --output=json");
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
                Action action = () => OpenshiftAliases.OpenshiftGetBuild(context, "my-build");

                // Then
                action.Should().Throw<ArgumentNullException>()
                    .Which.ParamName.Should().Be("context");
            }

            [TestMethod]
            public void Should_Throw_If_BuildName_Is_Null()
            {
                // Given
                ICakeContext context = Mock.Of<ICakeContext>();
                string buildName = null;

                // When
                Action action = () => OpenshiftAliases.OpenshiftGetBuild(context, buildName);

                // Then
                action.Should().Throw<ArgumentNullException>()
                    .Which.ParamName.Should().Be("buildName");
            }

            [TestMethod]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                ICakeContext context = Mock.Of<ICakeContext>();
                string buildName = "my-build";
                OpenshiftBuildGetterSettings settings = null;

                // When
                Action action = () => OpenshiftAliases.OpenshiftGetBuild(context, buildName, settings);

                // Then
                action.Should().Throw<ArgumentNullException>()
                    .Which.ParamName.Should().Be("settings");
            }
        }
    }
}
