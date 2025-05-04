#!/bin/bash

echo "Started ... DockerCompose.sh"

# Set the directory containing docker-compose.yml
SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
DOCKER_DIR="$SCRIPT_DIR/../../Booksi"

# Change to that directory
cd "$DOCKER_DIR" || { echo "Directory not found: $DOCKER_DIR"; exit 1; }

# Run docker compose
docker compose up --build

echo "Press any key to end..."
read -n 1 -s
