#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80


FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/ToDo.Application/ToDo.Application.csproj", "src/ToDo.Application/"]
RUN dotnet restore "src/ToDo.Application/ToDo.Application.csproj"
COPY . .
WORKDIR "/src/src/ToDo.Application"
RUN dotnet build "ToDo.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ToDo.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToDo.Application.dll"]