@echo off
cd /d %~dp0
dotnet tool list --global >> ./tools.tmp
findstr "dotnet-ef" ./tools.tmp> nul 2>&1
if %ERRORLEVEL% EQU 0 (
	echo [92mdotnet-ef installed[0m
) else (
	echo [91mdotnet-ef not installed[0m
	echo [93mdotnet-ef installing[0m
	dotnet tool install --global dotnet-ef
)
del /Q tools.tmp > nul 2>&1
del /Q .\Migrations\ > nul 2>&1
dotnet ef migrations add Init
dotnet ef database drop --force
dotnet ef database update
