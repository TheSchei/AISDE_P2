namespace WindowsFormsApp2
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.uruchom = new System.Windows.Forms.Button();
            this.obrazek = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.obrazek)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 19);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(626, 272);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // uruchom
            // 
            this.uruchom.Location = new System.Drawing.Point(12, 297);
            this.uruchom.Name = "uruchom";
            this.uruchom.Size = new System.Drawing.Size(118, 32);
            this.uruchom.TabIndex = 1;
            this.uruchom.Text = "uruchom";
            this.uruchom.UseVisualStyleBackColor = true;
            this.uruchom.Click += new System.EventHandler(this.button1_Click);
            // 
            // obrazek
            // 
            this.obrazek.Location = new System.Drawing.Point(644, 19);
            this.obrazek.Name = "obrazek";
            this.obrazek.Size = new System.Drawing.Size(836, 310);
            this.obrazek.TabIndex = 2;
            this.obrazek.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1492, 348);
            this.Controls.Add(this.obrazek);
            this.Controls.Add(this.uruchom);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Symulacja";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.obrazek)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button uruchom;
        private System.Windows.Forms.PictureBox obrazek;
    }
}

