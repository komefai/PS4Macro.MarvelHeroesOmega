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
            this.healthLabel = new System.Windows.Forms.Label();
            this.healthProgressBar = new System.Windows.Forms.ProgressBar();
            this.useMedKitLabel = new System.Windows.Forms.Label();
            this.useMedKitNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.spiritProgressBar = new System.Windows.Forms.ProgressBar();
            this.spiritLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.useMedKitNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // healthLabel
            // 
            this.healthLabel.AutoSize = true;
            this.healthLabel.Location = new System.Drawing.Point(13, 45);
            this.healthLabel.Name = "healthLabel";
            this.healthLabel.Size = new System.Drawing.Size(61, 13);
            this.healthLabel.TabIndex = 0;
            this.healthLabel.Text = "Health (0%)";
            // 
            // healthProgressBar
            // 
            this.healthProgressBar.Location = new System.Drawing.Point(91, 40);
            this.healthProgressBar.Name = "healthProgressBar";
            this.healthProgressBar.Size = new System.Drawing.Size(270, 23);
            this.healthProgressBar.TabIndex = 1;
            // 
            // useMedKitLabel
            // 
            this.useMedKitLabel.AutoSize = true;
            this.useMedKitLabel.Location = new System.Drawing.Point(88, 81);
            this.useMedKitLabel.Name = "useMedKitLabel";
            this.useMedKitLabel.Size = new System.Drawing.Size(144, 13);
            this.useMedKitLabel.TabIndex = 2;
            this.useMedKitLabel.Text = "Use Med Kit when health <= ";
            // 
            // useMedKitNumericUpDown
            // 
            this.useMedKitNumericUpDown.Location = new System.Drawing.Point(235, 78);
            this.useMedKitNumericUpDown.Name = "useMedKitNumericUpDown";
            this.useMedKitNumericUpDown.Size = new System.Drawing.Size(42, 20);
            this.useMedKitNumericUpDown.TabIndex = 3;
            this.useMedKitNumericUpDown.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // spiritProgressBar
            // 
            this.spiritProgressBar.Location = new System.Drawing.Point(91, 8);
            this.spiritProgressBar.Name = "spiritProgressBar";
            this.spiritProgressBar.Size = new System.Drawing.Size(270, 23);
            this.spiritProgressBar.TabIndex = 5;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 136);
            this.Controls.Add(this.spiritProgressBar);
            this.Controls.Add(this.spiritLabel);
            this.Controls.Add(this.useMedKitNumericUpDown);
            this.Controls.Add(this.useMedKitLabel);
            this.Controls.Add(this.healthProgressBar);
            this.Controls.Add(this.healthLabel);
            this.Name = "MainForm";
            this.Text = "PS4 Macro - Marvel Heroes Omega";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.useMedKitNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label healthLabel;
        private System.Windows.Forms.ProgressBar healthProgressBar;
        private System.Windows.Forms.Label useMedKitLabel;
        private System.Windows.Forms.NumericUpDown useMedKitNumericUpDown;
        private System.Windows.Forms.ProgressBar spiritProgressBar;
        private System.Windows.Forms.Label spiritLabel;
    }
}