using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using rosalind;

namespace CountingNucleotides
{
    class CountingNucleotidesCLI
    {
	    static void Main(string[] args)
	    {
	        string filename = args[0];
	        string data = System.IO.File.ReadAllText(@filename).Trim();
	        var strValues = CountingNucleotides.count(data).Values.Select(v => v.ToString());
	        Console.WriteLine(String.Join(" ", strValues));
	    }   
    }
}