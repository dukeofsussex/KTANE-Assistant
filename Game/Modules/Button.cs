namespace KTANE.Game.Modules
{
    using System.Speech.Recognition;
    using KTANE.Game;

    internal class Button : BombModule
    {
        private const string Hold = "Hold it, tell me the stripe color.";
        private const string Press = "Press and immediately release.";

        private string color;
        private string label;

        public override GrammarBuilder Grammar
        {
            get
            {
                Choices labelChoices = new (new string[] { "detonate", "hold", "press", "abort", "stripe" });
                GrammarBuilder red = new ("Red");
                GrammarBuilder yellow = new ("Yellow");
                GrammarBuilder blue = new ("Blue");
                GrammarBuilder white = new ("White");

                red.Append(labelChoices);
                yellow.Append(labelChoices);
                blue.Append(labelChoices);
                white.Append(labelChoices);

                return new Choices(new GrammarBuilder[] { red, yellow, blue, white });
            }
        }

        public override string Name => "Button";

        public override string Help => "<color> <label> | <color> stripe";

        public override string PreInfo => string.Empty;

        [RequiredBombSetting(nameof(Bomb.Batteries), nameof(Bomb.HasLitCAR), nameof(Bomb.HasLitFRK))]
        public override string Process(string command, Bomb bomb)
        {
            string[] parts = command.Split(' ');

            this.color = parts[0];

            if (command.EndsWith("stripe"))
            {
                if (this.color == "blue")
                {
                    return "Release at four.";
                }

                return this.color == "yellow" ? "Release at five." : "Release at one.";
            }

            this.label = parts[1].ToLowerInvariant();

            if (this.color == "blue" && this.label == "abort")
            {
                return Hold;
            }

            if (bomb.Batteries > 1 && this.label == "detonate")
            {
                return Press;
            }

            if (bomb.HasLitCAR.Value && this.color == "white")
            {
                return Hold;
            }

            if (bomb.HasLitFRK.Value && bomb.Batteries > 2)
            {
                return Press;
            }

            return this.color == "red" && this.label == "hold" ? Press : Hold;
        }
    }
}