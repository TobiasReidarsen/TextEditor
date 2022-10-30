namespace TextEditor;

public class MainMenu
{
    
    private string FileName { get; set; }

    private void MakeNewFile()
    {
        while (true)
        {
            Console.WriteLine("Welcome to this text editor. \nY to make new file. N to view other files.");
            ConsoleKeyInfo choice = Console.ReadKey();

            switch (choice.Key)
            {
                case ConsoleKey.Y:
                    // Run Editor
                    WriteFileName();
                    var textEditor = new TextEditor(FileName);

                    break;
                case ConsoleKey.N:
                    // #TODO make it so that the user can view older files and edit them
                    Console.Clear();
                    Console.WriteLine("Placeholder");
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid input. Y or N ONLY! Press anything to continue");
                    Console.ReadKey(true);
                    Console.Clear();
                    continue;
            }
            break;
        }
    }

    private void WriteFileName()
    {
        Console.Clear();                                                                 
        Console.WriteLine("Write the name of the file of file");                         
        string? nameOfFile = Console.ReadLine();
        Console.Clear();
        if (!(string.IsNullOrEmpty(nameOfFile) || string.IsNullOrWhiteSpace(nameOfFile)))
        {
            FileName = nameOfFile;  
        }
        Console.WriteLine("Created file with name: " + FileName + "\nPress anything to continue");
        Console.ReadKey(true);
    }

    public MainMenu()
    {
        FileName = "NewFile"; 
        MakeNewFile();
        
    }
}