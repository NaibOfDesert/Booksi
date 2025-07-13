#!/bin/bash

echo "Started ... Build.sh"

# Set the directory 
SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"

# Direction to project
PROJECT_PATH="$SCRIPT_DIR/../../Booksi/Booksi.csproj"

# Check if project exist
if [ ! -f "$PROJECT_PATH" ]; then
    echo "❌ Error: Project file not found at $PROJECT_PATH"
    echo "Current script directory: $SCRIPT_DIR"
    echo "Looking for project at: $PROJECT_PATH"
    echo "Press any key to end..."
    read -n 1 -s
    exit 1
fi

echo "📁 Building project: $PROJECT_PATH"
echo ""

# Build - verbosity diagnostic to simplify
dotnet build "$PROJECT_PATH" \
  --verbosity normal \
  --configuration Debug \
  --no-incremental \
  --nologo \
  --force

echo "Build completed."
echo "Press any key to end..."
read -n 1 -s