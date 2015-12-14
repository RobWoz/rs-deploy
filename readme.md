# rs-deploy

`rsdeploy.exe` is a command line tool to deploy SQL Server Reporting Services assets.  It uses the [Report Server Web Service](https://msdn.microsoft.com/en-us/library/ms152787.aspx) to upload data sources and reports.  When used with a deployment tool such as [Octopus Deploy](https://octopus.com/) you can deploy data sources with the correct connection strings for the environment you are deploying to, deploy reports, and ensure your reports use those data sources.  

## Why?

SQL Server Reporting Services doesn't have a automated tool in the box for deploying reports alongside other application components such as web sites and Windows services.  In Visual Studio there is the option to deploy reports:

![image](https://cloud.githubusercontent.com/assets/2734580/11786073/8de64248-a27c-11e5-8280-948a65283cdc.png)

And [Microsoft's](https://msdn.microsoft.com/en-us/library/ms162839.aspx) `rs.exe` tool allows a Visual Basic .NET script to be run against a report sever.  Neither of these approaches fits with our requirement to deploy SSRS reports as artifacts produced from a continuous integration build.

## How?

You'll need to pack your SSRS reports for deployment.  We use [Octopus Deploy](https://octopus.com/) to produce a NuGet package containing the following

- Our reports.
- A `datasources.config` file.
- The `rsdeploy.exe` executable.  

At deployment time, [Octopus](https://octopus.com/) sets the connection strings in `datasources.config` to match the environment we are deploying to.  It then invokes the following commands to deploy our data sources and reports:

````
rsdeploy.exe create-datasources -f DataSources.config -d {Target SSRS Folder} -s {Report Server}

rsdeploy.exe upload-folder -f {Source Folder} -d {Target SSRS Folder} -s {Report Server}
```` 

The `create-datasources` verb creates the data sources listed in the `DataSources.config` file in the specified destination folder on the report server.

The `upload-folder` verb uploads reports from the specified source folder to the destination folder on the report server.  It also ensures that any data sources in the uploaded reports are updated to use data sources created using the `create-datasources` verb.

For detailed usage instructions, please see the [wiki](https://github.com/CityOfYork/rs-deploy/wiki).

## Installing

Please install the NuGet package:

````
PM> Install-Package RSDeploy -Pre
````

## Contributing

We welcome contributions from the community.  Please open a pull request or issue early to let us know you are working on a feature.  If you would like to add a new feature, please open an issue so we can discuss it before submitting a pull request.  All contributions must be accompanied by unit tests.

## Continuous Integration

[![Build status](https://ci.appveyor.com/api/projects/status/axkinbek2iqdwktg?svg=true)](https://ci.appveyor.com/project/CityOfYork/rs-deploy)
