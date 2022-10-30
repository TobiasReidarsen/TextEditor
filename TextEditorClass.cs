using System.Dynamic;
using System.Text;
using Microsoft.VisualBasic;

namespace TextEditor;

public class TextEditorClass
{
    private string NameOfFile { get; set; }
    private int Pos { get; set; }
    private StringBuilder newString { get; set; }

    private void SetNewString(StringBuilder input)
    {
        //this.newString = newString.Append(input);
    }


    private void StartEditor()
    {
        Console.Clear();
        Console.TreatControlCAsInput = true;
        uint lineNumber = 1;
        Console.Write("#" + lineNumber + ": ");
        ConsoleKeyInfo info;
        while (true)
        {
            info = Console.ReadKey(true);

            char[] userInputChar;
            if (info.Key == ConsoleKey.Enter)
            {
                this.newString.Append('\n');
                Console.Write(this.newString[^1]);
                lineNumber++;
                Console.Write("#" + lineNumber + ": ");
                Pos = 4;
            }
            else if (info.Key == ConsoleKey.Backspace && Pos > 4)
            {
                BackSpaceFunc();
            }
            else if (info.Key == ConsoleKey.Spacebar)
            {
                SpaceBar();
            }
            else if (info.Key == ConsoleKey.Tab)
            {
                SpaceBar(5);
            }
            else if (Char.IsLetterOrDigit(info.KeyChar))
            {
                this.newString.Append(info.KeyChar);
                Console.Write(this.newString[^1]);
                Pos++;
            }
            else if ((info.Modifiers & ConsoleModifiers.Control) != 0)
            {
                if (info.Key == ConsoleKey.P)
                {
                    Console.Clear();
                    newString.Clear();
                    lineNumber = 1;
                    Console.Write("#" + lineNumber + ": ");//
                }
            }
        }
    }

    private void SpaceBar(int input = 1)
    {
        for (int i = 0; i < input; i++)
        {
            this.newString.Append(' ');
            Console.Write(this.newString[^1]);
            Pos++;
        }
    }
    
    private void BackSpaceFunc(int input = 1)
    {
        for (int i = 0; i < input; i++)
        {
            if (this.newString.Length != 0 && Pos > 4)
            {
                this.newString.Remove(this.newString.Length - 1, 1);
                Console.Write("\b \b");
                Pos--;
            }
        }
    }

    private void GetByteAndBitCount(string sInput)
    {
        Encoding utf8 = Encoding.UTF8;
        uint byteCount = Convert.ToUInt32(utf8.GetByteCount(sInput));
        uint bitCount = byteCount * 8;
        Console.WriteLine(
            "Bytes needed to encode: '{0}'" + '\n' +
            "ByteSize of '{0}' is: {1}" + '\n' +
            "BitSize of '{0} is: '{2}'", NameOfFile, byteCount, bitCount);
    }

    public TextEditorClass(string nameOfFile)
    {
        NameOfFile = nameOfFile;
        this.newString = new StringBuilder();
        StartEditor();
    }
}