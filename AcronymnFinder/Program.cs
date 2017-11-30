using System;
using System.Linq;

namespace AcronymnFinder
{
    using System.Text.RegularExpressions;

    /// C# features
    using static Console;

    /// <summary>
    /// String extension
    /// </summary>
    public static class StringExtension
    {
        /// regular expression for checking the letters in word are CAPS
        private const string _capsRegExpattern = @"[A-Z]{2,}";

        /// <summary>
        /// To check all letters in a word are capitalized
        /// </summary>
        public static bool IsCapitalized(this string source)
        {
            /// respond the match
            return string.IsNullOrWhiteSpace(source) ? false : Regex.IsMatch(source, _capsRegExpattern);
        }
    }

    class Program
    {
        /// <summary>
        /// Sample text like a document
        /// </summary>
        internal static string sampleText =
            "FAR\' FaaR\" away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts. " +
             Environment.NewLine +
             Environment.NewLine +
            "Separated they live in Bookmarksgrove right at the coast of the SEMA, a large language ocean. " +
            "A small river named Duden flows by their place and supplies it with the necessary REGE. " +
            "It is a PARA! country, in which roasted parts of sentences fly into your mouth. " +
            "Even the all-powerful Pointing has no control about the blind texts it is an almost unorthographic life One day however a small line of blind text by the name of Lorem Ipsum decided to leave for the far World of Grammar. " +
            "The Big OXMOX advised her not to do so, because there were thousands of bad Commas, wild Question Marks and devious SEMIKO, but the Little Blind Text didn’t listen. " +
             Environment.NewLine +
             Environment.NewLine +
            "She packed her seven VERS, put her initial into the belt and made herself on the way. ";

        static void Main(string[] args)
        {
            /// Do the processing below psuedo code:
            /// 1. Collect words from the document (end to end)
            /// 2. Find <[A-Z]{2,}>. (i.e., letters matching A to Z[capitalized] having minimum 2 letters)
            /// 3. Use “ “ while reading words from the document
            /// 4. Regular Expression: <[A-Z]{2,}>
            /// 5. Get the acronyms matched based on step 4 and display
            FindAcronymns(sampleText);

            /// stop the o/p
            ReadKey();
        }

        /// <summary>
        /// Represents the function to derive he acronymns in sample text provided
        /// </summary>
        public static void FindAcronymns(string sampleText)
        {
            /// 1. Get all the words
            ///     Remove spaces
            /// 2. Get the words which are CAPS and matches the 
            ///     Length (min) - 2 
            ///     A to Z characters


            /// 1. get all the words
            /// 1.1 get all the words - remove spaces
            var wordsInSampleText = from word in sampleText.Split(' ')
                                    where

                                     /// remove spaces
                                     word != "" && !string.IsNullOrWhiteSpace(word)

                                    /// select with trim
                                    select
                                    word
                                    .Replace(",", string.Empty)
                                    .Replace(".", string.Empty)
                                    .Replace("\"", string.Empty)
                                    .Replace("\'", string.Empty)
                                    .Replace("!", string.Empty)
                                    .Trim();

            /// 2. Get the words which are CAPS and matches the 
            ///     Length (min) - 2 &&  A to Z characters
            var acronymnsInSampleText = from word in wordsInSampleText
                                        where

                                       /// Length (min) - 2
                                       word.Length >= 2

                                       /// all letters should be CAPS
                                       && word.IsCapitalized()

                                        select word.TrimEnd();

            /// print the acronymns...
            foreach (var word in acronymnsInSampleText)
            {
                WriteLine($"{word}");
            }
        }

    }
}
