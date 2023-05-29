using System.Text;
using Newtonsoft.Json;

class Program
{

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

            Console.WriteLine(result);

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