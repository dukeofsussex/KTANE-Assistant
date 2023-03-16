namespace KTANE.Game.Modules
{
    using System.Collections.Generic;
    using System.Speech.Recognition;
    using System.Text;
    using KTANE.Game;

    internal class Simon : BombModule
    {
        private readonly List<string> sequence = new ();

        private readonly List<Dictionary<string, string>> vowel = new ()
        {
            new ()
            {
                { "red", "blue" },
                { "blue", "red" },
                { "green", "yellow" },
                { "yellow", "green" },
            },
            new ()
            {
                { "red", "yellow" },
                { "blue", "green" },
                { "green", "blue" },
                { "yellow", "red" },
            },
            new ()
            {
                { "red", "green" },
                { "blue", "red" },
                { "green", "yellow" },
                { "yellow", "blue" },
            },
        };

        private readonly List<Dictionary<string, string>> noVowel = new ()
        {
            new ()
            {
                { "red", "blue" },
                { "blue", "yellow" },
                { "green", "green" },
                { "yellow", "red" },
            },
            new ()
            {
                { "red", "red" },
                { "blue", "blue" },
                { "green", "yellow" },
                { "yellow", "green" },
            },
            new ()
            {
                { "red", "yellow" },
                { "blue", "green" },
                { "green", "blue" },
                { "yellow", "red" },
            },
        };

        public override string Name => "Simon";

        public override string Help => "<color that flashes last>";

        public override string PreInfo => string.Empty;

        public override GrammarBuilder Grammar
        {
            get
            {
                GrammarBuilder blue = new ("blue");
                GrammarBuilder green = new ("green");
                GrammarBuilder red = new ("red");
                GrammarBuilder yellow = new ("yellow");
                GrammarBuilder done = new ("done");

                return new Choices(new GrammarBuilder[] { blue, red, green, yellow, done });
            }
        }

        public override string Process(string command, Bomb bomb)
        {
            this.sequence.Add(command);

            StringBuilder buttonsToPress = new ();
            Dictionary<string, string> targetDict = bomb.HasVowel.Value
                ? this.vowel[bomb.Strikes]
                : this.noVowel[bomb.Strikes];

            foreach (string s in this.sequence)
            {
                _ = buttonsToPress.Append($"{targetDict[s]}, ");
            }

            return $"Press {buttonsToPress}.";
        }
    }
}