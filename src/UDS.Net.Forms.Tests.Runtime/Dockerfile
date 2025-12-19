FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ./src/UDS.Net.Forms.Tests.Runtime/UDS.Net.Forms.Tests.Runtime.csproj ./UDS.Net.Forms.Tests.Runtime/
COPY ./src/UDS.Net.Forms/UDS.Net.Forms.csproj ./UDS.Net.Forms/
COPY ./src/UDS.Net.Services/UDS.Net.Services.csproj ./UDS.Net.Services/

RUN dotnet restore ./UDS.Net.Forms.Tests.Runtime/UDS.Net.Forms.Tests.Runtime.csproj

COPY ./src/UDS.Net.Forms.Tests.Runtime ./UDS.Net.Forms.Tests.Runtime
COPY ./src/UDS.Net.Forms ./UDS.Net.Forms
COPY ./src/UDS.Net.Services ./UDS.Net.Services

RUN dotnet publish ./UDS.Net.Forms.Tests.Runtime/UDS.Net.Forms.Tests.Runtime.csproj -c Release -o /app/publish --verbosity quiet

FROM base AS final
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS="http://+:80"
ENTRYPOINT ["dotnet", "UDS.Net.Forms.Tests.Runtime.dll"]