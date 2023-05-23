#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 82
EXPOSE 445

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["UDS.Net.Web.MVC/UDS.Net.Web.MVC.csproj", "UDS.Net.Web.MVC/"]
COPY ["UDS.Net.Forms/UDS.Net.Forms.csproj", "UDS.Net.Forms/"]
COPY ["UDS.Net.Services/UDS.Net.Services.csproj", "UDS.Net.Services/"]
COPY ["UDS.Net.Web.MVC.Services/UDS.Net.Web.MVC.Services.csproj", "UDS.Net.Web.MVC.Services/"]
RUN dotnet restore "UDS.Net.Web.MVC/UDS.Net.Web.MVC.csproj"
COPY . .
WORKDIR "/src/UDS.Net.Web.MVC"
RUN dotnet build "UDS.Net.Web.MVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UDS.Net.Web.MVC.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UDS.Net.Web.MVC.dll"]
