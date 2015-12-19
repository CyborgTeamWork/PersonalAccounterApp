using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounter.Helpers
{
    public static class Validations
    {
        private const int MaxLenght = 50;
        private const int MingLenght = 3;

        public static bool ValidateLoginForm(string id, string pwd)
        {
            return ((id.Length <= MingLenght
                    || id.Length > MaxLenght)
                    || (pwd.Length > MaxLenght)
                    || pwd.Length <= MingLenght)
                    || id == null
                    || pwd == null;
        }

        public static bool ValidateString(string text, int MinLenght, int MaxLenght)
        {
            return text.Length <= MinLenght || text.Length > MaxLenght || !IsAlphabeticString(text); 
        }

        public static bool IsAlphabeticString(object value)
        {
            string str = value as string;
            return str != null && IsAllAlphabetic(str);
        }

        public static bool IsAllAlphabetic(string value)
        {
            foreach (char c in value)
            {
                if (!char.IsLetter(c))
                    return false;
            }

            return true;
        }
    }
}
