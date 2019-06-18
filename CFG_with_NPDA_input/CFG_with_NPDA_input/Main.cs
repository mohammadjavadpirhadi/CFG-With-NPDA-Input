using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CFG_with_NPDA_input
{
    public partial class Main : Form
    {
        public Main()
        {
            Icon icon = Icon.ExtractAssociatedIcon(@"Logo.ico");
            this.Icon = icon;
            InitializeComponent();
        }

        NPDA NPDA;
        CFG CFG;
        private void Main_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void NFALabel_Click(object sender, EventArgs e)
        {

        }

        private void CFGLabel_Click(object sender, EventArgs e)
        {

        }

        private void LoadNPDA_Click(object sender, EventArgs e)
        {
            NPDA = null;
            try
            {
                NPDA = new NPDA(NPDAPath.Text);
                MessageBox.Show("Your Input Text Parsed and NPDA Generated Successfully", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerateCFG_Click(object sender, EventArgs e)
        {
            try
            {
                if (NPDA != null)
                {
                    CFG = new CFG(NPDA);
                    CFG.ToTextFile(CFGPath.Text);
                    DialogResult result = MessageBox.Show("NPDA Parsed and CFG Generated Successfully\nDo You Want To Open It?", "Success!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                        Process.Start(CFGPath.Text);
                }
                else
                    MessageBox.Show("You Need to Load NPDA First", "Stop!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindDerivation_Click(object sender, EventArgs e)
        {
            try
            {
                if (CFG != null)
                {
                    bool hasWord = CFG.HasWord(word.Text, out string derivation);
                    if (hasWord)
                    {
                        StreamWriter writer = new StreamWriter(DerivationPath.Text);
                        writer.WriteLine(derivation);
                        writer.Close();
                        DialogResult result = MessageBox.Show("Derivation Found Successfully\nDo You Want To Open It?", "Success!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                            Process.Start(DerivationPath.Text);
                    }
                    MessageBox.Show("No Derivation Found!", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("You Need to Generate CFG First", "Stop!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
