namespace KTANE.Game.Modules.Utils
{
    using System.Drawing;

    internal class Node
    {
        private Point location;

        public Node(int x, int y)
        {
            this.location = new Point(x, y);
            this.Previous = null;
        }

        public int X
        {
            get => this.location.X;

            set => this.location = new Point(value, this.location.Y);
        }

        public int Y
        {
            get => this.location.Y;

            set => this.location = new Point(this.location.X, value);
        }

        public Node Previous { get; set; }
    }
}