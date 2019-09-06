#load nuget:?package=Cake.Recipe&version=1.0.0

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
