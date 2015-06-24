using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
namespace rosalind
{
    static public class Hamming
    {
        static public int Distance(TextReader s1, TextReader s2)
        {
            int distance = 0;
            int c1;
            while ((c1 = s1.Read()) != -1) {
                int c2 = s2.Read();
                if (c1 != c2) {
                    distance += 1;
                }
            }
            return distance;
        }
    }
}

