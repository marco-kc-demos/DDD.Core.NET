using DDD.SimpleCore;
using System;

namespace DDD.SimpleExample
{
    public class IBAN : ValueObject
    {
        public readonly string Number;

        public IBAN(string number)
        {
            CheckIfValidNumber(number);
            Number = number;
        }

        public static void CheckIfValidNumber(string number)
        {
            // there are better checks for this, then not checking at all...
        }

        protected override object[] GetAtomicValues()
        {
            return new object[] { Number };
        }
    }
}