namespace KTANE.Game.Modules
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Speech.Recognition;

    internal class Wires : BombModule
    {
        private readonly Dictionary<int, string> indexingDict = new ()
        {
            { 1, "first" },
            { 2, "second" },
            { 3, "third" },
            { 4, "fourth" },
            { 5, "fifth" },
            { 6, "sixth" },
        };

        public override string Name => "Wires";

        public override string Help => "<color, 3-6 times> done";

        public override string PreInfo => string.Empty;

        public override GrammarBuilder Grammar
        {
            get
            {
                GrammarBuilder grammarBuilder = new ();
                grammarBuilder.Append(new Choices(new string[] { "yellow", "blue", "black", "white", "red" }), 3, 6);
                grammarBuilder.Append("done");

                return grammarBuilder;
            }
        }

        public override string Process(string command, Bomb bomb)
        {
            string[] wires = command.Split(' ');
            wires = wires.Take(wires.Length - 1).ToArray();

            if (wires.Length > 6)
            {
                return $"Too many wires given. ({wires.Length})";
            }

            if (wires.Length < 3)
            {
                return $"You must give at least 3 wires. ({wires.Length} given)";
            }

            int redWires = (from wire in wires where wire == "red" select wire).Count();
            int whiteWires = (from wire in wires where wire == "white" select wire).Count();
            int blackWires = (from wire in wires where wire == "black" select wire).Count();
            int yellowWires = (from wire in wires where wire == "yellow" select wire).Count();
            int blueWires = (from wire in wires where wire == "blue" select wire).Count();

            int index = 0;

            switch (wires.Length)
            {
                case 3:
                    if (redWires == 0)
                    {
                        index = 2;
                    }
                    else if (wires.Last() == "white")
                    {
                        index = 3;
                    }
                    else if (blueWires > 1)
                    {
                        index = wires[0] == "blue" && wires[1] == "blue" && wires[2] != "blue" ? 2 : 3;
                    }
                    else
                    {
                        index = 3;
                    }

                    break;
                case 4:
                    if (redWires > 1 && !bomb.LastDigitEven.Value)
                    {
                        for (int i = 1; i < wires.Length; i++)
                        {
                            if (wires[i] == "red")
                            {
                                index = i + 1;
                            }
                        }
                    }
                    else if (wires.Last() == "yellow" && redWires == 0)
                    {
                        index = 1;
                    }
                    else if (blueWires == 1)
                    {
                        index = 1;
                    }
                    else
                    {
                        index = yellowWires > 1 ? 4 : 2;
                    }

                    break;
                case 5:
                    if (wires.Last() == "black" && !bomb.LastDigitEven.Value)
                    {
                        index = 4;
                    }
                    else if (redWires == 1 && yellowWires > 1)
                    {
                        index = 1;
                    }
                    else
                    {
                        index = blackWires == 0 ? 2 : 1;
                    }

                    break;
                case 6:
                    if (yellowWires == 0 && !bomb.LastDigitEven.Value)
                    {
                        index = 3;
                    }
                    else if (yellowWires == 1 && whiteWires > 1)
                    {
                        index = 4;
                    }
                    else
                    {
                        index = redWires == 0 ? 6 : 4;
                    }

                    break;
            }

            return $"Cut the {this.IndexToWords(index, wires.Length)} wire.";
        }

        private string IndexToWords(int index, int count)
        {
            return index == count ? "last" : this.indexingDict[index];
        }
    }
}