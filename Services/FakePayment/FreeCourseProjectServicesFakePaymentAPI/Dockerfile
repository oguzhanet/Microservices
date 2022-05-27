FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY Shared/FreeCourseShared/*.csproj Shared/FreeCourseShared/
COPY Services/FakePayment/FreeCourseProjectServicesFakePaymentAPI/*csproj Services/FakePayment/FreeCourseProjectServicesFakePaymentAPI/
RUN dotnet restore Services/FakePayment/FreeCourseProjectServicesFakePaymentAPI/*csproj
COPY . .
RUN dotnet publish Services/FakePayment/FreeCourseProjectServicesFakePaymentAPI/*csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","FreeCourseProjectServicesFakePaymentAPI.dll" ]
