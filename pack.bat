@echo off

set version=0.0.3

echo version=%version%

cd E:\GitHub\XUCore.Net5.Template.WebApi

nuget pack XUCore.Net5.Template.WebApi.nuspec -NoDefaultExcludes -OutputDirectory .

cd /

pause

