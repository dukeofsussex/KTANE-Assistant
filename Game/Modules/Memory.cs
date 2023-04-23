namespace KTANE.Game.Modules
{
    using System;
    using System.Linq;
    using System.Speech.Recognition;
    using KTANE.Game;

    internal class Memory : BombModule
    {
        private readonly int[] numbers = new int[5];
        private readonly int[] positions = new int[5];
        private int stage = 1;

        public override string Name => "Memory";

        public override string Help => "<number on display> <numbers on buttons>";

        public override string PreInfo => $", stage {this.stage}.";

        public override GrammarBuilder Grammar => new (new Choices(new[] { "1", "2", "3", "4" }), 5, 5);

        public override string Process(string command, Bomb bomb)
        {
            string[] parts = command.Split(' ');

            if (parts.Length != 5)
            {
                return "Invalid sequence.";
            }

            int[] numbers = parts.Select(int.Parse).ToArray();

            int numberToPress = 0;
            switch (this.stage)
            {
                case 1:
                    switch (numbers[0])
                    {
                        case 1:
                        case 2:
                            this.positions[0] = 2;
                            this.numbers[0] = numbers[2];
                            numberToPress = numbers[2];
                            break;
                        case 3:
                            this.positions[0] = 3;
                            this.numbers[0] = numbers[3];
                            numberToPress = numbers[3];
                            break;
                        default:
                            this.positions[0] = 4;
                            this.numbers[0] = numbers[4];
                            numberToPress = numbers[4];
                            break;
                    }

                    break;
                case 2:
                    switch (numbers[0])
                    {
                        case 1:
                            this.positions[1] = Array.IndexOf(numbers, 4);
                            this.numbers[1] = 4;
                            numberToPress = 4;
                            break;
                        case 2:
                            this.positions[1] = this.positions[0];
                            this.numbers[1] = numbers[this.positions[0]];
                            numberToPress = numbers[this.positions[0]];
                            break;
                        case 3:
                            this.positions[1] = 1;
                            this.numbers[1] = numbers[1];
                            numberToPress = numbers[1];
                            break;
                        default:
                            this.positions[1] = this.positions[0];
                            this.numbers[1] = numbers[this.positions[0]];
                            numberToPress = numbers[this.positions[0]];
                            break;
                    }

                    break;
                case 3:
                    switch (numbers[0])
                    {
                        case 1:
                            this.positions[2] = Array.IndexOf(numbers, parts[1]);
                            this.numbers[2] = this.numbers[1];
                            numberToPress = this.numbers[1];
                            break;
                        case 2:
                            this.positions[2] = Array.IndexOf(numbers, parts[0]);
                            this.numbers[2] = this.numbers[0];
                            numberToPress = this.numbers[0];
                            break;
                        case 3:
                            this.positions[2] = 3;
                            this.numbers[2] = numbers[3];
                            numberToPress = numbers[3];
                            break;
                        default:
                            this.positions[2] = Array.IndexOf(numbers, 4);
                            this.numbers[2] = 4;
                            numberToPress = 4;
                            break;
                    }

                    break;
                case 4:
                    switch (numbers[0])
                    {
                        case 1:
                            this.positions[3] = this.positions[0];
                            this.numbers[3] = numbers[this.positions[0]];
                            numberToPress = numbers[this.positions[0]];
                            break;
                        case 2:
                            this.positions[3] = 1;
                            this.numbers[3] = numbers[1];
                            numberToPress = numbers[1];
                            break;
                        case 3:
                            this.positions[3] = this.positions[1];
                            this.numbers[3] = numbers[this.positions[1]];
                            numberToPress = numbers[this.positions[1]];
                            break;
                        default:
                            this.positions[3] = this.positions[1];
                            this.numbers[3] = numbers[this.positions[1]];
                            numberToPress = numbers[this.positions[1]];
                            break;
                    }

                    break;

                case 5:
                    numberToPress = numbers[0] switch
                    {
                        1 => this.numbers[0],
                        2 => this.numbers[1],
                        3 => this.numbers[3],
                        _ => this.numbers[2],
                    };

                    break;
            }

            this.stage++;
            return $"Press {numberToPress}, {(this.stage != 6 ? $"stage {this.stage}" : "done")}.";
        }
    }
}