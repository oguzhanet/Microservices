FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY Shared/FreeCourseShared/*.csproj Shared/FreeCourseShared/
COPY Services/Basket/FreeCourseProjectServicesBasketAPI/*csproj Services/Basket/FreeCourseProjectServicesBasketAPI/
RUN dotnet restore Services/Basket/FreeCourseProjectServicesBasketAPI/*csproj
COPY . .
RUN dotnet publish Services/Basket/FreeCourseProjectServicesBasketAPI/*csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","FreeCourseProjectServicesBasketAPI.dll" ]
