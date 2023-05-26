using System.Text;
using Newtonsoft.Json;

class Program
{
    static async Task Main(string[] args)
    {
        SendText translator = new SendText();

        string late = "Cat napped at the attick";
        
        string result = await Scribe(translator,late);

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