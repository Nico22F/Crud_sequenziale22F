using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Reflection;

namespace Crud_sequenziale22F
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // controllo che il file sia presente. In caso contrario, lo creo

            if (File.Exists("./file_crud.dat") == false)
            {
                ResetFile();
            }
            else // riaggiorno l'array con i nomi e le posizioni dei prodotti
            {
                //AggiornoStruct();
            }
            
        }


        // creo l'array di struct che conterrà i nomi dei prodotti e le posizioni (ordinate alfabeticamente)
        public struct prodotto
        {
            public string nome;
            public float posizione;
        }
        public prodotto[] p = new prodotto[100];
        
        // VARIABILI GLOBALI

        public int size = 64;
        public int dim;

        // FUNZIONI

        // funzione che resetta il file, lo svuota (anche array di struct)
        public void ResetFile()
        {
            // resetta il file

            FileStream file = new FileStream("./file_crud.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryWriter bw = new BinaryWriter(file);
            string prodotto = "@", prezzo = "@";
            byte[] strInByte;

            string riga = prodotto.PadRight(32) + prezzo.PadRight(32);
            strInByte = Encoding.Default.GetBytes(riga);

            for (int i = 1; i <= 100; i++)
            {
                bw.Write(strInByte);
            }

            dim = 0;

            file.Close();
            bw.Close();
        }

        // quando apro il programma, se è presente un file (precedentemente creato), riaggiorno l'array

        /*
        public void AggiornoArray()
        {
            FileStream file = new FileStream("./file_crud.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryReader br = new BinaryReader(file);

            string nomeProdotto;
            bool uscita = false;

            while (uscita == false)
            {
                br.BaseStream.Seek((dim) * size, 0); // all'inizio dim vale 0 (reset programma)
                //nome prodotto
                byte[] bit = br.ReadBytes(32);
                nomeProdotto = Encoding.ASCII.GetString(bit, 0, bit.Length).Trim();

                // aggiungo all'array il nome del prodotto se non è nullo (@)

                if (nomeProdotto[0] != '@')
                {
                    nomiprodotti[dim] = nomeProdotto;
                    dim++;
                }
                else
                {
                    uscita = true;
                }

            }
        }
        */

        // quando chiudo il file, creo / aggiorno il ile che conterrà tutti i nomi,quantità e posizioni
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }
    }
}
