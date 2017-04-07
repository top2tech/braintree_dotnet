#pragma warning disable 1591

namespace Braintree
{
    public abstract class Enumeration
    {
        public string Name;

        public Enumeration()
        {
        }


        public Enumeration(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
