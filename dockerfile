FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base

# setting working directory
WORKDIR /app
EXPOSE 5050

#
RUN dotnet dev-certs https --trust

ENV ASPNETCORE_URLS="https://*:443;http://*:80"

#copy vault files
COPY ./workflow-vault.sh /workflow-vault.sh
COPY ./vault-policy.hcl /vault-policy.hcl
RUN chmod +x /workflow-vault.sh

# remove when going to production
ENV ASPNETCORE_ENVIRONMENT=Development

RUN apt-get update && \
    apt-get install -y openssl

# Create a directory for the app

# Generate a self-signed certificate
RUN openssl genrsa -out server.key 2048 && \
    openssl req -new -key server.key -out server.csr -subj "/C=US/ST=CA/L=San Francisco/O=MyOrg/CN=localhost" && \
    openssl x509 -req -days 365 -in server.csr -signkey server.key -out server.crt


COPY . .

# set api working directory
WORKDIR /app/Searching.Management.Api

# restore all the nuget packages
RUN dotnet restore

RUN dotnet publish -c Release -o /app/publish 

FROM base AS final
COPY --from=base /app/publish .
COPY --from=base /root/.dotnet/corefx/cryptography/x509stores/my/* /root/.dotnet/corefx/cryptography/x509stores/my/

RUN dotnet tool install --global dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"

EXPOSE 443
EXPOSE 8080
EXPOSE 7284

ENTRYPOINT ["dotnet", "Searching.Management.Api.dll"]

