using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BitmaskMapper
{
    public partial class Form1 : Form
    {
        private TextBox[] bitTextBoxes;
        private TextBox currentEditingBox;
        private int currentBitCount = 32;
        private bool isUpdating = false;

        public Form1()
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(700, 400);
            SetupUI();
        }

        private void SetupUI()
        {
            UpdateBitTextBoxes(32);
            binaryTextBox.TextChanged += BinaryTextChanged;
            hexTextBox.TextChanged += HexTextChanged;
            decimalTextBox.TextChanged += DecimalTextChanged;
            hexTextBox.KeyDown += TextBox_KeyDown;
            decimalTextBox.KeyDown += TextBox_KeyDown;
            binaryTextBox.Enter += (s, e) => currentEditingBox = binaryTextBox;
            hexTextBox.Enter += (s, e) => currentEditingBox = hexTextBox;
            decimalTextBox.Enter += (s, e) => currentEditingBox = decimalTextBox;
            clearButton.Click += ClearBits_Click;
            bitCountSelector.ValueChanged += BitCountSelector_ValueChanged;
            UpdateValues();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Back)
            {
                e.SuppressKeyPress = true;
                TextBox textBox = sender as TextBox;
                if (textBox == null) return;

                string text = textBox.Text;
                int cursorPos = textBox.SelectionStart;
                int wordStart = cursorPos - 1;
                while (wordStart >= 0 && text[wordStart] != ' ') wordStart--;
                wordStart++;

                if (wordStart < cursorPos)
                {
                    textBox.Text = text.Remove(wordStart, cursorPos - wordStart);
                    textBox.SelectionStart = wordStart;
                }
            }
        }

        private void UpdateBitTextBoxes(int bitCount)
        {
            // Remove existing bit textboxes and their labels
            if (bitTextBoxes != null)
            {
                foreach (var tb in bitTextBoxes)
                {
                    if (tb != null)
                    {
                        tb.TextChanged -= BitTextChanged;
                        tb.Enter -= (s, e) => currentEditingBox = (TextBox)s;
                        this.Controls.Remove(tb);
                        tb.Dispose();
                    }
                }
            }

            // Remove all bit labels (both number labels and bit value boxes)
            var controlsToRemove = this.Controls.OfType<Control>()
                .Where(c => (c is Label && c.Tag?.ToString() == "bitLabel") ||
                           (c is TextBox && c.Tag?.ToString() == "bitBox"))
                .ToList();

            foreach (var control in controlsToRemove)
            {
                this.Controls.Remove(control);
                control.Dispose();
            }

            currentBitCount = bitCount;
            bitTextBoxes = new TextBox[bitCount];
            int bitsPerRow = 16;
            int rows = (int)Math.Ceiling((double)bitCount / bitsPerRow);
            int baseY = 40;
            int rowSpacing = 45;

            for (int row = 0; row < rows; row++)
            {
                int bitsInThisRow = Math.Min(bitsPerRow, bitCount - row * bitsPerRow);
                int yPos = baseY + row * rowSpacing;

                for (int i = 0; i < bitsInThisRow; i++)
                {
                    int bitIndex = row * bitsPerRow + i;
                    int bitNumber = bitCount - 1 - bitIndex;

                    Label lbl = new Label
                    {
                        Text = bitNumber.ToString(),
                        Left = 10 + (i * 30),
                        Top = yPos,
                        Width = 30,
                        Tag = "bitLabel"
                    };

                    bitTextBoxes[bitIndex] = new TextBox
                    {
                        Left = 10 + (i * 30),
                        Top = yPos + 20,
                        Width = 25,
                        Text = "0",
                        MaxLength = 1,
                        Tag = "bitBox"
                    };

                    bitTextBoxes[bitIndex].TextChanged += BitTextChanged;
                    bitTextBoxes[bitIndex].Enter += (s, e) => currentEditingBox = (TextBox)s;

                    this.Controls.Add(lbl);
                    this.Controls.Add(bitTextBoxes[bitIndex]);
                }
            }

            int binaryY = baseY + rows * rowSpacing + 30;
            binaryLabel.Top = binaryY;
            binaryTextBox.Top = binaryY + 20;
            this.ClientSize = new System.Drawing.Size(this.ClientSize.Width, binaryY + 100);
            UpdateValues();
        }

        private void BitCountSelector_ValueChanged(object sender, EventArgs e)
        {
            int newBitCount = (int)bitCountSelector.Value;
            UpdateBitTextBoxes(newBitCount);
        }

        private void BitTextChanged(object sender, EventArgs e)
        {
            currentEditingBox = (TextBox)sender;
            UpdateValues();
        }

        private void BinaryTextChanged(object sender, EventArgs e)
        {
            if (isUpdating) return;
            currentEditingBox = binaryTextBox;
            UpdateFromInput(binaryTextBox.Text, true, false, false);
        }

        private void HexTextChanged(object sender, EventArgs e)
        {
            if (isUpdating) return;
            currentEditingBox = hexTextBox;
            UpdateFromInput(hexTextBox.Text, false, true, false);
        }

        private void DecimalTextChanged(object sender, EventArgs e)
        {
            if (isUpdating) return;
            currentEditingBox = decimalTextBox;
            UpdateFromInput(decimalTextBox.Text, false, false, true);
        }

        private void UpdateFromInput(string input, bool isBinary, bool isHex, bool isDecimal)
        {
            if (isUpdating || bitTextBoxes == null) return;
            isUpdating = true;

            try
            {
                int selectionStart = currentEditingBox.SelectionStart;
                int selectionLength = currentEditingBox.SelectionLength;

                foreach (var tb in bitTextBoxes) tb.TextChanged -= BitTextChanged;

                string binary = "";
                if (isBinary && !string.IsNullOrEmpty(input))
                {
                    input = input.PadLeft(currentBitCount, '0');
                    if (input.Length > currentBitCount) input = input.Substring(input.Length - currentBitCount, currentBitCount);
                    for (int i = 0; i < currentBitCount && i < input.Length; i++)
                    {
                        if (input[i] == '0' || input[i] == '1')
                            bitTextBoxes[i].Text = input[i].ToString();
                    }
                }
                else if (isHex && !string.IsNullOrEmpty(input))
                {
                    input = input.Replace("0x", "").Trim();
                    if (!Regex.IsMatch(input, @"^[0-9A-Fa-f]+$")) return;
                    ulong value = Convert.ToUInt64(input, 16);
                    binary = Convert.ToString((long)value, 2).PadLeft(currentBitCount, '0');
                    if (binary.Length > currentBitCount) binary = binary.Substring(binary.Length - currentBitCount, currentBitCount);
                    for (int i = 0; i < currentBitCount; i++) bitTextBoxes[i].Text = binary[i].ToString();
                }
                else if (isDecimal && !string.IsNullOrEmpty(input))
                {
                    if (!ulong.TryParse(input, out ulong value)) return;
                    binary = Convert.ToString((long)value, 2).PadLeft(currentBitCount, '0');
                    if (binary.Length > currentBitCount) binary = binary.Substring(binary.Length - currentBitCount, currentBitCount);
                    for (int i = 0; i < currentBitCount; i++) bitTextBoxes[i].Text = binary[i].ToString();
                }

                if (binary == "")
                {
                    for (int i = 0; i < currentBitCount; i++) binary += (bitTextBoxes[i]?.Text == "1" ? "1" : "0");
                }

                ulong decimalValue = Convert.ToUInt64(binary, 2);

                if (currentEditingBox != binaryTextBox) binaryTextBox.Text = binary;
                if (currentEditingBox != hexTextBox) hexTextBox.Text = "0x" + decimalValue.ToString("X" + (currentBitCount / 4));
                if (currentEditingBox != decimalTextBox) decimalTextBox.Text = decimalValue.ToString();

                currentEditingBox.SelectionStart = selectionStart;
                currentEditingBox.SelectionLength = selectionLength;
            }
            finally
            {
                foreach (var tb in bitTextBoxes) tb.TextChanged += BitTextChanged;
                isUpdating = false;
            }
        }

        private void UpdateValues()
        {
            if (isUpdating || bitTextBoxes == null) return;
            isUpdating = true;

            try
            {
                int selectionStart = currentEditingBox?.SelectionStart ?? 0;
                int selectionLength = currentEditingBox?.SelectionLength ?? 0;

                foreach (var tb in bitTextBoxes) tb.TextChanged -= BitTextChanged;

                string binary = "";
                for (int i = 0; i < currentBitCount; i++) binary += (bitTextBoxes[i]?.Text == "1" ? "1" : "0");

                ulong decimalValue = Convert.ToUInt64(binary, 2);

                if (currentEditingBox != binaryTextBox) binaryTextBox.Text = binary;
                if (currentEditingBox != hexTextBox) hexTextBox.Text = "0x" + decimalValue.ToString("X" + (currentBitCount / 4));
                if (currentEditingBox != decimalTextBox) decimalTextBox.Text = decimalValue.ToString();

                if (currentEditingBox != null)
                {
                    currentEditingBox.SelectionStart = selectionStart;
                    currentEditingBox.SelectionLength = selectionLength;
                }
            }
            finally
            {
                foreach (var tb in bitTextBoxes) tb.TextChanged += BitTextChanged;
                isUpdating = false;
            }
        }

        private void ClearBits_Click(object sender, EventArgs e)
        {
            if (bitTextBoxes == null) return;
            foreach (var tb in bitTextBoxes) if (tb != null) tb.Text = "0";
            UpdateValues();
        }
    }
}