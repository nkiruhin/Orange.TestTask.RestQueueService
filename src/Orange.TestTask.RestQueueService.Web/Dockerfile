#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["nuget.config", "."]
COPY ["src/Orange.TestTask.RestQueueService.Web/Orange.TestTask.RestQueueService.Web.csproj", "src/Orange.TestTask.RestQueueService.Web/"]
COPY ["src/Orange.TestTask.RestQueueService.Contracts/Orange.TestTask.RestQueueService.Contracts.csproj", "src/Orange.TestTask.RestQueueService.Contracts/"]
COPY ["src/Orange.TestTask.RestQueueService.Infrastructure/Orange.TestTask.RestQueueService.Infrastructure.csproj", "src/Orange.TestTask.RestQueueService.Infrastructure/"]
COPY ["src/Orange.TestTask.RestQueueService.Core/Orange.TestTask.RestQueueService.Core.csproj", "src/Orange.TestTask.RestQueueService.Core/"]
RUN dotnet restore "src/Orange.TestTask.RestQueueService.Web/Orange.TestTask.RestQueueService.Web.csproj"
COPY . .
WORKDIR "/src/src/Orange.TestTask.RestQueueService.Web"
RUN dotnet build "Orange.TestTask.RestQueueService.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Orange.TestTask.RestQueueService.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Orange.TestTask.RestQueueService.Web.dll"]