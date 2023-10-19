#!/bin/bash

# Check if the "webapi" service container is running using docker-compose
CONTAINER_ID=$(docker ps -q --filter "name=webapi")

if [ -n "$CONTAINER_ID" ]; then
  echo "The 'webapi' service container is running with Docker Compose."
  
  # Check the command-line argument
  if [ "$1" == "-g" ]; then
    # Generate a migration
    echo "Generating a migration..."
    docker-compose exec webapi bash -c "cd /app/Searching.Infrastructure && dotnet ef migrations add $2 -s ../Searching.Management.Api --context DatabaseContext"
    echo "Migration generated successfully."
  elif [ "$1" == "-u" ]; then
    # Update the database
    echo "Updating the database..."
    docker-compose exec webapi dotnet ef database update
    echo "Database updated successfully."
  else
    echo "Invalid option. Use '-g' to generate a migration or '-u' to update the database."
  fi
else
  echo "The 'webapi' service is not running with Docker Compose. Running the command directly."
  if [ "$1" == "-g" ]; then
    echo "Generating a migration..."
    cd Searching.Infrastructure && dotnet ef migrations add $2 -s ../Searching.Management.Api --context DatabaseContext
    echo "Migration generated successfully."
  elif [ "$1" == "-u" ]; then
    echo "Updating the database..."
    cd Searching.Management.Api && dotnet ef database update
    echo "Database updated successfully."
  else
    echo "Invalid option. Use '-g' to generate a migration or '-u' to update the database."
  fi
fi
