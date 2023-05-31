using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using Newtonsoft.Json;

namespace translator
{
    //Ohjelma tää perkeleestä
    //Softa sieltä ja syvältä
    //Pyydän sinut tulkaamahan
    //jsoneita tavaamahan
    //ja käännöksiä näyttämähän
    //tekstejä piirtämähän
    //tai roskiksehen sinut heitän
    //matosille marehdittivän

    //friend recommended that I try to hex this with a poem
    //it didn't fix the issues
    class Translation
    {

        public List<TextTo>? translation { get; set; }

    }

    class TextTo
    {

        public string? text { get; set; }

        public string? to { get; set; }
    }

    class Program
    {

        static void parseJson(string res)
        {
            string json = res;

            JsonNode rootNode = JsonNode.Parse(json)!;
            JsonArray translations = rootNode[0]["translations"].AsArray();

            foreach (var translation in translations)
            {
                Console.WriteLine(translation["text"].AsValue());
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
}