using System;
using System.Collections.Generic;
using System.Linq;

class CountingNucleotides
{
    static SortedDictionary<char, int> count(string data)
    {
	var counts = new SortedDictionary<char, int>();
	foreach (char c in data)
	{
	    if (!counts.ContainsKey(c))
	    {
		counts[c] = 0;
	    }
	    
	    counts[c] += 1;
	}
	return counts;
    }
    
    static void Main()
    {
	string data = "AGCTTTTCATTCTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGATAGCAGC";
	var strValues = count(data).Values.Select(v => v.ToString());
	Console.WriteLine(String.Join(" ", strValues));
    }   
}