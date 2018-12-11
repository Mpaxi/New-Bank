FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 16320
EXPOSE 44355

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY NB.Registration.API/NB.Registration.API.csproj NB.Registration.API/
COPY ["NB.Registration.API/Nuget.Config", "/root/.nuget/NuGet/NuGet.Config"]
COPY NB.Registration.Domain/NB.Registration.Domain.csproj NB.Registration.Domain/
COPY NB.Registration.Repository/NB.Registration.Repository.csproj NB.Registration.Repository/
RUN dotnet restore --configfile "/root/.nuget/NuGet/NuGet.Config" NB.Registration.API/NB.Registration.API.csproj
COPY . .
WORKDIR /src/NB.Registration.API
RUN dotnet build NB.Registration.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish NB.Registration.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "NB.Registration.API.dll"]
