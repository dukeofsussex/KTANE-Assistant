namespace KTANE.Game.Modules.Utils
{
    public class Block
    {
        public Block(bool up, bool down, bool left, bool right)
        {
            this.Up = up;
            this.Down = down;
            this.Left = left;
            this.Right = right;
            this.Marked = false;
        }

        public bool Up { get; }

        public bool Down { get; }

        public bool Left { get; }

        public bool Right { get; }

        public bool Marked { get; set; }

        public static Block Nothing()
        {
            return new Block(false, false, false, false);
        }

        public static Block OnlyLeft()
        {
            return new Block(false, false, false, true);
        }

        public static Block OnlyRight()
        {
            return new Block(false, false, true, false);
        }

        public static Block LeftRight()
        {
            return new Block(false, false, true, true);
        }

        public static Block OnlyDown()
        {
            return new Block(false, true, false, false);
        }

        public static Block DownLeft()
        {
            return new Block(false, true, false, true);
        }

        public static Block DownRight()
        {
            return new Block(false, true, true, false);
        }

        public static Block DownLeftRight()
        {
            return new Block(false, true, true, true);
        }

        public static Block OnlyUp()
        {
            return new Block(true, false, false, false);
        }

        public static Block UpLeft()
        {
            return new Block(true, false, false, true);
        }

        public static Block UpRight()
        {
            return new Block(true, false, true, false);
        }

        public static Block UpLeftRight()
        {
            return new Block(true, false, true, true);
        }

        public static Block UpDown()
        {
            return new Block(true, true, false, false);
        }

        public static Block UpDownLeft()
        {
            return new Block(true, true, false, true);
        }

        public static Block UpDownRight()
        {
            return new Block(true, true, true, false);
        }

        public static Block All()
        {
            return new Block(true, true, true, true);
        }
    }
}