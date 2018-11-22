FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["EnergyOrderManagement.Api/EnergyOrderManagement.Api.csproj", "EnergyOrderManagement.Api/"]
RUN dotnet restore "EnergyOrderManagement.Api/EnergyOrderManagement.Api.csproj"
COPY . .
WORKDIR "/src/EnergyOrderManagement.Api"
RUN dotnet build "EnergyOrderManagement.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "EnergyOrderManagement.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EnergyOrderManagement.Api.dll"]