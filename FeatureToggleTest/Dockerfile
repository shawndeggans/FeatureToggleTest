FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["FeatureToggleTest/FeatureToggleTest.csproj", "FeatureToggleTest/"]
RUN dotnet restore "FeatureToggleTest/FeatureToggleTest.csproj"
COPY . .
WORKDIR "/src/FeatureToggleTest"
RUN dotnet build "FeatureToggleTest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FeatureToggleTest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FeatureToggleTest.dll"]