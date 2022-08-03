﻿using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Emoji_Detector
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string patternEmojis = @"([/*]{2}|[:]{2})(?<emoji>[A-Z][a-z]{2,})\1";
            string patternNumbers = @"\d";
            MatchCollection emojiMatches = Regex.Matches(text, patternEmojis);
            MatchCollection numberMatches = Regex.Matches(text, patternNumbers);
            long treshold = 1;
            foreach (Match number in numberMatches)
            {
                treshold *= int.Parse(number.Value);
            }
            Console.WriteLine($"Cool threshold: {treshold}");
            Console.WriteLine($"{emojiMatches.Count} emojis found in the text. The cool ones are:");
            
            foreach (Match emojiMatch in emojiMatches)
            {
                string emoji = emojiMatch.Groups["emoji"].Value;
                long emojiThreshold = emoji.ToCharArray().Sum(c => c);
                if (emojiThreshold >= treshold)
                {
                    Console.WriteLine(emojiMatch.Value);
                }
            }
        }
    }
}
