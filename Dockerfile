FROM mcr.microsoft.com/dotnet/core/sdk AS build-env
WORKDIR /app

COPY  ./ ./
RUN dotnet restore OccupancyTracker.sln
COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet", "OccupancyTracker.dll" ]
