using System.Text;
using Newtonsoft.Json;

class Program
{
    static async Task Main(string[] args)
    {
        string? aLine = null;
        string? iLang = null;

        Console.WriteLine("Enter 2 character language code:");
        iLang = Console.ReadLine();

        Console.WriteLine("Enter Text to be translated into spanish:");
        aLine = Console.ReadLine();
        Console.WriteLine("Translating...");

        SendText translator = new SendText();
        
        await Task.Delay(1000);

        string result = await translator.Translate(aLine,iLang);

        Console.WriteLine(result);
    }

}