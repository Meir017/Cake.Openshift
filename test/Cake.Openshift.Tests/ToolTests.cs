using FluentAssertions;
using System;

namespace Cake.Openshift.Tests
{
    public static class ToolTests
    {
        public static void The_Run_Method_Should_Throw_If_Settings_Are_Null<TSettings>(OpenshiftFixture<TSettings> fixture)
            where TSettings : OpenshiftSettings, new()
        {
            // Given
            fixture.Settings = null;

            // When
            Action action = () => fixture.Run();

            // Then
            action.Should().Throw<ArgumentNullException>()
                .Which.ParamName.Should().Be("settings");
        }
    }
}
