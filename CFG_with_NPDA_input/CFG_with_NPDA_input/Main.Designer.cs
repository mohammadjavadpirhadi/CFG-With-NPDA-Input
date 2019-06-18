namespace CFG_with_NPDA_input
{
    partial class Main
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
            this.FindDerivation = new System.Windows.Forms.Button();
            this.GenerateCFG = new System.Windows.Forms.Button();
            this.LoadNPDA = new System.Windows.Forms.Button();
            this.CFGLabel = new System.Windows.Forms.Label();
            this.wordLabel = new System.Windows.Forms.Label();
            this.NPDALabel = new System.Windows.Forms.Label();
            this.DerivationPath = new System.Windows.Forms.TextBox();
            this.CFGPath = new System.Windows.Forms.TextBox();
            this.NPDAPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.word = new System.Windows.Forms.TextBox();
            this.derivationLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FindDerivation
            // 
            this.FindDerivation.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FindDerivation.Location = new System.Drawing.Point(967, 231);
            this.FindDerivation.Name = "FindDerivation";
            this.FindDerivation.Size = new System.Drawing.Size(152, 50);
            this.FindDerivation.TabIndex = 27;
            this.FindDerivation.Text = "Find Derivation";
            this.FindDerivation.UseVisualStyleBackColor = true;
            this.FindDerivation.Click += new System.EventHandler(this.FindDerivation_Click);
            // 
            // GenerateCFG
            // 
            this.GenerateCFG.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenerateCFG.Location = new System.Drawing.Point(967, 155);
            this.GenerateCFG.Name = "GenerateCFG";
            this.GenerateCFG.Size = new System.Drawing.Size(152, 50);
            this.GenerateCFG.TabIndex = 26;
            this.GenerateCFG.Text = "Generate CFG";
            this.GenerateCFG.UseVisualStyleBackColor = true;
            this.GenerateCFG.Click += new System.EventHandler(this.GenerateCFG_Click);
            // 
            // LoadNPDA
            // 
            this.LoadNPDA.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadNPDA.Location = new System.Drawing.Point(966, 80);
            this.LoadNPDA.Name = "LoadNPDA";
            this.LoadNPDA.Size = new System.Drawing.Size(153, 50);
            this.LoadNPDA.TabIndex = 25;
            this.LoadNPDA.Text = "Load NPDA";
            this.LoadNPDA.UseVisualStyleBackColor = true;
            this.LoadNPDA.Click += new System.EventHandler(this.LoadNPDA_Click);
            // 
            // CFGLabel
            // 
            this.CFGLabel.AutoSize = true;
            this.CFGLabel.Font = new System.Drawing.Font("Monotype Corsiva", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CFGLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.CFGLabel.Location = new System.Drawing.Point(17, 164);
            this.CFGLabel.Name = "CFGLabel";
            this.CFGLabel.Size = new System.Drawing.Size(245, 29);
            this.CFGLabel.TabIndex = 24;
            this.CFGLabel.Text = "CFG Output Text Path:";
            this.CFGLabel.Click += new System.EventHandler(this.CFGLabel_Click);
            // 
            // wordLabel
            // 
            this.wordLabel.AutoSize = true;
            this.wordLabel.Font = new System.Drawing.Font("Monotype Corsiva", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wordLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.wordLabel.Location = new System.Drawing.Point(17, 240);
            this.wordLabel.Name = "wordLabel";
            this.wordLabel.Size = new System.Drawing.Size(74, 29);
            this.wordLabel.TabIndex = 23;
            this.wordLabel.Text = "Word:";
            // 
            // NPDALabel
            // 
            this.NPDALabel.AutoSize = true;
            this.NPDALabel.Font = new System.Drawing.Font("Monotype Corsiva", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NPDALabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.NPDALabel.Location = new System.Drawing.Point(17, 89);
            this.NPDALabel.Name = "NPDALabel";
            this.NPDALabel.Size = new System.Drawing.Size(255, 29);
            this.NPDALabel.TabIndex = 22;
            this.NPDALabel.Text = "NPDA Input Text Path:";
            this.NPDALabel.Click += new System.EventHandler(this.NFALabel_Click);
            // 
            // DerivationPath
            // 
            this.DerivationPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.DerivationPath.Location = new System.Drawing.Point(608, 231);
            this.DerivationPath.Multiline = true;
            this.DerivationPath.Name = "DerivationPath";
            this.DerivationPath.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.DerivationPath.Size = new System.Drawing.Size(340, 50);
            this.DerivationPath.TabIndex = 21;
            // 
            // CFGPath
            // 
            this.CFGPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.CFGPath.Location = new System.Drawing.Point(608, 155);
            this.CFGPath.Multiline = true;
            this.CFGPath.Name = "CFGPath";
            this.CFGPath.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.CFGPath.Size = new System.Drawing.Size(340, 50);
            this.CFGPath.TabIndex = 20;
            // 
            // NPDAPath
            // 
            this.NPDAPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.NPDAPath.Location = new System.Drawing.Point(608, 80);
            this.NPDAPath.Multiline = true;
            this.NPDAPath.Name = "NPDAPath";
            this.NPDAPath.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.NPDAPath.Size = new System.Drawing.Size(340, 50);
            this.NPDAPath.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Cornsilk;
            this.label2.Location = new System.Drawing.Point(846, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(273, 34);
            this.label2.TabIndex = 18;
            this.label2.Text = "By Mirzaei and Pirhadi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mistral", 28.2F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(653, 57);
            this.label1.TabIndex = 17;
            this.label1.Text = "NPDA to CFG and derivation checking";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // word
            // 
            this.word.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.word.Location = new System.Drawing.Point(97, 231);
            this.word.Multiline = true;
            this.word.Name = "word";
            this.word.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.word.Size = new System.Drawing.Size(165, 50);
            this.word.TabIndex = 28;
            // 
            // derivationLabel
            // 
            this.derivationLabel.AutoSize = true;
            this.derivationLabel.Font = new System.Drawing.Font("Monotype Corsiva", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.derivationLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.derivationLabel.Location = new System.Drawing.Point(268, 240);
            this.derivationLabel.Name = "derivationLabel";
            this.derivationLabel.Size = new System.Drawing.Size(305, 29);
            this.derivationLabel.TabIndex = 29;
            this.derivationLabel.Text = "Derivation Output Text Path:";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.IndianRed;
            this.ClientSize = new System.Drawing.Size(1146, 313);
            this.Controls.Add(this.derivationLabel);
            this.Controls.Add(this.word);
            this.Controls.Add(this.FindDerivation);
            this.Controls.Add(this.GenerateCFG);
            this.Controls.Add(this.LoadNPDA);
            this.Controls.Add(this.CFGLabel);
            this.Controls.Add(this.wordLabel);
            this.Controls.Add(this.NPDALabel);
            this.Controls.Add(this.DerivationPath);
            this.Controls.Add(this.CFGPath);
            this.Controls.Add(this.NPDAPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button FindDerivation;
        private System.Windows.Forms.Button GenerateCFG;
        private System.Windows.Forms.Button LoadNPDA;
        private System.Windows.Forms.Label CFGLabel;
        private System.Windows.Forms.Label wordLabel;
        private System.Windows.Forms.Label NPDALabel;
        private System.Windows.Forms.TextBox DerivationPath;
        private System.Windows.Forms.TextBox CFGPath;
        private System.Windows.Forms.TextBox NPDAPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox word;
        private System.Windows.Forms.Label derivationLabel;
    }
}

