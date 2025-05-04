#!/bin/bash

echo "Started ... BooksiRun.sh"

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
dotnet build "$SCRIPT_DIR/../../Booksi/Booksi.csproj"

echo "Press any key to end..."
read -n 1 -s
