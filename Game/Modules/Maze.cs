namespace KTANE.Game.Modules
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Speech.Recognition;
    using KTANE.Game;

    internal class Maze : BombModule
    {
        private const char Circle = 'O';
        private const char Wall = '|';

        private readonly List<char[,]> mazes = new ()
        {
            new char[,]
            {
                { '*', ' ', '*', ' ', '*', '|', '*', ' ', '*', ' ', '*' },
                { ' ', '|', '|', '|', ' ', '|', ' ', '|', '|', '|', '|' },
                { 'O', '|', '*', ' ', '*', '|', '*', ' ', '*', ' ', '*' },
                { ' ', '|', ' ', '|', '|', '|', '|', '|', '|', '|', ' ' },
                { '*', '|', '*', ' ', '*', '|', '*', ' ', '*', ' ', 'O' },
                { ' ', '|', '|', '|', ' ', '|', ' ', '|', '|', '|', ' ' },
                { '*', '|', '*', ' ', '*', ' ', '*', '|', '*', ' ', '*' },
                { ' ', '|', '|', '|', '|', '|', '|', '|', '|', '|', ' ' },
                { '*', ' ', '*', ' ', '*', '|', '*', ' ', '*', '|', '*' },
                { ' ', '|', '|', '|', ' ', '|', ' ', '|', '|', '|', ' ' },
                { '*', ' ', '*', '|', '*', ' ', '*', '|', '*', ' ', '*' },
            },
            new char[,]
            {
                { '*', ' ', '*', ' ', '*', '|', '*', ' ', '*', ' ', '*' },
                { '|', '|', ' ', '|', '|', '|', ' ', '|', ' ', '|', '|' },
                { '*', ' ', '*', '|', '*', ' ', '*', '|', 'O', ' ', '*' },
                { ' ', '|', '|', '|', ' ', '|', '|', '|', '|', '|', ' ' },
                { '*', '|', '*', ' ', '*', '|', '*', ' ', '*', ' ', '*' },
                { ' ', '|', ' ', '|', '|', '|', ' ', '|', '|', '|', ' ' },
                { '*', ' ', 'O', '|', '*', ' ', '*', '|', '*', '|', '*' },
                { ' ', '|', '|', '|', ' ', '|', '|', '|', ' ', '|', ' ' },
                { '*', '|', '*', '|', '*', '|', '*', ' ', '*', '|', '*' },
                { ' ', '|', ' ', '|', ' ', '|', ' ', '|', '|', '|', ' ' },
                { '*', '|', '*', ' ', '*', '|', '*', ' ', '*', ' ', '*' },
            },
            new char[,]
            {
                { '*', ' ', '*', ' ', '*', '|', '*', '|', '*', ' ', '*' },
                { ' ', '|', '|', '|', ' ', '|', ' ', '|', ' ', '|', ' ' },
                { '*', '|', '*', '|', '*', '|', '*', ' ', '*', '|', '*' },
                { '|', '|', ' ', '|', ' ', '|', '|', '|', '|', '|', ' ' },
                { '*', ' ', '*', '|', '*', '|', '*', ' ', '*', '|', '*' },
                { ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ' },
                { '*', '|', '*', '|', '*', '|', 'O', '|', '*', '|', 'O' },
                { ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ' },
                { '*', '|', '*', ' ', '*', '|', '*', '|', '*', '|', '*' },
                { ' ', '|', '|', '|', '|', '|', ' ', '|', ' ', '|', ' ' },
                { '*', ' ', '*', ' ', '*', ' ', '*', '|', '*', ' ', '*' },
            },
            new char[,]
            {
                { 'O', ' ', '*', '|', '*', ' ', '*', ' ', '*', ' ', '*' },
                { ' ', '|', ' ', '|', '|', '|', '|', '|', '|', '|', ' ' },
                { '*', '|', '*', '|', '*', ' ', '*', ' ', '*', ' ', '*' },
                { ' ', '|', ' ', '|', ' ', '|', '|', '|', '|', '|', ' ' },
                { '*', '|', '*', ' ', '*', '|', '*', ' ', '*', '|', '*' },
                { ' ', '|', '|', '|', '|', '|', ' ', '|', '|', '|', ' ' },
                { 'O', '|', '*', ' ', '*', ' ', '*', ' ', '*', ' ', '*' },
                { ' ', '|', '|', '|', '|', '|', '|', '|', '|', '|', ' ' },
                { '*', ' ', '*', ' ', '*', ' ', '*', ' ', '*', '|', '*' },
                { ' ', '|', '|', '|', '|', '|', '|', '|', ' ', '|', ' ' },
                { '*', ' ', '*', ' ', '*', '|', '*', ' ', '*', '|', '*' },
            },
            new char[,]
            {
                { '*', ' ', '*', ' ', '*', ' ', '*', ' ', '*', ' ', '*' },
                { '|', '|', '|', '|', '|', '|', '|', '|', ' ', '|', ' ' },
                { '*', ' ', '*', ' ', '*', ' ', '*', ' ', '*', '|', '*' },
                { ' ', '|', '|', '|', '|', '|', ' ', '|', '|', '|', '|' },
                { '*', ' ', '*', '|', '*', ' ', '*', '|', 'O', ' ', '*' },
                { ' ', '|', ' ', '|', '|', '|', '|', '|', ' ', '|', ' ' },
                { '*', '|', '*', ' ', '*', ' ', '*', '|', '*', '|', '*' },
                { ' ', '|', '|', '|', '|', '|', ' ', '|', '|', '|', ' ' },
                { '*', '|', '*', ' ', '*', ' ', '*', ' ', '*', '|', '*' },
                { ' ', '|', ' ', '|', '|', '|', '|', '|', '|', '|', ' ' },
                { '*', '|', '*', ' ', '*', ' ', 'O', ' ', '*', ' ', '*' },
            },
            new char[,]
            {
                { '*', '|', '*', ' ', '*', '|', '*', ' ', 'O', ' ', '*' },
                { ' ', '|', ' ', '|', ' ', '|', '|', '|', ' ', '|', ' ' },
                { '*', '|', '*', '|', '*', '|', '*', ' ', '*', '|', '*' },
                { ' ', '|', ' ', '|', ' ', '|', ' ', '|', '|', '|', ' ' },
                { '*', ' ', '*', '|', '*', '|', '*', '|', '*', ' ', '*' },
                { ' ', '|', '|', '|', '|', '|', ' ', '|', ' ', '|', '|' },
                { '*', ' ', '*', '|', '*', ' ', '*', '|', '*', '|', '*' },
                { '|', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ' },
                { '*', ' ', '*', '|', 'O', '|', '*', '|', '*', ' ', '*' },
                { ' ', '|', '|', '|', '|', '|', ' ', '|', '|', '|', ' ' },
                { '*', ' ', '*', ' ', '*', ' ', '*', '|', '*', ' ', '*' },
            },
            new char[,]
            {
                { '*', ' ', 'O', ' ', '*', ' ', '*', '|', '*', ' ', '*' },
                { ' ', '|', '|', '|', '|', '|', ' ', '|', ' ', '|', ' ' },
                { '*', '|', '*', ' ', '*', '|', '*', ' ', '*', '|', '*' },
                { ' ', '|', ' ', '|', '|', '|', '|', '|', '|', '|', ' ' },
                { '*', ' ', '*', '|', '*', ' ', '*', '|', '*', ' ', '*' },
                { '|', '|', '|', '|', ' ', '|', '|', '|', ' ', '|', '|' },
                { '*', ' ', '*', '|', '*', ' ', '*', ' ', '*', '|', '*' },
                { ' ', '|', ' ', '|', ' ', '|', '|', '|', '|', '|', ' ' },
                { '*', '|', '*', '|', '*', ' ', '*', ' ', '*', '|', '*' },
                { ' ', '|', '|', '|', '|', '|', '|', '|', ' ', '|', ' ' },
                { '*', ' ', 'O', ' ', '*', ' ', '*', ' ', '*', ' ', '*' },
            },
            new char[,]
            {
                { '*', '|', '*', ' ', '*', ' ', 'O', '|', '*', ' ', '*' },
                { ' ', '|', ' ', '|', '|', '|', ' ', '|', ' ', '|', ' ' },
                { '*', ' ', '*', ' ', '*', '|', '*', ' ', '*', '|', '*' },
                { ' ', '|', '|', '|', '|', '|', '|', '|', '|', '|', ' ' },
                { '*', '|', '*', ' ', '*', ' ', '*', ' ', '*', '|', '*' },
                { ' ', '|', ' ', '|', '|', '|', '|', '|', ' ', '|', ' ' },
                { '*', '|', '*', ' ', 'O', '|', '*', ' ', '*', ' ', '*' },
                { ' ', '|', '|', '|', ' ', '|', '|', '|', '|', '|', '|' },
                { '*', '|', '*', '|', '*', ' ', '*', ' ', '*', ' ', '*' },
                { ' ', '|', ' ', '|', '|', '|', '|', '|', '|', '|', '|' },
                { '*', ' ', '*', ' ', '*', ' ', '*', ' ', '*', ' ', '*' },
            },
            new char[,]
            {
                { '*', '|', '*', ' ', '*', ' ', '*', ' ', '*', ' ', '*' },
                { ' ', '|', ' ', '|', '|', '|', '|', '|', ' ', '|', ' ' },
                { '*', '|', '*', '|', 'O', ' ', '*', '|', '*', '|', '*' },
                { ' ', '|', ' ', '|', ' ', '|', '|', '|', ' ', '|', ' ' },
                { '*', ' ', '*', ' ', '*', '|', '*', ' ', '*', '|', '*' },
                { ' ', '|', '|', '|', '|', '|', ' ', '|', '|', '|', ' ' },
                { '*', '|', '*', '|', '*', ' ', '*', '|', '*', ' ', '*' },
                { ' ', '|', ' ', '|', ' ', '|', '|', '|', '|', '|', ' ' },
                { 'O', '|', '*', '|', '*', '|', '*', ' ', '*', '|', '*' },
                { ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', '|' },
                { '*', ' ', '*', '|', '*', ' ', '*', '|', '*', ' ', '*' },
            },
        };

        private Point? squareLocation;

        private char[,] targetMaze;

        private Point? triangleLocation;

        private bool solved;

        public override string Name => "Maze";

        public override string Help => "<0-6>, <0-6>. (Column, Row)";

        public override string PreInfo => ", either green circle's coordinates?";

        public override GrammarBuilder Grammar
        {
            get
            {
                GrammarBuilder grammarBuilder = new ();
                grammarBuilder.Append(new Choices(new string[] { "1", "2", "3", "4", "5", "6" }), 2, 2);

                return grammarBuilder;
            }
        }

        public override string Process(string command, Bomb bomb)
        {
            string[] parts = command.Split(' ');
            int x = (int.Parse(parts[0]) - 1) * 2;
            int y = (int.Parse(parts[1]) - 1) * 2;

            if (this.targetMaze == null)
            {
                int index = this.mazes.FindIndex(m => m[y, x] == Circle);

                if (index != -1)
                {
                    this.targetMaze = this.mazes[index];

                    return "Square coordinates?";
                }

                return "Invalid circle coordinates.";
            }

            if (!this.squareLocation.HasValue)
            {
                this.squareLocation = new Point(x, y);
                return "Triangle coordinates?";
            }

            this.triangleLocation = new Point(x, y);

            if (this.triangleLocation.Value.X == this.squareLocation.Value.X && this.triangleLocation.Value.Y == this.squareLocation.Value.Y)
            {
                this.squareLocation = new Point(0, 0);
                return "Square and triangle must be in different places.";
            }

            List<string> directions = this.Solve(this.squareLocation.Value.X, this.squareLocation.Value.Y, new List<string>());

            if (directions.Count > 0)
            {
                return string.Join(". ", directions);
            }

            return "No path found.";
        }

        private List<string> Solve(int x, int y, List<string> currentPath, string direction = null)
        {
            if (x == this.triangleLocation.Value.X && y == this.triangleLocation.Value.Y)
            {
                this.solved = true;
            }

            if (!this.solved && direction != "down" && this.IsValidPosition(x, y - 2) && this.CanMoveTo(x, y - 1))
            {
                currentPath.Add("Up");

                currentPath = this.Solve(x, y - 2, currentPath, "up");
            }

            if (!this.solved && direction != "up" && this.IsValidPosition(x, y + 2) && this.CanMoveTo(x, y + 1))
            {
                currentPath.Add("Down");

                currentPath = this.Solve(x, y + 2, currentPath, "down");
            }

            if (!this.solved && direction != "right" && this.IsValidPosition(x - 2, y) && this.CanMoveTo(x - 1, y))
            {
                currentPath.Add("Left");

                currentPath = this.Solve(x - 2, y, currentPath, "left");
            }

            if (!this.solved && direction != "left" && this.IsValidPosition(x + 2, y) && this.CanMoveTo(x + 1, y))
            {
                currentPath.Add("Right");

                currentPath = this.Solve(x + 2, y, currentPath, "right");
            }

            // Backtrack
            if (!this.solved && currentPath.Count > 0)
            {
                currentPath.RemoveAt(currentPath.Count - 1);
            }

            return currentPath;
        }

        private bool CanMoveTo(int x, int y)
        {
            return this.targetMaze[y, x] is not Wall;
        }

        private bool IsValidPosition(int x, int y)
        {
            return x >= 0
                && x < this.targetMaze.GetLength(1)
                && y >= 0
                && y < this.targetMaze.GetLength(0);
        }
    }
}