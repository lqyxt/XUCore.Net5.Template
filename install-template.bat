@echo off

set Version=0.0.2

echo %Version%

dotnet new -u XUCore.Net5.Template

dotnet new --install XUCore.Net5.Template::%Version%

pause

