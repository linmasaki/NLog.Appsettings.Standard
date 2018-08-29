# NLog.Appsettings.Standard
[![Version](https://img.shields.io/nuget/vpre/NLog.Appsettings.Standard.svg)](https://www.nuget.org/packages/NLog.Appsettings.Standard)  
An NLog Layout Renderer be used to access appsettings.json with .NET Standard 2.0.   

## Attention ##  
The older package [NLog.Appsetting.Standard](https://www.nuget.org/packages/NLog.Appsetting.Standard) is no longer updated and maintained. It is recommended to replace this new version.  

## How To Use ##   
Install the [NLog.Appsettings.Standard](https://www.nuget.org/packages/NLog.Appsettings.Standard) package from NuGet. You need add NLog 4.5 or higher, then put the syntax in your NLog configuration below:

```xml
<nlog>
    <extensions>
        <add assembly="NLog.Appsettings.Standard" />
    </extensions>
</nlog>
```

### Appsettings layout renderer configuration ###
The layout renderer's name is ``appsettings``.   

#### Configuration Syntax & Parameters ####
``${appsettings:name=String.String2.String3:default=String}``
* **name** - Key in your appsettings.\<EnvironmentName\>.json file. If it has a multi-level hierarchy that you want to access, you can separate by a dot. Required.
* **default** - Default value if not present. Optional.

#### Example: ####
Target appsettings.json

```json
{
    "Mode":"Prod",
    "Options":{
        "StorageConnectionString":"abcdefg123456789",
        "Container":"YourProdContainer"
    }
}
```

* **${appsettings:name=Mode}** - Get "Prod" in this case.
* **${appsettings:name=Options.StorageConnectionString}** - Get "abcdefg123456789" in this case.
* **${appsettings:name=Options.StorageConnectionString2:default=DefaultString}** - Get "DefaultString" in this case.

## Test App ##
NLog.Appsettings.Standard.Test is a console program that is preconfigured to use the ``appsettings`` layout renderer. It is a good sample that you can follow.  

## Note ##
If you need other NLog extensions(Target or Layout Renderer) that built by me or prefer all in one like me. You can refer [this](https://www.nuget.org/packages/NLog.Extended.Standard) and its [document](https://github.com/linmasaki/NLog.Extended.Standard)!!!

## Reference ##  
[NLog.Extended](https://github.com/nlog/nlog/wiki/AppSetting-Layout-Renderer) by [NLog](http://nlog-project.org/)
