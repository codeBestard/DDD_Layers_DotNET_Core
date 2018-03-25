FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY DDD.OnlineSchoolRegistration.sln ./
COPY OSR.Web.Api/OSR.Web.Api.csproj OSR.Web.Api/
COPY OSR.Application/OSR.Application.csproj OSR.Application/
COPY OSR.Infrastructure/OSR.Infrastructure.csproj OSR.Infrastructure/
COPY OSR.Infrastructure.Persistance.Sql/OSR.Infrastructure.Persistance.Sql.csproj OSR.Infrastructure.Persistance.Sql/
COPY OSR.Domain.Common/OSR.Domain.Common.csproj OSR.Domain.Common/
COPY OSR.Domain/OSR.Domain.csproj OSR.Domain/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/OSR.Web.Api
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "OSR.Web.Api.dll"]
