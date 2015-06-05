using System;
using System.Collections.Generic;
using System.Linq;

namespace rosalind
{
    static public class CountingNucleotides
    {
	    public static SortedDictionary<char, int> count(string data)
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
    }
}