FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
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
COPY aspnetapp.pfx /https/aspnetapp.pfx

ENV ASPNETCORE_URLS="https://+:443;http://+:80"
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx
ENV ASPNETCORE_Kestrel__Certificates__Default__Password=Password123!
ENTRYPOINT ["dotnet", "UDS.Net.Forms.Tests.Runtime.dll"]