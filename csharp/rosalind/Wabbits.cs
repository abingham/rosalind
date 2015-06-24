using System;

namespace rosalind
{
    static public class Wabbits
    {
        static public Int64 wabbits(Int64 n, Int64 k)
        {
            Int64 prev = 1;
            Int64 curr = 1;
            for (Int64 i = 0; i < n - 2; ++i) {
                Int64 new_curr = prev * k + curr;
                prev = curr;
                curr = new_curr;
            }
            return curr;
        }
    }
}

