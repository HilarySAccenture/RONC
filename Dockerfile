#this block is not necessary with docker-compose using volumes option
#WORKDIR .
#COPY ./Certificate/server.crt ./etc/ssl/certs/server.crt
#ADD server.crt /etc/ssl/certs/server.crt
#RUN update-ca-certificates

# copy csproj and restore as distinct layers
FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /app
COPY *.sln .
COPY RONC/. ./MVCApp/
RUN dotnet restore ./MVCApp/RONC.csproj
#COPY RONC/. ./FrontEndApp/

#publish everything
WORKDIR /app/MVCApp
RUN dotnet publish -c Release -o out

#start the app
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime
WORKDIR /app
COPY --from=build /app/MVCApp/out ./
CMD ["dotnet", "RONC.dll"]