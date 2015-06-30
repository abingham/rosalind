using System;

namespace rosalind
{
    public static class ExpectedOffspring
    {
        public static Rational calc(
            long AAAA,
            long AAAa,
            long AAaa,
            long AaAa,
            long Aaaa) {
            var AA = new Rational(1) * AAAA + new Rational(1, 2) * AAAa + new Rational(1, 4) * AaAa;
            var Aa = new Rational (1, 2) * AAAa + new Rational (1) * AAaa + new Rational (1, 2) * AaAa + new Rational (1, 2) * Aaaa;
            return (AA + Aa) * 2;
        }
     }
}

