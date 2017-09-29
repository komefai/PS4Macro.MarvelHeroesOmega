namespace PS4Macro.MarvelHeroesOmega
{
    partial class DebugLootForm
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
            this.imageAPictureBox = new System.Windows.Forms.PictureBox();
            this.compareButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.minHeightTextBox = new System.Windows.Forms.TextBox();
            this.minWidthTextBox = new System.Windows.Forms.TextBox();
            this.imageBGroupBox = new System.Windows.Forms.GroupBox();
            this.imageBPictureBox = new System.Windows.Forms.PictureBox();
            this.imageAGroupBox = new System.Windows.Forms.GroupBox();
            this.bottomPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.imageAPictureBox)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            this.imageBGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBPictureBox)).BeginInit();
            this.imageAGroupBox.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageAPictureBox
            // 
            this.imageAPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageAPictureBox.Location = new System.Drawing.Point(10, 23);
            this.imageAPictureBox.Name = "imageAPictureBox";
            this.imageAPictureBox.Size = new System.Drawing.Size(478, 380);
            this.imageAPictureBox.TabIndex = 1;
            this.imageAPictureBox.TabStop = false;
            // 
            // compareButton
            // 
            this.compareButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.compareButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.compareButton.ForeColor = System.Drawing.Color.MidnightBlue;
            this.compareButton.Location = new System.Drawing.Point(10, 5);
            this.compareButton.Name = "compareButton";
            this.compareButton.Size = new System.Drawing.Size(1017, 30);
            this.compareButton.TabIndex = 9;
            this.compareButton.Text = "SIMILARITY";
            this.compareButton.UseVisualStyleBackColor = true;
            this.compareButton.Click += new System.EventHandler(this.compareButton_Click);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.minHeightTextBox, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.minWidthTextBox, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.imageBGroupBox, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.imageAGroupBox, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.87671F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.123288F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1037, 467);
            this.tableLayoutPanel.TabIndex = 20;
            // 
            // minHeightTextBox
            // 
            this.minHeightTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.minHeightTextBox.Location = new System.Drawing.Point(533, 436);
            this.minHeightTextBox.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.minHeightTextBox.Name = "minHeightTextBox";
            this.minHeightTextBox.Size = new System.Drawing.Size(489, 20);
            this.minHeightTextBox.TabIndex = 20;
            this.minHeightTextBox.Text = "4";
            // 
            // minWidthTextBox
            // 
            this.minWidthTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.minWidthTextBox.Location = new System.Drawing.Point(15, 436);
            this.minWidthTextBox.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.minWidthTextBox.Name = "minWidthTextBox";
            this.minWidthTextBox.Size = new System.Drawing.Size(488, 20);
            this.minWidthTextBox.TabIndex = 19;
            this.minWidthTextBox.Text = "4";
            // 
            // imageBGroupBox
            // 
            this.imageBGroupBox.Controls.Add(this.imageBPictureBox);
            this.imageBGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageBGroupBox.ForeColor = System.Drawing.Color.Orange;
            this.imageBGroupBox.Location = new System.Drawing.Point(528, 10);
            this.imageBGroupBox.Margin = new System.Windows.Forms.Padding(10);
            this.imageBGroupBox.Name = "imageBGroupBox";
            this.imageBGroupBox.Padding = new System.Windows.Forms.Padding(10);
            this.imageBGroupBox.Size = new System.Drawing.Size(499, 413);
            this.imageBGroupBox.TabIndex = 18;
            this.imageBGroupBox.TabStop = false;
            this.imageBGroupBox.Text = "Image B";
            // 
            // imageBPictureBox
            // 
            this.imageBPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageBPictureBox.Location = new System.Drawing.Point(10, 23);
            this.imageBPictureBox.Name = "imageBPictureBox";
            this.imageBPictureBox.Size = new System.Drawing.Size(479, 380);
            this.imageBPictureBox.TabIndex = 1;
            this.imageBPictureBox.TabStop = false;
            // 
            // imageAGroupBox
            // 
            this.imageAGroupBox.Controls.Add(this.imageAPictureBox);
            this.imageAGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageAGroupBox.ForeColor = System.Drawing.Color.Orange;
            this.imageAGroupBox.Location = new System.Drawing.Point(10, 10);
            this.imageAGroupBox.Margin = new System.Windows.Forms.Padding(10);
            this.imageAGroupBox.Name = "imageAGroupBox";
            this.imageAGroupBox.Padding = new System.Windows.Forms.Padding(10);
            this.imageAGroupBox.Size = new System.Drawing.Size(498, 413);
            this.imageAGroupBox.TabIndex = 17;
            this.imageAGroupBox.TabStop = false;
            this.imageAGroupBox.Text = "Image A";
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.compareButton);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 467);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.bottomPanel.Size = new System.Drawing.Size(1037, 40);
            this.bottomPanel.TabIndex = 19;
            // 
            // DebugLootForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 507);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.bottomPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "DebugLootForm";
            this.Text = "Debug Loot Form";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.ImageHashForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.ImageHashForm_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.imageAPictureBox)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.imageBGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageBPictureBox)).EndInit();
            this.imageAGroupBox.ResumeLayout(false);
            this.bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imageAPictureBox;
        private System.Windows.Forms.Button compareButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.TextBox minHeightTextBox;
        private System.Windows.Forms.TextBox minWidthTextBox;
        private System.Windows.Forms.GroupBox imageBGroupBox;
        private System.Windows.Forms.PictureBox imageBPictureBox;
        private System.Windows.Forms.GroupBox imageAGroupBox;
        private System.Windows.Forms.Panel bottomPanel;
    }
}