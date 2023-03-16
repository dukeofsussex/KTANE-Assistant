namespace KTANE.Game.Modules
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Speech.Recognition;
    using System.Text;
    using KTANE.Game;
    using KTANE.Game.Modules.Utils;

    internal class Maze : BombModule
    {
        private readonly List<Block[,]> mazes = new ()
        {
            new Block[,]
            {
                { Block.DownRight(), Block.LeftRight(), Block.DownLeft(), Block.DownRight(), Block.LeftRight(), Block.OnlyLeft() },
                { Block.UpDown(), Block.DownRight(), Block.UpLeft(), Block.UpRight(), Block.LeftRight(), Block.DownLeft() },
                { Block.UpDown(), Block.UpRight(), Block.DownLeft(), Block.DownRight(), Block.LeftRight(), Block.UpDownLeft() },
                { Block.UpDown(), Block.OnlyRight(), Block.UpLeftRight(), Block.UpLeft(), Block.OnlyRight(), Block.UpDownLeft() },
                { Block.UpDownRight(), Block.LeftRight(), Block.DownLeft(), Block.DownRight(), Block.OnlyLeft(), Block.UpDown() },
                { Block.UpRight(), Block.OnlyLeft(), Block.UpRight(), Block.UpLeft(), Block.OnlyRight(), Block.UpLeft() },
            },
            new Block[,]
            {
                { Block.OnlyRight(), Block.DownLeftRight(), Block.OnlyLeft(), Block.DownRight(), Block.DownLeftRight(), Block.OnlyLeft() },
                { Block.DownRight(), Block.UpLeft(), Block.DownRight(), Block.UpLeft(), Block.UpRight(), Block.DownLeft() },
                { Block.UpDown(), Block.DownRight(), Block.UpLeft(), Block.DownRight(), Block.LeftRight(), Block.UpDownLeft() },
                { Block.UpDownRight(), Block.UpLeft(), Block.DownRight(), Block.UpLeft(), Block.OnlyDown(), Block.UpDown() },
                { Block.UpDown(), Block.OnlyDown(), Block.UpDown(), Block.DownRight(), Block.UpLeft(), Block.UpDown() },
                { Block.OnlyUp(), Block.UpRight(), Block.UpLeft(), Block.UpRight(), Block.LeftRight(), Block.UpLeft() },
            },
            new Block[,]
            {
                { Block.DownRight(), Block.LeftRight(), Block.DownLeft(), Block.OnlyDown(), Block.DownRight(), Block.DownLeft() },
                { Block.OnlyUp(), Block.OnlyDown(), Block.UpDown(), Block.UpRight(), Block.UpLeft(), Block.UpDown() },
                { Block.DownRight(), Block.UpDownLeft(), Block.UpDown(), Block.DownRight(), Block.DownLeft(), Block.UpDown() },
                { Block.UpDown(), Block.UpDown(), Block.UpDown(), Block.UpDown(), Block.UpDown(), Block.UpDown() },
                { Block.UpDown(), Block.UpRight(), Block.UpLeft(), Block.UpDown(), Block.UpDown(), Block.UpDown() },
                { Block.UpRight(), Block.LeftRight(), Block.LeftRight(), Block.UpLeft(), Block.UpRight(), Block.UpLeft() },
            },
            new Block[,]
            {
                { Block.DownRight(), Block.DownLeft(), Block.OnlyRight(), Block.LeftRight(), Block.LeftRight(), Block.DownLeft() },
                { Block.UpDown(), Block.UpDown(), Block.DownRight(), Block.LeftRight(), Block.LeftRight(), Block.UpDownLeft() },
                { Block.UpDown(), Block.UpRight(), Block.UpLeft(), Block.DownRight(), Block.OnlyLeft(), Block.UpDown() },
                { Block.UpDown(), Block.OnlyRight(), Block.LeftRight(), Block.UpLeftRight(), Block.LeftRight(), Block.UpDownLeft() },
                { Block.UpDownRight(), Block.LeftRight(), Block.LeftRight(), Block.LeftRight(), Block.DownLeft(), Block.UpDown() },
                { Block.UpRight(), Block.LeftRight(), Block.OnlyLeft(), Block.OnlyRight(), Block.UpLeft(), Block.OnlyUp() },
            },
            new Block[,]
            {
                { Block.OnlyRight(), Block.LeftRight(), Block.LeftRight(), Block.LeftRight(), Block.DownLeftRight(), Block.DownLeft() },
                { Block.DownRight(), Block.LeftRight(), Block.LeftRight(), Block.DownLeftRight(), Block.UpLeft(), Block.OnlyUp() },
                { Block.UpDownRight(), Block.DownLeft(), Block.OnlyRight(), Block.UpLeft(), Block.DownRight(), Block.DownLeft() },
                { Block.UpDown(), Block.UpRight(), Block.LeftRight(), Block.DownLeft(), Block.OnlyUp(), Block.UpDown() },
                { Block.UpDown(), Block.DownRight(), Block.LeftRight(), Block.UpLeftRight(), Block.OnlyLeft(), Block.UpDown() },
                { Block.OnlyUp(), Block.UpRight(), Block.LeftRight(), Block.LeftRight(), Block.LeftRight(), Block.UpLeft() },
            },
            new Block[,]
            {
                { Block.OnlyDown(), Block.DownRight(), Block.DownLeft(), Block.OnlyRight(), Block.DownLeftRight(), Block.DownLeft() },
                { Block.UpDown(), Block.UpDown(), Block.UpDown(), Block.DownRight(), Block.UpLeft(), Block.UpDown() },
                { Block.UpDownRight(), Block.UpLeft(), Block.OnlyUp(), Block.UpDown(), Block.DownRight(), Block.UpLeft() },
                { Block.UpRight(), Block.DownLeft(), Block.DownRight(), Block.UpDownLeft(), Block.UpDown(), Block.OnlyDown() },
                { Block.DownRight(), Block.UpLeft(), Block.OnlyUp(), Block.UpDown(), Block.UpRight(), Block.UpDownLeft() },
                { Block.UpRight(), Block.LeftRight(), Block.LeftRight(), Block.UpLeft(), Block.OnlyRight(), Block.UpLeft() },
            },
            new Block[,]
            {
                { Block.DownRight(), Block.LeftRight(), Block.LeftRight(), Block.DownLeft(), Block.DownRight(), Block.DownLeft() },
                { Block.UpDown(), Block.DownRight(), Block.OnlyLeft(), Block.UpRight(), Block.UpLeft(), Block.UpDown() },
                { Block.UpRight(), Block.UpLeft(), Block.DownRight(), Block.OnlyLeft(), Block.DownRight(), Block.UpLeft() },
                { Block.DownRight(), Block.DownLeft(), Block.UpDownRight(), Block.LeftRight(), Block.UpLeft(), Block.OnlyDown() },
                { Block.UpDown(), Block.OnlyUp(), Block.UpRight(), Block.LeftRight(), Block.DownLeft(), Block.UpDown() },
                { Block.UpRight(), Block.LeftRight(), Block.LeftRight(), Block.LeftRight(), Block.UpLeftRight(), Block.UpLeft() },
            },
            new Block[,]
            {
                { Block.OnlyDown(), Block.DownRight(), Block.LeftRight(), Block.DownLeft(), Block.DownRight(), Block.DownLeft() },
                { Block.UpDownRight(), Block.UpLeftRight(), Block.OnlyLeft(), Block.UpRight(), Block.UpLeft(), Block.UpDown() },
                { Block.UpDown(), Block.DownRight(), Block.LeftRight(), Block.LeftRight(), Block.DownLeft(), Block.UpDown() },
                { Block.UpDown(), Block.UpRight(), Block.DownLeft(), Block.OnlyRight(), Block.UpLeftRight(), Block.UpLeft() },
                { Block.UpDown(), Block.OnlyDown(), Block.UpRight(), Block.LeftRight(), Block.LeftRight(), Block.OnlyLeft() },
                { Block.UpRight(), Block.UpLeftRight(), Block.LeftRight(), Block.LeftRight(), Block.LeftRight(), Block.OnlyLeft() },
            },
            new Block[,]
            {
                { Block.OnlyDown(), Block.DownRight(), Block.LeftRight(), Block.LeftRight(), Block.DownLeftRight(), Block.DownLeft() },
                { Block.UpDown(), Block.UpDown(), Block.DownRight(), Block.OnlyLeft(), Block.UpDown(), Block.UpDown() },
                { Block.UpDownRight(), Block.UpLeftRight(), Block.UpLeft(), Block.DownRight(), Block.UpLeft(), Block.UpDown() },
                { Block.UpDown(), Block.OnlyDown(), Block.DownRight(), Block.UpLeft(), Block.OnlyRight(), Block.UpDownLeft() },
                { Block.UpDown(), Block.UpDown(), Block.UpDown(), Block.DownRight(), Block.DownLeft(), Block.OnlyUp() },
                { Block.UpRight(), Block.UpLeft(), Block.UpRight(), Block.UpLeft(), Block.UpRight(), Block.OnlyLeft() },
            },
        };

        private readonly List<List<Point>> circleLocations = new ()
        {
            new () { new Point(2, 1), new Point(3, 6) },
            new () { new Point(4, 2), new Point(2, 5) },
            new () { new Point(4, 4), new Point(4, 6) },
            new () { new Point(1, 1), new Point(4, 1) },
            new () { new Point(6, 4), new Point(3, 5) },
            new () { new Point(1, 5), new Point(5, 3) },
            new () { new Point(1, 2), new Point(6, 2) },
            new () { new Point(1, 4), new Point(4, 3) },
            new () { new Point(2, 3), new Point(5, 1) },
        };

        private Node squareLocation;

        private Block[,] targetMaze;

        private Node triangleLocation;

        public override string Name => "Maze";

        public override string Help => "<0-6>, <0-6>. (Column, Row)";

        public override string PreInfo => ", either green circle's coordinates?";

        public override GrammarBuilder Grammar
        {
            get
            {
                Choices numbers = new ("1", "2", "3", "4", "5", "6");

                GrammarBuilder one = new ("1");
                GrammarBuilder two = new ("2");
                GrammarBuilder three = new ("3");
                GrammarBuilder four = new ("4");
                GrammarBuilder five = new ("5");
                GrammarBuilder six = new ("6");

                one.Append(numbers);
                two.Append(numbers);
                three.Append(numbers);
                four.Append(numbers);
                five.Append(numbers);
                six.Append(numbers);

                return new Choices(new GrammarBuilder[] { one, two, three, four, five, six });
            }
        }

        public override string Process(string command, Bomb bomb)
        {
            string[] parts = command.Split(' ');
            int x = int.Parse(parts[0]);
            int y = int.Parse(parts[1]);

            if (this.targetMaze == null)
            {
                int index = this.circleLocations.FindIndex(m => m.Contains(new Point(x, y)));

                if (index != -1)
                {
                    this.targetMaze = this.mazes[index];

                    foreach (Block block in this.targetMaze)
                    {
                        block.Marked = false;
                    }

                    return "Square coordinates?";
                }

                return "Invalid circle coordinates.";
            }

            if (this.squareLocation == null)
            {
                this.squareLocation = new Node(--x, --y);
                return "Triangle coordinates?";
            }

            this.triangleLocation = new Node(--x, --y);

            if (this.triangleLocation.X == this.squareLocation.X && this.triangleLocation.Y == this.squareLocation.Y)
            {
                return "Square and triangle must be in different places.";
            }

            // BFS to find a path
            Queue<Node> visitedPoints = new ();
            visitedPoints.Enqueue(this.squareLocation);

            while (visitedPoints.Count != 0)
            {
                Node cell = visitedPoints.Dequeue();
                this.targetMaze[cell.X, cell.Y].Marked = true;

                if (cell.X == this.triangleLocation.X && cell.Y == this.triangleLocation.Y)
                {
                    return this.ConstructPath(cell);
                }

                // Move right
                if (cell.Y + 1 < 6 && !this.targetMaze[cell.X, cell.Y + 1].Marked && this.targetMaze[cell.X, cell.Y].Right)
                {
                    visitedPoints.Enqueue(new Node(cell.X, cell.Y + 1) { Previous = cell });
                }

                // Move left
                if (cell.Y - 1 >= 0 && !this.targetMaze[cell.X, cell.Y - 1].Marked && this.targetMaze[cell.X, cell.Y].Left)
                {
                    visitedPoints.Enqueue(new Node(cell.X, cell.Y - 1) { Previous = cell });
                }

                // Move down
                if (cell.X + 1 < 6 && !this.targetMaze[cell.X + 1, cell.Y].Marked && this.targetMaze[cell.X, cell.Y].Down)
                {
                    visitedPoints.Enqueue(new Node(cell.X + 1, cell.Y) { Previous = cell });
                }

                // Move up
                if (cell.X - 1 >= 0 && !this.targetMaze[cell.X - 1, cell.Y].Marked && this.targetMaze[cell.X, cell.Y].Up)
                {
                    visitedPoints.Enqueue(new Node(cell.X - 1, cell.Y) { Previous = cell });
                }
            }

            return "No path found.";
        }

        /// <summary>
        /// Constructs a path from a certain starting point to an end.
        /// </summary>
        /// <param name="end">The objective/goal to be reached.</param>
        /// <returns>A sequence of moves to be followed in order to reach the goal from start to end.</returns>
        private string ConstructPath(Node end)
        {
            Node previous = end;
            List<Node> path = new ();

            while (previous != null)
            {
                path.Add(previous);
                previous = previous.Previous;
            }

            StringBuilder pathBuilder = new ();
            path.Reverse();
            for (int i = 1; i < path.Count; i++)
            {
                if (path[i].X - path[i - 1].X == -1)
                {
                    _ = pathBuilder.Append("Up. ");
                }

                if (path[i].X - path[i - 1].X == 1)
                {
                    _ = pathBuilder.Append("Down. ");
                }

                if (path[i].Y - path[i - 1].Y == -1)
                {
                    _ = pathBuilder.Append("Left. ");
                }

                if (path[i].Y - path[i - 1].Y == 1)
                {
                    _ = pathBuilder.Append("Right. ");
                }
            }

            return pathBuilder.ToString();
        }
    }
}