#!/bin/bash

echo "Started ... BooksiRun.sh"

# Set the directory 
SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
PROJECT_PATH="$SCRIPT_DIR/../../Booksi/Booksi.csproj"

echo "Using project: $PROJECT_PATH"

# Set environment for production
export ENVIRONMENT=prod

# Run in background
dotnet run --project "$PROJECT_PATH" &
APP_PID=$!

sleep 2
open "http://localhost:5231" || xdg-open "http://localhost:5231"

echo "Press any key to stop the app..."
read -n 1 -s

# Kill the app
kill $APP_PID

