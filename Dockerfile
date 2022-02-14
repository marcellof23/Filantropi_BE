#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["App/if3250_2022_19_filantropi_backend.csproj", "."]
RUN dotnet restore "./if3250_2022_19_filantropi_backend.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "App/if3250_2022_19_filantropi_backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "App/if3250_2022_19_filantropi_backend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "if3250_2022_19_filantropi_backend.dll", "--environment=Development"]