using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Helpers
{
    public static class Ensure
    {
        public static void NotNull<TObject>(this TObject obj)
        {
            if(obj == null)
            {
                throw new ArgumentNullException($"{nameof(obj)} was null.");
            }
        }

        public static void NotNull<TObject>(this TObject obj, string errorMessage)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(errorMessage);

            }
        }

        public static void NotNullOrWhiteSpace(this string text)
        {
            if(string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException($"{nameof(text)} was null or whitespace.");
            }
        }

        public static void NotNullOrWhiteSpace(this string text, string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException(errorMessage);
            }
        }
    }
}
