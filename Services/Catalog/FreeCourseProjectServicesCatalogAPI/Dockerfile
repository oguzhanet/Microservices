FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY Shared/FreeCourseShared/*.csproj Shared/FreeCourseShared/
COPY Services/Catalog/FreeCourseProjectServicesCatalogAPI/*csproj Services/Catalog/FreeCourseProjectServicesCatalogAPI/
RUN dotnet restore Services/Catalog/FreeCourseProjectServicesCatalogAPI/*csproj
COPY . .
RUN dotnet publish Services/Catalog/FreeCourseProjectServicesCatalogAPI/*csproj -c Release - o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","FreeCourseProjectServicesCatalogAPI.dll" ]
