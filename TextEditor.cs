namespace TextEditor;

public class TextEditor
{
    public string NameOfFile { get; private set; }

    private void StartEditor()
    {
        Console.Clear();
        var str = "HEI DET ER MEG!";
        str = str + " MEG PÅ DEG";
        Console.WriteLine(str);
    }

    public TextEditor(string nameOfFile)
    {
        NameOfFile = nameOfFile;
        StartEditor();
    }
}