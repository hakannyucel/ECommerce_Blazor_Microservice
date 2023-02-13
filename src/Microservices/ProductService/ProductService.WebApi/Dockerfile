#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Microservices/ProductService/ProductService.WebApi/ProductService.WebApi.csproj", "src/Microservices/ProductService/ProductService.WebApi/"]
COPY ["src/Common/Common/Common.csproj", "src/Common/Common/"]
COPY ["src/Microservices/ProductService/ProductService.Application/ProductService.Application.csproj", "src/Microservices/ProductService/ProductService.Application/"]
COPY ["src/Common/Common.Persistence/Common.Persistence.csproj", "src/Common/Common.Persistence/"]
COPY ["src/Microservices/ProductService/ProductService.Domain/ProductService.Domain.csproj", "src/Microservices/ProductService/ProductService.Domain/"]
RUN dotnet restore "src/Microservices/ProductService/ProductService.WebApi/ProductService.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Microservices/ProductService/ProductService.WebApi"
RUN dotnet build "ProductService.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductService.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductService.WebApi.dll"]