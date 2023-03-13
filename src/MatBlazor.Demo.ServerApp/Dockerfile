FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MatBlazor.Demo.ServerApp/MatBlazor.Demo.ServerApp.csproj", "MatBlazor.Demo.ServerApp/"]
COPY ["MatBlazor.Demo/MatBlazor.Demo.csproj", "MatBlazor.Demo/"]
COPY ["MatBlazor/MatBlazor.csproj", "MatBlazor/"]
RUN dotnet restore "MatBlazor.Demo.ServerApp/MatBlazor.Demo.ServerApp.csproj"
COPY . .
WORKDIR "/src/MatBlazor.Demo.ServerApp"
RUN dotnet build "MatBlazor.Demo.ServerApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MatBlazor.Demo.ServerApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MatBlazor.Demo.ServerApp.dll"]
