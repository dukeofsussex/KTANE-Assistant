namespace KTANE.Game
{
    using KTANE.Brain;

    internal abstract class BombModule : SpeechProcessor
    {
        public abstract string PreInfo { get; }
    }
}