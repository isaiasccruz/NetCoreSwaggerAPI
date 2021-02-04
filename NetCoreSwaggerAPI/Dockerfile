FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Copy csproj and restore as distinct layers
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ./NetCoreSwaggerAPI/NetCoreSwaggerAPI/NetCoreSwaggerAPI.csproj .
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image

# runtime para broker console e aspnet para as aplicações asp.net core

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/ .
ENTRYPOINT ["dotnet", "NetCoreSwaggerAPI.dll"]