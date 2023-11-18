using System.Drawing.Printing;

namespace _18_11_23 {
    public partial class Form1 : Form {
        bool isChanged = false;
        PrintDocument doc = new PrintDocument();

        public Form1 () {
            InitializeComponent();
        }

        private void âûáîğØğèôòàToolStripMenuItem_Click (object sender, EventArgs e) {
            var result = fontDialog1.ShowDialog();
            if (result == DialogResult.OK) {
                textBox1.Font = fontDialog1.Font;
            }
        }

        private void âûáîğÖâåòàToolStripMenuItem_Click (object sender, EventArgs e) {
            var result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK) {
                textBox1.ForeColor = colorDialog1.Color;
            }
        }

        private void âûáîğÖâåòàÔîíàToolStripMenuItem_Click (object sender, EventArgs e) {
            var result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK) {
                textBox1.BackColor = colorDialog1.Color;
            }
        }

        private void îòìåíèòüToolStripMenuItem_Click (object sender, EventArgs e) {
            textBox1.Undo();
        }

        private void êîïèğîâàòüToolStripMenuItem_Click (object sender, EventArgs e) {
            textBox1.Copy();
        }

        private void âñòàâèòüToolStripMenuItem_Click (object sender, EventArgs e) {
            textBox1.Paste();
        }

        private void âûğåçàòüToolStripMenuItem_Click (object sender, EventArgs e) {
            textBox1.Cut();
        }

        private void âûäåëèòüÂñåToolStripMenuItem_Click (object sender, EventArgs e) {
            textBox1.SelectAll();
        }

        private void îòêğûòüToolStripMenuItem_Click (object sender, EventArgs e) {
            openFileDialog1.Filter = "Text_files (*.txt)|*.txt";
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) {
                textBox1.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void ñîõğàíèòüToolStripMenuItem_Click (object sender, EventArgs e) {
            SaveFile();
        }

        void SaveFile () {
            saveFileDialog1.Filter = "Text_files (*.txt)|*.txt";
            var result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK) {
                File.WriteAllText(saveFileDialog1.FileName, textBox1.Text);
            }
        }

        private void âûõîäToolStripMenuItem_Click (object sender, EventArgs e) {
            Close();
        }

        private void textBox1_TextChanged (object sender, EventArgs e) {
            isChanged = true;
        }

        private void Form1_FormClosing (object sender, FormClosingEventArgs e) {
            e.Cancel = SaveIsChanged();
        }

        private void ïå÷àòüToolStripMenuItem_Click (object sender, EventArgs e) {
            var result = printDialog1.ShowDialog();
            if (result == DialogResult.Yes) {
                doc.Print();
            }
        }

        bool SaveIsChanged () {
            if (isChanged) {
                var result = MessageBox.Show("Òåêñò íå ñîõğàíåí. Ñîõğàíèòü?", "Âûõîä",
                    MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes) {
                    SaveFile();
                    isChanged = false;
                } else if (result == DialogResult.Cancel) {
                    return true;

                }
            }
            return false;
        }

        private void ñîçäàòüToolStripMenuItem_Click (object sender, EventArgs e) {
            if (SaveIsChanged()) {
                return;
            }
            textBox1.Clear();
        }
    }
}