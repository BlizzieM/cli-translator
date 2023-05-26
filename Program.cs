using System.Text;
using Newtonsoft.Json;

class Program
{
    static async Task Main(string[] args)
    {
        string? aLine = null;
        string? iLang = null;
        string? oLang = null;

        Console.WriteLine("Enter 2 character language code for languate to translate from:");
        iLang = Console.ReadLine();

        Console.WriteLine("Enter 2 character language code for languate to translate to:");
        oLang = Console.ReadLine();

        Console.WriteLine("Enter Text to be translated:");
        aLine = Console.ReadLine();
        Console.WriteLine("Translating...");

        SendText translator = new SendText();
        
        await Task.Delay(2000);

        string result = await translator.Translate(aLine,iLang,oLang);

        Console.WriteLine(result);
    }

}