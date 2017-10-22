using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;
using Cake.Core;
using Moq;

namespace Cake.Openshift.Tests.StartBuild
{
    public class OpenshiftBuildStarterTests
    {
        [TestClass]
        public class TheRunMethod
        {
            [TestMethod]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                var fixture = new OpenshiftBuildStarterFixture();
                fixture.BuildConfig = "hello-world";
                fixture.Settings = null;

                // When
                Action action = () => fixture.Run();

                // Then
                action.Should().Throw<ArgumentNullException>()
                    .Which.ParamName.Should().Be("settings");
            }

            [DataTestMethod]
            [DataRow(null)]
            [DataRow("")]
            public void Should_Throw_If_BuildConfig_Is_Null_Or_Empty(string buildConfig)
            {
                // Given
                var fixture = new OpenshiftBuildStarterFixture();
                fixture.BuildConfig = buildConfig;

                // When
                Action action = () => fixture.Run();

                // Then
                action.Should().Throw<ArgumentNullException>()
                    .Which.ParamName.Should().Be("buildConfig");
            }

            [TestMethod]
            public void Should_Add_BuildConfig()
            {
                // Given
                var fixture = new OpenshiftBuildStarterFixture();
                fixture.BuildConfig = "hello-world";

                // When
                var result = fixture.Run();

                // Then
                result.Args.Should().Be($"start-build {fixture.BuildConfig}");
            }

            [TestMethod]
            public void Should_Add_BuildConfig_And_Follow_Flag()
            {
                // Given
                var fixture = new OpenshiftBuildStarterFixture();
                fixture.BuildConfig = "hello-world";
                fixture.Settings.Follow = true;

                // When
                var result = fixture.Run();

                // Then
                result.Args.Should().Be($"start-build {fixture.BuildConfig} --follow");
            }

            [TestMethod]
            public void Should_Add_BuildConfig_And_Wait_Flag()
            {
                // Given
                var fixture = new OpenshiftBuildStarterFixture();
                fixture.BuildConfig = "hello-world";
                fixture.Settings.Wait = true;

                // When
                var result = fixture.Run();

                // Then
                result.Args.Should().Be($"start-build {fixture.BuildConfig} --wait");
            }

            [TestMethod]
            public void Should_Add_BuildConfig_And_Follow_And_Wait_Flags()
            {
                // Given
                var fixture = new OpenshiftBuildStarterFixture();
                fixture.BuildConfig = "hello-world";
                fixture.Settings.Follow = true;
                fixture.Settings.Wait = true;

                // When
                var result = fixture.Run();

                // Then
                result.Args.Should().Be($"start-build {fixture.BuildConfig} --follow --wait");
            }
        }

        [TestClass]
        public class TheAliases
        {
            [TestMethod]
            public void Should_Throw_If_Context_Is_Null()
            {
                // Given
                ICakeContext context = null;

                // When
                Action action = () => OpenshiftAliases.OpenshiftStartBuild(context, "fake");

                // Then
                action.Should().Throw<ArgumentNullException>()
                    .Which.ParamName.Should().Be("context");
            }

            [DataTestMethod]
            [DataRow(null)]
            [DataRow("")]
            public void Should_Throw_If_BuildConfig_Is_Null_Or_Empty(string buildConfig)
            {
                // Given
                var context = Mock.Of<ICakeContext>();

                // When
                Action action = () => OpenshiftAliases.OpenshiftStartBuild(context, buildConfig);

                // Then
                action.Should().Throw<ArgumentNullException>()
                    .Which.ParamName.Should().Be("buildConfig");
            }

            [TestMethod]
            public void Should_Throw_If_Settings_Is_Null()
            {
                // Given
                var context = Mock.Of<ICakeContext>();
                
                // When
                Action action = () => OpenshiftAliases.OpenshiftStartBuild(context, "fake", null);

                // Then
                action.Should().Throw<ArgumentNullException>()
                    .Which.ParamName.Should().Be("settings");
            }
        }
    }
}
