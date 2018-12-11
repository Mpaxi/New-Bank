FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 2707
EXPOSE 44394

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY NB.CheckingAccountTransaction.API/NB.CheckingAccountTransaction.API.csproj NB.CheckingAccountTransaction.API/
COPY ["NB.CheckingAccountTransaction.API/Nuget.Config", "/root/.nuget/NuGet/NuGet.Config"]
COPY NB.CheckingAccountTransaction.Repository/NB.CheckingAccountTransaction.Repository.csproj NB.CheckingAccountTransaction.Repository/
COPY NB.CheckingAccountTransaction.Domain/NB.CheckingAccountTransaction.Domain.csproj NB.CheckingAccountTransaction.Domain/
COPY NB.CheckingAccountTransaction.Infrastructure/NB.CheckingAccountTransaction.Infrastructure.csproj NB.CheckingAccountTransaction.Infrastructure/
RUN dotnet restore --configfile "/root/.nuget/NuGet/NuGet.Config" NB.CheckingAccountTransaction.API/NB.CheckingAccountTransaction.API.csproj
COPY . .
WORKDIR /src/NB.CheckingAccountTransaction.API
RUN dotnet build NB.CheckingAccountTransaction.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish NB.CheckingAccountTransaction.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "NB.CheckingAccountTransaction.API.dll"]
