#!/bin/bash

echo "Started ... BooksiRun.sh"

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
PROJECT_PATH="$SCRIPT_DIR/../../Booksi/Booksi.csproj"

dotnet run --project "$PROJECT_PATH"

if [ $? -ne 0 ]; then
    echo "dotnet run failed"
    exit 1
fi

echo "Press any key to end..."
read -n 1 -s
