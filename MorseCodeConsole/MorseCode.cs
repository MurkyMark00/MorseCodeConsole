using System;
using System.Collections.Generic;
using System.Linq;

namespace MorseCodeConsole
{
    static class Morse
    {
        private static IEnumerable<string> Divide(string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize));
        }

        private static Dictionary<string, string> morse = new Dictionary<string, string>()
        {
            { "A", ".-" }, { "B", "-..." }, { "C", "-.-." }, { "D", "-.." }, { "E", "." }, { "F", "..-." },
            { "G", "--." }, { "H", "...." }, { "I", ".." }, { "J", ".---" }, { "K", "-.-" }, { "L", ".-.." },
            { "M", "--" }, { "N", "-." }, { "O", "---" }, { "P", ".--." }, { "Q", "--.-" }, { "R", ".-." },
            { "S", "..." }, { "T", "-" }, { "U", "..-" }, { "V", "...-" }, { "W", ".--" }, { "X", "-..-" },
            { "Y", "-.--" }, { "Z", "--.." },

            { "0", "-----" }, { "1", ".----" }, { "2", "..---" }, { "3", "...--" }, { "4", "....-" },
            { "5", "....." },  { "6", "-...." }, { "7", "--..." }, { "8", "---.." }, { "9", "----." }
        };

        public static string Encode(string text)
        {
            List<string> wordList = text.Split(" ").ToList(); // "hello world" -> "hello", "world" 

            List<string> morseList = new List<string>();

            for (int i = 0; i < wordList.Count; i++)
            {
                List<string> dividedWord = Divide(wordList[i], 1).ToList(); // "hello" -> "h", "e", "l"...

                for (int j = 0; j < dividedWord.Count; j++)
                {
                    dividedWord[j] = morse.SingleOrDefault(morseletter =>
                    string.Equals(dividedWord[j], morseletter.Key, StringComparison.OrdinalIgnoreCase)).Value;
                }

                morseList.Add(string.Join(" ", dividedWord));
            }

            return string.Join("   ", morseList);
        }

        public static string Decode(string morseText)
        {
            List<string> morseWordList = morseText.Split("   ").ToList();
            List<string> wordList = new List<string>();

            for (int i = 0; i < morseWordList.Count; ++i)
            {
                List<string> morseLetterList = morseWordList[i].Split(" ").ToList();

                for (int j = 0; j < morseLetterList.Count; ++j)
                {
                    morseLetterList[j] = morse.SingleOrDefault(morseTemp => string.Equals(morseLetterList[j], morseTemp.Value, StringComparison.OrdinalIgnoreCase)).Key;
                }

                wordList.Add(string.Join(String.Empty, morseLetterList));
            }

            return string.Join(" ", wordList);
        }
    }
}