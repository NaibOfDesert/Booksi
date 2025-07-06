#!/bin/bash

echo "Started ... BooksiDbUpdate.sh"

# Set the directory 
SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"  

# Set environment for production
export ENVIRONMENT=prod

# Project paths
MAIN_PROJECT_PATH="$SCRIPT_DIR/../../Booksi/Booksi.csproj"
MIGRATIONS_PROJECT_PATH="$SCRIPT_DIR/../../Booksi.Data/Booksi.Data.csproj"

# Check if projects exist
if [ ! -f "$MAIN_PROJECT_PATH" ]; then
    echo "❌ Error: Main project not found at $MAIN_PROJECT_PATH"
    echo "Press any key to end..."
    read -n 1 -s
    exit 1
fi

if [ ! -f "$MIGRATIONS_PROJECT_PATH" ]; then
    echo "❌ Error: Data project not found at $MIGRATIONS_PROJECT_PATH"
    echo "Press any key to end..."
    read -n 1 -s
    exit 1
fi

echo "📁 Main project: $MAIN_PROJECT_PATH"
echo "📁 Data project: $MIGRATIONS_PROJECT_PATH"
echo ""

# Function to check if dotnet ef tools are installed
check_ef_tools() {
    if ! dotnet ef --version &> /dev/null; then
        echo "⚠️  Entity Framework tools not found. Installing..."
        dotnet tool install --global dotnet-ef
        
        if [ $? -ne 0 ]; then
            echo "❌ Failed to install Entity Framework tools"
            echo "Press any key to end..."
            read -n 1 -s
            exit 1
        fi
        echo "✅ Entity Framework tools installed successfully"
    else
        echo "✅ Entity Framework tools are available"
        dotnet ef --version
    fi
    echo ""
}

# Function to update database
update_database() {
    echo "🔄 Updating database..."
    
    # Update database using the main project as startup project
    dotnet ef database update \
        --project "$MIGRATIONS_PROJECT_PATH" \
        --startup-project "$MAIN_PROJECT_PATH" \
        --verbose
    
    local exit_code=$?
    
    if [ $exit_code -eq 0 ]; then
        echo ""
        echo "✅ Database updated successfully!"
    else
        echo ""
        echo "❌ Database update failed with exit code: $exit_code"
        echo ""
        echo "🔍 Common solutions:"
        echo "  1. Check if database server is running"
        echo "  2. Verify connection string in appsettings.json"
        echo "  3. Ensure migrations exist in the project"
        echo "  4. Check if database user has proper permissions"
        return $exit_code
    fi
}

# Function to list available migrations
list_migrations() {
    echo "📋 Available migrations:"
    dotnet ef migrations list \
        --project "$MIGRATIONS_PROJECT_PATH" \
        --startup-project "$MAIN_PROJECT_PATH" \
        --no-build
    echo ""
}

# Function to show database info
show_database_info() {
    echo "🔍 Database connection info:"
    dotnet ef dbcontext info \
        --project "$MIGRATIONS_PROJECT_PATH" \
        --startup-project "$MAIN_PROJECT_PATH" \
        --no-build
    echo ""
}

# Main execution
echo "🚀 Starting Booksi Database Update Process..."
echo "Environment: $ENVIRONMENT"
echo ""

# Check EF tools
check_ef_tools

# Show database info
show_database_info

# List migrations
list_migrations

# Ask user for confirmation
echo "❓ Do you want to proceed with database update? (y/N)"
read -n 1 -r
echo ""

if [[ $REPLY =~ ^[Yy]$ ]]; then
    update_database
    update_exit_code=$?
    
    if [ $update_exit_code -eq 0 ]; then
        echo ""
        echo "🎉 Database update completed successfully!"
        echo "📊 Final database state:"
        show_database_info
    else
        echo ""
        echo "💥 Database update process failed!"
        echo "Please check the error messages above and try again."
    fi
else
    echo "❌ Database update cancelled by user"
    update_exit_code=1
fi

echo ""
echo "📝 Database update process finished"
echo "Press any key to end..."
read -n 1 -s

exit $update_exit_code