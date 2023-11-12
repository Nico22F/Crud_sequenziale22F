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
            this.SuspendLayout();
            // 
            // aggiungi
            // 
            this.aggiungi.Location = new System.Drawing.Point(94, 86);
            this.aggiungi.Name = "aggiungi";
            this.aggiungi.Size = new System.Drawing.Size(227, 89);
            this.aggiungi.TabIndex = 0;
            this.aggiungi.Text = "AGGIUNGI PRODOTTO";
            this.aggiungi.UseVisualStyleBackColor = true;
            this.aggiungi.Click += new System.EventHandler(this.aggiungi_Click);
            // 
            // visualizza_file
            // 
            this.visualizza_file.Location = new System.Drawing.Point(145, 439);
            this.visualizza_file.Name = "visualizza_file";
            this.visualizza_file.Size = new System.Drawing.Size(344, 103);
            this.visualizza_file.TabIndex = 1;
            this.visualizza_file.Text = "VISUALIZZA FILE";
            this.visualizza_file.UseVisualStyleBackColor = true;
            this.visualizza_file.Click += new System.EventHandler(this.visualizza_file_Click);
            // 
            // resetta_file
            // 
            this.resetta_file.Location = new System.Drawing.Point(95, 298);
            this.resetta_file.Name = "resetta_file";
            this.resetta_file.Size = new System.Drawing.Size(226, 89);
            this.resetta_file.TabIndex = 2;
            this.resetta_file.Text = "RESETTA FILE";
            this.resetta_file.UseVisualStyleBackColor = true;
            this.resetta_file.Click += new System.EventHandler(this.resetta_file_Click);
            // 
            // modifica_prodotto
            // 
            this.modifica_prodotto.Location = new System.Drawing.Point(327, 86);
            this.modifica_prodotto.Name = "modifica_prodotto";
            this.modifica_prodotto.Size = new System.Drawing.Size(227, 89);
            this.modifica_prodotto.TabIndex = 3;
            this.modifica_prodotto.Text = "MODIFICA PRODOTTO";
            this.modifica_prodotto.UseVisualStyleBackColor = true;
            this.modifica_prodotto.Click += new System.EventHandler(this.modifica_prodotto_Click);
            // 
            // elimina
            // 
            this.elimina.Location = new System.Drawing.Point(328, 298);
            this.elimina.Name = "elimina";
            this.elimina.Size = new System.Drawing.Size(226, 89);
            this.elimina.TabIndex = 4;
            this.elimina.Text = "ELIMINA PRODOTTO";
            this.elimina.UseVisualStyleBackColor = true;
            this.elimina.Click += new System.EventHandler(this.elimina_Click);
            // 
            // cancellazione_fisica
            // 
            this.cancellazione_fisica.AutoSize = true;
            this.cancellazione_fisica.Location = new System.Drawing.Point(243, 166);
            this.cancellazione_fisica.Name = "cancellazione_fisica";
            this.cancellazione_fisica.Size = new System.Drawing.Size(182, 20);
            this.cancellazione_fisica.TabIndex = 5;
            this.cancellazione_fisica.Text = "CANCELLAZIONE FISICA";
            this.cancellazione_fisica.UseVisualStyleBackColor = true;
            this.cancellazione_fisica.CheckedChanged += new System.EventHandler(this.cancellazione_fisica_CheckedChanged);
            // 
            // cancellazione_logica
            // 
            this.cancellazione_logica.AutoSize = true;
            this.cancellazione_logica.Location = new System.Drawing.Point(246, 216);
            this.cancellazione_logica.Name = "cancellazione_logica";
            this.cancellazione_logica.Size = new System.Drawing.Size(189, 20);
            this.cancellazione_logica.TabIndex = 6;
            this.cancellazione_logica.Text = "CANCELLAZIONE LOGICA";
            this.cancellazione_logica.UseVisualStyleBackColor = true;
            this.cancellazione_logica.CheckedChanged += new System.EventHandler(this.cancellazione_logica_CheckedChanged);
            // 
            // annulla
            // 
            this.annulla.Location = new System.Drawing.Point(206, 410);
            this.annulla.Name = "annulla";
            this.annulla.Size = new System.Drawing.Size(228, 89);
            this.annulla.TabIndex = 7;
            this.annulla.Text = "ANNULLA";
            this.annulla.UseVisualStyleBackColor = true;
            this.annulla.Click += new System.EventHandler(this.annulla_Click);
            // 
            // titolo_cancellazione
            // 
            this.titolo_cancellazione.AutoSize = true;
            this.titolo_cancellazione.Location = new System.Drawing.Point(240, 58);
            this.titolo_cancellazione.Name = "titolo_cancellazione";
            this.titolo_cancellazione.Size = new System.Drawing.Size(256, 16);
            this.titolo_cancellazione.TabIndex = 8;
            this.titolo_cancellazione.Text = "SELEZIONA IL TIPO DI CANCELLAZIONE";
            // 
            // trova_prodotto
            // 
            this.trova_prodotto.Location = new System.Drawing.Point(327, 192);
            this.trova_prodotto.Name = "trova_prodotto";
            this.trova_prodotto.Size = new System.Drawing.Size(227, 89);
            this.trova_prodotto.TabIndex = 9;
            this.trova_prodotto.Text = "TROVA PRODOTTO";
            this.trova_prodotto.UseVisualStyleBackColor = true;
            this.trova_prodotto.Click += new System.EventHandler(this.trova_prodotto_Click);
            // 
            // recupera
            // 
            this.recupera.Location = new System.Drawing.Point(95, 192);
            this.recupera.Name = "recupera";
            this.recupera.Size = new System.Drawing.Size(226, 89);
            this.recupera.TabIndex = 10;
            this.recupera.Text = "RECUPERA PRODOTTO";
            this.recupera.UseVisualStyleBackColor = true;
            this.recupera.Click += new System.EventHandler(this.recupera_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 554);
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
            this.Margin = new System.Windows.Forms.Padding(4);
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
    }
}

