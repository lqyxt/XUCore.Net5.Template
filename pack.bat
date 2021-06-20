@echo off

set version=0.0.2

echo version=%version%

cd E:\GitHub\XUCore.Net5.Template

nuget pack XUCore.Net5.Template.nuspec -NoDefaultExcludes -OutputDirectory .

cd /

pause

