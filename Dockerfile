#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM default-route-openshift-image-registry.apps.ocp-unix-airgap.mobcorp.com/digital/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://*:5000

FROM sdk:6.0 AS build
WORKDIR /src
COPY ["WeatherCast/WeatherCast/WeatherCast.csproj", "WeatherCast/WeatherCast/"]
COPY ["WeatherCastCommon/WeatherCast.Common.Entities/WeatherCast.Common.Entities.csproj", "WeatherCastCommon/WeatherCast.Common.Entities/"]
RUN dotnet restore "WeatherCast/WeatherCast/WeatherCast.csproj"
COPY . .
WORKDIR "/src/WeatherCast"
RUN dotnet build "WeatherCast/WeatherCast.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WeatherCast/WeatherCast.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WeatherCast.dll"]