#!/bin/bash

echo "Started ... DockerCompose.sh"

# Set the directory containing docker-compose.yml
SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
DOCKER_DIR="$SCRIPT_DIR/../../Booksi"

# Change to that directory
cd "$DOCKER_DIR" || { echo "Directory not found: $DOCKER_DIR"; exit 1; }

# Set environment for production
export ENVIRONMENT=prod

# Build docker images without running containers
echo "Building Docker images..."
docker compose build

# Check if build was successful
if [ $? -eq 0 ]; then
    echo "Docker images built successfully!"
else
    echo "Error: Failed to build Docker images"
    exit 1
fi

echo "Build completed. Press any key to exit..."
read -n 1 -s