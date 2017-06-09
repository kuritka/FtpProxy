# beware where you run docker instance.
# dotnet publish -c Release -o out
# docker build -t ftpproxy .
# docker run -it --rm ftpproxy

FROM microsoft/dotnet:2.0.0-preview1-sdk
WORKDIR /ftpproxy
COPY out .
ENTRYPOINT ["dotnet", "ftpproxy.dll"]
