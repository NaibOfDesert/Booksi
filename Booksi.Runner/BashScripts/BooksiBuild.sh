#!/bin/bash

echo "Started ... BooksiBuild.sh"

# Set the directory 
SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"

# Set environment for production
export ENVIRONMENT=prod

# Build
dotnet build "$SCRIPT_DIR/../../Booksi/Booksi.csproj"

echo "Press any key to end..."
read -n 1 -s
