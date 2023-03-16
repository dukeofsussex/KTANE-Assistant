
namespace KTANE
{
    using System.Windows.Forms;

    partial class Assistant
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Assistant));
            this.textBoxCommand = new TextBox();
            this.labelCommand = new Label();
            this.labelResponse = new Label();
            this.textBoxResponse = new TextBox();
            this.flowLayoutPanelSideUpper = new FlowLayoutPanel();
            this.groupBoxBombState = new GroupBox();
            this.labelStrikes = new Label();
            this.labelBatteries = new Label();
            this.labelDigit = new Label();
            this.labelFRK = new Label();
            this.labelVowel = new Label();
            this.labelCAR = new Label();
            this.labelPort = new Label();
            this.groupBoxSettings = new GroupBox();
            this.labelVoice = new Label();
            this.comboBoxVoices = new ComboBox();
            this.checkBoxResetBomb = new CheckBox();
            this.panelMain = new Panel();
            this.richTextBoxHelp = new RichTextBox();
            this.flowLayoutPanelSideLower = new FlowLayoutPanel();
            this.buttonListenToggle = new Button();
            this.flowLayoutPanelButtons = new FlowLayoutPanel();
            this.buttonResetBomb = new Button();
            this.buttonRandomBomb = new Button();
            this.flowLayoutPanelSideUpper.SuspendLayout();
            this.groupBoxBombState.SuspendLayout();
            this.groupBoxSettings.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.flowLayoutPanelSideLower.SuspendLayout();
            this.flowLayoutPanelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxCommand
            // 
            this.textBoxCommand.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.textBoxCommand.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxCommand.BorderStyle = BorderStyle.FixedSingle;
            this.textBoxCommand.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxCommand.Location = new System.Drawing.Point(0, 134);
            this.textBoxCommand.Margin = new Padding(4, 3, 4, 3);
            this.textBoxCommand.Name = "textBoxCommand";
            this.textBoxCommand.ReadOnly = true;
            this.textBoxCommand.Size = new System.Drawing.Size(517, 25);
            this.textBoxCommand.TabIndex = 2;
            // 
            // labelCommand
            // 
            this.labelCommand.AutoSize = true;
            this.labelCommand.CausesValidation = false;
            this.labelCommand.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelCommand.Location = new System.Drawing.Point(3, 113);
            this.labelCommand.Margin = new Padding(4, 0, 4, 0);
            this.labelCommand.Name = "labelCommand";
            this.labelCommand.Size = new System.Drawing.Size(86, 19);
            this.labelCommand.TabIndex = 3;
            this.labelCommand.Text = "COMMAND";
            this.labelCommand.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelResponse
            // 
            this.labelResponse.AutoSize = true;
            this.labelResponse.CausesValidation = false;
            this.labelResponse.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelResponse.Location = new System.Drawing.Point(3, 182);
            this.labelResponse.Margin = new Padding(4, 0, 4, 0);
            this.labelResponse.Name = "labelResponse";
            this.labelResponse.Size = new System.Drawing.Size(79, 19);
            this.labelResponse.TabIndex = 4;
            this.labelResponse.Text = "RESPONSE";
            this.labelResponse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxResponse
            // 
            this.textBoxResponse.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.textBoxResponse.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxResponse.BorderStyle = BorderStyle.FixedSingle;
            this.textBoxResponse.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxResponse.Location = new System.Drawing.Point(0, 203);
            this.textBoxResponse.Margin = new Padding(0);
            this.textBoxResponse.Multiline = true;
            this.textBoxResponse.Name = "textBoxResponse";
            this.textBoxResponse.ReadOnly = true;
            this.textBoxResponse.Size = new System.Drawing.Size(517, 253);
            this.textBoxResponse.TabIndex = 6;
            // 
            // flowLayoutPanelSideUpper
            // 
            this.flowLayoutPanelSideUpper.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            this.flowLayoutPanelSideUpper.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.flowLayoutPanelSideUpper.CausesValidation = false;
            this.flowLayoutPanelSideUpper.Controls.Add(this.groupBoxBombState);
            this.flowLayoutPanelSideUpper.Controls.Add(this.groupBoxSettings);
            this.flowLayoutPanelSideUpper.FlowDirection = FlowDirection.TopDown;
            this.flowLayoutPanelSideUpper.Location = new System.Drawing.Point(538, 15);
            this.flowLayoutPanelSideUpper.Margin = new Padding(15, 0, 0, 0);
            this.flowLayoutPanelSideUpper.Name = "flowLayoutPanelSideUpper";
            this.flowLayoutPanelSideUpper.Size = new System.Drawing.Size(256, 356);
            this.flowLayoutPanelSideUpper.TabIndex = 8;
            // 
            // groupBoxBombState
            // 
            this.groupBoxBombState.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.groupBoxBombState.AutoSize = true;
            this.groupBoxBombState.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.groupBoxBombState.CausesValidation = false;
            this.groupBoxBombState.Controls.Add(this.labelStrikes);
            this.groupBoxBombState.Controls.Add(this.labelBatteries);
            this.groupBoxBombState.Controls.Add(this.labelDigit);
            this.groupBoxBombState.Controls.Add(this.labelFRK);
            this.groupBoxBombState.Controls.Add(this.labelVowel);
            this.groupBoxBombState.Controls.Add(this.labelCAR);
            this.groupBoxBombState.Controls.Add(this.labelPort);
            this.groupBoxBombState.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxBombState.Location = new System.Drawing.Point(0, 0);
            this.groupBoxBombState.Margin = new Padding(0, 0, 0, 5);
            this.groupBoxBombState.Name = "groupBoxBombState";
            this.groupBoxBombState.Padding = new Padding(5);
            this.groupBoxBombState.Size = new System.Drawing.Size(256, 201);
            this.groupBoxBombState.TabIndex = 0;
            this.groupBoxBombState.TabStop = false;
            this.groupBoxBombState.Text = "Bomb State";
            // 
            // labelStrikes
            // 
            this.labelStrikes.AutoSize = true;
            this.labelStrikes.CausesValidation = false;
            this.labelStrikes.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelStrikes.Location = new System.Drawing.Point(9, 163);
            this.labelStrikes.Margin = new Padding(0, 5, 0, 5);
            this.labelStrikes.Name = "labelStrikes";
            this.labelStrikes.Size = new System.Drawing.Size(55, 13);
            this.labelStrikes.TabIndex = 10;
            this.labelStrikes.Text = "Strikes: --";
            this.labelStrikes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelBatteries
            // 
            this.labelBatteries.AutoSize = true;
            this.labelBatteries.CausesValidation = false;
            this.labelBatteries.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelBatteries.Location = new System.Drawing.Point(9, 25);
            this.labelBatteries.Margin = new Padding(0, 5, 0, 5);
            this.labelBatteries.Name = "labelBatteries";
            this.labelBatteries.Size = new System.Drawing.Size(65, 13);
            this.labelBatteries.TabIndex = 4;
            this.labelBatteries.Text = "Batteries: --";
            this.labelBatteries.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDigit
            // 
            this.labelDigit.AutoSize = true;
            this.labelDigit.CausesValidation = false;
            this.labelDigit.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelDigit.Location = new System.Drawing.Point(9, 140);
            this.labelDigit.Margin = new Padding(0, 5, 0, 5);
            this.labelDigit.Name = "labelDigit";
            this.labelDigit.Size = new System.Drawing.Size(46, 13);
            this.labelDigit.TabIndex = 9;
            this.labelDigit.Text = "Digit: --";
            this.labelDigit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelFRK
            // 
            this.labelFRK.AutoSize = true;
            this.labelFRK.CausesValidation = false;
            this.labelFRK.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelFRK.Location = new System.Drawing.Point(9, 71);
            this.labelFRK.Margin = new Padding(0, 5, 0, 5);
            this.labelFRK.Name = "labelFRK";
            this.labelFRK.Size = new System.Drawing.Size(40, 13);
            this.labelFRK.TabIndex = 5;
            this.labelFRK.Text = "FRK: --";
            this.labelFRK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelVowel
            // 
            this.labelVowel.AutoSize = true;
            this.labelVowel.CausesValidation = false;
            this.labelVowel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelVowel.Location = new System.Drawing.Point(9, 117);
            this.labelVowel.Margin = new Padding(0, 5, 0, 5);
            this.labelVowel.Name = "labelVowel";
            this.labelVowel.Size = new System.Drawing.Size(52, 13);
            this.labelVowel.TabIndex = 7;
            this.labelVowel.Text = "Vowel: --";
            this.labelVowel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCAR
            // 
            this.labelCAR.AutoSize = true;
            this.labelCAR.CausesValidation = false;
            this.labelCAR.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCAR.Location = new System.Drawing.Point(9, 48);
            this.labelCAR.Margin = new Padding(0, 5, 0, 5);
            this.labelCAR.Name = "labelCAR";
            this.labelCAR.Size = new System.Drawing.Size(42, 13);
            this.labelCAR.TabIndex = 6;
            this.labelCAR.Text = "CAR: --";
            this.labelCAR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.CausesValidation = false;
            this.labelPort.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPort.Location = new System.Drawing.Point(9, 94);
            this.labelPort.Margin = new Padding(0, 5, 0, 5);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(42, 13);
            this.labelPort.TabIndex = 8;
            this.labelPort.Text = "Port: --";
            this.labelPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Anchor = AnchorStyles.Bottom;
            this.groupBoxSettings.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.groupBoxSettings.CausesValidation = false;
            this.groupBoxSettings.Controls.Add(this.labelVoice);
            this.groupBoxSettings.Controls.Add(this.comboBoxVoices);
            this.groupBoxSettings.Controls.Add(this.checkBoxResetBomb);
            this.groupBoxSettings.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxSettings.Location = new System.Drawing.Point(0, 211);
            this.groupBoxSettings.Margin = new Padding(0, 5, 0, 5);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Padding = new Padding(5);
            this.groupBoxSettings.Size = new System.Drawing.Size(256, 116);
            this.groupBoxSettings.TabIndex = 1;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Settings";
            // 
            // labelVoice
            // 
            this.labelVoice.AutoSize = true;
            this.labelVoice.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelVoice.Location = new System.Drawing.Point(7, 56);
            this.labelVoice.Margin = new Padding(4, 0, 4, 0);
            this.labelVoice.Name = "labelVoice";
            this.labelVoice.Size = new System.Drawing.Size(51, 13);
            this.labelVoice.TabIndex = 9;
            this.labelVoice.Text = "Voice:";
            this.labelVoice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxVoices
            // 
            this.comboBoxVoices.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxVoices.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxVoices.FormattingEnabled = true;
            this.comboBoxVoices.Location = new System.Drawing.Point(7, 72);
            this.comboBoxVoices.Margin = new Padding(4, 3, 4, 3);
            this.comboBoxVoices.Name = "comboBoxVoices";
            this.comboBoxVoices.Size = new System.Drawing.Size(240, 21);
            this.comboBoxVoices.Sorted = true;
            this.comboBoxVoices.TabIndex = 10;
            this.comboBoxVoices.SelectedIndexChanged += this.OnComboBoxVoicesSelectedIndexChanged;
            // 
            // checkBoxResetBomb
            // 
            this.checkBoxResetBomb.AutoSize = true;
            this.checkBoxResetBomb.Checked = true;
            this.checkBoxResetBomb.CheckState = CheckState.Checked;
            this.checkBoxResetBomb.Location = new System.Drawing.Point(9, 25);
            this.checkBoxResetBomb.Margin = new Padding(4, 3, 4, 3);
            this.checkBoxResetBomb.Name = "checkBoxResetBomb";
            this.checkBoxResetBomb.Size = new System.Drawing.Size(217, 17);
            this.checkBoxResetBomb.TabIndex = 12;
            this.checkBoxResetBomb.Text = "Reset Bomb upon Explosion/Defusal";
            this.checkBoxResetBomb.UseVisualStyleBackColor = true;
            this.checkBoxResetBomb.CheckedChanged += this.OnCheckBoxResetBombChanged;
            // 
            // panelMain
            // 
            this.panelMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.panelMain.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panelMain.CausesValidation = false;
            this.panelMain.Controls.Add(this.richTextBoxHelp);
            this.panelMain.Controls.Add(this.labelCommand);
            this.panelMain.Controls.Add(this.textBoxCommand);
            this.panelMain.Controls.Add(this.textBoxResponse);
            this.panelMain.Controls.Add(this.labelResponse);
            this.panelMain.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panelMain.Location = new System.Drawing.Point(15, 15);
            this.panelMain.Margin = new Padding(0, 0, 15, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(517, 456);
            this.panelMain.TabIndex = 12;
            // 
            // richTextBoxHelp
            // 
            this.richTextBoxHelp.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.richTextBoxHelp.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.richTextBoxHelp.BorderStyle = BorderStyle.None;
            this.richTextBoxHelp.CausesValidation = false;
            this.richTextBoxHelp.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.richTextBoxHelp.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxHelp.Margin = new Padding(0);
            this.richTextBoxHelp.Name = "richTextBoxHelp";
            this.richTextBoxHelp.ReadOnly = true;
            this.richTextBoxHelp.Size = new System.Drawing.Size(517, 107);
            this.richTextBoxHelp.TabIndex = 11;
            this.richTextBoxHelp.Text = "HELP";
            // 
            // flowLayoutPanelSideLower
            // 
            this.flowLayoutPanelSideLower.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.flowLayoutPanelSideLower.AutoSize = true;
            this.flowLayoutPanelSideLower.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.flowLayoutPanelSideLower.CausesValidation = false;
            this.flowLayoutPanelSideLower.Controls.Add(this.buttonListenToggle);
            this.flowLayoutPanelSideLower.Controls.Add(this.flowLayoutPanelButtons);
            this.flowLayoutPanelSideLower.FlowDirection = FlowDirection.BottomUp;
            this.flowLayoutPanelSideLower.Location = new System.Drawing.Point(538, 371);
            this.flowLayoutPanelSideLower.Margin = new Padding(15, 0, 0, 0);
            this.flowLayoutPanelSideLower.Name = "flowLayoutPanelSideLower";
            this.flowLayoutPanelSideLower.Size = new System.Drawing.Size(256, 100);
            this.flowLayoutPanelSideLower.TabIndex = 11;
            // 
            // buttonListenToggle
            // 
            this.buttonListenToggle.Anchor = AnchorStyles.Bottom;
            this.buttonListenToggle.AutoSize = true;
            this.buttonListenToggle.BackColor = System.Drawing.Color.Green;
            this.buttonListenToggle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonListenToggle.ForeColor = System.Drawing.Color.White;
            this.buttonListenToggle.Location = new System.Drawing.Point(0, 53);
            this.buttonListenToggle.Margin = new Padding(0, 5, 0, 0);
            this.buttonListenToggle.Name = "buttonListenToggle";
            this.buttonListenToggle.Size = new System.Drawing.Size(256, 47);
            this.buttonListenToggle.TabIndex = 5;
            this.buttonListenToggle.Text = "START LISTENING";
            this.buttonListenToggle.UseVisualStyleBackColor = false;
            this.buttonListenToggle.Click += this.OnButtonListenToggleClick;
            // 
            // flowLayoutPanelButtons
            // 
            this.flowLayoutPanelButtons.Anchor = AnchorStyles.Bottom;
            this.flowLayoutPanelButtons.AutoSize = true;
            this.flowLayoutPanelButtons.Controls.Add(this.buttonResetBomb);
            this.flowLayoutPanelButtons.Controls.Add(this.buttonRandomBomb);
            this.flowLayoutPanelButtons.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.flowLayoutPanelButtons.Location = new System.Drawing.Point(2, 0);
            this.flowLayoutPanelButtons.Margin = new Padding(0, 0, 0, 5);
            this.flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
            this.flowLayoutPanelButtons.Padding = new Padding(5);
            this.flowLayoutPanelButtons.Size = new System.Drawing.Size(251, 43);
            this.flowLayoutPanelButtons.TabIndex = 10;
            // 
            // buttonResetBomb
            // 
            this.buttonResetBomb.AutoSize = true;
            this.buttonResetBomb.BackColor = System.Drawing.Color.Red;
            this.buttonResetBomb.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonResetBomb.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonResetBomb.Location = new System.Drawing.Point(5, 5);
            this.buttonResetBomb.Margin = new Padding(0);
            this.buttonResetBomb.Name = "buttonResetBomb";
            this.buttonResetBomb.Size = new System.Drawing.Size(139, 33);
            this.buttonResetBomb.TabIndex = 1;
            this.buttonResetBomb.Text = "RESET BOMB";
            this.buttonResetBomb.UseVisualStyleBackColor = false;
            this.buttonResetBomb.Click += this.OnButtonResetBombClick;
            // 
            // buttonRandomBomb
            // 
            this.buttonRandomBomb.AutoSize = true;
            this.buttonRandomBomb.BackColor = System.Drawing.Color.White;
            this.buttonRandomBomb.FlatStyle = FlatStyle.System;
            this.buttonRandomBomb.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonRandomBomb.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonRandomBomb.Location = new System.Drawing.Point(144, 5);
            this.buttonRandomBomb.Margin = new Padding(0);
            this.buttonRandomBomb.Name = "buttonRandomBomb";
            this.buttonRandomBomb.Size = new System.Drawing.Size(102, 33);
            this.buttonRandomBomb.TabIndex = 7;
            this.buttonRandomBomb.Text = "Random Bomb";
            this.buttonRandomBomb.UseVisualStyleBackColor = false;
            this.buttonRandomBomb.Click += this.OnButtonRandomBombClick;
            // 
            // Assistant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(809, 486);
            this.Controls.Add(this.flowLayoutPanelSideUpper);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.flowLayoutPanelSideLower);
            this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            this.Margin = new Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(825, 525);
            this.Name = "Assistant";
            this.Padding = new Padding(15);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Keep Talking and Nobody Explodes Defuser";
            this.Load += this.OnLoad;
            this.flowLayoutPanelSideUpper.ResumeLayout(false);
            this.flowLayoutPanelSideUpper.PerformLayout();
            this.groupBoxBombState.ResumeLayout(false);
            this.groupBoxBombState.PerformLayout();
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.flowLayoutPanelSideLower.ResumeLayout(false);
            this.flowLayoutPanelSideLower.PerformLayout();
            this.flowLayoutPanelButtons.ResumeLayout(false);
            this.flowLayoutPanelButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.RichTextBox richTextBoxHelp;

        private System.Windows.Forms.ComboBox comboBoxVoices;

        private System.Windows.Forms.Label labelVoice;

        private System.Windows.Forms.Label labelFRK;
        private System.Windows.Forms.Label labelCAR;
        private System.Windows.Forms.Label labelVowel;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.Label labelDigit;

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSideUpper;
        private System.Windows.Forms.GroupBox groupBoxBombState;
        private System.Windows.Forms.Label labelBatteries;

        private System.Windows.Forms.TextBox textBoxResponse;

        private System.Windows.Forms.Label labelCommand;

        private System.Windows.Forms.Label labelResponse;
        private System.Windows.Forms.TextBox textBoxCommand;

        #endregion
        private GroupBox groupBoxSettings;
        private Panel panelMain;
        private FlowLayoutPanel flowLayoutPanelSideLower;
        private FlowLayoutPanel flowLayoutPanelButtons;
        private Button buttonRandomBomb;
        private Button buttonResetBomb;
        private Button buttonListenToggle;
        internal protected CheckBox checkBoxResetBomb;
        private Label labelStrikes;
    }
}

