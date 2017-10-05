namespace PS4Macro.MarvelHeroesOmega
{
    partial class AttackSequenceForm
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.delayLabel = new System.Windows.Forms.Label();
            this.delayNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Buttons = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delayNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Index,
            this.Buttons});
            this.dataGridView.Location = new System.Drawing.Point(12, 13);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(207, 149);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_CellFormatting);
            // 
            // delayLabel
            // 
            this.delayLabel.AutoSize = true;
            this.delayLabel.Location = new System.Drawing.Point(22, 186);
            this.delayLabel.Name = "delayLabel";
            this.delayLabel.Size = new System.Drawing.Size(59, 13);
            this.delayLabel.TabIndex = 1;
            this.delayLabel.Text = "Delay (ms):";
            // 
            // delayNumericUpDown
            // 
            this.delayNumericUpDown.Location = new System.Drawing.Point(87, 184);
            this.delayNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.delayNumericUpDown.Name = "delayNumericUpDown";
            this.delayNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.delayNumericUpDown.TabIndex = 2;
            this.delayNumericUpDown.ValueChanged += new System.EventHandler(this.delayNumericUpDown_ValueChanged);
            // 
            // Index
            // 
            this.Index.FillWeight = 40F;
            this.Index.HeaderText = "#";
            this.Index.Name = "Index";
            this.Index.ReadOnly = true;
            this.Index.Width = 40;
            // 
            // Buttons
            // 
            this.Buttons.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Buttons.DataPropertyName = "Name";
            this.Buttons.HeaderText = "Buttons";
            this.Buttons.Items.AddRange(new object[] {
            "Triangle",
            "Circle",
            "Cross",
            "Square",
            "L2 + Triangle",
            "L2 + Circle",
            "L2 + Cross",
            "L2 + Square"});
            this.Buttons.Name = "Buttons";
            // 
            // AttackSequenceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 221);
            this.Controls.Add(this.delayNumericUpDown);
            this.Controls.Add(this.delayLabel);
            this.Controls.Add(this.dataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AttackSequenceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Attack Sequence";
            this.Load += new System.EventHandler(this.AttackSequenceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delayNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label delayLabel;
        private System.Windows.Forms.NumericUpDown delayNumericUpDown;
        private System.Windows.Forms.DataGridViewTextBoxColumn Index;
        private System.Windows.Forms.DataGridViewComboBoxColumn Buttons;
    }
}