using System.ComponentModel.DataAnnotations;

namespace Booksi.Runner.Menu;

public enum MainMenuOption
{
    Build,
    Up,
    Run,
    AddScripts,
    Kill,
    Exit
}

public enum UpMenuOption
{
    Compose,
    DbUpdate,
    DbUpdateAuto,
    Back
}