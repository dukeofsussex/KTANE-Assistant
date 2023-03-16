namespace KTANE.Brain
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Reflection;
    using System.Speech.Recognition;
    using System.Speech.Synthesis;
    using KTANE.Game;

    internal class Brain
    {
        private const string DefusalGrammar = "DEFUSAL";
        private const string GlobalGrammar = "GLOBAL";

        private readonly Dictionary<string, SpeechProcessor> processors = new ();

        public Brain()
        {
            this.Speech = new SpeechSynthesizer();
            this.Recognition = new SpeechRecognitionEngine();
            this.Recognition.SetInputToDefaultAudioDevice();

            this.RegisterProcessors();
            this.Toggle(false);
        }

        public SpeechRecognitionEngine Recognition { get; private set; }

        public SpeechSynthesizer Speech { get; private set; }

        public List<string> Voices => this.Speech.GetInstalledVoices()
            .Select(v => v.VoiceInfo.Name)
            .ToList();

        public bool Active { get; private set; }

        public string ProcessInput(RecognitionResult result, Bomb bomb)
        {
            string command = result.Text.ToLowerInvariant();

            string message = this.ProcessGlobal(command, bomb);

            if (message != null)
            {
                return message;
            }

            if (command.StartsWith("defuse"))
            {
                return this.ProcessModule(command, bomb);
            }

            message = this.processors[result.Grammar.Name].Process(command, bomb);

            if (bomb.ActiveModule != null)
            {
                bomb.ActiveModule = null;
            }

            return message;
        }

        public void Toggle(bool state)
        {
            this.Active = state;

            if (state)
            {
                this.Recognition.RecognizeAsync(RecognizeMode.Multiple);
            }
            else
            {
                this.Recognition.RecognizeAsyncCancel();
            }
        }

        public void ResetProcessors()
        {
            foreach (Grammar grammar in this.Recognition.Grammars)
            {
                if (grammar.Enabled
                    && this.processors.TryGetValue(grammar.Name, out SpeechProcessor module)
                    && !module.IsGlobal)
                {
                    grammar.Enabled = false;
                }
            }
        }

        private void RegisterProcessors()
        {
            GrammarBuilder builder = new ("Defuse");
            Choices choices = new ();

            foreach (Type type in Assembly.GetEntryAssembly()
                .GetTypes()
                .Where(t => typeof(SpeechProcessor).IsAssignableFrom(t)
                    && !t.IsInterface
                    && !t.IsAbstract))
            {
                SpeechProcessor module = Activator.CreateInstance(type) as SpeechProcessor;
                string moduleName = module.Name.ToUpperInvariant();

                if (this.processors.Any(m => m.Key == moduleName))
                {
                    throw new DuplicateNameException($"Duplicate grammar name \"{module.Name}\" for \"{type.Name}\"!");
                }

                if (typeof(BombModule).IsAssignableFrom(type))
                {
                    choices.Add(moduleName.ToLowerInvariant());
                }

                this.processors.Add(moduleName, module);
                this.Recognition.LoadGrammarAsync(new Grammar(module.Grammar)
                {
                    Name = moduleName,
                    Enabled = module.IsGlobal,
                });
            }

            builder.Append(choices);

            this.Recognition.LoadGrammarAsync(new Grammar(builder) { Name = DefusalGrammar });
            this.Recognition.LoadGrammarAsync(new Grammar(new Choices(new[] { "cancel", "stop" })) { Name = GlobalGrammar });
        }

        private string ProcessGlobal(string command, Bomb bomb)
        {
            if (command == "stop")
            {
                this.Speech.SpeakAsyncCancelAll();
                return string.Empty;
            }

            if (command == "cancel" && bomb.ActiveModule != null)
            {
                string name = bomb.ActiveModule.Name;
                this.ResetProcessors();
                bomb.ActiveModule = null;
                return $"Cancelled {name.ToLowerInvariant()}.";
            }
            else if (command == "cancel")
            {
                return "No active module.";
            }

            return null;
        }

        private string ProcessModule(string command, Bomb bomb)
        {
            if (!bomb.Ready)
            {
                return "Bomb not set up.";
            }

            string module = command[(command.IndexOf(' ') + 1) ..].ToUpperInvariant();

            if (bomb.ActiveModule != null)
            {
                this.ResetProcessors();
            }

            SpeechProcessor speechModule = this.processors[module];

            if (!speechModule.IsGlobal)
            {
                speechModule = Activator.CreateInstance(this.processors[module].GetType()) as SpeechProcessor;
                this.processors[module] = speechModule;
            }

            bomb.ActiveModule = speechModule as BombModule;
            this.Recognition.Grammars.Where(g => g.Name == module)
                .First()
                .Enabled = true;

            return $"Defusing {module.ToLowerInvariant()}{bomb.ActiveModule.PreInfo}.";
        }
    }
}