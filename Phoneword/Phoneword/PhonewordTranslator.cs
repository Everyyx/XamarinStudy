using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoneword
{
    public static class PhonewordTranslator
    {
        public static string ToNumber(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw))
                return null;
            raw = raw.ToUpperInvariant();

            var newNumer = new StringBuilder();
            foreach(var c in raw)
            {
                if ("-0123456789".Contains(c))
                    newNumer.Append(c);
                else
                {
                    var result = TranslateToNumer(c);
                    if (result!=null)
                        newNumer.Append(result);
                        //bad character?
                        else
                            return null;
                }
            }
            return newNumer.ToString();
        }

        static bool Contains(this string keyString,char c)
        {
            return keyString.IndexOf(c) >= 0;
        }

        static readonly string[] digits =
        {
            "ABC","DEF","GHI","JKL","MNO","PQRS","TUV","WXYZ"
        };

        static int? TranslateToNumer(char c)
        {
            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i].Contains (c))
                {
                    return 2 + i;
                }
            }
            return null;
        }
    }
}
