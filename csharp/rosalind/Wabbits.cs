using System;
using System.Collections.Generic;
using System.Linq;

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

        static public IEnumerable<UInt64> seasonalWabbits(int lifespan)
        {
            var pops = new CircularBuffer<UInt64> (lifespan);

            // Initialize the generation counts to 0
            for (int i = 0; i < lifespan; ++i) {
                pops.pushBack (0);
            }

            // Gen-1 has only one baby pair
            pops [0] = 1;

            for (;;) {
                var totalPop = pops.Aggregate ((rslt, item) => rslt + item);
                yield return totalPop;

                var numBabies = totalPop - pops [0];
                pops.popBack ();
                pops.pushFront (numBabies);
            }
        }
    }
}

