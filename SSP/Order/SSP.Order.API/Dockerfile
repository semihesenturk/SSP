#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Order/SSP.Order.API/SSP.Order.API.csproj", "Order/SSP.Order.API/"]
COPY ["Order/SSP.Order.Application/SSP.Order.Application.csproj", "Order/SSP.Order.Application/"]
COPY ["Order/SSP.Order.Domain/SSP.Order.Domain.csproj", "Order/SSP.Order.Domain/"]
COPY ["Order/SSP.Order.Infrastructure/SSP.Order.Infrastructure.csproj", "Order/SSP.Order.Infrastructure/"]
RUN dotnet restore "Order/SSP.Order.API/SSP.Order.API.csproj"
COPY . .
WORKDIR "/src/Order/SSP.Order.API"
RUN dotnet build "SSP.Order.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SSP.Order.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SSP.Order.API.dll"]
