FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ProjectManagement.Api/ProjectManagement.Api.csproj", "ProjectManagement.Api/"]
RUN dotnet restore "ProjectManagement.Api/ProjectManagement.Api.csproj"
COPY . .
WORKDIR "/src/ProjectManagement.Api"
RUN dotnet build "ProjectManagement.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProjectManagement.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "ProjectManagement.Api.dll"]

RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh
