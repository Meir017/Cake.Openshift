# Cake.Openshift
A set of aliases for Cake to help with running Openshift commands

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