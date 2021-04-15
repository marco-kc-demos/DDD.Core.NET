using System;

namespace DDD.SimpleCore
{
    /// <summary>
    /// Represents a ValueObject in the domain (DDD).
    /// It implements equality (and HashCode) based on the AtomicValues.
    /// </summary>
    public abstract class ValueObject
    {
        protected abstract object[] GetAtomicValues();

        public override bool Equals(object obj)
        {
            return obj != null &&
                   this.GetType() == obj.GetType() &&
                   AreEqual(this, (ValueObject)obj);
        }

        private static bool AreEqual(ValueObject left, ValueObject right)
        {
            if ((object)left == null) return (object)right == null;
            if ((object)right == null) return false;

            object[] lefts = left.GetAtomicValues();
            object[] rights = right.GetAtomicValues();
            for (int i = 0; i < lefts.Length; i++)
            {
                if (! lefts[i].Equals(rights[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool operator ==(ValueObject left, ValueObject right)
        {
            return AreEqual(left, right);
        }

        public static bool operator !=(ValueObject left, ValueObject right)
        {
            return !AreEqual(left, right);
        }

        public override int GetHashCode()
        {
            int hashcode = 0;
            foreach (object value in GetAtomicValues())
            {
                hashcode = hashcode ^ value.GetHashCode();
            }
            return hashcode;
        }
    }

}
