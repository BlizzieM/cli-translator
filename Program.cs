using System.Text;
using Newtonsoft.Json;

class Program
{
    static async Task Main(string[] args)
    {
        string? aLine = null;

        Console.WriteLine("Enter English Text to be translated into spanish:");
        aLine = Console.ReadLine();
        Console.WriteLine("Translating...");

        SendText translator = new SendText();
        
        string result = await Scribe(translator,aLine);

        Console.WriteLine(result);
    }

    static async Task<string> Scribe(SendText txt, string tlate)
    {
        string lated = " ";

        await Task.Delay(5000);

        lated = await txt.Translate(tlate);

        return lated;
    }

}