pushd %~dp0

SET basePath=%~dp0
SET rootPath=%basePath:~0,-1%\..


cd %rootPath%\MatBlazor.Web
call npm i
call npm run build

cd %rootPath%
dotnet clean --force
dotnet build -c Debug --force

cd %rootPath%\MatBlazor.DevUtils\bin\Debug\netcoreapp3.0
call MatBlazor.DevUtils.exe

cd %rootPath%
dotnet clean --force
dotnet build -c Release --force

mkdir %rootPath%\Deploy\Nuget
dotnet pack MatBlazor --force -o %rootPath%\Deploy\Nuget

rmdir %rootPath%\Deploy\MatBlazor.Demo.ServerApp /s /q
mkdir %rootPath%\Deploy\MatBlazor.Demo.ServerApp
dotnet publish MatBlazor.Demo.ServerApp -c Release --force -o %rootPath%\Deploy\MatBlazor.Demo.ServerApp

rmdir %rootPath%\Deploy\MatBlazor.Demo.ClientApp /s /q
mkdir %rootPath%\Deploy\MatBlazor.Demo.ClientApp
dotnet publish MatBlazor.Demo.ClientApp -c Release --force -o %rootPath%\Deploy\MatBlazor.Demo.ClientApp
copy  %rootPath%\Deploy\MatBlazor.Demo.ClientApp\MatBlazor.Demo.ClientApp\dist\_framework %rootPath%\..\docs\_framework /y
copy  %rootPath%\Deploy\MatBlazor.Demo.ClientApp\MatBlazor.Demo.ClientApp\dist\_content %rootPath%\..\docs\_content /y


popd
pause