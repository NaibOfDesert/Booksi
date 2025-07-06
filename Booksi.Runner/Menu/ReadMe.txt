## Menu System
The application features a cross-platform interactive menu system that adapts to different operating systems and provides various options for managing the Booksi application.

### How the Menu System Works

#### 1. Application Startup
- The application starts by calling `new Menu().StartMenu(args)` from the main entry point
- Command line arguments are passed to determine the operating system environment
- The application uses proper error handling with try-catch blocks for robust operation

#### 2. Environment Detection
- The system analyzes command line arguments to detect the operating system
- If "WIN" is found in arguments (case-insensitive), it sets Windows environment
- Otherwise, it defaults to Mac environment
- The detected environment is properly passed to both MenuProvider and CodeFactory
- Environment setup ensures consistent behavior across all components

#### 3. Menu Provider Initialization
- A `MenuProvider` is created based on the detected environment
- The provider uses a delegate pattern to select the appropriate menu display method:
    - **Mac Environment**: Text input menu (type-to-select)
    - **Windows Environment**: Arrow navigation menu (keyboard navigation)

#### 4. Menu Display Methods
##### Text Input Menu (Mac)
- Displays all available options in a list format
- User types the exact option name they want to select
- Input validation ensures only valid options are accepted
- Loops until a valid option is entered

##### Arrow Navigation Menu (Windows)
- Shows options with visual highlighting of the currently selected item
- User navigates using Up/Down arrow keys
- Selected option is highlighted with different colors
- Enter key confirms the selection
- Provides intuitive keyboard navigation experience

#### 5. Main Menu Options
The system provides the following main menu options:
- **Build**: Compiles and builds the Booksi application using external terminal
- **Up**: Opens a submenu for deployment-related tasks
- **Run**: Starts the Booksi application in external terminal
- **AddScripts**: Runs script permissions setup in internal terminal
- **Kill**: Terminates running Booksi processes in internal terminal
- **Exit**: Closes the menu application

#### 6. Submenu System (Up Menu)
When "Up" is selected, a secondary menu appears with options:
- **Compose**: Starts Docker composition for Booksi (internal terminal)
- **DbUpdate**: Updates the database schema (external terminal)
- **Back**: Returns to the main menu

The submenu properly handles the "Back" option and loops until the user chooses to return to the main menu.

#### 7. Command Execution Architecture
- **CodeFactory**: Central command execution hub that handles environment-specific logic
- **Terminal Types**: 
  - `Internal`: Runs commands within the application, captures output/errors
  - `External`: Opens new terminal windows for interactive commands
- **Platform-Specific Execution**:
  - **Mac**: Uses `open -a Terminal` for external terminals, `/bin/bash` for internal
  - **Windows**: Uses `cmd.exe` with `start` command for external terminals
- **Error Handling**: Comprehensive error handling with logging for failed operations
- **Output Capture**: Internal terminal captures and displays command output and errors

#### 8. Script Management
The system executes various bash scripts:
- **BooksiBuild.sh**: Builds the .NET application with production environment
- **BooksiCompose.sh**: Handles Docker composition
- **BooksiRun.sh**: Starts the application
- **AddScripts.sh**: Sets executable permissions on scripts
- **BooksiKill.sh**: Terminates running processes on specific ports
- **DbUpdate.sh**: Updates database schema

#### 9. Menu Loop & Navigation
- After executing a command, the system returns to the appropriate menu level
- Main menu continues until the user selects "Exit"
- Submenu continues until user selects "Back"
- Enum-based option handling ensures type safety and prevents invalid selections
- Proper string conversion from enums for display and comparison

### Architecture Improvements

#### Simplified Design
- **Removed unnecessary abstractions**: Eliminated redundant `TerminalRunner` and `ITerminalRunner` interfaces
- **Direct execution**: Commands execute directly through `CodeFactory` without unnecessary wrapper layers
- **Cleaner namespace structure**: Moved menu classes to `Booksi.Runner.MenuSystem` to avoid naming conflicts

#### Error Handling & Logging
- **Comprehensive error handling**: Try-catch blocks at multiple levels
- **Detailed logging**: Process exit codes, error messages, and operation status
- **Graceful failure**: Application continues running even if individual commands fail

#### Cross-Platform Support
- **Environment-aware execution**: Different command strategies for Mac/Windows
- **Path handling**: Proper script path construction for different operating systems
- **Terminal integration**: Native terminal launching for each platform

### Key Features
- **Cross-platform compatibility** with adaptive UI and command execution
- **Type-safe enum-based options** for reliable menu handling
- **Flexible command execution** supporting both internal and external terminals
- **Intuitive user experience** tailored to each operating system
- **Robust error handling** with comprehensive logging and input validation
- **Extensible design** allowing easy addition of new menu options
- **Clean architecture** with simplified command execution flow
- **Proper namespace organization** preventing naming conflicts

### Technical Stack
- **.NET 7.0** with C# 11.0
- **ASP.NET Core** with Razor
- **Cross-platform bash script execution**
- **Native terminal integration** for Mac and Windows
- **Enum-driven menu system** for type safety

This menu system serves as the primary interface for managing all Booksi application operations, providing users with an efficient and user-friendly way to execute various development and deployment tasks across different operating systems.