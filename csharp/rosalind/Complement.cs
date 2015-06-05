using System;
using System.Collections.Generic;
using System.Linq;

namespace rosalind
{
    public static class Complementer
    {
        static char Replacement(char b)
        {
            switch (b)
            {
            case 'A': return 'T';
            case 'T': return 'A';
            case 'G': return 'C';
            case 'C': return 'G';
            default:
                throw new ArgumentOutOfRangeException ();
            }
        }

        public static IEnumerable<char> Complement(IEnumerable<char> dna)
        {
            return dna.Select(b => Replacement(b)).Reverse();
        }
    }
}

