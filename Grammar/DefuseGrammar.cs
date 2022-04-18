using System.IO;
using System.Speech.Recognition;

namespace KTANE_Bot
{
    public static class DefuseGrammar
    {
        public static Grammar StandardDefuseGrammar = new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"Defuse.txt"))));
        public static Grammar BombCheckGrammar => bombCheckGrammar();
        public static Grammar ButtonGrammar => buttonGrammar();

        //bomb checking grammar
        private static Grammar bombCheckGrammar()
        {
            var batteryChoices = new Choices(new string[] {"none", "0", "1", "2", "more than 2", "3", "4", "5", "6"});
            var countBatteries = new GrammarBuilder(batteryChoices);
            var trueOrFalse = new Choices(new string[] {"yes", "no", "true", "false"});
            var trueOrFalseChoices = new GrammarBuilder(trueOrFalse);
            var oddEven = new Choices(new string[] {"odd", "even"});
            var oddEvenChoices = new GrammarBuilder(oddEven);
                
            //batteries
            var battery = new GrammarBuilder("Batteries");
            battery.Append(countBatteries);
                
            //parallel port
            var parallelPort = new GrammarBuilder("Parallel");
            parallelPort.Append(trueOrFalse);
                
            //frk, interpreted as the word "freak".
            var frk = new GrammarBuilder("Freak");
            frk.Append(trueOrFalse);
                
            //car, interpreted as the word "car".
            var car = new GrammarBuilder("Car");
            car.Append(trueOrFalse);
                
            //vowel in serial number
            var vowel = new GrammarBuilder("Vowel");
            vowel.Append(trueOrFalse);
                
            //last number of serial number
            var digit = new GrammarBuilder("Digit");
            digit.Append(oddEven);
                
            var allChoices = new Choices(new GrammarBuilder[] {battery, vowel, parallelPort, digit, frk, car});
            return new Grammar(allChoices);
        }

        private static Grammar buttonGrammar()
        {
            var labelChoices = new Choices(new string[] { "detonate", "hold", "press", "abort", "stripe"});
            var red = new GrammarBuilder("Red");
            var yellow = new GrammarBuilder("Yellow");
            var blue = new GrammarBuilder("Blue");
            var white = new GrammarBuilder("White");
            
            red.Append(labelChoices);
            yellow.Append(labelChoices);
            blue.Append(labelChoices);
            white.Append(labelChoices);

            var allChoices = new Choices(new GrammarBuilder[] {red, yellow, blue, white});
            return new Grammar(allChoices);
        }

        private static Grammar memoryGrammar()
        {
            var nums = new Choices(new string[] {"1", "2", "3", "4"});
            var sequence = new GrammarBuilder("Sequence");
            sequence.Append(nums);

            var allChoices = new Choices(sequence);
            return new Grammar(allChoices);
        }
    }
}