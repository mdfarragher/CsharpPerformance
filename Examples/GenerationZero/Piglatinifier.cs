using System;
using System.Text;
using System.Threading;

namespace GenerationZero
{
	public class Piglatinifier
	{
		// ==============================================================================
		// Every time you need to create a string, you have to call one of these methods
        //   so that the string allocations can be tracked and counted
		// ==============================================================================

        public string GetString(string s)
        {
            Interlocked.Increment(ref MainClass.NumberOfStrings);
            return s;
        }

        public string GetString(char c)
        {
            Interlocked.Increment(ref MainClass.NumberOfStrings);
            return c.ToString();
        }
    
		// ==============================================================================
		// The code below converts a string to pig latin, but in an extremely inefficient 
        // manner. Fix the code so that it creates as few strings as possible
		// ==============================================================================

        public string Convert(string s)
        {
            // count number of spaces
            int spaces = 0;
            for (int i = 0; i < s.Length; i++)
            {
                var ch = GetString(s[i]);
                if (ch == " ")
                    spaces++;
            }

            // get array of words
            string[] words = new string[spaces + 1];
            string word = string.Empty;
            int wordIndex = 0;
            for (int i = 0; i < s.Length; i++)
            {
                var ch = GetString(s[i]);
                if (ch == " ")
                {
                    words[wordIndex] = word;
                    word = string.Empty;
                    wordIndex++;
                }
                else
                    word = GetString(word + ch);
            }
            if (word.Length > 0)
                words[wordIndex] = word;

            // create array of pig words
            string[] pigWords = new string[spaces + 1];
            for (int w = 0; w < words.Length; w++)
            {
                string firstLetter = GetString(words[w][0]);
                firstLetter = GetString(firstLetter.ToLower());
                string remainder = GetString(words[w].Substring(1));
                pigWords[w] = GetString(remainder + firstLetter);
                pigWords[w] = GetString(pigWords[w] + "ay");
            }

            // assemble final string
            string result = string.Empty;
            for (int w = 0; w < words.Length; w++)
            {
                result = GetString(result + pigWords[w]);
                result = GetString(result + " ");
            }

            return result;
        }

        public string ConvertOptimized(string s)
        {
            // count number of spaces
            int spaces = 0;
            for (int i = 0; i < s.Length; i++)
            {
                var ch = s[i];
                if (ch == ' ')
                    spaces++;
            }

            // get array of words
            string[] words = new string[spaces + 1];
            string word = string.Empty;
            int wordIndex = 0;
            int wordStart = 0;
            for (int i = 0; i < s.Length; i++)
            {
                var ch = s[i];
                if (ch == ' ')
                {
                    word = GetString(s.Substring(wordStart, i - wordStart));
                    words[wordIndex] = word;
                    word = string.Empty;
                    wordStart = i+1;
                    wordIndex++;
                }
            }
            if (wordStart < s.Length)
            {
                word = GetString(s.Substring(wordStart, s.Length - wordStart));
                words[wordIndex] = word;
            }

            // create array of pig words
            StringBuilder pigString = new StringBuilder();
            for (int w = 0; w < words.Length; w++)
            {
                var firstLetter = words[w][0];
                firstLetter = char.ToLower(firstLetter);
                string remainder = GetString(words[w].Substring(1));
                pigString.Append(remainder);
                pigString.Append(firstLetter);
                pigString.Append("ay");
                pigString.Append(" ");
            }

            // remove final space
            pigString.Remove(pigString.Length - 1, 1);
            return GetString(pigString.ToString());
        }


	}
}