// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");



// Run PlaywrightRunner for Testing.


Console.WriteLine("");

Menu();
var input = Console.ReadLine();

 

void Menu(){

    Console.WriteLine("Description: \n"); 

    Console.WriteLine("Options: \n" + 
        "1. Run tests (dotnet run )" + 
        "2. Docker compose up build" + 
        "3. Db)");
}

void Switch(string inpput) {
    switch (inpput) {
        case "1":
            Console.WriteLine("Test running\n");
            // start docker try
            
            System.Diagnostics.Process.Start("dotnet", "run --project ../Booksi/Booksi.csproj");
            break;
        case "2":
            System.Diagnostics.Process.Start("dotnet", "run --project ../Booksi.PlaywrightRunner/Booksi.PlaywrightRunner.csproj");
            break;
        case "3":
            break;
        default:
            break;
    }
}

void Clear() {
    System.Diagnostics.Process.Start("clear");
}
void MenuDb() {
    Console.WriteLine("");
}