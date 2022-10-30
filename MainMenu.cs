namespace TextEditor;

public class MainMenu
{
    private string FileName { get; set; }

    private void MainMenuOptions()
    {
        Console.Clear();
        Console.WriteLine(
            "Write 'list' for a list of options\nWrite 'info + ARGUMENT' to see info on that argument");
        while (true)
        {
            string? optionChoice = Console.ReadLine();
            if (string.IsNullOrEmpty(optionChoice)) MainMenuOptions();
            string[] words = optionChoice.Split(' ');
            Console.Clear();
            if (words[0] == "list")
            {
                DisplayOptions();
            }
            else if (words.Contains("info") && words.Length >= 2)
            {
                DisplayOptions(words);
            }
            else if(words[0] == "exit" && words.Length == 1)
            {
                Environment.Exit(0);
            }
        }
    }

    private void DisplayOptions()
    {
        Console.Clear();
        var dictionary = DictBuilder();
        foreach (var keyElement in dictionary)
        {
            Console.WriteLine(keyElement.Key);
        }
    }

    private void DisplayOptions(string[] input)
    {
        var dictionary = DictBuilder();
        string value = "";
        for (int i = 1; i < input.Length; i++)
        {
            Console.WriteLine(dictionary.TryGetValue(input[i], out value)? dictionary[input[i]]: value );
        }

        Console.ReadKey(true);
    }

    private Dictionary<string, string> DictBuilder()
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>()
        {
            { "editor", "editor : Opens a simple Console Based Text Editor" },
            { "exit", "exit : exits the application" }
        };
        return dictionary;
    }

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
                    // #TODO make i
                    // t so that the user can view older files and edit them
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
        this.FileName = "NewFile";
        MainMenuOptions();
        //MakeNewFile();
    }
}