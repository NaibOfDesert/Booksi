#!/bin/bash

echo "Started new migration ... BooksiDbUpdate.sh"

# Set the directory 
SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"  






echo ""
echo "📝 New Migration process finished"
echo "Press any key to end..."
read -n 1 -s

exit $update_exit_code