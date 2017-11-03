`Cake.Openshift` is A set of aliases for Cake to help with running Openshift commands

[![License](http://img.shields.io/:license-mit-blue.svg)](https://github.com/cake-contrib/Cake.Openshift/blob/master/LICENSE)

## Information

| | Stable | Pre-release |
|:--:|:--:|:--:|
|GitHub Release|-|[![GitHub release](https://img.shields.io/github/release/cake-contrib/Cake.Openshift.svg)](https://github.com/cake-contrib/Cake.Openshift/releases/latest)|
|NuGet|[![NuGet](https://img.shields.io/nuget/v/Cake.Openshift.svg)](https://www.nuget.org/packages/Cake.Openshift)|[![NuGet](https://img.shields.io/nuget/vpre/Cake.Openshift.svg)](https://www.nuget.org/packages/Cake.Openshift)|

## Build Status

|Master|
|:--:|
[![Build status](https://ci.appveyor.com/api/projects/status/movbectbuf2g5deb/branch/master?svg=true)](https://ci.appveyor.com/project/cakecontrib/cake-openshift/branch/master)

## Usage

```c#
#addin "Cake.Openshift"

var target = Argument("target", "Default");

Task("Openshift-Login-With-Username-And-Password")
    .Does(() => 
    {
        var username = "admin";
        var password = "Password1";

        OpenshiftLogin(username, password);
    });

Task("Openshift-Login-With-Bearer-Token")
    .Does(() => 
    {
        var token = "token";

        OpenshiftLogin(token);
    });

Task("Openshift-StartBuild")
    .Does(() =>
    {
        var buildConfig = "hello-world";

        OpenshiftStartBuild(buildConfig, new OpenshiftBuildStarterSettings
        {
            Follow = true,
            Wait = true
        });
    });

Task("Default")
    .IsDependentOn("Openshift-Login");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
```

## Documentation

TODO

## I cant do _insert-command-here_

If you have feature requests please submit them as issues, or better yet as pull requests :)