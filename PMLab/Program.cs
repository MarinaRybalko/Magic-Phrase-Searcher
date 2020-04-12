using System;
using System.IO;

namespace PMLab
{
    public class Program
    {
      
        static void Main(string[] args)
        {
            var phraseSearcher = new PhraseSearcher(10);
            var text = File.ReadAllText("mess.txt");
            
            Console.WriteLine(phraseSearcher.GetPhrase(text));
            Console.ReadKey();
        }
    }
}
