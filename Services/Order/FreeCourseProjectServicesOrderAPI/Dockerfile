FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY Shared/FreeCourseShared/*.csproj Shared/FreeCourseShared/

COPY Services/Order/FreeCourseProjectServicesOrderApplication/*csproj Services/Order/FreeCourseProjectServicesOrderApplication/
COPY Services/Order/FreeCourseProjectServicesOrderDomain/*csproj Services/Order/FreeCourseProjectServicesOrderDomain/
COPY Services/Order/FreeCourseProjectServicesOrderDomainCore/*csproj Services/Order/FreeCourseProjectServicesOrderDomainCore/
COPY Services/Order/FreeCourseProjectServicesOrderInfrastructure/*csproj Services/Order/FreeCourseProjectServicesOrderInfrastructure/

COPY Services/Order/FreeCourseProjectServicesOrderAPI/*csproj Services/Order/FreeCourseProjectServicesOrderAPI/
RUN dotnet restore Services/Order/FreeCourseProjectServicesOrderAPI/*csproj
COPY . .
RUN dotnet publish Services/Order/FreeCourseProjectServicesOrderAPI/*csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","FreeCourseProjectServicesOrderAPI.dll" ]
