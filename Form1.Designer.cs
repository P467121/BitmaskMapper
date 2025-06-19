namespace BitmaskMapper
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.bitCountLabel = new System.Windows.Forms.Label();
            this.bitCountSelector = new System.Windows.Forms.NumericUpDown();
            this.binaryLabel = new System.Windows.Forms.Label();
            this.hexLabel = new System.Windows.Forms.Label();
            this.decimalLabel = new System.Windows.Forms.Label();
            this.binaryTextBox = new System.Windows.Forms.TextBox();
            this.hexTextBox = new System.Windows.Forms.TextBox();
            this.decimalTextBox = new System.Windows.Forms.TextBox();
            this.clearButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bitCountSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // bitCountLabel
            // 
            this.bitCountLabel.AutoSize = true;
            this.bitCountLabel.Location = new System.Drawing.Point(10, 10);
            this.bitCountLabel.Name = "bitCountLabel";
            this.bitCountLabel.Size = new System.Drawing.Size(53, 13);
            this.bitCountLabel.TabIndex = 0;
            this.bitCountLabel.Text = "Bit Count:";
            // 
            // bitCountSelector
            // 
            this.bitCountSelector.Location = new System.Drawing.Point(69, 8);
            this.bitCountSelector.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.bitCountSelector.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.bitCountSelector.Name = "bitCountSelector";
            this.bitCountSelector.Size = new System.Drawing.Size(60, 20);
            this.bitCountSelector.TabIndex = 1;
            this.bitCountSelector.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // binaryLabel
            // 
            this.binaryLabel.AutoSize = true;
            this.binaryLabel.Location = new System.Drawing.Point(10, 200);
            this.binaryLabel.Name = "binaryLabel";
            this.binaryLabel.Size = new System.Drawing.Size(36, 13);
            this.binaryLabel.TabIndex = 2;
            this.binaryLabel.Text = "Binary";
            // 
            // hexLabel
            // 
            this.hexLabel.AutoSize = true;
            this.hexLabel.Location = new System.Drawing.Point(500, 40);
            this.hexLabel.Name = "hexLabel";
            this.hexLabel.Size = new System.Drawing.Size(26, 13);
            this.hexLabel.TabIndex = 3;
            this.hexLabel.Text = "Hex";
            // 
            // decimalLabel
            // 
            this.decimalLabel.AutoSize = true;
            this.decimalLabel.Location = new System.Drawing.Point(500, 90);
            this.decimalLabel.Name = "decimalLabel";
            this.decimalLabel.Size = new System.Drawing.Size(45, 13);
            this.decimalLabel.TabIndex = 4;
            this.decimalLabel.Text = "Decimal";
            // 
            // binaryTextBox
            // 
            this.binaryTextBox.Location = new System.Drawing.Point(10, 220);
            this.binaryTextBox.MaxLength = 64;
            this.binaryTextBox.Name = "binaryTextBox";
            this.binaryTextBox.Size = new System.Drawing.Size(396, 20);
            this.binaryTextBox.TabIndex = 5;
            // 
            // hexTextBox
            // 
            this.hexTextBox.Location = new System.Drawing.Point(500, 60);
            this.hexTextBox.Name = "hexTextBox";
            this.hexTextBox.Size = new System.Drawing.Size(150, 20);
            this.hexTextBox.TabIndex = 6;
            this.hexTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // decimalTextBox
            // 
            this.decimalTextBox.Location = new System.Drawing.Point(500, 110);
            this.decimalTextBox.Name = "decimalTextBox";
            this.decimalTextBox.Size = new System.Drawing.Size(150, 20);
            this.decimalTextBox.TabIndex = 7;
            this.decimalTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(500, 140);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(100, 23);
            this.clearButton.TabIndex = 8;
            this.clearButton.Text = "Clear Bits";
            this.clearButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(700, 247);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.decimalTextBox);
            this.Controls.Add(this.hexTextBox);
            this.Controls.Add(this.binaryTextBox);
            this.Controls.Add(this.decimalLabel);
            this.Controls.Add(this.hexLabel);
            this.Controls.Add(this.binaryLabel);
            this.Controls.Add(this.bitCountSelector);
            this.Controls.Add(this.bitCountLabel);
            this.Name = "Form1";
            this.Text = "Binary Mapper";
            ((System.ComponentModel.ISupportInitialize)(this.bitCountSelector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label bitCountLabel;
        private System.Windows.Forms.NumericUpDown bitCountSelector;
        private System.Windows.Forms.Label binaryLabel;
        private System.Windows.Forms.Label hexLabel;
        private System.Windows.Forms.Label decimalLabel;
        private System.Windows.Forms.TextBox binaryTextBox;
        private System.Windows.Forms.TextBox hexTextBox;
        private System.Windows.Forms.TextBox decimalTextBox;
        private System.Windows.Forms.Button clearButton;
    }
}