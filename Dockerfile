FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY *.sln .
COPY NetGameProjectBlazor/NetGameProjectBlazor/NetGameProjectBlazor.csproj NetGameProjectBlazor/NetGameProjectBlazor/
COPY NetGameProjectBlazor/NetGameProjectBlazor.Client/NetGameProjectBlazor.Client.csproj NetGameProjectBlazor/NetGameProjectBlazor.Client/
COPY NetGameProjectBlazor.Shared/NetGameProjectBlazor.Shared.csproj NetGameProjectBlazor.Shared/

RUN dotnet restore NetGameProjectBlazor/NetGameProjectBlazor/NetGameProjectBlazor.csproj

COPY . .

RUN dotnet publish NetGameProjectBlazor/NetGameProjectBlazor/NetGameProjectBlazor.csproj -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app .

ENV ASPNETCORE_ENVIRONMENT=Production
EXPOSE 8080
ENTRYPOINT ["dotnet", "NetGameProjectBlazor.dll"]