pushd %~dp0

SET basePath=%~dp0
SET rootPath=%basePath:~0,-1%
#SET nugetPath=%basePath%nuget.exe
SET msbuildPath=c:\Program Files (x86)\Microsoft Visual Studio\2019\Preview\MSBuild\Current\Bin\MSBuild.exe
SET mstestPath=c:\Program Files (x86)\Microsoft Visual Studio\2019\Preview\Common7\IDE\MSTest.exe

cd "%rootPath%"
"%msbuildPath%"  /p:Platform="Any CPU" /p:Configuration=Release /t:Clean;Rebuild /clp:ErrorsOnly

cd "%rootPath%\MatBlazor.DevUtils\bin\Release\netcoreapp2.1"
"%mstestPath%" /testcontainer:MatBlazor.DevUtils.dll /test:MatBlazor.DevUtils.DemoContentGenerator

popd
pause