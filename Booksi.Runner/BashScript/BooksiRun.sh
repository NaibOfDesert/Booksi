#!/bin/bash

echo "Started ... BooksiRun.sh"

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
dotnet run "$SCRIPT_DIR/../../Booksi/Booksi.csproj"

sleep 5   # wait a few seconds

