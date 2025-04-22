// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");



// Run PlaywrightRunner for Testing.


Console.WriteLine("");

Menu();
string? input = Console.ReadLine();
Switch(input);
 

void Menu(){

    Console.WriteLine("Description: \n"); 

    Console.WriteLine("Options: \n" + 
        "1. Build" + 
        "2. Up" + 
        "3. Run");
}

void MenuUp(){

    Console.WriteLine("Description: \n"); 

    Console.WriteLine("Options: \n" + 
        "1. Db Add Migration" + 
        "2. Up Update" + 
        "3. Docker Compose");
}


void Switch(string? input1, string input2 = "0") {
    if(input != null) {
        switch (input1) {
            case "1":
                Console.WriteLine("Build\n");
                System.Diagnostics.Process.Start("dotnet", "build --project ../Booksi.csproj");
                break;
            case "2":
                Console.WriteLine("Up\n");
                switch (input2){
                    case "1":
                    break;
                }

                System.Diagnostics.Process.Start("dotnet", "run --project ../Booksi.PlaywrightRunner/Booksi.PlaywrightRunner.csproj");
                break;
            case "3":
                break;
            default:
                break;
        }
    
    }
    else {
        throw new Exception("Value cannot be null");
    }

}



void Run() {

}

void Clear() {
    System.Diagnostics.Process.Start("clear");
}
void MenuDb() {
    Console.WriteLine("");
}