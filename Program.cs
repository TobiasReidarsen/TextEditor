TxtEd();

static void TxtEd() // #TODO make this into a class.
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Clear();
    int lineNumber = 1;
    Console.Write("#" + lineNumber + ": ");
    int pos = Console.CursorLeft;
    ConsoleKeyInfo info;
    ConsoleKeyInfo shortCut;

    List<char> userTxt = new List<char>();


    while (true)
    {
        info = Console.ReadKey(true);
       
        if (info.Modifiers == ConsoleModifiers.Control)
        {
            shortCut = Console.ReadKey(true);
            switch (shortCut.Key)
            {
                case ConsoleKey.M:
                    userTxt.Clear();
                    Console.Clear();
                    lineNumber = 1;
                    Console.Write("#" + lineNumber + ": ");
                    break;
            }
        }
        else
        {
            switch (info.Key)
            {
                // #TODO enable navigation using arrow keys (maybe also hjkl like in vim?)
                // #TODO enable the use of shortcuts. Like "CTRL + :" to be enable command mode. "CTRL + i" for insert mode.
                // #TODO commands could be their own class?
                // #TODO: remove the nested ifs
                case ConsoleKey.Backspace:
                    if (Console.CursorLeft > pos)
                    {
                        userTxt.RemoveAt(userTxt.Count - 1);
                        Console.CursorLeft -= 1;
                        Console.Write(' ');
                        Console.CursorLeft -= 1;
                    }

                    break;
                case ConsoleKey.Enter:
                    Console.Write(Environment.NewLine);
                    lineNumber++;
                    Console.Write("#" + lineNumber + ": ");
                    break;
                case ConsoleKey.Spacebar:
                    userTxt.Add(' ');
                    break;
                default:
                    if (Char.IsLetterOrDigit(info.KeyChar))
                    {
                        Console.Write(info.KeyChar);
                        userTxt.Add(info.KeyChar);
                    }

                    break;
            }
        }
    }
}

// Code used from here: https://stackoverflow.com/questions/7565415/edit-text-in-c-sharp-console-application
// By user: Tadeusz
/*
string input = "her er en string";

ReadLine(input);

static string ReadLine(string input)
{
    int pos = Console.CursorLeft;
    Console.WriteLine(input);
    ConsoleKeyInfo info;
    List<char> chars = new List<char>();
    if (string.IsNullOrEmpty(input) == false)
    {
        chars.AddRange(input.ToCharArray());
    }

    while (true)
    {
        info = Console.ReadKey(true);
        if (info.Key == ConsoleKey.Backspace && Console.CursorLeft > pos)
        {
            chars.RemoveAt(chars.Count - 1);
            Console.CursorLeft -= 1;
            Console.Write(' ');
            //Console.CursorLeft -= 1;
        }
        else if (info.Key == ConsoleKey.Enter)
        {
            Console.Write(Environment.NewLine);
        }
        else if (char.IsLetterOrDigit(info.KeyChar))
        {
            Console.Write(info.KeyChar);
            chars.Add(info.KeyChar);
        }
    }

    return new string(chars.ToArray());
}*/