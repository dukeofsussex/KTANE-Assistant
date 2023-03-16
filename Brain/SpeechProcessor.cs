namespace KTANE.Brain
{
    using System.Speech.Recognition;
    using KTANE.Game;

    internal abstract class SpeechProcessor
    {
        public abstract string Name { get; }

        public abstract GrammarBuilder Grammar { get; }

        public abstract string Help { get; }

        public virtual bool IsGlobal { get; } = false;

        public abstract string Process(string input, Bomb bomb);
    }
}
