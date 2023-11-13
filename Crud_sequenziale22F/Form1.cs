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
using System.Collections;
using System.Globalization;

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
            // controlla se macano dei file, in caso negativo aggiorna la struct

            GestioneFile();

            // rendo invisibili alcuni oggetti

            cancellazione_fisica.Visible = false;
            cancellazione_logica.Visible = false;
            annulla.Visible = false;
            titolo_cancellazione.Visible = false;
        }


        // creo l'array di struct che conterrà i nomi dei prodotti e le posizioni (ordinate alfabeticamente)
        public struct prodotto
        {
            public string nome;
            public int posizione;
        }
        public prodotto[] p = new prodotto[100];
        
        // VARIABILI GLOBALI

        public int size = 64;
        public int dim;

        // FUNZIONI

        // funzione che gestisce i file e controlla se sono presenti o meno

        public void GestioneFile()
        {
            if (File.Exists("./struct.txt") == true && File.Exists("./file_crud.dat") == true) // non manca niente
            {
                RiempiStruct();
            }
            if (!File.Exists("./file_crud.dat") && !File.Exists("./struct.txt")) // non esiste nessun file
            {
                ResetFile(); // crea il file
            }
            if (!File.Exists("./struct.txt") && File.Exists("./file_crud.dat") == true) // manca file struct
            {
                RicreoFileStruct(); // riempe la struct leggendo dal file "utente"
            }
            if (File.Exists("./struct.txt") == true && !File.Exists("./file_crud.dat")) // manca file "normale"
            {
                ResetFile();
                ResettaFileStruct(); // resetta il file struct
            }
        }
       
        // funzione che resetta il file, lo svuota (anche array di struct)
        public void ResetFile()
        {
            // resetta il file

            FileStream file = new FileStream("./file_crud.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryWriter bw = new BinaryWriter(file);
            string chiocciola = "@";
            byte[] strInByte;

            string riga = chiocciola.PadRight(30) + chiocciola.PadRight(30) + (chiocciola.ToString()).PadRight(4);
            strInByte = Encoding.Default.GetBytes(riga);

            for (int i = 1; i <= 100; i++)
            {
                bw.Write(strInByte);
            }

            dim = 0;

            file.Close();
            bw.Close();
        }

        // funzione che legge il file "normale" se manca il file struct e lo aggiorna

        public void RicreoFileStruct()
        {
            FileStream file = new FileStream("./file_crud.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryReader br = new BinaryReader(file);

            string prodotto;
            bool uscita = false;

            // ricreo la struct

            while (uscita == false)
            {
                br.BaseStream.Seek((dim) * size, 0);

                byte[] bit = br.ReadBytes(30);

                prodotto = Encoding.ASCII.GetString(bit, 0, bit.Length).Trim();

                if (prodotto[0] != '@')
                {
                    p[dim].nome = prodotto;
                    p[dim].posizione = dim;
                    dim++;
                }
                else
                {
                    uscita = true;
                }

            }

            // ricreo il file struct ma non lo riempio, verrà riempito una volta chiuso il programma

            FileStream file_struct = new FileStream("./struct.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            
            file_struct.Close();
            file.Close();
            br.Close();
        }

        // resetta file struct

        public void ResettaFileStruct()
        {
            var files = new FileStream("./struct.txt", FileMode.Truncate, FileAccess.Write, FileShare.Read);
            StreamWriter sw = new StreamWriter(files);
            sw.Write(string.Empty);

            files.Close();
            sw.Close();
        }

        // funzione che riempie la struct dal file struct

        public void RiempiStruct()
        {
            StreamReader sr = new StreamReader("./struct.txt");
           
            string riga = sr.ReadLine();

            // leggo ogni riga e la metto nella struct

            do
            {
                if (riga != null)
                {
                    string[] elementi = Split(riga, ';');
                    p[dim].nome = elementi[0];
                    p[dim].posizione = Convert.ToInt16(elementi[1]);

                    // aumento dim

                    dim++;

                    riga = sr.ReadLine();
                }
            }
            while (riga != null);

            // una volta finito gli ordino alfabeticamente

            OrdineAlfabetico();

            sr.Close();
        }

        // funzione che splitta

        static string[] Split(string stringa, char separatore)
        {

            string[] array = new string[2];
            string frase = "";
            int p = 0;

            for (int i = 0; i < stringa.Length; i++)
            {
                if (stringa[i] == separatore)
                {
                    array[p] = frase;
                    p++;
                    frase = "";
                }
                else
                {
                    frase += stringa[i];
                }

                if (i == stringa.Length - 1)
                {
                    array[p] = frase;
                }
            }
            return array;
        }

        // funzione che ordina in modo alfabetico la struct

        public void OrdineAlfabetico()
        {
            // inserisco nell'array gli items della lista

            string[] array = new string[dim]; // contiene i nomi
            int[] array_posizione = new int[dim]; // contiene la posizione
            bool scambiato = false;

            // riempie gli array

            for (int i = 0; i < dim; i++)
            {
                array[i] = p[i].nome;
                array_posizione[i] = p[i].posizione;
            }

            // scambia le posizioni negli array

            do
            {
                scambiato = false;

                for (int i = 1; i < dim; i++)
                {
                    if (string.Compare(array[i - 1], array[i], StringComparison.Ordinal) > 0)
                    {
                        // Scambia le stringhe
                        string temp = array[i - 1];
                        int temp_pos = array_posizione[i - 1];

                        array[i - 1] = array[i];
                        array_posizione[i - 1] = array_posizione[i];

                        array[i] = temp;
                        array_posizione[i] = temp_pos;

                        scambiato = true;
                    }
                }
            }
            while (scambiato == true);

            // riordino la struct

            for (int i = 0; i < dim; i++)
            {
                p[i].nome = array[i];
                p[i].posizione = array_posizione[i];
            }
        }

        // funzione che aggiunge un prodotto al file

        public void AggiungiProdotto()
        {
            if (dim == 99) // se ci sono più di 100 prodotti allora da errore
            {
                MessageBox.Show("Errore, ci sono troppi prodotti");
            }
            else // se non ci sono più di 100 prodotti
            {
                // input box nome e do while per input corretto
                // nel caso l'utente esca quando inserisce il nome oppure lascia il campo vuoto, non verrà chiesto il prezzo


                string titolo_input = "Aggiungi Prodotto - NOME", esempio = "nome prodotto", frase = "Inserisci il nome del prodotto che vuoi aggiungere";
                object input_aggiungiprodotto = Interaction.InputBox(frase, titolo_input, esempio);

                string nome_temporaneo = (string)input_aggiungiprodotto; // salvo il nome in una variabile temporanea, verrà scritto nel file solo se il prezzo verrà scritto nel modo corretto


                if (nome_temporaneo == null || nome_temporaneo == "" || nome_temporaneo[0] == '§' || nome_temporaneo == "@" || nome_temporaneo[0] == '@') // non si può modificare un prodotto eliminato logicamente
                {
                    MessageBox.Show("Errore nell'aggiunta del prodotto", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    // controlla che non sia presente un prodotto identico (in caso affermativo allora aumenta la quantità)
                    bool quantita = false;
                    int posizione = 0; // se il prodotto è già stato aggiunto in precedenza, segna la posizione

                    quantita = ControlloProdotto(ref quantita, nome_temporaneo, ref posizione);

                    if (quantita == true) // prodotto già presente
                    {
                        AumentaQuantita(posizione - 1);
                        MessageBox.Show("il prodotto da lei inserito è già stato inserito. Quantità aumentata");
                    }
                    else // prodotto nuovo
                    {

                        // input prezzo

                        titolo_input = "Aggiungi Prodotto - Prezzo"; esempio = "prezzo prodotto"; frase = "Inserisci il prezzo del prodotto che vuoi aggiungere";
                        input_aggiungiprodotto = Interaction.InputBox(frase, titolo_input, esempio);
                        float prova_numero = 0; // se la conversione risultasse corretta (questa sotto) la stringa convertita in float finirebbe qua

                        // tryparse serve per vedere se la conversione funziona
                        if (!float.TryParse((string)input_aggiungiprodotto, out prova_numero))
                        {
                            MessageBox.Show("Errore nell'aggiunta del prodotto", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            p[dim].nome = null;
                        }
                        else
                        {
                            int quantita_prodotto = 1;
                            AggiungiProdottoFile((string)input_aggiungiprodotto, nome_temporaneo, quantita_prodotto, dim);
                            OrdineAlfabetico();

                        }
                    }

                }
            }
        }

        // funzione che controlla se un prodotto è già presente nella struct (ricerca dicotomica)

        public bool ControlloProdotto(ref bool quantita, string nome, ref int posizione)
        {
            int sinistra = 0;
            int destra = dim;

            while (sinistra <= destra)
            {
                int medio = sinistra + (destra - sinistra) / 2;

                // Controlla se l'elemento è presente al centro dell'array
                if (p[medio].nome == nome)
                {
                    posizione = p[medio].posizione;
                    return quantita = true;
                }

                // Se l'elemento è maggiore, ignora la metà sinistra
                if (string.Compare(p[medio].nome, nome, StringComparison.Ordinal) == -1) // se è -1 allora la prima stringa è più piccolo della seconda
                {
                    sinistra = medio + 1;
                }
                else // Se l'elemento è minore, ignora la metà destra
                {
                    destra = medio - 1;
                }
            }


            return quantita = false;
        }

        // funzione che aumenta la quantità
        
        public void AumentaQuantita(int posizione)
        {
            FileStream file = new FileStream("./file_crud.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryWriter bw = new BinaryWriter(file);
            BinaryReader br = new BinaryReader(file);

            // posizionamento

            br.BaseStream.Seek((posizione) * size, 0);

            // nome

            byte[] bit = br.ReadBytes(30);

            string nome = Encoding.ASCII.GetString(bit, 0, bit.Length).Trim();

            // prezzo

            bit = br.ReadBytes(30);

            string prezzo = Encoding.ASCII.GetString(bit, 0, bit.Length).Trim();

            // quantità

            bit = br.ReadBytes(4);

            string quantita = Encoding.ASCII.GetString(bit, 0, bit.Length).Trim();

            int nuova_quantita = Convert.ToInt32(quantita);
            nuova_quantita++;

            // riscrivo la riga
            bw.BaseStream.Seek((posizione) * size, 0);
            byte[] strInByte;
            string riga = nome.PadRight(30) + prezzo.PadRight(30) + (nuova_quantita.ToString()).PadRight(4);
            strInByte = Encoding.Default.GetBytes(riga);

            bw.Write(strInByte);

            br.Close();
            bw.Close();
            file.Close();
        }

        // aggiunge un prodotto al file
        public void AggiungiProdottoFile(string prezzo, string nome,int quantita, int posizione)
        {
            bool buco = false;
            int posizione_buco = 0;

            while (buco == false)
            {
                FileStream file = new FileStream("./file_crud.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                BinaryWriter bw = new BinaryWriter(file);

                if (posizione_buco == dim)
                {
                    buco = true;

                    // inserimento
                    string riga = nome.PadRight(30) + prezzo.PadRight(30) + (quantita.ToString()).PadRight(4);
                    byte[] strInByte = Encoding.Default.GetBytes(riga);
                    bw.BaseStream.Seek((posizione_buco) * size, SeekOrigin.Begin);
                    bw.Write(strInByte);
                    p[posizione_buco].nome = nome;
                    p[posizione_buco].posizione = dim+1;

                    dim++;
                }
                else
                {
                    if (p[posizione_buco].nome == null || p[posizione_buco].nome =="@")
                    {
                        buco = true;

                        // inserimento
                        string riga = nome.PadRight(30) + prezzo.PadRight(30) + (quantita.ToString()).PadRight(4);
                        byte[] strInByte = Encoding.Default.GetBytes(riga);
                        bw.BaseStream.Seek((posizione_buco) * size, SeekOrigin.Begin);
                        bw.Write(strInByte);
                        p[posizione_buco].nome = nome;
                        p[posizione_buco].posizione = dim+1;
                    }
                    else
                    {
                        posizione_buco++;
                    }
                }

                file.Close();
                bw.Close();

            }

        }

        // resetto il file struct e lo aggiorno
        public void AggiornaFileStruct()
        {
            StreamWriter sw = new StreamWriter("./struct.txt");
            
            for (int i = 0; i < dim; i++)
            {
                string riga = $"{p[i].nome};{p[i].posizione}";
                sw.WriteLine(riga);
            }
            sw.Close();
        }

        // funzione che resetta il file struct

        public void ResettaStruct()
        {
            for (int i = 0; i <= dim;i++)
            {
                p[i].nome = "@";
                p[i].posizione = 0;
            }

            dim = 0;
        }

        // quando chiudo il file, creo / aggiorno il ile che conterrà tutti i nomi,quantità e posizioni
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            AggiornaFileStruct();
        }

        // aggiungi prodotto
        private void aggiungi_Click(object sender, EventArgs e)
        {
            AggiungiProdotto();
        }

        // visualizza file
        private void visualizza_file_Click(object sender, EventArgs e)
        {
            // trova il percorso del file

            string percorsoFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "file_crud.dat");

            // apre il file

            Process.Start(percorsoFile);
        }

        // resetta il file e la struct
        private void resetta_file_Click(object sender, EventArgs e)
        {
            // prima di resettare chiede una conferma dall'utente

            DialogResult ConfermaReset = MessageBox.Show("Vuoi resettare l'intero file?", "RESET FILE", MessageBoxButtons.YesNo);

            if (ConfermaReset == DialogResult.Yes) // se l'utente clicca si
            {
                ResetFile(); // resetta file

                ResettaStruct(); //resetta struct
            }
        }

        // funzione che utilizza la ricerca dicotomica per trovare la posizione di un prodotto

        public void RicercaDicotomica(ref int posizione, string nome)
        {
            int sinistra = 0;
            int destra = dim;

            while (sinistra <= destra)
            {
                int medio = sinistra + (destra - sinistra) / 2;

                // Controlla se l'elemento è presente al centro dell'array
                if (p[medio].nome == nome)
                {
                    posizione = p[medio].posizione;
                    break;
                }

                // Se l'elemento è maggiore, ignora la metà sinistra
                if (string.Compare(p[medio].nome, nome, StringComparison.Ordinal) == -1) // se è -1 allora la prima stringa è più piccolo della seconda
                {
                    sinistra = medio + 1;
                }
                else // Se l'elemento è minore, ignora la metà destra
                {
                    destra = medio - 1;
                }
            }
        }

        // funzione che modifica un prodotto

        public void ModificaProdotto(int posizione)
        {
            FileStream file = new FileStream("./file_crud.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryReader br = new BinaryReader(file);

            string nomeProdotto, PrezzoProdotto;

            br.BaseStream.Seek((posizione-1) * size, 0);
            //nome prodotto
            byte[] bit = br.ReadBytes(30);
            nomeProdotto = Encoding.ASCII.GetString(bit, 0, bit.Length).Trim();

            // prezzo prodotto
            bit = br.ReadBytes(30);
            PrezzoProdotto = Encoding.ASCII.GetString(bit, 0, bit.Length).Trim();
            
            // input modfica prodotto nome

            string titolo_input = "Modifica Prodotto - NOME", frase = "Inserisci il nome del prodotto che vuoi modifcare";
            object input_aggiungiprodotto = Interaction.InputBox(frase, titolo_input, nomeProdotto);

            if ((string)input_aggiungiprodotto == "") // user esce o lascia il campo vuoto
            {
                MessageBox.Show("Errore nella modifica del prodotto", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                string nome_temporaneo = (string)input_aggiungiprodotto; // salvo il nome in una variabile temporanea, verrà scritto nel file solo se il prezzo verrà scritto nel modo corretto

                if (nome_temporaneo[0] == '§' || nome_temporaneo == "@" || nome_temporaneo[0] == '@' || nome_temporaneo == "") // non si può modificare un prodotto eliminato logicamente
                {
                    MessageBox.Show("Errore nella modifica del prodotto. NON PUOI MODIFICARE UN PRODOTTO PRECEDENTEMENTE ELIMINATO", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else // se non è stato eliminato
                {
                    // input prezzo

                    titolo_input = "Modifica Prodotto - Prezzo"; frase = "Inserisci il prezzo del prodotto che vuoi modificare";
                    input_aggiungiprodotto = Interaction.InputBox(frase, titolo_input, PrezzoProdotto);
                    float prova_numero = 0; // se la conversione risultasse corretta (questa sotto) la stringa convertita in float finirebbe qua

                    // tryparse serve per vedere se la conversione funziona
                    if (!float.TryParse((string)input_aggiungiprodotto, out prova_numero))
                    {
                        MessageBox.Show("Errore nell'aggiunta del prodotto", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else // modifica quantità
                    {
                        titolo_input = "Modifica Prodotto - Quantità"; frase = "Inserisci la quantità del prodotto che vuoi modificare";
                        input_aggiungiprodotto = Interaction.InputBox(frase, titolo_input, PrezzoProdotto);
                        int prova_quantita = 0; // se la conversione risultasse corretta (questa sotto) la stringa convertita in float finirebbe qua

                        // tryparse serve per vedere se la conversione funziona
                        if (!int.TryParse((string)input_aggiungiprodotto, out prova_quantita))
                        {
                            MessageBox.Show("Errore nella modifica del prodotto", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        else // tutto corretto
                        {
                            p[posizione-1].nome = nome_temporaneo;

                            // scrittura

                            BinaryWriter bw = new BinaryWriter(file);
                            bw.BaseStream.Seek((posizione-1) * size, 0);

                            string riga = nome_temporaneo.PadRight(30) + Convert.ToString(prova_numero).PadRight(30) + (prova_quantita.ToString()).PadRight(4);
                            byte[] strInByte = Encoding.Default.GetBytes(riga);
                            bw.Write(strInByte);

                            // riordino alfabeticamente 
                            OrdineAlfabetico();
                            bw.Close();
                            file.Close();
                            br.Close();
                        }
                    }
                }
            }
            
        }

        // modifica un prodotto in base al nome
        private void modifica_prodotto_Click(object sender, EventArgs e)
        {
            string titolo_input = "MODIFICA Prodotto - NOME", esempio = "nome prodotto", frase = "Inserisci il nome del prodotto che vuoi modificare";
            object input_modificaprodotto = Interaction.InputBox(frase, titolo_input, esempio);
            int posizione = -1; // serve per la poszione del prodotto da cercare; se posizione rimane -1, allora l'utente ha sbagliato a scrivere
            string nome_temporaneo = (string)input_modificaprodotto;

            if (nome_temporaneo == null || nome_temporaneo == "" || nome_temporaneo[0] == '§' || nome_temporaneo == "@" || nome_temporaneo[0] == '@') // non si può modificare un prodotto eliminato logicamente
            {
                MessageBox.Show("Errore nella modifica del prodotto. NON PUOI MODIFICARE UN PRODOTTO PRECEDENTEMENTE ELIMINATO / LASCIARE IL CAMPO VUOTO", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else // se inserisce input "corretto"
            {
                RicercaDicotomica(ref posizione, (string)input_modificaprodotto);

                // se non trova nessun nome (input errato) allora lo segnala all'utente

                if (posizione == -1)
                {
                    MessageBox.Show("Errore nella modifica del prodotto. Nome prodotto non esistente", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    ModificaProdotto(posizione);
                }

            }
        }

        private void elimina_Click(object sender, EventArgs e)
        {
            // rendo invisibili alcuni elementi

            aggiungi.Visible = false;
            modifica_prodotto.Visible = false;
            elimina.Visible = false;
            resetta_file.Visible = false;
            visualizza_file.Visible = false;
            recupera.Visible = false;
            trova_prodotto.Visible=false;
            //trova_indice.Visible = false;

            // rendo visibile le due scelte di cancellazione

            cancellazione_fisica.Visible = true;
            cancellazione_logica.Visible = true;
            annulla.Visible = true;
            titolo_cancellazione.Visible = true;
        }

        // scelta cancellazione fisica
        private void cancellazione_fisica_CheckedChanged(object sender, EventArgs e)
        {
            // rendo visibili alcuni elementi

            aggiungi.Visible = true;
            modifica_prodotto.Visible = true;
            elimina.Visible = true;
            resetta_file.Visible = true;
            visualizza_file.Visible = true;
            recupera.Visible = true;
            trova_prodotto.Visible = true;
            //trova_indice.Visible = true;

            // rendo visibile le due scelte di cancellazione

            cancellazione_fisica.Visible = false;
            cancellazione_logica.Visible = false;
            annulla.Visible = false;
            titolo_cancellazione.Visible = false;

            // input prodotto da eliminare

            string titolo_input = "Eliminazione Prodotto - NOME", esempio = "nome prodotto", frase = "Inserisci il nome del prodotto che vuoi eliminare";
            object input_eliminaprodotto = Interaction.InputBox(frase, titolo_input, esempio);
            
            if ((string)input_eliminaprodotto == "") // user esce o lascia il campo vuoto
            {
                MessageBox.Show("Errore nella cancellazione del prodotto", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else // se inserisce input "corretto"
            {
                string nome_temporaneo = (string)input_eliminaprodotto;
                int posizione = -1; // se rimane -1 allora l'utente ha sbagliato a scrivere
                if (nome_temporaneo[0] == '§' || nome_temporaneo == "@" || nome_temporaneo[0] == '@') // non si può modificare un prodotto eliminato logicamente
                {
                    MessageBox.Show("Errore nella cancellazione del prodotto", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    RicercaDicotomica(ref posizione, nome_temporaneo);

                    // se non trova nessun nome (input errato) allora lo segnala all'utente

                    if (posizione == -1)
                    {
                        MessageBox.Show("Errore nella cancellazione del prodotto. Nome prodotto non esistente", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else
                    {
                        CancellazioneFisica(posizione); // cancello fisicamente
                        OrdineAlfabetico(); // riaggiorno la struct
                    }
                }
            }
        }

        // funzione cancellazione fisica

        public void CancellazioneFisica(int posizione)
        {
            // cancellazione fisica nella struct

            p[posizione-1].nome = null;
            p[posizione-1].posizione = 0;

            // cancellazione fisica nel file

            FileStream file = new FileStream("./file_crud.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryWriter bw = new BinaryWriter(file);

            string chiocciola = "@";
            byte[] strInByte;
            string riga = chiocciola.PadRight(30) + chiocciola.PadRight(30) + (chiocciola.ToString()).PadRight(4);
            strInByte = Encoding.Default.GetBytes(riga);

            bw.BaseStream.Seek((posizione-1) * size, SeekOrigin.Begin);
            bw.Write(strInByte);
            file.Close();
        }

        // scelta cancellazione logica
        private void cancellazione_logica_CheckedChanged(object sender, EventArgs e)
        {
            // rendo visibili alcuni elementi

            aggiungi.Visible = true;
            modifica_prodotto.Visible = true;
            elimina.Visible = true;
            resetta_file.Visible = true;
            visualizza_file.Visible = true;
            recupera.Visible = true;
            trova_prodotto.Visible=true;

            // rendo invisibile le due scelte di cancellazione

            cancellazione_fisica.Visible = false;
            cancellazione_logica.Visible = false;
            annulla.Visible = false;
            titolo_cancellazione.Visible = false;

            // input prodotto da eliminare

            string titolo_input = "Eliminazione Prodotto - NOME", esempio = "nome prodotto", frase = "Inserisci il nome del prodotto che vuoi eliminare";
            object input_eliminaprodotto = Interaction.InputBox(frase, titolo_input, esempio);

            if ((string)input_eliminaprodotto == "") // user esce o lascia il campo vuoto
            {
                MessageBox.Show("Errore nell'eliminazione del prodotto", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else // se inserisce input "corretto"
            {
                string nome_temporaneo = (string)input_eliminaprodotto;
                int posizione = -1; // se rimane -1, allora l'utente ha sbagliato a scrivere

                if (nome_temporaneo[0] == '§' || nome_temporaneo == "@" || nome_temporaneo[0] == '@') // non si può modificare un prodotto eliminato logicamente
                {
                    MessageBox.Show("Errore nella cancellazione del prodotto", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    RicercaDicotomica(ref posizione, nome_temporaneo);

                    if (posizione == -1)
                    {
                        MessageBox.Show("Errore nell'eliminazione del prodotto. Nome prodotto non esistente", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else // nessun errore
                    {
                        CancellazioneLogica(posizione);
                        OrdineAlfabetico();
                    }
                }

            }
        }

        // funzione che cancella un prodotto logicamente

        public void CancellazioneLogica(int posizione)
        {
            FileStream file = new FileStream("./file_crud.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryWriter bw = new BinaryWriter(file);
            BinaryReader br = new BinaryReader(file);

            // copio la riga e aggiungo una § davanti alla riga così da renderlo eliminato (teoricamente)

            br.BaseStream.Seek((posizione-1) * size, 0);

            //nome prodotto
            byte[] bit = br.ReadBytes(30);
            string nomeProdotto = Encoding.ASCII.GetString(bit, 0, bit.Length).Trim();

            // prezzo prodotto
            bit = br.ReadBytes(30);
            string PrezzoProdotto = Encoding.ASCII.GetString(bit, 0, bit.Length).Trim();

            // quantità prodotto
            bit = br.ReadBytes(4);
            string quantita = Encoding.ASCII.GetString(bit, 0, bit.Length).Trim();

            // riscrivo la riga
            string rigaeliminata = $"§{nomeProdotto.PadRight(29)}§{PrezzoProdotto.PadRight(29)}§{quantita.PadRight(3)}";
            byte[] strInByte = Encoding.Default.GetBytes(rigaeliminata);
            bw.BaseStream.Seek((posizione-1) * size, SeekOrigin.Begin);
            bw.Write(strInByte);


            file.Close();
            bw.Close();
            br.Close();

            // cancellazione nella struct

            p[posizione-1].nome = $"§{p[posizione - 1].nome}";

        }

        // funzione che trova un prodotto e ne mostra il nome, prezzo, posizione e quantità

        public void TrovaProdotto(int posizione)
        {
            //recupero la quantità ed il prezzo

            FileStream file = new FileStream("./file_crud.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryReader br = new BinaryReader(file);

            // copio la riga e aggiungo una § davanti alla riga così da renderlo eliminato (teoricamente)

            br.BaseStream.Seek((posizione - 1) * size, 0);

            // prezzo prodotto
            byte[] bit = br.ReadBytes(30);
            bit = br.ReadBytes(30);
            string PrezzoProdotto = Encoding.ASCII.GetString(bit, 0, bit.Length).Trim();

            // quantità prodotto
            bit = br.ReadBytes(4);
            string quantita = Encoding.ASCII.GetString(bit, 0, bit.Length).Trim();

            MessageBox.Show($"Nome: {p[posizione-1].nome}\nPrezzo: {PrezzoProdotto}\nPosizione: {p[posizione-1].posizione}\nQuantità: {quantita}");

            file.Close();
            br.Close();
        }

        // ricerca dicotomica per la funzione recupera

        public void RicercaRecupera(ref int posizione, string nome)
        {
           for (int i = 0; i < dim; i++)
           {
                if (p[i].nome[0] == '§')
                {
                    posizione = i;
                }
           }
        }

        // toglie il carattere dell'eliminazione da un prodotto

        public void RecuperaProdotto(int posizione, string nome)
        {
            string parola = "";
            string prodotto = p[posizione].nome;

            for (int i = 0;i < prodotto.Length; i++)
            {
                if (prodotto[i] =='§')
                {

                }
                else
                {
                    parola += prodotto[i];
                }
            }

            // ripristino parola

            if (parola == nome)
            {
                // struct

                p[posizione].nome = nome;

                // file

                FileStream file = new FileStream("./file_crud.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                BinaryReader br = new BinaryReader(file);

                // copio la riga e aggiungo una § davanti alla riga così da renderlo eliminato (teoricamente)

                br.BaseStream.Seek((posizione) * size, 0);

                // prezzo prodotto
                byte[] bit = br.ReadBytes(30);
                bit = br.ReadBytes(30);
                string PrezzoProdotto = Encoding.ASCII.GetString(bit, 1, bit.Length-1).Trim();
                /*
                string frase = "";
                for (int i = 0; i < PrezzoProdotto.Length; i++)
                {
                    if (PrezzoProdotto[i]  !=  '§')
                    {
                        frase += PrezzoProdotto[i];
                    }
                }
                PrezzoProdotto = frase;
                */

                // quantità prodotto

                bit = br.ReadBytes(4);
                string quantita = Encoding.ASCII.GetString(bit, 1, bit.Length-1).Trim();

               /* for (int i = 0; i < quantita.Length; i++)
                {
                    if (quantita[i] != '§')
                    {
                        frase += quantita[i];
                    }
                }
                quantita = frase;
               */

                // scrittura

                BinaryWriter bw = new BinaryWriter(file);

                string rigaeliminata = $"{p[posizione].nome.PadRight(30)}{PrezzoProdotto.PadRight(30)}{quantita.PadRight(4)}";
                byte[] strInByte = Encoding.Default.GetBytes(rigaeliminata);
                bw.BaseStream.Seek((posizione) * size, SeekOrigin.Begin);
                bw.Write(strInByte);


                file.Close();
                bw.Close();
                br.Close();
            }
            
        }

        private void annulla_Click(object sender, EventArgs e)
        {
            // rendo visibili alcuni elementi

            aggiungi.Visible = true;
            modifica_prodotto.Visible = true;
            elimina.Visible = true;
            resetta_file.Visible = true;
            visualizza_file.Visible = true;
            recupera.Visible = true;
            trova_prodotto.Visible=true;
            //trova_indice.Visible = true;

            // rendo visibile le due scelte di cancellazione

            cancellazione_fisica.Visible = false;
            cancellazione_logica.Visible = false;
            annulla.Visible = false;
            titolo_cancellazione.Visible = false;
        }

        
        // trova prodotto
        private void trova_prodotto_Click(object sender, EventArgs e)
        {
            // input prodotto da eliminare

            string titolo_input = "Eliminazione Prodotto - NOME", esempio = "nome prodotto", frase = "Inserisci il nome del prodotto che vuoi eliminare";
            object input_eliminaprodotto = Interaction.InputBox(frase, titolo_input, esempio);

            if ((string)input_eliminaprodotto == "") // user esce o lascia il campo vuoto
            {
                MessageBox.Show("Errore nell'eliminazione del prodotto", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else // se inserisce input "corretto"
            {
                string nome_temporaneo = (string)input_eliminaprodotto;
                int posizione = -1; // se rimane -1, allora l'utente ha sbagliato a scrivere

                if (nome_temporaneo[0] == '§' || nome_temporaneo == "@" || nome_temporaneo[0] == '@'|| nome_temporaneo =="") // non si può modificare un prodotto eliminato logicamente
                {
                    MessageBox.Show("Prodotto errato", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    RicercaDicotomica(ref posizione, nome_temporaneo);

                    if (posizione == -1)
                    {
                        MessageBox.Show("Nome prodotto non esistente", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else // nessun errore
                    {
                        TrovaProdotto(posizione);
                    }
                }

            }
        }

        // recupera un prodotto eliminato logicamente
        private void recupera_Click(object sender, EventArgs e)
        {
            // input prodotto da eliminare

            string titolo_input = "Eliminazione Prodotto - NOME", esempio = "nome prodotto", frase = "Inserisci il nome del prodotto che vuoi eliminare";
            object input_eliminaprodotto = Interaction.InputBox(frase, titolo_input, esempio);

            if ((string)input_eliminaprodotto == "") // user esce o lascia il campo vuoto
            {
                MessageBox.Show("Errore nella ricerca del prodotto", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else // se inserisce input "corretto"
            {
                string nome_temporaneo = (string)input_eliminaprodotto;
                int posizione = -1; // se rimane -1, allora l'utente ha sbagliato a scrivere

                if (nome_temporaneo[0] == '§' || nome_temporaneo == "@" || nome_temporaneo[0] == '@' || nome_temporaneo == "") // non si può modificare un prodotto eliminato logicamente
                {
                    MessageBox.Show("Prodotto errato", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    RicercaRecupera(ref posizione, nome_temporaneo);

                    if (posizione == -1)
                    {
                        MessageBox.Show("Nome prodotto non esistente", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else // nessun errore
                    {
                        RecuperaProdotto(posizione, nome_temporaneo);
                    }
                }

            }
        }
    }
}
    