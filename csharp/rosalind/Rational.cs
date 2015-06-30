using System;

namespace rosalind
{
    public struct Rational
    {
        private readonly long Numerator_;
        private readonly long Denominator_;

        static long GCD(long a, long b)
        {
            long rem;

            while (b != 0)
            {
                rem = a % b;
                a = b;
                b = rem;
            }

            return a;
        }

        public Rational(long num, long den) {
            if (den == 0)
                num = 0;
            
            if (num == 0)
                den = 1;
            
            long gcd = GCD (num, den);
            if (gcd != 0) {
                num = num / gcd;
                den = den / gcd;
            }
            Numerator_ = num;
            Denominator_ = den;
        }

        public Rational(long num) : this(num, 1) {
        }

        public static implicit operator Rational(long num) {
            return new Rational(num);
        }

        public long Numerator {
            get { return Numerator_; }
        }

        public long Denominator {
            get { return Denominator_; }
        }

        public static Rational operator +(Rational r1, Rational r2)
        {
            //  TOOD: How can we make automatic casting from 0 to a rational work here?
            if (r1 == new Rational(0))
                return r2;
            else if (r2 == new Rational(0))
                return r1;
            else if (r1.Denominator == r2.Denominator)
                return new Rational (r1.Numerator + r2.Numerator, r1.Denominator);
            return new Rational (
                r1.Numerator * r2.Denominator + r2.Numerator * r1.Denominator,
                r1.Denominator * r2.Denominator);
        }

        public static Rational operator *(Rational r1, Rational r2)
        {
            return new Rational (r1.Numerator * r2.Numerator, r1.Denominator * r2.Denominator);
        }

        public override int GetHashCode()
        {
            return Numerator.GetHashCode() * Denominator.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Rational))
            {
                return false;
            }
            return Equals((Rational)obj);
        }

        public bool Equals(Rational other) {
            return Numerator == other.Numerator && Denominator == other.Denominator;
        }

        public static bool operator ==(Rational r1, Rational r2)
        {
            return r1.Equals(r2);
        }

        public static bool operator !=(Rational r1, Rational r2)
        {
            return ! r1.Equals(r2);
        }

        public override string ToString ()
        {
            return Numerator_.ToString () + "/" + Denominator_.ToString ();
        }
    }
}

