#load nuget:https://www.myget.org/F/cake-contrib/api/v2?package=Cake.Recipe&prerelease

Environment.SetVariableNames();

BuildParameters.SetParameters(context: Context,
                            buildSystem: BuildSystem,
                            sourceDirectoryPath: "./src",
                            title: "Cake.Openshift",
                            repositoryOwner: "cake-contrib",
                            repositoryName: "Cake.Openshift",
                            appVeyorAccountName: "cakecontrib",
                            solutionFilePath: "./Cake.Openshift.sln",
                            shouldRunDotNetCorePack: true,
                            shouldPublishNuGet: true);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context);

Build.RunDotNetCore();
