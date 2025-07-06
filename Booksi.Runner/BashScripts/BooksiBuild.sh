#!/bin/bash

echo "Started ... BooksiBuild.sh"

# Set the directory 
SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"

# Set environment for production
export ENVIRONMENT=prod

# Build - verbosity diagnostic to simplify
dotnet build "$SCRIPT_DIR/../../Booksi/Booksi.csproj" \
  --verbosity diagnostic \
  --configuration Debug \
  --no-incremental \
  --force

echo "Build completed."
echo "Press any key to end..."
read -n 1 -s
