FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY Shared/FreeCourseShared/*.csproj Shared/FreeCourseShared/
COPY Services/PhotoStock/FreeCourseProjectServicesPhotoStockAPI/*csproj Services/PhotoStock/FreeCourseProjectServicesPhotoStockAPI/
RUN dotnet restore Services/PhotoStock/FreeCourseProjectServicesPhotoStockAPI/*csproj
COPY . .
RUN dotnet publish Services/PhotoStock/FreeCourseProjectServicesPhotoStockAPI/*csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","FreeCourseProjectServicesPhotoStockAPI.dll" ]
