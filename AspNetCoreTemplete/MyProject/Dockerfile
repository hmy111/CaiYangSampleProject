FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
#COPY ["../XXXProject/XXXProject.csproj", "XXXProject/"]
COPY ../ .
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM base AS final
WORKDIR /app
COPY --from=build /src/out .
ENTRYPOINT ["dotnet", "MyProject.dll"]
