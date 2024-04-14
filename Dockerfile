FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["CurrencyConverter_CL.csproj", "./"]
RUN dotnet restore "CurrencyConverter_CL.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "CurrencyConverter_CL.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CurrencyConverter_CL.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CurrencyConverter_CL.dll"]
