using System;
using System.Collections.Generic;
using System.IO;

namespace rosalind
{
    public static class TranslateRNA
    {
        // RNA codon table
        static IDictionary<string, char?> codons = new Dictionary<string, char?>(){
            {"UUU", 'F'},
            {"CUU", 'L'},
            {"AUU", 'I'},
            {"GUU", 'V'},
            {"UUC", 'F'},
            {"CUC", 'L'},
            {"AUC", 'I'},
            {"GUC", 'V'},
            {"UUA", 'L'},
            {"CUA", 'L'},
            {"AUA", 'I'},
            {"GUA", 'V'},
            {"UUG", 'L'},
            {"CUG", 'L'},
            {"AUG", 'M'},
            {"GUG", 'V'},
            {"UCU", 'S'},
            {"CCU", 'P'},
            {"ACU", 'T'},
            {"GCU", 'A'},
            {"UCC", 'S'},
            {"CCC", 'P'},
            {"ACC", 'T'},
            {"GCC", 'A'},
            {"UCA", 'S'},
            {"CCA", 'P'},
            {"ACA", 'T'},
            {"GCA", 'A'},
            {"UCG", 'S'},
            {"CCG", 'P'},
            {"ACG", 'T'},
            {"GCG", 'A'},
            {"UAU", 'Y'},
            {"CAU", 'H'},
            {"AAU", 'N'},
            {"GAU", 'D'},
            {"UAC", 'Y'},
            {"CAC", 'H'},
            {"AAC", 'N'},
            {"GAC", 'D'},
            {"UAA", null},
            {"CAA", 'Q'},
            {"AAA", 'K'},
            {"GAA", 'E'},
            {"UAG", null},
            {"CAG", 'Q'},
            {"AAG", 'K'},
            {"GAG", 'E'},
            {"UGU", 'C'},
            {"CGU", 'R'},
            {"AGU", 'S'},
            {"GGU", 'G'},
            {"UGC", 'C'},
            {"CGC", 'R'},
            {"AGC", 'S'},
            {"GGC", 'G'},
            {"UGA", null},
            {"CGA", 'R'},
            {"AGA", 'R'},
            {"GGA", 'G'},
            {"UGG", 'W'},
            {"CGG", 'R'},
            {"AGG", 'R'},
            {"GGG", 'G'} 
        };
    
        static char? codonToAminoAcid(string codon)
        {
            return codons[codon];
        }

        public static IEnumerable<char> codonsToAminoAcids(TextReader input)
        {
            var buff = new char[3];
            while (input.ReadBlock (buff, 0, 3) == 3)
            {
                char? acid = codonToAminoAcid(new string(buff));
                if (acid.HasValue)
                    yield return acid.Value;
            }
        }
    }
}

