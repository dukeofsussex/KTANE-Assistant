namespace KTANE.Game
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Speech.Recognition;
    using KTANE.Brain;

    internal class Bomb : SpeechProcessor
    {
        private readonly Dictionary<string, bool> truthyChoices = new ()
        {
            { "none", false },
            { "odd", false },
            { "even", true },
            { "yes", true },
            { "no", false },
            { "true", true },
            { "false", false },
            { "lit", true },
            { "unlit", false },
            { "on", true },
            { "off", false },
        };

        public bool AutoReset { get; set; }

        public int? Batteries { get; set; }

        public bool? HasParallelPort { get; set; }

        public bool? HasLitFRK { get; set; }

        public bool? HasLitCAR { get; set; }

        public bool? HasVowel { get; set; }

        public bool? LastDigitEven { get; set; }

        public int Strikes { get; set; }

        public BombModule ActiveModule { get; set; }

        public override string Name => "Bomb";

        public override string Help => "Bomb defused | Bomb exploded | Set <property> <value>";

        public override bool IsGlobal => true;

        public override GrammarBuilder Grammar
        {
            get
            {
                Choices batteryChoices = new (new string[] { "none", "0", "1", "2", "more than 2", "3", "4", "5", "6" });
                Choices trueOrFalse = new (this.truthyChoices.Keys.ToArray());
                Choices oddEven = new (new string[] { "odd", "even" });

                GrammarBuilder battery = new ("Set batteries");
                battery.Append(batteryChoices);

                GrammarBuilder parallelPort = new ("Set port");
                parallelPort.Append(trueOrFalse);

                GrammarBuilder frk = new ("Set freak");
                frk.Append(trueOrFalse);

                GrammarBuilder car = new ("Set car");
                car.Append(trueOrFalse);

                GrammarBuilder vowel = new ("Set vowel");
                vowel.Append(trueOrFalse);

                GrammarBuilder digit = new ("Set digit");
                digit.Append(oddEven);

                GrammarBuilder strikes = new ("Set strikes");
                strikes.Append(new Choices(new string[] { "0", "1", "2" }));

                GrammarBuilder defused = new ("Bomb defused");
                GrammarBuilder exploded = new ("Bomb exploded");

                return new Choices(new GrammarBuilder[] { battery, parallelPort, frk, car, vowel, digit, strikes, defused, exploded });
            }
        }

        public bool Ready => typeof(Bomb).GetProperties()
            .Where(p => p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
            .All(p => p.GetValue(this) != null);

        public static Bomb CreateRandom()
        {
            Random rng = new ();

            return new Bomb
            {
                Batteries = rng.Next(0, 7),
                HasParallelPort = rng.Next(0, 2) == 1,
                HasLitCAR = rng.Next(0, 2) == 1,
                HasLitFRK = rng.Next(0, 2) == 1,
                HasVowel = rng.Next(0, 2) == 1,
                LastDigitEven = rng.Next(0, 2) == 0,
                Strikes = 0,
            };
        }

        public void Reset()
        {
            this.ActiveModule = null;
            this.Batteries = null;
            this.LastDigitEven = null;
            this.HasLitCAR = null;
            this.HasLitFRK = null;
            this.HasParallelPort = null;
            this.HasVowel = null;
            this.LastDigitEven = null;
            this.Strikes = 0;
        }

        public override string Process(string command, Bomb bomb)
        {
            if (command.StartsWith("bomb"))
            {
                Random rng = new ();

                if (bomb.AutoReset)
                {
                    bomb.Reset();
                }

                string[] messages = command.EndsWith("defused")
                    ? new[] { "Good job!", "Nice!", "We did it!", "Yay!", "Woo-hoo!", "Congratulations!" }
                    : new[] { "Aww :(", "Let's go again.", "Mission failed, we'll get them next time.", "Dead.", "We tried our best." };

                return messages[rng.Next(0, messages.Length)];
            }

            string message = string.Empty;

            if (command.StartsWith("set"))
            {
                string[] parts = command.Split(' ');
                string prop = parts[1];
                string param = parts[2];

                bool value = false;

                if (this.truthyChoices.ContainsKey(param))
                {
                    value = this.truthyChoices[param];
                }

                switch (prop)
                {
                    case "batteries":
                        int count = param == "more" ? 420 : int.Parse(param);
                        bomb.Batteries = count;
                        message = count > 2 ? "More than two batteries." : $"{count} " + (count == 1 ? "battery" : "batteries");
                        break;
                    case "port":
                        bomb.HasParallelPort = value;
                        message = value ? "Has parallel port." : "No parallel port.";
                        break;
                    case "freak":
                        bomb.HasLitFRK = value;
                        message = value ? "Lit FRK label." : "Unlit FRK label.";
                        break;
                    case "car":
                        bomb.HasLitCAR = value;
                        message = value ? "Lit CAR label." : "Unlit CAR label.";
                        break;
                    case "vowel":
                        bomb.HasVowel = value;
                        message = value ? "Has vowel." : "No vowel.";
                        break;
                    case "digit":
                        bomb.LastDigitEven = value;
                        message = value ? "Last digit is even." : "Last digit is odd.";
                        break;
                    case "strikes":
                        count = int.Parse(param);
                        bomb.Strikes = count;
                        message = $"{count} " + (count == 1 ? "strike" : "strikes");
                        break;
                }
            }

            return message;
        }
    }
}