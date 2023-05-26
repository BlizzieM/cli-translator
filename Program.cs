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
        
        await Task.Delay(2000);

        string result = await translator.Translate(aLine);

        Console.WriteLine(result);
    }

}