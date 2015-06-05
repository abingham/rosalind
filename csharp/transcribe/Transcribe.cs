using System;

using rosalind;

namespace transcribe
{
    class TranscribeCLI
    {
        public static void Main(string[] args)
        {
            string filename = args[0];
            string data = System.IO.File.ReadAllText(@filename).Trim();
            Console.WriteLine(rosalind.Transcriber.Transcribe(data));    
        }
    }
}
