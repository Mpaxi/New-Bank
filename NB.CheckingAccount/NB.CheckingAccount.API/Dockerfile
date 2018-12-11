FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
ENV certPassword password

# Use opnssl to generate a self signed certificate cert.pfx with password $env:certPassword
RUN openssl genrsa -des3 -passout pass:${certPassword} -out server.key 2048
RUN openssl rsa -passin pass:${certPassword} -in server.key -out server.key
RUN openssl req -sha256 -new -key server.key -out server.csr -subj '/CN=localhost'
RUN openssl x509 -req -sha256 -days 365 -in server.csr -signkey server.key -out server.crt
RUN openssl pkcs12 -export -out cert.pfx -inkey server.key -in server.crt -certfile server.crt -passout pass:${certPassword}

EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
#RUN wget -P "/root/.nuget/NuGet/" https://download.microsoft.com/download/1/9/F/19FEB118-A1D8-4B0E-B74C-D155FC5D297E/aspnetcore-runtime-2.2.0-preview1-35029-linux-x64.tar.gz
COPY ["NB.CheckingAccount.API/NB.CheckingAccount.API.csproj", "NB.CheckingAccount.API/"]
COPY ["NB.CheckingAccount.API/Nuget.Config", "/root/.nuget/NuGet/NuGet.Config"]
COPY ["NB.CheckingAccount.Domain/NB.CheckingAccount.Domain.csproj", "NB.CheckingAccount.Domain/"]
COPY ["NB.CheckingAccount.Repository/NB.CheckingAccount.Repository.csproj", "NB.CheckingAccount.Repository/"]
RUN dotnet restore --configfile "/root/.nuget/NuGet/NuGet.Config" "NB.CheckingAccount.API/NB.CheckingAccount.API.csproj"
COPY . .
WORKDIR "/src/NB.CheckingAccount.API"
RUN dotnet build "NB.CheckingAccount.API.csproj" -c Release -o /app


FROM build AS publish
RUN dotnet publish "NB.CheckingAccount.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app

COPY --from=publish /app .
ENTRYPOINT ["dotnet", "NB.CheckingAccount.API.dll"]