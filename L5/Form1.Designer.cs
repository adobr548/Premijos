namespace L5
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.failasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ivestiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spausdintiDuomenisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baigtiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uzduotiesVeiksmaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darbuotojuPremijosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maziausiaiUzdirbeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pagalbaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Darbuot = new System.Windows.Forms.RichTextBox();
            this.Indel = new System.Windows.Forms.RichTextBox();
            this.Rezultatai = new System.Windows.Forms.RichTextBox();
            this.bankoPavIvedimas = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PavedimuFormavimas = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.failasToolStripMenuItem,
            this.uzduotiesVeiksmaiToolStripMenuItem,
            this.pagalbaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(789, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // failasToolStripMenuItem
            // 
            this.failasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ivestiToolStripMenuItem,
            this.spausdintiDuomenisToolStripMenuItem,
            this.baigtiToolStripMenuItem});
            this.failasToolStripMenuItem.Name = "failasToolStripMenuItem";
            this.failasToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.failasToolStripMenuItem.Text = "Failas";
            // 
            // ivestiToolStripMenuItem
            // 
            this.ivestiToolStripMenuItem.Name = "ivestiToolStripMenuItem";
            this.ivestiToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.ivestiToolStripMenuItem.Text = "Ivesti";
            this.ivestiToolStripMenuItem.Click += new System.EventHandler(this.ivestiToolStripMenuItem_Click);
            // 
            // spausdintiDuomenisToolStripMenuItem
            // 
            this.spausdintiDuomenisToolStripMenuItem.Name = "spausdintiDuomenisToolStripMenuItem";
            this.spausdintiDuomenisToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.spausdintiDuomenisToolStripMenuItem.Text = "Spausdinti duomenis";
            this.spausdintiDuomenisToolStripMenuItem.Click += new System.EventHandler(this.spausdintiDuomenisToolStripMenuItem_Click);
            // 
            // baigtiToolStripMenuItem
            // 
            this.baigtiToolStripMenuItem.Name = "baigtiToolStripMenuItem";
            this.baigtiToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.baigtiToolStripMenuItem.Text = "Baigti";
            this.baigtiToolStripMenuItem.Click += new System.EventHandler(this.baigtiToolStripMenuItem_Click);
            // 
            // uzduotiesVeiksmaiToolStripMenuItem
            // 
            this.uzduotiesVeiksmaiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.darbuotojuPremijosToolStripMenuItem,
            this.maziausiaiUzdirbeToolStripMenuItem});
            this.uzduotiesVeiksmaiToolStripMenuItem.Name = "uzduotiesVeiksmaiToolStripMenuItem";
            this.uzduotiesVeiksmaiToolStripMenuItem.Size = new System.Drawing.Size(120, 20);
            this.uzduotiesVeiksmaiToolStripMenuItem.Text = "Uzduoties veiksmai";
            // 
            // darbuotojuPremijosToolStripMenuItem
            // 
            this.darbuotojuPremijosToolStripMenuItem.Name = "darbuotojuPremijosToolStripMenuItem";
            this.darbuotojuPremijosToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.darbuotojuPremijosToolStripMenuItem.Text = "Darbuotoju premijos";
            this.darbuotojuPremijosToolStripMenuItem.Click += new System.EventHandler(this.darbuotojuPremijosToolStripMenuItem_Click);
            // 
            // maziausiaiUzdirbeToolStripMenuItem
            // 
            this.maziausiaiUzdirbeToolStripMenuItem.Name = "maziausiaiUzdirbeToolStripMenuItem";
            this.maziausiaiUzdirbeToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.maziausiaiUzdirbeToolStripMenuItem.Text = "Maziausiai uzdirbe";
            this.maziausiaiUzdirbeToolStripMenuItem.Click += new System.EventHandler(this.maziausiaiUzdirbeToolStripMenuItem_Click);
            // 
            // pagalbaToolStripMenuItem
            // 
            this.pagalbaToolStripMenuItem.Name = "pagalbaToolStripMenuItem";
            this.pagalbaToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.pagalbaToolStripMenuItem.Text = "Pagalba";
            this.pagalbaToolStripMenuItem.Click += new System.EventHandler(this.pagalbaToolStripMenuItem_Click);
            // 
            // Darbuot
            // 
            this.Darbuot.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Darbuot.Location = new System.Drawing.Point(13, 27);
            this.Darbuot.Name = "Darbuot";
            this.Darbuot.Size = new System.Drawing.Size(518, 180);
            this.Darbuot.TabIndex = 1;
            this.Darbuot.Text = "";
            // 
            // Indel
            // 
            this.Indel.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Indel.Location = new System.Drawing.Point(639, 109);
            this.Indel.Name = "Indel";
            this.Indel.Size = new System.Drawing.Size(138, 382);
            this.Indel.TabIndex = 2;
            this.Indel.Text = "";
            // 
            // Rezultatai
            // 
            this.Rezultatai.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Rezultatai.Location = new System.Drawing.Point(13, 213);
            this.Rezultatai.Name = "Rezultatai";
            this.Rezultatai.Size = new System.Drawing.Size(603, 278);
            this.Rezultatai.TabIndex = 3;
            this.Rezultatai.Text = "";
            // 
            // bankoPavIvedimas
            // 
            this.bankoPavIvedimas.Location = new System.Drawing.Point(677, 38);
            this.bankoPavIvedimas.Name = "bankoPavIvedimas";
            this.bankoPavIvedimas.Size = new System.Drawing.Size(100, 20);
            this.bankoPavIvedimas.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(537, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Iveskite banko pavadinima";
            // 
            // PavedimuFormavimas
            // 
            this.PavedimuFormavimas.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PavedimuFormavimas.Location = new System.Drawing.Point(622, 77);
            this.PavedimuFormavimas.Name = "PavedimuFormavimas";
            this.PavedimuFormavimas.Size = new System.Drawing.Size(155, 26);
            this.PavedimuFormavimas.TabIndex = 6;
            this.PavedimuFormavimas.Text = "Suformuoti pavedima";
            this.PavedimuFormavimas.UseVisualStyleBackColor = true;
            this.PavedimuFormavimas.Click += new System.EventHandler(this.PavedimuFormavimas_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 492);
            this.Controls.Add(this.PavedimuFormavimas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bankoPavIvedimas);
            this.Controls.Add(this.Rezultatai);
            this.Controls.Add(this.Indel);
            this.Controls.Add(this.Darbuot);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "L5-6 Premijos";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem failasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ivestiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baigtiToolStripMenuItem;
        private System.Windows.Forms.RichTextBox Darbuot;
        private System.Windows.Forms.RichTextBox Indel;
        private System.Windows.Forms.RichTextBox Rezultatai;
        private System.Windows.Forms.TextBox bankoPavIvedimas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button PavedimuFormavimas;
        private System.Windows.Forms.ToolStripMenuItem uzduotiesVeiksmaiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darbuotojuPremijosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maziausiaiUzdirbeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pagalbaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spausdintiDuomenisToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
    }
}

