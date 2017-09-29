namespace PS4Macro.MarvelHeroesOmega
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.healthLabel = new System.Windows.Forms.Label();
            this.useMedKitLabel = new System.Windows.Forms.Label();
            this.useMedKitNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.spiritLabel = new System.Windows.Forms.Label();
            this.settingsGroupBox = new System.Windows.Forms.GroupBox();
            this.attackComboBox = new System.Windows.Forms.ComboBox();
            this.attackLabel = new System.Windows.Forms.Label();
            this.dashComboBox = new System.Windows.Forms.ComboBox();
            this.dashLabel = new System.Windows.Forms.Label();
            this.debugGroupBox = new System.Windows.Forms.GroupBox();
            this.lootDebugButton = new System.Windows.Forms.Button();
            this.enemyInfoSplitterLabel = new System.Windows.Forms.Label();
            this.enemyHealthLabel = new System.Windows.Forms.Label();
            this.enemyLabel = new System.Windows.Forms.Label();
            this.macrosGroupBox = new System.Windows.Forms.GroupBox();
            this.startupMacroButton = new System.Windows.Forms.Button();
            this.startupMacroLabel = new System.Windows.Forms.Label();
            this.prepareCombatMacroLabel = new System.Windows.Forms.Label();
            this.prepareCombatMacroButton = new System.Windows.Forms.Button();
            this.currentSceneLabel = new System.Windows.Forms.Label();
            this.playerAxisDisplay = new PS4Macro.MarvelHeroesOmega.AxisDisplay();
            this.enemyHealthProgressBar = new PS4Macro.MarvelHeroesOmega.ColorProgressBar();
            this.healthProgressBar = new PS4Macro.MarvelHeroesOmega.ColorProgressBar();
            this.spiritProgressBar = new PS4Macro.MarvelHeroesOmega.ColorProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.useMedKitNumericUpDown)).BeginInit();
            this.settingsGroupBox.SuspendLayout();
            this.debugGroupBox.SuspendLayout();
            this.macrosGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // healthLabel
            // 
            this.healthLabel.AutoSize = true;
            this.healthLabel.Location = new System.Drawing.Point(13, 40);
            this.healthLabel.Name = "healthLabel";
            this.healthLabel.Size = new System.Drawing.Size(61, 13);
            this.healthLabel.TabIndex = 0;
            this.healthLabel.Text = "Health (0%)";
            // 
            // useMedKitLabel
            // 
            this.useMedKitLabel.AutoSize = true;
            this.useMedKitLabel.Location = new System.Drawing.Point(6, 25);
            this.useMedKitLabel.Name = "useMedKitLabel";
            this.useMedKitLabel.Size = new System.Drawing.Size(122, 13);
            this.useMedKitLabel.TabIndex = 2;
            this.useMedKitLabel.Text = "Med Kit when health <= ";
            // 
            // useMedKitNumericUpDown
            // 
            this.useMedKitNumericUpDown.Location = new System.Drawing.Point(128, 22);
            this.useMedKitNumericUpDown.Name = "useMedKitNumericUpDown";
            this.useMedKitNumericUpDown.Size = new System.Drawing.Size(42, 20);
            this.useMedKitNumericUpDown.TabIndex = 3;
            this.useMedKitNumericUpDown.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // spiritLabel
            // 
            this.spiritLabel.AutoSize = true;
            this.spiritLabel.Location = new System.Drawing.Point(13, 13);
            this.spiritLabel.Name = "spiritLabel";
            this.spiritLabel.Size = new System.Drawing.Size(53, 13);
            this.spiritLabel.TabIndex = 4;
            this.spiritLabel.Text = "Spirit (0%)";
            // 
            // settingsGroupBox
            // 
            this.settingsGroupBox.Controls.Add(this.attackComboBox);
            this.settingsGroupBox.Controls.Add(this.attackLabel);
            this.settingsGroupBox.Controls.Add(this.dashComboBox);
            this.settingsGroupBox.Controls.Add(this.dashLabel);
            this.settingsGroupBox.Controls.Add(this.useMedKitLabel);
            this.settingsGroupBox.Controls.Add(this.useMedKitNumericUpDown);
            this.settingsGroupBox.Location = new System.Drawing.Point(12, 66);
            this.settingsGroupBox.Name = "settingsGroupBox";
            this.settingsGroupBox.Size = new System.Drawing.Size(349, 124);
            this.settingsGroupBox.TabIndex = 6;
            this.settingsGroupBox.TabStop = false;
            this.settingsGroupBox.Text = "Settings";
            // 
            // attackComboBox
            // 
            this.attackComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.attackComboBox.FormattingEnabled = true;
            this.attackComboBox.Location = new System.Drawing.Point(235, 89);
            this.attackComboBox.Name = "attackComboBox";
            this.attackComboBox.Size = new System.Drawing.Size(101, 21);
            this.attackComboBox.TabIndex = 7;
            // 
            // attackLabel
            // 
            this.attackLabel.Location = new System.Drawing.Point(181, 93);
            this.attackLabel.Name = "attackLabel";
            this.attackLabel.Size = new System.Drawing.Size(46, 13);
            this.attackLabel.TabIndex = 6;
            this.attackLabel.Text = "Attack";
            this.attackLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dashComboBox
            // 
            this.dashComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dashComboBox.FormattingEnabled = true;
            this.dashComboBox.Location = new System.Drawing.Point(235, 62);
            this.dashComboBox.Name = "dashComboBox";
            this.dashComboBox.Size = new System.Drawing.Size(101, 21);
            this.dashComboBox.TabIndex = 5;
            // 
            // dashLabel
            // 
            this.dashLabel.Location = new System.Drawing.Point(181, 66);
            this.dashLabel.Name = "dashLabel";
            this.dashLabel.Size = new System.Drawing.Size(46, 13);
            this.dashLabel.TabIndex = 4;
            this.dashLabel.Text = "Dash";
            this.dashLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // debugGroupBox
            // 
            this.debugGroupBox.Controls.Add(this.currentSceneLabel);
            this.debugGroupBox.Controls.Add(this.lootDebugButton);
            this.debugGroupBox.Controls.Add(this.playerAxisDisplay);
            this.debugGroupBox.Controls.Add(this.enemyInfoSplitterLabel);
            this.debugGroupBox.Controls.Add(this.enemyHealthLabel);
            this.debugGroupBox.Controls.Add(this.enemyLabel);
            this.debugGroupBox.Controls.Add(this.enemyHealthProgressBar);
            this.debugGroupBox.Location = new System.Drawing.Point(12, 290);
            this.debugGroupBox.Name = "debugGroupBox";
            this.debugGroupBox.Size = new System.Drawing.Size(349, 87);
            this.debugGroupBox.TabIndex = 7;
            this.debugGroupBox.TabStop = false;
            this.debugGroupBox.Text = "Debug";
            // 
            // lootDebugButton
            // 
            this.lootDebugButton.Location = new System.Drawing.Point(143, 16);
            this.lootDebugButton.Name = "lootDebugButton";
            this.lootDebugButton.Size = new System.Drawing.Size(75, 23);
            this.lootDebugButton.TabIndex = 5;
            this.lootDebugButton.Text = "Loot Debug";
            this.lootDebugButton.UseVisualStyleBackColor = true;
            this.lootDebugButton.Click += new System.EventHandler(this.lootDebugButton_Click);
            // 
            // enemyInfoSplitterLabel
            // 
            this.enemyInfoSplitterLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.enemyInfoSplitterLabel.Location = new System.Drawing.Point(224, 16);
            this.enemyInfoSplitterLabel.Name = "enemyInfoSplitterLabel";
            this.enemyInfoSplitterLabel.Size = new System.Drawing.Size(3, 60);
            this.enemyInfoSplitterLabel.TabIndex = 3;
            // 
            // enemyHealthLabel
            // 
            this.enemyHealthLabel.AutoSize = true;
            this.enemyHealthLabel.Location = new System.Drawing.Point(235, 37);
            this.enemyHealthLabel.Name = "enemyHealthLabel";
            this.enemyHealthLabel.Size = new System.Drawing.Size(61, 13);
            this.enemyHealthLabel.TabIndex = 2;
            this.enemyHealthLabel.Text = "Health (0%)";
            // 
            // enemyLabel
            // 
            this.enemyLabel.AutoSize = true;
            this.enemyLabel.Location = new System.Drawing.Point(235, 16);
            this.enemyLabel.Name = "enemyLabel";
            this.enemyLabel.Size = new System.Drawing.Size(45, 13);
            this.enemyLabel.TabIndex = 1;
            this.enemyLabel.Text = "ENEMY";
            // 
            // macrosGroupBox
            // 
            this.macrosGroupBox.Controls.Add(this.prepareCombatMacroButton);
            this.macrosGroupBox.Controls.Add(this.prepareCombatMacroLabel);
            this.macrosGroupBox.Controls.Add(this.startupMacroButton);
            this.macrosGroupBox.Controls.Add(this.startupMacroLabel);
            this.macrosGroupBox.Location = new System.Drawing.Point(12, 196);
            this.macrosGroupBox.Name = "macrosGroupBox";
            this.macrosGroupBox.Size = new System.Drawing.Size(349, 88);
            this.macrosGroupBox.TabIndex = 8;
            this.macrosGroupBox.TabStop = false;
            this.macrosGroupBox.Text = "Macros";
            // 
            // startupMacroButton
            // 
            this.startupMacroButton.Location = new System.Drawing.Point(53, 20);
            this.startupMacroButton.Name = "startupMacroButton";
            this.startupMacroButton.Size = new System.Drawing.Size(63, 23);
            this.startupMacroButton.TabIndex = 1;
            this.startupMacroButton.Tag = "Startup";
            this.startupMacroButton.Text = "NOT SET";
            this.startupMacroButton.UseVisualStyleBackColor = true;
            this.startupMacroButton.Click += new System.EventHandler(this.macroButton_Click);
            // 
            // startupMacroLabel
            // 
            this.startupMacroLabel.AutoSize = true;
            this.startupMacroLabel.Location = new System.Drawing.Point(6, 25);
            this.startupMacroLabel.Name = "startupMacroLabel";
            this.startupMacroLabel.Size = new System.Drawing.Size(41, 13);
            this.startupMacroLabel.TabIndex = 0;
            this.startupMacroLabel.Text = "Startup";
            // 
            // prepareCombatMacroLabel
            // 
            this.prepareCombatMacroLabel.AutoSize = true;
            this.prepareCombatMacroLabel.Location = new System.Drawing.Point(6, 56);
            this.prepareCombatMacroLabel.Name = "prepareCombatMacroLabel";
            this.prepareCombatMacroLabel.Size = new System.Drawing.Size(83, 13);
            this.prepareCombatMacroLabel.TabIndex = 2;
            this.prepareCombatMacroLabel.Text = "Prepare Combat";
            // 
            // prepareCombatMacroButton
            // 
            this.prepareCombatMacroButton.Location = new System.Drawing.Point(95, 51);
            this.prepareCombatMacroButton.Name = "prepareCombatMacroButton";
            this.prepareCombatMacroButton.Size = new System.Drawing.Size(63, 23);
            this.prepareCombatMacroButton.TabIndex = 3;
            this.prepareCombatMacroButton.Tag = "PrepareCombat";
            this.prepareCombatMacroButton.Text = "NOT SET";
            this.prepareCombatMacroButton.UseVisualStyleBackColor = true;
            this.prepareCombatMacroButton.Click += new System.EventHandler(this.macroButton_Click);
            // 
            // currentSceneLabel
            // 
            this.currentSceneLabel.AutoSize = true;
            this.currentSceneLabel.Location = new System.Drawing.Point(59, 58);
            this.currentSceneLabel.Name = "currentSceneLabel";
            this.currentSceneLabel.Size = new System.Drawing.Size(47, 13);
            this.currentSceneLabel.TabIndex = 6;
            this.currentSceneLabel.Text = "Scene: -";
            // 
            // playerAxisDisplay
            // 
            this.playerAxisDisplay.InnerColor = System.Drawing.Color.GhostWhite;
            this.playerAxisDisplay.InnerSize = 12;
            this.playerAxisDisplay.Location = new System.Drawing.Point(9, 32);
            this.playerAxisDisplay.Name = "playerAxisDisplay";
            this.playerAxisDisplay.OuterColor = System.Drawing.Color.DodgerBlue;
            this.playerAxisDisplay.Size = new System.Drawing.Size(44, 44);
            this.playerAxisDisplay.TabIndex = 4;
            this.playerAxisDisplay.Value = ((System.Drawing.PointF)(resources.GetObject("playerAxisDisplay.Value")));
            // 
            // enemyHealthProgressBar
            // 
            this.enemyHealthProgressBar.FillColor = System.Drawing.Color.Red;
            this.enemyHealthProgressBar.Location = new System.Drawing.Point(238, 53);
            this.enemyHealthProgressBar.Name = "enemyHealthProgressBar";
            this.enemyHealthProgressBar.Size = new System.Drawing.Size(100, 23);
            this.enemyHealthProgressBar.TabIndex = 0;
            // 
            // healthProgressBar
            // 
            this.healthProgressBar.FillColor = System.Drawing.Color.Red;
            this.healthProgressBar.Location = new System.Drawing.Point(91, 35);
            this.healthProgressBar.Name = "healthProgressBar";
            this.healthProgressBar.Size = new System.Drawing.Size(270, 23);
            this.healthProgressBar.TabIndex = 1;
            // 
            // spiritProgressBar
            // 
            this.spiritProgressBar.FillColor = System.Drawing.SystemColors.HotTrack;
            this.spiritProgressBar.Location = new System.Drawing.Point(91, 8);
            this.spiritProgressBar.Name = "spiritProgressBar";
            this.spiritProgressBar.Size = new System.Drawing.Size(270, 23);
            this.spiritProgressBar.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 389);
            this.Controls.Add(this.macrosGroupBox);
            this.Controls.Add(this.debugGroupBox);
            this.Controls.Add(this.settingsGroupBox);
            this.Controls.Add(this.healthProgressBar);
            this.Controls.Add(this.spiritProgressBar);
            this.Controls.Add(this.spiritLabel);
            this.Controls.Add(this.healthLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "PS4 Macro - Marvel Heroes Omega";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.useMedKitNumericUpDown)).EndInit();
            this.settingsGroupBox.ResumeLayout(false);
            this.settingsGroupBox.PerformLayout();
            this.debugGroupBox.ResumeLayout(false);
            this.debugGroupBox.PerformLayout();
            this.macrosGroupBox.ResumeLayout(false);
            this.macrosGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label healthLabel;
        private System.Windows.Forms.Label useMedKitLabel;
        private System.Windows.Forms.NumericUpDown useMedKitNumericUpDown;
        private System.Windows.Forms.Label spiritLabel;
        private ColorProgressBar spiritProgressBar;
        private ColorProgressBar healthProgressBar;
        private System.Windows.Forms.GroupBox settingsGroupBox;
        private System.Windows.Forms.GroupBox debugGroupBox;
        private System.Windows.Forms.Label enemyLabel;
        private ColorProgressBar enemyHealthProgressBar;
        private System.Windows.Forms.Label enemyHealthLabel;
        private System.Windows.Forms.Label enemyInfoSplitterLabel;
        private AxisDisplay playerAxisDisplay;
        private System.Windows.Forms.ComboBox attackComboBox;
        private System.Windows.Forms.Label attackLabel;
        private System.Windows.Forms.ComboBox dashComboBox;
        private System.Windows.Forms.Label dashLabel;
        private System.Windows.Forms.Button lootDebugButton;
        private System.Windows.Forms.GroupBox macrosGroupBox;
        private System.Windows.Forms.Button startupMacroButton;
        private System.Windows.Forms.Label startupMacroLabel;
        private System.Windows.Forms.Button prepareCombatMacroButton;
        private System.Windows.Forms.Label prepareCombatMacroLabel;
        private System.Windows.Forms.Label currentSceneLabel;
    }
}