FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY OSR.Web.Api/OSR.Web.Api.csproj OSR.Web.Api/
COPY OSR.Application/OSR.Application.csproj OSR.Application/
COPY OSR.Infrastructure/OSR.Infrastructure.csproj OSR.Infrastructure/
COPY OSR.Infrastructure.Persistance.Sql/OSR.Infrastructure.Persistance.Sql.csproj OSR.Infrastructure.Persistance.Sql/
COPY OSR.Domain.Common/OSR.Domain.Common.csproj OSR.Domain.Common/
COPY OSR.Domain/OSR.Domain.csproj OSR.Domain/
RUN dotnet restore OSR.Web.Api/OSR.Web.Api.csproj
COPY . .
WORKDIR /src/OSR.Web.Api
RUN dotnet build OSR.Web.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish OSR.Web.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "OSR.Web.Api.dll"]
