namespace Crud_sequenziale22F
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.aggiungi = new System.Windows.Forms.Button();
            this.visualizza_file = new System.Windows.Forms.Button();
            this.resetta_file = new System.Windows.Forms.Button();
            this.modifica_prodotto = new System.Windows.Forms.Button();
            this.elimina = new System.Windows.Forms.Button();
            this.cancellazione_fisica = new System.Windows.Forms.CheckBox();
            this.cancellazione_logica = new System.Windows.Forms.CheckBox();
            this.annulla = new System.Windows.Forms.Button();
            this.titolo_cancellazione = new System.Windows.Forms.Label();
            this.trova_prodotto = new System.Windows.Forms.Button();
            this.recupera = new System.Windows.Forms.Button();
            this.titolo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // aggiungi
            // 
            this.aggiungi.BackColor = System.Drawing.Color.Transparent;
            this.aggiungi.Location = new System.Drawing.Point(70, 70);
            this.aggiungi.Margin = new System.Windows.Forms.Padding(2);
            this.aggiungi.Name = "aggiungi";
            this.aggiungi.Size = new System.Drawing.Size(170, 72);
            this.aggiungi.TabIndex = 0;
            this.aggiungi.Text = "AGGIUNGI PRODOTTO";
            this.aggiungi.UseVisualStyleBackColor = false;
            this.aggiungi.Click += new System.EventHandler(this.aggiungi_Click);
            // 
            // visualizza_file
            // 
            this.visualizza_file.Location = new System.Drawing.Point(109, 357);
            this.visualizza_file.Margin = new System.Windows.Forms.Padding(2);
            this.visualizza_file.Name = "visualizza_file";
            this.visualizza_file.Size = new System.Drawing.Size(258, 84);
            this.visualizza_file.TabIndex = 1;
            this.visualizza_file.Text = "VISUALIZZA FILE";
            this.visualizza_file.UseVisualStyleBackColor = true;
            this.visualizza_file.Click += new System.EventHandler(this.visualizza_file_Click);
            // 
            // resetta_file
            // 
            this.resetta_file.Location = new System.Drawing.Point(71, 242);
            this.resetta_file.Margin = new System.Windows.Forms.Padding(2);
            this.resetta_file.Name = "resetta_file";
            this.resetta_file.Size = new System.Drawing.Size(170, 72);
            this.resetta_file.TabIndex = 2;
            this.resetta_file.Text = "RESETTA FILE";
            this.resetta_file.UseVisualStyleBackColor = true;
            this.resetta_file.Click += new System.EventHandler(this.resetta_file_Click);
            // 
            // modifica_prodotto
            // 
            this.modifica_prodotto.Location = new System.Drawing.Point(245, 70);
            this.modifica_prodotto.Margin = new System.Windows.Forms.Padding(2);
            this.modifica_prodotto.Name = "modifica_prodotto";
            this.modifica_prodotto.Size = new System.Drawing.Size(170, 72);
            this.modifica_prodotto.TabIndex = 3;
            this.modifica_prodotto.Text = "MODIFICA PRODOTTO";
            this.modifica_prodotto.UseVisualStyleBackColor = true;
            this.modifica_prodotto.Click += new System.EventHandler(this.modifica_prodotto_Click);
            // 
            // elimina
            // 
            this.elimina.Location = new System.Drawing.Point(245, 242);
            this.elimina.Margin = new System.Windows.Forms.Padding(2);
            this.elimina.Name = "elimina";
            this.elimina.Size = new System.Drawing.Size(170, 72);
            this.elimina.TabIndex = 4;
            this.elimina.Text = "ELIMINA PRODOTTO";
            this.elimina.UseVisualStyleBackColor = true;
            this.elimina.Click += new System.EventHandler(this.elimina_Click);
            // 
            // cancellazione_fisica
            // 
            this.cancellazione_fisica.AutoSize = true;
            this.cancellazione_fisica.Font = new System.Drawing.Font("NSimSun", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancellazione_fisica.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.cancellazione_fisica.Location = new System.Drawing.Point(119, 129);
            this.cancellazione_fisica.Margin = new System.Windows.Forms.Padding(2);
            this.cancellazione_fisica.Name = "cancellazione_fisica";
            this.cancellazione_fisica.Size = new System.Drawing.Size(248, 23);
            this.cancellazione_fisica.TabIndex = 5;
            this.cancellazione_fisica.Text = "CANCELLAZIONE FISICA";
            this.cancellazione_fisica.UseVisualStyleBackColor = true;
            this.cancellazione_fisica.CheckedChanged += new System.EventHandler(this.cancellazione_fisica_CheckedChanged);
            // 
            // cancellazione_logica
            // 
            this.cancellazione_logica.AutoSize = true;
            this.cancellazione_logica.Font = new System.Drawing.Font("NSimSun", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancellazione_logica.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.cancellazione_logica.Location = new System.Drawing.Point(119, 221);
            this.cancellazione_logica.Margin = new System.Windows.Forms.Padding(2);
            this.cancellazione_logica.Name = "cancellazione_logica";
            this.cancellazione_logica.Size = new System.Drawing.Size(248, 23);
            this.cancellazione_logica.TabIndex = 6;
            this.cancellazione_logica.Text = "CANCELLAZIONE LOGICA";
            this.cancellazione_logica.UseVisualStyleBackColor = true;
            this.cancellazione_logica.CheckedChanged += new System.EventHandler(this.cancellazione_logica_CheckedChanged);
            // 
            // annulla
            // 
            this.annulla.Location = new System.Drawing.Point(154, 333);
            this.annulla.Margin = new System.Windows.Forms.Padding(2);
            this.annulla.Name = "annulla";
            this.annulla.Size = new System.Drawing.Size(171, 72);
            this.annulla.TabIndex = 7;
            this.annulla.Text = "ANNULLA";
            this.annulla.UseVisualStyleBackColor = true;
            this.annulla.Click += new System.EventHandler(this.annulla_Click);
            // 
            // titolo_cancellazione
            // 
            this.titolo_cancellazione.AutoSize = true;
            this.titolo_cancellazione.Font = new System.Drawing.Font("NSimSun", 14.25F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titolo_cancellazione.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.titolo_cancellazione.Location = new System.Drawing.Point(54, 9);
            this.titolo_cancellazione.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.titolo_cancellazione.Name = "titolo_cancellazione";
            this.titolo_cancellazione.Size = new System.Drawing.Size(383, 19);
            this.titolo_cancellazione.TabIndex = 8;
            this.titolo_cancellazione.Text = "SELEZIONA IL TIPO DI CANCELLAZIONE";
            // 
            // trova_prodotto
            // 
            this.trova_prodotto.Location = new System.Drawing.Point(245, 156);
            this.trova_prodotto.Margin = new System.Windows.Forms.Padding(2);
            this.trova_prodotto.Name = "trova_prodotto";
            this.trova_prodotto.Size = new System.Drawing.Size(170, 72);
            this.trova_prodotto.TabIndex = 9;
            this.trova_prodotto.Text = "TROVA PRODOTTO";
            this.trova_prodotto.UseVisualStyleBackColor = true;
            this.trova_prodotto.Click += new System.EventHandler(this.trova_prodotto_Click);
            // 
            // recupera
            // 
            this.recupera.Location = new System.Drawing.Point(71, 156);
            this.recupera.Margin = new System.Windows.Forms.Padding(2);
            this.recupera.Name = "recupera";
            this.recupera.Size = new System.Drawing.Size(170, 72);
            this.recupera.TabIndex = 10;
            this.recupera.Text = "RECUPERA PRODOTTO";
            this.recupera.UseVisualStyleBackColor = true;
            this.recupera.Click += new System.EventHandler(this.recupera_Click);
            // 
            // titolo
            // 
            this.titolo.AutoSize = true;
            this.titolo.Font = new System.Drawing.Font("NSimSun", 14.25F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titolo.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.titolo.Location = new System.Drawing.Point(54, 9);
            this.titolo.Name = "titolo";
            this.titolo.Size = new System.Drawing.Size(361, 19);
            this.titolo.TabIndex = 11;
            this.titolo.Text = "CRUD CON ACCESSO SEQUENZIALE 22F";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(478, 450);
            this.Controls.Add(this.titolo);
            this.Controls.Add(this.recupera);
            this.Controls.Add(this.trova_prodotto);
            this.Controls.Add(this.titolo_cancellazione);
            this.Controls.Add(this.annulla);
            this.Controls.Add(this.cancellazione_logica);
            this.Controls.Add(this.cancellazione_fisica);
            this.Controls.Add(this.elimina);
            this.Controls.Add(this.modifica_prodotto);
            this.Controls.Add(this.resetta_file);
            this.Controls.Add(this.visualizza_file);
            this.Controls.Add(this.aggiungi);
            this.Name = "Form1";
            this.Text = "Finestra22F";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button aggiungi;
        private System.Windows.Forms.Button visualizza_file;
        private System.Windows.Forms.Button resetta_file;
        private System.Windows.Forms.Button modifica_prodotto;
        private System.Windows.Forms.Button elimina;
        private System.Windows.Forms.CheckBox cancellazione_fisica;
        private System.Windows.Forms.CheckBox cancellazione_logica;
        private System.Windows.Forms.Button annulla;
        private System.Windows.Forms.Label titolo_cancellazione;
        private System.Windows.Forms.Button trova_prodotto;
        private System.Windows.Forms.Button recupera;
        private System.Windows.Forms.Label titolo;
    }
}

