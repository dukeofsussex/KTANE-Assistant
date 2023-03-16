namespace KTANE.Game.Modules
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Speech.Recognition;
    using KTANE.Game;

    internal class Knob : BombModule
    {
        private readonly Dictionary<string, string> positionsDict = new ()
        {
            { "off off on on on on", "up" },
            { "on off on off on on", "up" },
            { "off on on on on on", "down" },
            { "on off on off on off", "down" },
            { "off off off on off off", "left" },
            { "off off off off off off", "left" },
            { "on off on on on on", "right" },
        };

        public override string Name => "Knob";

        public override string Help => "<on | off, 6 times> (3 times upper left, 3 times lower left)";

        public override string PreInfo => string.Empty;

        public override GrammarBuilder Grammar => new Choices(this.positionsDict.Keys.ToArray());

        public override string Process(string command, Bomb bomb)
        {
            return $"{this.positionsDict[command].ToUpperInvariant()} position.";
        }
    }
}