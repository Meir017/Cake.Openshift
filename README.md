# Cake.Openshift
A set of aliases for Cake to help with running Openshift commands

## Usage

```c#
#addin "Cake.Openshift"

var target = Argument("target", "Default");

Task("Openshift-Login")
    .Does(() => 
    {
        var username = "admin";
        var password = "Password1";

        OpenshiftLogin(username, password);
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