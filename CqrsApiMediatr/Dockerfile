# FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
# WORKDIR /app

# # Creates a non-root user with an explicit UID and adds permission to access the /app folder
# # For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
# RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
# USER appuser

# FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
# WORKDIR /src
# COPY ["CqrsApi/CqrsApi.csproj", "CqrsApi/"]
# RUN dotnet restore "CqrsApi/CqrsApi.csproj"
# COPY . .
# WORKDIR "/src/CqrsApi"
# RUN dotnet build "CqrsApi.csproj" -c Release -o /app/build

# FROM build AS publish
# RUN dotnet publish "CqrsApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "CqrsApi.dll"]

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 9001

RUN addgroup --system dotnet && adduser --system dotnet -ingroup dotnet
RUN cd / && chown -R dotnet:dotnet app/ && ls -l | grep app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
RUN ls
RUN dotnet build CqrsApi/CqrsApi.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish CqrsApi/CqrsApi.csproj -c Release -o /app

FROM base as final
WORKDIR /app
COPY --from=publish /app .

USER dotnet
ENV PORT=9001

ENTRYPOINT ["dotnet", "CqrsApi.dll"]