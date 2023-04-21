namespace KTANE.Game.Modules
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Speech.Recognition;
    using System.Text.RegularExpressions;
    using KTANE.Game;

    internal partial class Morse : BombModule
    {
        private readonly Dictionary<string, char> morseCodes = new ()
        {
            { "01", 'a' },
            { "1000", 'b' },
            { "1010", 'c' },
            { "100", 'd' },
            { "0", 'e' },
            { "0010", 'f' },
            { "110", 'g' },
            { "0000", 'h' },
            { "00", 'i' },
            { "0111", 'j' },
            { "101", 'k' },
            { "0100", 'l' },
            { "11", 'm' },
            { "10", 'n' },
            { "111", 'o' },
            { "0110", 'p' },
            { "1101", 'q' },
            { "010", 'r' },
            { "000", 's' },
            { "1", 't' },
            { "001", 'u' },
            { "0001", 'v' },
            { "011", 'w' },
            { "1001", 'x' },
            { "1011", 'y' },
            { "1100", 'z' },
        };

        private readonly Dictionary<string, float> words = new ()
        {
            { "shell", 3.505f },
            { "halls", 3.515f },
            { "slick", 3.522f },
            { "trick", 3.532f },
            { "boxes", 3.535f },
            { "leaks", 3.542f },
            { "strobe", 3.545f },
            { "bistro", 3.552f },
            { "flick", 3.555f },
            { "bombs", 3.565f },
            { "break", 3.572f },
            { "brick", 3.575f },
            { "steak", 3.582f },
            { "sting", 3.592f },
            { "vector", 3.595f },
            { "beats", 3.600f },
        };

        private List<char> letters = new ();

        public override string Name => "Morse";

        public override string Help => "<<short | dot> | <long | dash>, 1-4 times>";

        public override string PreInfo => ", first letter?";

        public override GrammarBuilder Grammar => new (new Choices("dot", "dash", "short", "long"), 1, 4);

        public override string Process(string command, Bomb bomb)
        {
            command = ZeroRegex().Replace(command, "0");
            command = OneRegex().Replace(command, "1");
            command = command.Replace(" ", string.Empty);

            if (this.morseCodes.TryGetValue(command, out char value))
            {
                this.letters.Add(value);
            }

            List<string> possibleWords = this.words.Keys.Where(k => this.letters.All(l => k.Contains(l)))
                .ToList();

            if (possibleWords.Count is 0 or 16)
            {
                this.letters = new ();
                return "No words found, try again.";
            }

            return possibleWords.Count == 1
                ? $"Set freq to {this.words[possibleWords[0]]} mega hertz, word is \"{possibleWords[0]}\"."
                : $"{this.DigitToWord(this.letters.Count)} letter?";
        }

        [GeneratedRegex("(dot|short)", RegexOptions.Compiled)]
        private static partial Regex ZeroRegex();

        [GeneratedRegex("(dash|long)", RegexOptions.Compiled)]
        private static partial Regex OneRegex();
    }
}