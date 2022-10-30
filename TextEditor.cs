using System.Text;

namespace TextEditor;

public class TextEditor
{
    public string NameOfFile { get; private set; }

    private void StartEditor()
    {
        Console.Clear();

        
    }
    
    public void GetByteAndBitCount(string sInput)
    {
        Encoding utf8 = Encoding.UTF8;
        uint byteCount = Convert.ToUInt32(utf8.GetByteCount(sInput));
        uint bitCount = byteCount * 8;
        Console.WriteLine(
            "Bytes needed to encode: '{0}'" + '\n' +
            "ByteSize of '{0}' is: {1}" + '\n' +
            "BitSize of '{0} is: '{2}'", NameOfFile, byteCount, bitCount);

    }

    public TextEditor(string nameOfFile)
    {
        NameOfFile = nameOfFile;
        StartEditor();
    }
}