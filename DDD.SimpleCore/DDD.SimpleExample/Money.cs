using DDD.SimpleCore;
using System;
using System.Text.RegularExpressions;

namespace DDD.SimpleExample
{
    public class Money : ValueObject
    {
        public readonly string CurrencyCode;
        public readonly decimal Amount;

        public Money(string currencyCode, decimal amount)
        {
            CheckIfValidCurrencyCode(currencyCode);
            CurrencyCode = currencyCode;
            Amount = amount;
        }

        private static readonly Regex CurrencyCodePattern = new Regex(@"^[A-Z]{3}$", RegexOptions.Compiled);

        public static void CheckIfValidCurrencyCode(string currencyCode)
        {
            if (!CurrencyCodePattern.IsMatch(currencyCode))
            {
                throw new InvalidValueException("A currency code must consist of exactly three capital letters.");
            }
        }

        protected override object[] GetAtomicValues()
        {
            return new object[] { CurrencyCode, Amount };
        }
    }
}
