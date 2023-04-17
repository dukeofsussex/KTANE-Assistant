namespace KTANE.Game.Modules
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Speech.Recognition;
    using KTANE.Game;

    internal class Password : BombModule
    {
        private readonly char[][] columns = new char[5][];
        private readonly int[] columnOrder = new int[] { 2, 4, 0, 1, 3 };
        private readonly string[] words = new[]
        {
            "about",
            "after",
            "again",
            "below",
            "could",
            "every",
            "first",
            "found",
            "great",
            "house",
            "large",
            "learn",
            "never",
            "other",
            "place",
            "plant",
            "point",
            "right",
            "small",
            "sound",
            "spell",
            "still",
            "study",
            "their",
            "there",
            "these",
            "thing",
            "think",
            "three",
            "water",
            "where",
            "which",
            "world",
            "would",
            "write",
        };

        private int columnOrderCounter;

        public override string Name => "Password";

        public override string Help => "<military alphabet, 6 times>";

        public override string PreInfo => $", column {this.Column + 1}.";

        public override GrammarBuilder Grammar => new (
            new Choices(
                "ALPHA",
                "BRAVO",
                "CHARLIE",
                "DELTA",
                "ECHO",
                "FOXTROT",
                "GOLF",
                "HOTEL",
                "INDIA",
                "JULIET",
                "KILO",
                "LIMA",
                "MIKE",
                "NOVEMBER",
                "OSCAR",
                "PAPA",
                "QUEBEC",
                "ROMEO",
                "SIERRA",
                "TANGO",
                "UNIFORM",
                "VICTOR",
                "WHISKEY",
                "X-RAY",
                "YANKEE",
                "ZULU"),
            6,
            6);

        private int Column => this.columnOrder[this.columnOrderCounter];

        public override string Process(string command, Bomb bomb)
        {
            char[] parts = command.Split(' ').Select(p => p[0])
                .Distinct()
                .ToArray();

            if (parts.Length != 6)
            {
                return "Invalid sequence.";
            }

            this.columns[this.Column] = parts;

            List<string> possibleWords = this.words.ToList();

            for (int i = 0; i < this.columnOrder.Length; i++)
            {
                int col = this.columnOrder[i];

                if (this.columns[col] == null)
                {
                    break;
                }

                possibleWords = possibleWords.Where(w => this.columns[col].Contains(w[col]))
                    .ToList();
            }

            if (possibleWords.Count == 1)
            {
                return $"The password is \"{possibleWords[0]}.\"";
            }

            this.columnOrderCounter++;
            return possibleWords.Count < 6
                ? $"Try words: {string.Join(", ", possibleWords)}"
                : $"Column {this.Column + 1}.";
        }
    }
}