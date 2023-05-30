using System.Text;
using System.Text.Json;
using Newtonsoft.Json;

public record struct Transl
{
    public string? text { get; set; }

    public string? to { get; set; }
}

class Program
{

    static void parseJson(string res)
    {
        var result = new List<Transl>();

        result = System.Text.Json.JsonSerializer.Deserialize<List<Transl>>(res);

        if (result != null && result.Count > 0)
        {
            foreach (var Transl in result)
            {
                Console.WriteLine($"{Transl.text}");
            }
        }
    }

    static async Task Main(string[] args)
    {
        string? aLine = null;
        string? iLang = null;
        string? oLang = null;
        bool shouldRun = true;



        do
        {
            Console.WriteLine("Enter 2 character language code for languate to translate from:");
            iLang = Console.ReadLine();

            Console.WriteLine("Enter 2 character language code for languate to translate to:");
            oLang = Console.ReadLine();

            Console.WriteLine("Enter Text to be translated:");
            aLine = Console.ReadLine();
            Console.WriteLine("Translating...");

            SendText translator = new SendText();

            string result = await translator.Translate(aLine, iLang, oLang);

            parseJson(result);

            Console.WriteLine("Want to translate another line? (Y)es/(N)o:");

            bool continueCheck = true;

            do
            {
                string? keepTranslating = Console.ReadLine();
                if (keepTranslating == "Y" || keepTranslating == "y")
                {
                    continueCheck = false;
                }

                else if (keepTranslating == "N" || keepTranslating == "n")
                {
                    shouldRun = false;
                    continueCheck = false;
                }

                else
                {
                    Console.WriteLine("Please enter a valid character!");
                }
            }
            while (continueCheck == true);
        }
        while (shouldRun == true);
    }

}