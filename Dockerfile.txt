FROM mcr.microsoft.com/dotnet/sdk:10.0

WORKDIR /src

COPY . .

RUN dotnet restore MyBot.csproj
RUN dotnet build MyBot.csproj -c Release

CMD ["dotnet", "run", "--project", "MyBot.csproj"]