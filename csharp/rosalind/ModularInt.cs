using System;
using System.Diagnostics.Contracts;

namespace rosalind
{
    public struct ModularInt
    {
        readonly int val_;
        readonly int mod_;

        [ContractInvariantMethod]
        public void ObjectInvariant () 
        {
            Contract.Invariant (val_ < mod_);
        }

        public ModularInt (int value, int mod)
        {
            mod_ = mod;
            val_ = (value % mod_);
            while (val_ < 0) {
                val_ += mod_;
            }
        }

        public int value {
            get { return val_; }
        }

        public int mod {
            get { return mod_; }
        }

        public static explicit operator int(ModularInt i)
        {
            return i.value;
        }

        static public ModularInt operator+(ModularInt lhs, int rhs) {
            return new ModularInt (lhs.value + rhs, lhs.mod);
        }

        static public ModularInt operator+(ModularInt lhs, ModularInt rhs) {
            return lhs + (int)rhs;
        }

        static public ModularInt operator-(ModularInt lhs, int rhs) {
            return new ModularInt (lhs.value - rhs, lhs.mod);
        }

        static public ModularInt operator-(ModularInt lhs, ModularInt rhs) {
            return lhs - (int)rhs;
        }

        public override string ToString() {
            return string.Format ("ModularInt({0}, {1})", value, mod);
        }
    }
}

