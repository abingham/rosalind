using System;

namespace rosalind
{
    public static class Transcriber
    {
        public static string Transcribe(string dna)
        {
            return dna.Replace("T", "U");
        }
    }
}

