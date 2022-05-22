FROM mcr.microsoft.com/dotnet/sdk:3.1 as build
WORKDIR /app
EXPOSE 80
COPY Shared/FreeCourseShared/*.csproj Shared/FreeCourseShared/
COPY IdentityServer/FreeCourseIdentityServer/*csproj IdentityServer/FreeCourseIdentityServer/
RUN dotnet restore IdentityServer/FreeCourseIdentityServer/*csproj
COPY . .
RUN dotnet publish IdentityServer/FreeCourseIdentityServer/*csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:3.1 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","FreeCourseIdentityServer.dll" ]
