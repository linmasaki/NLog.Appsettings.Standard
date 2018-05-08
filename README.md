# NLog.Appsetting.Standard
[![Version](https://img.shields.io/nuget/vpre/NLog.Appsetting.Standard.svg)](https://www.nuget.org/packages/NLog.Appsetting.Standard)  
An NLog Layout Renderer be used to access appsettings.json with .NET Standard 2.0.   

## How To Use ##   
Install the [NLog.Appsetting.Standard](https://www.nuget.org/packages/NLog.Appsetting.Standard) package from NuGet. You need add NLog 4.5 or higher, then put the syntax in your NLog configuration below:

```xml
<nlog>
    <extensions>
        <add assembly="NLog.Appsetting.Standard" />
    </extensions>
</nlog>
```

### Appsetting layout renderer configuration ###
The layout renderer's name is ``appsetting``.   

#### Configuration Syntax & Parameters ####
``${appsetting:name=String.String2.String3:default=String}``
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

* **${appsetting:name=Mode}** - Get "Prod" in this case.
* **${appsetting:name=Options.StorageConnectionString}** - Get "abcdefg123456789" in this case.
* **${appsetting:name=Options.StorageConnectionString2:default=DefaultString}** - Get "DefaultString" in this case.

## Test App ##
NLog.Appsetting.Standard.Test is a console program that is preconfigured to use the ``appsetting`` layout renderer. It is a good sample that you can follow.  

## Note ##
If you need other NLog extensions(Target or Layout Renderer) that built by me or prefer all in one like me. You can refer [this](https://www.nuget.org/packages/NLog.Extended.Standard) and its [document](https://github.com/linmasaki/NLog.Extended.Standard)!!!

## Reference ##  
[NLog.Extended](https://github.com/nlog/nlog/wiki/AppSetting-Layout-Renderer) by [NLog](http://nlog-project.org/)
