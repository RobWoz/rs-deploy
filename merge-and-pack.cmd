@ECHO OFF

SET ILMerged=ilmerged

ECHO Running ILMerge to make single rsdeploy.exe.

IF EXIST ilmerged RD ilmerged /S /Q
MD ilmerged

packages\ILMerge.2.14.1208\tools\ILMerge.exe src\CYC.RsDeploy.Console\bin\Release\rsdeploy.exe src\CYC.RsDeploy.Console\bin\Release\*.dll /out:%ILMerged%\rsdeploy.exe /wildcards

ECHO Copying files needed to make package.

COPY src\CYC.RsDeploy.Console\bin\Release\rsdeploy.exe.config  %ILMerged% 
COPY .nuget\RSDeploy.nuspec %ILMerged% 

nuget pack %ILMerged%\RSDeploy.nuspec