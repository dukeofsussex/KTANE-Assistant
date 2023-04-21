namespace KTANE.Brain
{
    using System.Collections.Generic;
    using System.Speech.Recognition;
    using KTANE.Game;

    internal abstract class SpeechProcessor
    {
        private readonly List<string> digits = new ()
        {
            { "first" },
            { "second" },
            { "third" },
            { "fourth" },
            { "fifth" },
            { "sixth" },
        };

        public abstract string Name { get; }

        public abstract GrammarBuilder Grammar { get; }

        public abstract string Help { get; }

        public virtual bool IsGlobal { get; } = false;

        public abstract string Process(string input, Bomb bomb);

        protected string DigitToWord(int digit)
        {
            return this.digits[digit];
        }
    }
}
