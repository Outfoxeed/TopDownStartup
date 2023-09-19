using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TU_Challenge
{
    public class MyStringImplementation
    {
        internal static string BazardString(string input)
        {
            throw new NotImplementedException();
        }

        internal static bool IsNullEmptyOrWhiteSpace(string input)
        {
            if (input == null || input.Length == 0)
            {
                return true;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != ' ')
                {
                    return false;
                }
            }
            return true;
        }

        internal static string MixString(string a, string b)
        {
            if (IsNullEmptyOrWhiteSpace(a) || IsNullEmptyOrWhiteSpace(b))
            {
                throw new ArgumentException("Given string is null or empty");
            }
            
            StringBuilder sb = new StringBuilder();
            int maxIndex = Mathf.Max(a.Length, b.Length);
            for (int i = 0; i < maxIndex; i++)
            {
                if (i < a.Length)
                {
                    sb.Append(a[i]);
                }         
                if (i < b.Length)
                {
                    sb.Append(b[i]);
                }
            }
            return sb.ToString();
        }

        internal static string ToCesarCode(string input, int offset)
        {
            throw new NotImplementedException();
        }

        internal static string ToLowerCase(string a)
        {
            if (IsNullEmptyOrWhiteSpace(a))
            {
                throw new ArgumentException("Given string is null or empty");
            }
            
            StringBuilder sb = new();
            for (int i = 0; i < a.Length; i++)
            {
                sb.Append(ToLowerCase(a[i]));
            }
            return sb.ToString();
        }

        internal static char ToLowerCase(char character)
        {
            Dictionary<char, char> lowerCase = new() { { 'É', 'é' }, {'Ç', 'ç'}};
            if (65 <= character && character <= 90)
            {
                return (char)(character + 32);
            }

            if (lowerCase.TryGetValue(character, out var lowerCaseCharacter))
            {
                return lowerCaseCharacter;
            }
            return character;
        }

        internal static string UnBazardString(string input)
        {
            throw new NotImplementedException();
        }

        internal static string Voyelles(string a)
        {
            char[] voyels = { 'a', 'e', 'i', 'o', 'u' };
            StringBuilder sb = new();
            foreach (char character in a)
            {
                if (voyels.Contains(ToLowerCase(character)))
                {
                    sb.Append(character);
                }
            }
            return sb.ToString();
        }
    }
}
