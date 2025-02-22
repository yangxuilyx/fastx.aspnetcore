#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# FROM node:20.12.2 AS front
# WORKDIR /app
# COPY ./src/angular .
# RUN npm i
# RUN npm run build

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
ENV TZ=Asia/Shanghai 
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY . .
RUN dotnet restore "src/aspnetcore/FastX.App.Host/FastX.App.Host.csproj"
RUN dotnet build "src/aspnetcore/FastX.App.Host/FastX.App.Host.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "src/aspnetcore/FastX.App.Host/FastX.App.Host.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
COPY src/aspnetcore/FastX.App.Host/browser /app/publish/browser

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .

# COPY --from=front /app/dist/ng-ant-admin/browser ./web
ENTRYPOINT ["dotnet", "FastX.App.Host.dll"]