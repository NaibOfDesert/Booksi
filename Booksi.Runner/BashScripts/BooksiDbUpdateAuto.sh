#!/bin/bash

echo "Started ... BooksiDbUpdateAuto.sh (Automatic mode)"

# Set the directory 
SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"

# Set environment for production
export ENVIRONMENT=prod

# Project paths
MAIN_PROJECT_PATH="$SCRIPT_DIR/../../Booksi/Booksi.csproj"
MIGRATIONS_PROJECT_PATH="$SCRIPT_DIR/../../Booksi.Data/Booksi.Data.csproj"

echo "🚀 Auto-updating Booksi database..."
echo "Environment: $ENVIRONMENT"

# Check if dotnet ef tools are installed
if ! dotnet ef --version &> /dev/null; then
    echo "⚠️  Installing Entity Framework tools..."
    dotnet tool install --global dotnet-ef
fi

# Update database automatically
echo "🔄 Updating database..."
dotnet ef database update \
    --project "$MIGRATIONS_PROJECT_PATH" \
    --startup-project "$MAIN_PROJECT_PATH"

if [ $? -eq 0 ]; then
    echo "✅ Database updated successfully!"
else
    echo "❌ Database update failed!"
    exit 1
fi

echo "📝 Auto database update completed"