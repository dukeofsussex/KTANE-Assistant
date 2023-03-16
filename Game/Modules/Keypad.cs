namespace KTANE.Game.Modules
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Speech.Recognition;
    using KTANE.Game;

    internal class Keypad : BombModule
    {
        private readonly List<List<string>> columns = new ()
        {
            new ()
            {
                "balloon",
                "at",
                "lambda",
                "lightning",
                "kitty",
                "curly h",
                "reverse c",
            },
            new ()
            {
                "euro",
                "balloon",
                "reverse c",
                "pigtail",
                "empty star",
                "curly h",
                "question mark",
            },
            new ()
            {
                "copyright",
                "pumpkin",
                "pigtail",
                "double k",
                "three",
                "lambda",
                "empty star",
            },
            new ()
            {
                "six",
                "paragraph",
                "bt",
                "kitty",
                "double k",
                "question mark",
                "smiley face",
            },
            new ()
            {
                "pitchfork",
                "smiley face",
                "bt",
                "c",
                "paragraph",
                "dragon",
                "full star",
            },
            new ()
            {
                "six",
                "euro",
                "puzzle",
                "ash",
                "pitchfork",
                "reverse n",
                "omega",
            },
        };

        private readonly List<string> symbols = new ();

        public override string Name => "Keypad";

        public override string Help => "<symbol>";

        public override string PreInfo => ", first symbol?";

        public override GrammarBuilder Grammar => new (new Choices(this.columns.SelectMany(x => x).Distinct().ToArray()));

        public override string Process(string command, Bomb bomb)
        {
            if (this.symbols.Count < 4)
            {
                this.symbols.Add(command);

                if (this.symbols.Count < 4)
                {
                    return $"{command}, next.";
                }
            }

            List<string> column = null;

            for (int i = 0; i < this.columns.Count; i++)
            {
                if (this.symbols.All(x => this.columns[i].Contains(x)))
                {
                    column = this.columns[i];
                    break;
                }
            }

            if (column == null)
            {
                return "Wrong sequence.";
            }

            List<string> output = this.symbols.OrderBy(column.IndexOf).ToList();

            return $"First is {output[0]}, then {output[1]}, then {output[2]}, then {output[3]}.";
        }
    }
}