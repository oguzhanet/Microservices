FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY Shared/FreeCourseShared/*.csproj Shared/FreeCourseShared/
COPY Frontends/FreeCourseProjectWebUI/*csproj Frontends/FreeCourseProjectWebUI/
RUN dotnet restore Frontends/FreeCourseProjectWebUI/*csproj
COPY . .
RUN dotnet publish Frontends/FreeCourseProjectWebUI/*csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","FreeCourseProjectWebUI.dll" ]
