namespace KTANE.Game.Modules
{
    using System.Speech.Recognition;
    using KTANE.Game;

    internal class ComplexWires : BombModule
    {
        public override string Name => "Complicated";

        public override string Help => "<THE COLORS OF THE WIRE> + <nothing|star|light|star and light>";

        public override string PreInfo => string.Empty;

        public override GrammarBuilder Grammar
        {
            get
            {
                Choices properties = new ("nothing", "star", "light", "star and light", "light and star");

                GrammarBuilder red = new ("red");
                GrammarBuilder redWhite = new ("red and white");
                GrammarBuilder whiteRed = new ("white and red");

                GrammarBuilder blue = new ("blue");
                GrammarBuilder blueWhite = new ("blue and white");
                GrammarBuilder whiteBlue = new ("white and blue");

                GrammarBuilder blueRed = new ("blue and red");
                GrammarBuilder redBlue = new ("red and blue");

                GrammarBuilder white = new ("white");

                GrammarBuilder done = new ("done");

                red.Append(properties);
                redWhite.Append(properties);
                whiteRed.Append(properties);
                blue.Append(properties);
                blueWhite.Append(properties);
                whiteBlue.Append(properties);
                blueRed.Append(properties);
                redBlue.Append(properties);
                white.Append(properties);

                return new Choices(new GrammarBuilder[] { red, redWhite, whiteRed, blue, blueWhite, whiteBlue, blueRed, redBlue, white, done });
            }
        }

        public override string Process(string command, Bomb bomb)
        {
            bool red = command.Contains("red");
            bool blue = command.Contains("blue");
            bool star = command.Contains("star");
            bool light = command.Contains("light");

            if ((!red && !blue && !star && !light)
                || (!red && !blue && star && !light)
                || (red && !blue && star && !light))
            {
                return "Yes.";
            }

            if ((red && blue && !star && !light)
                || (red && blue && !star && light)
                || (red && !blue && !star && !light)
                || (!red && blue && !star && !light))
            {
                return bomb.LastDigitEven.Value ? "Yes." : "No."; // S
            }

            if ((red && blue && star && !light)
                || (!red && blue && star && light)
                || (!red && blue && !star && light))
            {
                return bomb.HasParallelPort.Value ? "Yes." : "No."; // P
            }

            if ((red && !blue && star && light)
                || (red && !blue && !star && light)
                || (!red && !blue && star && light))
            {
                return bomb.Batteries > 1 ? "Yes." : "No."; // B
            }

            return "No.";
        }
    }
}