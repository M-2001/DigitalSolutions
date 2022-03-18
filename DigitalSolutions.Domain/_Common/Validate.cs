using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DigitalSolutions
{
    /// <summary>
    /// Performs objects high level validation
    /// </summary>
    public static class Validate
    {

        public static void AreEqual(object A, object B, string message)
        {
            if (!A.Equals(B))
                ThrowEx(message);
        }

        public static void IsTrue(bool p, string message)
        {
            if (!p)
                ThrowEx(message);
        }

        public static void IsFalse(bool p, string message)
        {
            if (p)
                ThrowEx(message);
        }

        public static void NotEqual<T>(T A, T B, string message)
        {
            if (A.Equals(B))
                ThrowEx(message);
        }

        public static void NotNull<T>(T val, string message) where T : class
        {
            if (val == null)
                ThrowEx(message);
        }


        public static void NotNullEmpty<T>(IList<T> lst, string message)
        {
            if (lst == null || lst.Count == 0)
                ThrowEx(message);
        }

        public static void NotNullEmpty(string paramValue, string message)
        {
            if (string.IsNullOrEmpty(paramValue))
                ThrowEx(message);
        }


        public static void Regex(string value, string regex, string message)
        {
            if (string.IsNullOrEmpty(value) || !System.Text.RegularExpressions.Regex.IsMatch(value, regex))
                ThrowEx(message);
        }


        public static void KeyExists<TKey, TValue>(IDictionary<TKey, TValue> dict, TKey ID, string message)
        {
            if (!dict.ContainsKey(ID))
                ThrowEx(message);
        }

        public static void KeyNotExists<TKey, TValue>(IDictionary<TKey, TValue> dict, TKey ID, string message)
        {
            if (dict.ContainsKey(ID))
                ThrowEx(message);
        }


        public static void MaxLength(string p1, int maxlength, string message)
        {
            if (p1 != null && p1.Length > maxlength)
                ThrowEx(message);
        }


        private static void ThrowEx(string message)
        {
            throw new BusinessRuleException(message);
        }

    }
}
