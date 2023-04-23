namespace KTANE.Game.Modules
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Speech.Recognition;
    using KTANE.Game;

    internal class WhoIsOnFirst : BombModule
    {
        private readonly Dictionary<string, string> positions = new ()
        {
            { "it is blank", "lower left" },
            { "blank", "middle right" },
            { "c letter", "upper right" },
            { "cee", "lower right" },
            { "display", "lower right" },
            { "first", "upper right" },
            { "hold on", "lower right" },
            { "lead dog", "lower right" },
            { "led", "middle left" },
            { "el ee ee dee", "lower left" },
            { "no", "lower right" },
            { "nothing", "middle left" },
            { "okay", "upper right" },
            { "read book", "middle right" },
            { "red color", "middle right" },
            { "ar ee ee dee", "lower left" },
            { "says", "lower right" },
            { "see eyes", "lower right" },
            { "their pronoun", "middle right" },
            { "there", "lower right" },
            { "they're apostrophe", "lower left" },
            { "they are", "middle left" },
            { "u r letters", "upper left" },
            { "yes", "middle left" },
            { "you", "middle right" },
            { "your pronoun", "middle right" },
            { "you're apostrophe", "middle right" },
            { "you are", "lower right" },
        };

        private readonly Dictionary<string, string> words = new ()
        {
            { "blank", "WAIT. RIGHT. OKAY. MIDDLE. BLANK" },
            { "done", "SURE. U H SPACE H U H . NEXT. WHAT QUESTION MARK. YOUR PRONOUN. UR LETTERS. YOU'RE APOSTROPHE. HOLD. LIKE. YOU. U LETTER. YOU ARE. U H SPACE U H . DONE" },
            { "first", "LEFT. OKAY. YES. MIDDLE. NO. RIGHT. NOTHING. U H H H. WAIT. READY. BLANK. WHAT. PRESS. FIRST" },
            { "hold", "YOU ARE. U LETTER. DONE. U H SPACE U H . YOU. UR LETTERS. SURE. WHAT QUESTION MARK. YOU'RE APOSTROPHE. NEXT. HOLD" },
            { "left", "RIGHT. LEFT" },
            { "like", "YOU'RE APOSTROPHE. NEXT. U LETTER. UR LETTERS. HOLD. DONE. U H SPACE U H . WHAT QUESTION MARK. U H SPACE H U H . YOU. LIKE" },
            { "middle", "BLANK. READY. OKAY. WHAT. NOTHING. PRESS. NO. WAIT. LEFT. MIDDLE" },
            { "next", "WHAT QUESTION MARK. U H SPACE H U H . U H SPACE U H . YOUR PRONOUN. HOLD. SURE. NEXT" },
            { "no", "BLANK. U H H H. WAIT. FIRST. WHAT. READY. RIGHT. YES. NOTHING. LEFT. PRESS. OKAY. NO" },
            { "nothing", "U H H H. RIGHT. OKAY. MIDDLE. YES. BLANK. NO. PRESS. LEFT. WHAT. WAIT. FIRST. NOTHING" },
            { "okay", "MIDDLE. NO. FIRST. YES. U H H H. NOTHING. WAIT. OKAY" },
            { "press", "RIGHT. MIDDLE. YES. READY. PRESS" },
            { "ready", "YES. OKAY. WHAT. MIDDLE. LEFT. PRESS. RIGHT. BLANK. READY. NO. FIRST. U H H H. NOTHING. WAIT" },
            { "right", "YES. NOTHING. READY. PRESS. NO. WAIT. WHAT. RIGHT" },
            { "sure", "YOU ARE. DONE. LIKE. YOU'RE APOSTROPHE. YOU. HOLD. U H SPACE H U H . UR LETTERS. SURE" },
            { "u letter", "U H SPACE H U H . SURE. NEXT. WHAT QUESTION MARK. YOU'RE APOSTROPHE. UR LETTERS. U H SPACE U H . DONE. U LETTER" },
            { "u h h h", "READY. NOTHING. LEFT. WHAT. OKAY. YES. RIGHT. NO. PRESS. BLANK. U H H H" },
            { "u r letters", "DONE. U LETTER. UR LETTERS" },
            { "u h space h u h", "U H SPACE H U H" },
            { "u h space u h", "UR LETTERS. U LETTER. YOU ARE. YOU'RE APOSTROPHE. NEXT. U H SPACE U H" },
            { "wait", "U H H H. NO. BLANK. OKAY. YES. LEFT. FIRST. PRESS. WHAT. WAIT" },
            { "what", "U H H H. WHAT" },
            { "what question mark", "YOU. HOLD. YOU'RE APOSTROPHE. YOUR PRONOUN. U LETTER. DONE. U H SPACE U H . LIKE. YOU ARE. U H SPACE H U H . UR LETTERS. NEXT. WHAT QUESTION MARK" },
            { "yes", "OKAY. RIGHT. U H H H. MIDDLE. FIRST. WHAT. PRESS. READY. NOTHING. YES" },
            { "you", "SURE. YOU ARE. YOUR PRONOUN. YOU'RE APOSTROPHE. NEXT. U H SPACE H U H . UR LETTERS. HOLD. WHAT QUESTION MARK. YOU" },
            { "your pronoun", "U H SPACE U H . YOU ARE. U H SPACE H U H . YOUR PRONOUN" },
            { "you're apostrophe", "YOU. YOU'RE APOSTROPHE" },
            { "you are", "YOUR PRONOUN. NEXT. LIKE. U H SPACE H U H . WHAT QUESTION MARK. DONE. U H SPACE U H . HOLD. YOU. U LETTER. YOU'RE APOSTROPHE. SURE. UR LETTERS. YOU ARE" },
        };

        private string display;

        public override string Name => "Who Is On First";

        public override string Help => "Say what you see except: it is blank, c letter, lead dog, el ee ee dee, read book, red color, ar ee ee dee, see eyes, their/your pronoun,"
            + "they're/you're apostrophe, u h h h, u h space (h) u h";

        public override string PreInfo => ", what's on the display?";

        public override GrammarBuilder Grammar => new Choices(this.positions.Keys.Union(this.words.Keys).ToArray());

        public override string Process(string command, Bomb bomb)
        {
            if (!string.IsNullOrEmpty(this.display)
                && this.words.TryGetValue(command, out string words))
            {
                this.display = string.Empty;
                return words;
            }

            if (string.IsNullOrEmpty(this.display)
                && this.positions.TryGetValue(command, out string position))
            {
                this.display = command;
                return position;
            }

            return $"Couldn't find {command}.";
        }
    }
}