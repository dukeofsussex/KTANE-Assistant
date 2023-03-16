namespace KTANE.Game.Modules
{
    using System;
    using System.Linq;
    using System.Speech.Recognition;
    using KTANE.Game;

    internal class Sequence : BombModule
    {
        private readonly string[][] redOccurences = new[]
        {
            new[] { "charlie" },
            new[] { "bravo" },
            new[] { "alpha" },
            new[] { "alpha", "charlie" },
            new[] { "bravo" },
            new[] { "alpha", "charlie" },
            new[] { "alpha", "bravo", "charlie" },
            new[] { "alpha", "bravo" },
            new[] { "bravo" },
        };

        private readonly string[][] blueOccurences = new[]
        {
            new[] { "bravo" },
            new[] { "alpha", "charlie" },
            new[] { "bravo" },
            new[] { "alpha" },
            new[] { "bravo" },
            new[] { "bravo", "charlie" },
            new[] { "charlie" },
            new[] { "alpha", "charlie" },
            new[] { "alpha" },
        };

        private readonly string[][] blackOccurences = new[]
        {
            new[] { "alpha", "bravo", "charlie" },
            new[] { "alpha", "charlie" },
            new[] { "bravo" },
            new[] { "alpha", "charlie" },
            new[] { "bravo" },
            new[] { "bravo", "charlie" },
            new[] { "alpha", "bravo" },
            new[] { "charlie" },
            new[] { "charlie" },
        };

        private int blackWires;
        private int blueWires;
        private int redWires;

        public override string Name => "Sequence";

        public override string Help => "<COLOR OF THE WIRE> + <alpha|bravo|charlie>";

        public override string PreInfo => string.Empty;

        public override GrammarBuilder Grammar
        {
            get
            {
                Choices letters = new ("alpha", "bravo", "charlie");

                GrammarBuilder red = new ("red");
                GrammarBuilder blue = new ("blue");
                GrammarBuilder black = new ("black");
                GrammarBuilder done = new ("done");

                red.Append(letters);
                blue.Append(letters);
                black.Append(letters);

                return new Choices(new GrammarBuilder[] { red, black, blue, done });
            }
        }

        public override string Process(string command, Bomb bomb)
        {
            string[] parts = command.Split(' ');

            string[] targetArray = Array.Empty<string>();

            switch (parts[0])
            {
                case "red":
                    targetArray = this.redOccurences[this.redWires];
                    this.redWires++;
                    break;
                case "blue":
                    targetArray = this.blueOccurences[this.blueWires];
                    this.blueWires++;
                    break;
                case "black":
                    targetArray = this.blackOccurences[this.blackWires];
                    this.blackWires++;
                    break;
            }

            return targetArray.Contains(parts[1]) ? "Yes." : "No.";
        }
    }
}