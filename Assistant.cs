namespace KTANE
{
    using System;
    using System.Drawing;
    using System.Speech.Recognition;
    using System.Windows.Forms;
    using KTANE.Game;

    internal partial class Assistant : Form
    {
        private Bomb bomb;
        private Brain.Brain brain;

        public Assistant()
        {
            this.InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            this.bomb = new Bomb();

            this.brain = new Brain.Brain();
            this.brain.Recognition.SpeechRecognized += this.OnSpeechRecognized;

            foreach (string voice in this.brain.Voices)
            {
                _ = this.comboBoxVoices.Items.Add(voice);
            }

            this.comboBoxVoices.SelectedIndex = 0;
            this.checkBoxResetBomb.Checked = true;
            this.OnCheckBoxResetBombChanged(sender, e);
            this.UpdateHelp();
        }

        private void OnSpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            this.brain.Speech.SpeakAsyncCancelAll();
            this.textBoxCommand.Text = e.Result.Text;
            this.textBoxResponse.Text = this.brain.ProcessInput(e.Result, this.bomb);
            _ = this.brain.Speech.SpeakAsync(this.textBoxResponse.Text);
            this.UpdateHelp();
            this.UpdateProperties();
        }

        private void OnButtonListenToggleClick(object sender, EventArgs e)
        {
            if (this.brain.Active)
            {
                this.buttonListenToggle.Text = "START LISTENING";
                this.buttonListenToggle.BackColor = Color.Green;
            }
            else
            {
                this.buttonListenToggle.Text = "STOP LISTENING";
                this.buttonListenToggle.BackColor = Color.DarkRed;
            }

            this.brain.Toggle(!this.brain.Active);
        }

        private void OnButtonRandomBombClick(object sender, EventArgs e)
        {
            this.bomb = Bomb.CreateRandom();
            this.brain.ResetProcessors();
            this.UpdateProperties();
        }

        private void OnButtonResetBombClick(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to reset the bomb? All its properties will be gone, and you will have to initialize them again.",
                "Reset Bomb",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                this.bomb.Reset();
                this.brain.ResetProcessors();
                this.textBoxCommand.Text = string.Empty;
                this.textBoxResponse.Text = string.Empty;
                this.UpdateHelp();
                this.UpdateProperties();
            }
        }

        private void OnCheckBoxResetBombChanged(object sender, EventArgs e)
        {
            this.bomb.AutoReset = this.checkBoxResetBomb.Checked;
        }

        private void OnComboBoxVoicesSelectedIndexChanged(object sender, EventArgs e)
        {
            string voiceName = this.comboBoxVoices.SelectedItem.ToString();

            if (this.brain.Voices.Contains(voiceName))
            {
                this.brain.Speech.SelectVoice(voiceName);
            }
        }

        private void UpdateHelp()
        {
            this.richTextBoxHelp.Text = $"Global: Cancel | Stop | Defuse <module> | {this.bomb.Help}\n";
            this.richTextBoxHelp.Select(0, 7);
            this.richTextBoxHelp.SelectionFont = new Font(this.richTextBoxHelp.Font, FontStyle.Bold);

            if (this.bomb.ActiveModule != null)
            {
                int start = this.richTextBoxHelp.Text.Length;
                this.richTextBoxHelp.AppendText($"{this.bomb.ActiveModule.Name}: {this.bomb.ActiveModule.Help}");
                this.richTextBoxHelp.Select(start, this.bomb.ActiveModule.Name.Length + 1);
                this.richTextBoxHelp.SelectionFont = new Font(this.richTextBoxHelp.Font, FontStyle.Bold);
            }
        }

        private void UpdateProperties()
        {
            this.labelBatteries.Text = $"Batteries: {(this.bomb.Batteries.HasValue ? this.bomb.Batteries : "--")}";
            this.labelCAR.Text = $"CAR: {(this.bomb.HasLitCAR.HasValue ? (this.bomb.HasLitCAR.Value ? "Yes" : "No") : "--")}";
            this.labelFRK.Text = $"FRK: {(this.bomb.HasLitFRK.HasValue ? (this.bomb.HasLitFRK.Value ? "Yes" : "No") : "--")}";
            this.labelPort.Text = $"Port: {(this.bomb.HasParallelPort.HasValue ? (this.bomb.HasParallelPort.Value ? "Yes" : "No") : "--")}";
            this.labelVowel.Text = $"Vowel: {(this.bomb.HasVowel.HasValue ? (this.bomb.HasVowel.Value ? "Yes" : "No") : "--")}";
            this.labelDigit.Text = $"Digit: {(this.bomb.LastDigitEven.HasValue ? (this.bomb.LastDigitEven.Value ? "Even" : "Odd") : "--")}";
            this.labelStrikes.Text = $"Strikes: {this.bomb.Strikes}";
        }
    }
}
