using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace rosalind
{
    public class Profile
    {
        private uint size_;
        private IDictionary<Base, uint[]> profile_;

        public Profile(uint size) {
            size_ = size;
            profile_ = new Dictionary<Base, uint[]> ();
            foreach (Base b in Enum.GetValues(typeof(Base))) {
                profile_ [b] = new uint[size];
            }
        }

        public uint size {
            get { return size_; }
        }

        public IEnumerable<uint> this[Base b] {
            get { return profile_[b]; }
        }

        public IEnumerable<Base> consensus {
            get { 
                for (int i = 0; i < size; i++) {
                    Base maxBase = Base.A;
                    uint max = 0;
                    foreach (Base b in Enum.GetValues(typeof(Base))) {
                        if (profile_ [b] [i] > max) {
                            maxBase = b;
                            max = profile_ [b] [i];
                        } 
                    }
                    yield return maxBase;
                }
            }
        }

        public void add(IEnumerable<Base> dna) {
            foreach (var item in dna.Select((b, i) => new {b, i})) {
                profile_[item.b][item.i] += 1;    
            }
        }
    }
}

