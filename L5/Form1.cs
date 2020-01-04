using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace L5
{
    public partial class Form1 : Form
    {
        /// Konstantos        
        const string CFr = "Rezultatai.txt";                                 // rezultatu failas
        const string CFn = "Nurodymai.txt";                                 // nurodymų failo vardas 
       
        Sarasas<Darbuotojas> Darbuotojai;                                     //Darbuotoju duomenys
        Sarasas<Indelis> Indeliai = new Sarasas<Indelis>();                   //Indeliu duomenys
        List<Premija> Premijos = new List<Premija>();                         //Premijos
        
        Sarasas<Darbuotojas> MaziauUzdirbe = new Sarasas<Darbuotojas>();           //Maziausiai uzdirbusiu darbuotoju sarasas
        Sarasas<Indelis> MaziKoef;                                                 //Maziausiu koef. sarasas

        Sarasas<Darbuotojas> Pavedimai ;                                          // Pavedimu sarasas
     
        public Form1()
        {
            //Jei rezultatu failas egzistuoja,ji isvalo
            if (File.Exists(CFr))
                File.Delete(CFr);

            InitializeComponent();

            // Nurodyti meniu punktai padaromi pasyviais 
            darbuotojuPremijosToolStripMenuItem.Enabled = false;
            maziausiaiUzdirbeToolStripMenuItem.Enabled = false;
            PavedimuFormavimas.Enabled = false;
            spausdintiDuomenisToolStripMenuItem.Enabled = false;
        }

        //-----------------------------------------------------
        // Grafines sasajos valdymo metodai
        //-----------------------------------------------------
        /// <summary>
        /// Menu punkto "Baigti" atliekami veiksmai
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void baigtiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Menu punkto "Ivesti" atliekami veiksmai
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ivestiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // OpenFileDialog komponento savybių nustatymas 
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";             // filtras
            openFileDialog1.Title = "Pasirinkite duomenų failą";                               // pavadinimas
            DialogResult result = openFileDialog1.ShowDialog();

            OpenFileDialog openFileDialog2 = new OpenFileDialog();
            openFileDialog2.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog2.Title = "Pasirinkite duomenų failą";
            DialogResult result2 = openFileDialog2.ShowDialog();

            // jeigu pasirinktas failas
            if (result == DialogResult.OK)
            {
                string fv = openFileDialog1.FileName;                             // fv - duomenu failo vardas

                //Duomenu parodymas richtextboxe                
                Darbuot.LoadFile(fv, RichTextBoxStreamType.PlainText);
                //Nuskaitymas
                Darbuotojai = SkaitytiDarbuotojus(fv);
                
            }

            // jeigu pasirinktas failas
            if (result2 == DialogResult.OK)
            {
                string fv2 = openFileDialog2.FileName;

                Indel.LoadFile(fv2, RichTextBoxStreamType.PlainText);

                SkaitytiIndelius(fv2, Indeliai, Premijos);
            }

        
            // Meniu punktų nustatymai
            ivestiToolStripMenuItem.Enabled = false;
            darbuotojuPremijosToolStripMenuItem.Enabled = true;
            maziausiaiUzdirbeToolStripMenuItem.Enabled = true;
            PavedimuFormavimas.Enabled = true;
            spausdintiDuomenisToolStripMenuItem.Enabled = true;

        }

        /// <summary>
        /// Menu punkto "Pavedimu formavimas" atliekami veiksmai
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PavedimuFormavimas_Click(object sender, EventArgs e)
        {
            //Klaidos isvedimas jei textboxe yra tuscia vieta

            if (bankoPavIvedimas.Text.Trim() == "")
            {
                MessageBox.Show("Klaida! Prasom ivesti banko pavadinima");
            }

            else 
            {
                //vartotojo ivestas banko pavadinimas
                string bankoPav = bankoPavIvedimas.Text;
                //atrenka bankus ir susformuoja pavedimu sarasa
                Pavedimai = BankuAtrinkimas(Darbuotojai, bankoPav);
                //Rezultatu parodymas richtextboxe
                Rezultatai.AppendText("\n Pavedimu sarasas\n");
                for (Pavedimai.Pradzia(); Pavedimai.Yra(); Pavedimai.Kitas())
                {
                    Rezultatai.AppendText(Pavedimai.ImtiDuomenis().ToString() + "\n");
                }
                //tikrina ar pavedimu sarasas netuscias
                Pavedimai.Pradzia();
                if (Pavedimai.Yra())
                  SpausdintiDarbuotojus(CFr, Pavedimai, "Atrinkti bankai");
                else
                    MessageBox.Show("Tokio banko nera!");

                //po atrinkimo sunaikinamas sarasas
                Pavedimai.Naikinti();

            }
        }

        /// <summary>
        /// Menu punkto "Darbuotoju Premijos " atliekami veiksmai
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void darbuotojuPremijosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Suskaiciuoja visu temu premijos dydi kiekvienam darbuotojui
            SkaiciuotiKiekviena(CFr, Indeliai, Premijos);
            //Suskaiciuoja bendros sumos premijas kiekvienam darbuotojui
            SkaiciuotiBendra(CFr,Indeliai, Premijos);
            //Parodo rezultatus
            Rezultatai.LoadFile(CFr, RichTextBoxStreamType.PlainText);

            darbuotojuPremijosToolStripMenuItem.Enabled = false;
        }

        /// <summary>
        /// Menu punkto "Maziausiai uzdirbe" atliekami veiksmai
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void maziausiaiUzdirbeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Suformuoja mazu koef. sarasa
            MaziKoef = Formuoti(Indeliai);

            for (MaziKoef.Pradzia(); MaziKoef.Yra(); MaziKoef.Kitas())
            {
                string id = MaziKoef.ImtiDuomenis().AsmensKodas;
                //remiantis mazu koef. sarasu pagal asmens koda suformuoja darbuotoju sarasa      
                FormavimasDarbuotojuSaraso(Darbuotojai, MaziauUzdirbe, id);

            }

            //Rezultatu parodymas richtextboxe
            Rezultatai.AppendText("\nDarbuotoju uzdirbusiu maziau uz vidurki sarasas\n");
            for (MaziauUzdirbe.Pradzia(); MaziauUzdirbe.Yra();MaziauUzdirbe.Kitas() )
            {
                Rezultatai.AppendText(MaziauUzdirbe.ImtiDuomenis().ToString() + "\n");
            }
            //tikrina ar maz.uzdirbusiu sarasas netuscias
            MaziauUzdirbe.Pradzia();
            if(MaziauUzdirbe.Yra())
            SpausdintiDarbuotojus(CFr, MaziauUzdirbe, "Maziausiai uzdirbe");
            else
                MessageBox.Show("Sarasas tuscias!");

            maziausiaiUzdirbeToolStripMenuItem.Enabled = false;
        }
        /// <summary>
        /// Menu punkto "Spausdinti duomenis" atliekami veiksmai
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spausdintiDuomenisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpausdintiDarbuotojus(CFr, Darbuotojai, "Darbuotoju duomenys");

            SpausdintiIndelius(CFr, Indeliai, Premijos, " duomenys apie indelius i darba");
        }
        /// <summary>
        /// Menu punkto "Pagalba" atliekami veiksmai
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pagalbaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rezultatai.LoadFile(CFn, RichTextBoxStreamType.PlainText);
        }

        //------------------------------------------------------------
        // Uzduoties metodai
        //------------------------------------------------------------
        /// <summary>
        /// Skaito darbuotoju sarasa is failo
        /// </summary>
        /// <param name="fv">failo vardas</param>
        /// <returns>grazina sudeta sarasa tiesiogine tvarka</returns>
        static Sarasas<Darbuotojas> SkaitytiDarbuotojus(string fv)
        {
            var Darbuotojai = new Sarasas<Darbuotojas>();

            using (var reader = new StreamReader(fv, Encoding.GetEncoding(1257)))
            {
                string eilute;                                                // visa duomenu failo eilute
                while ((eilute = reader.ReadLine()) != null)
                {
                    string[] parts = eilute.Split(';');
                    string kodas = parts[0].Trim();
                    string pavrd = parts[1];
                    string vard = parts[2];
                    string bankas = parts[3].Trim();
                    string saskaita = parts[4].Trim();
                    Darbuotojas darb = new Darbuotojas(kodas, pavrd, vard, bankas, saskaita);
                    Darbuotojai.DetiDuomTiesiog(darb);
                }
            }

            return Darbuotojai;
        }

        /// <summary>
        /// Skaito indeliu sarasa ir premijas is failo
        /// </summary>
        /// <param name="fv">failo vardas</param>
        /// <param name="Indeliai">indeliu koef sarasas</param>
        /// <param name="Premijos">premiju sarasas</param>
        static void SkaitytiIndelius(string fv, Sarasas<Indelis> Indeliai, List<Premija> Premijos)
        {            
            using (var reader = new StreamReader(fv, Encoding.GetEncoding(1257)))
            {
                string pirmaeil = reader.ReadLine();
                string[] eildalis = pirmaeil.Split(';');

                for (int i = 0; i < eildalis.Length - 1; i++)
                {
                    double premija = double.Parse(eildalis[i]);
                    Premija prem = new Premija(premija);
                    Premijos.Add(prem);
                }


                string eilute;                                                // visa duomenu failo eilute
                while ((eilute = reader.ReadLine()) != null)
                {
                    string[] parts = eilute.Split(';');
                    string kodas = parts[0];
                    double koef = double.Parse(parts[1]);
                    Indelis indel = new Indelis(kodas, koef);
                    Indeliai.DetiDuomTiesiog(indel);
                }
            }
        }

        /// <summary>
        /// Spausdina darbuotoju sarasa i faila
        /// </summary>
        /// <param name="fv">failo vardas</param>
        /// <param name="Darb">darbuotoju sarasas</param>
        /// <param name="antraste">antraste</param>
        static void SpausdintiDarbuotojus(string fv, Sarasas<Darbuotojas> Darb, string antraste)
        {
            string eilute = new string('-', 60);
            using (var fr = new StreamWriter(File.Open(fv, FileMode.Append), Encoding.GetEncoding(1257)))
            {

                fr.WriteLine("\n" + antraste);
                fr.WriteLine(eilute);
                fr.WriteLine("Asmens kodas  Pavarde  Vardas Bankas SaskaitosNr");
                fr.WriteLine(eilute);
                for (Darb.Pradzia(); Darb.Yra(); Darb.Kitas())
                {
                    fr.WriteLine("{0}", Darb.ImtiDuomenis().ToString());
                }
                fr.WriteLine(eilute);

            }

        }

        /// <summary>
        /// Spausdina Indeliu sarasa kartu su premijomis i faila
        /// </summary>
        /// <param name="fv">failo vardas</param>
        /// <param name="Indel">indeliu sarasas</param>
        /// <param name="Premijos">premiju sarasas</param>
        /// <param name="antraste">antraste</param>
        static void SpausdintiIndelius(string fv, Sarasas<Indelis> Indel, List<Premija> Premijos, string antraste)
        {
            string eilute = new string('-', 55);
            using (var fr = new StreamWriter(File.Open(fv, FileMode.Append), Encoding.GetEncoding(1257)))
            {

                fr.WriteLine("\n" + antraste);
                fr.WriteLine(eilute);
                fr.WriteLine("Premiju sarasas");
                fr.WriteLine(eilute);
                for (int i = 0; i < Premijos.Count; i++)
                {
                    fr.WriteLine("{0}", Premijos[i].PremijosDydis);
                }
                fr.WriteLine(eilute);
                fr.WriteLine("Asmens kodas Koef.");
                fr.WriteLine(eilute);
                for (Indel.Pradzia(); Indel.Yra(); Indel.Kitas())
                {
                    fr.WriteLine("{0}", Indel.ImtiDuomenis().ToString());
                }
                fr.WriteLine(eilute);

            }

        }

       /// <summary>
       /// Indeliu Koef. suma
       /// </summary>
       /// <param name="Indel">Indeliu sarasas</param>
       /// <returns>grazina koef.suma</returns>
        static double KoefSuma(Sarasas<Indelis> Indel)
        {
            double ats = 0;

            for (Indel.Pradzia(); Indel.Yra(); Indel.Kitas())
            {
                Indelis duom = Indel.ImtiDuomenis();

                ats = ats + duom.IndelioKoef;

            }

            return ats;

        }

        /// <summary>
        /// Suskaiciuoja kiekvienos temos darbuotoju premijos dydi
        /// </summary>
        /// <param name="fv">failo vardas</param>
        /// <param name="indeliai">indeliu sarasas</param>
        /// <param name="premijos">premiju sarasas</param>
        static void SkaiciuotiKiekviena(string fv, Sarasas<Indelis> indeliai, List<Premija> premijos)
        {

            double ats1 = 0;
            double ats2 = 0;
            double ats3 = 0;
            double ats4 = 0;

            double premija1 = premijos[0].PremijosDydis / KoefSuma(indeliai);
            double premija2 = premijos[1].PremijosDydis / KoefSuma(indeliai);
            double premija3 = premijos[2].PremijosDydis / KoefSuma(indeliai);
            double premija4 = premijos[3].PremijosDydis / KoefSuma(indeliai);
           
            using (var fr = File.AppendText(CFr))
            {
                fr.WriteLine("Premijos dydziai");
                fr.WriteLine("----------------------------------------------------");
                fr.WriteLine("Asmens kodas 1tema 2tema 3tema 4tema");
                fr.WriteLine("----------------------------------------------------");
                for (indeliai.Pradzia(); indeliai.Yra(); indeliai.Kitas())
                {
                    Indelis duom = indeliai.ImtiDuomenis();

                    ats1 = premija1 * duom.IndelioKoef;
                    ats2 = premija2 * duom.IndelioKoef;
                    ats3 = premija3 * duom.IndelioKoef;
                    ats4 = premija4 * duom.IndelioKoef;
                  
                    fr.WriteLine("{0} {1:f2} {2:f2} {3:f2} {4:f2}", duom.AsmensKodas,ats1, ats2, ats3, ats4);
                   
                }
                fr.WriteLine("----------------------------------------------------");
            }
        }
        /// <summary>
        /// Suskaiciuoja darbuotoju premijos dydi pagal visu temu bendra suma
        /// </summary>
        /// <param name="fv">failo vardas</param>
        /// <param name="indeliai">indeliu sarasas</param>
        /// <param name="premijos">premijos sarasas</param>
        /// <returns>premijos dydi pagal bendra suma</returns>
        static double SkaiciuotiBendra(string fv,Sarasas<Indelis> indeliai, List<Premija> premijos)
        {
            double atsbendra = 0;

            double bendra = (premijos[0].PremijosDydis + premijos[1].PremijosDydis
              + premijos[2].PremijosDydis + premijos[3].PremijosDydis) / KoefSuma(indeliai);

            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine("Asmens kodas Bendra");
                fr.WriteLine("----------------------------------------------------");
                for (indeliai.Pradzia(); indeliai.Yra(); indeliai.Kitas())
                {
                    Indelis duom = indeliai.ImtiDuomenis();
                    atsbendra = bendra * duom.IndelioKoef;

                    fr.WriteLine("{0} {1:f2}",duom.AsmensKodas, atsbendra);
                }

                return atsbendra;
            }
        }

        /// <summary>
        /// Suformuoja indeliu koef. sarasa mazesni uz vidurki
        /// </summary>
        /// <param name="indeliai">indeliu sarasas</param>
        /// <returns>grazina suformuota sarasa</returns>
        static Sarasas<Indelis> Formuoti(Sarasas<Indelis> indeliai )
        {
            var Naujas = new Sarasas<Indelis>();
            
            double vidurkis = Vidurkis( indeliai);
            
            for (indeliai.Pradzia(); indeliai.Yra(); indeliai.Kitas())
            {
                Indelis duom = indeliai.ImtiDuomenis();
                if (vidurkis > duom.IndelioKoef)
                    Naujas.DetiDuomTiesiog(duom);
            }

            return Naujas;
        }

        /// <summary>
        /// Suformuoja darbuotoju sarasa pagal asmens koda
        /// </summary>
        /// <param name="Darb">darbuotoju sarasas</param>
        /// <param name="Naujas">atrinktu darbuotoju sarasas</param>
        /// <param name="kodas">asmens kodas</param>
        static void FormavimasDarbuotojuSaraso(Sarasas<Darbuotojas> Darb, Sarasas<Darbuotojas> Naujas, string kodas)
        {
            for (Darb.Pradzia(); Darb.Yra(); Darb.Kitas())
            {
                Darbuotojas duom = Darb.ImtiDuomenis();
                if (duom.AsmensKodas == kodas)
                    Naujas.DetiDuomTiesiog(duom);
            }
        }

        /// <summary>
        /// Suranda indeliu vidurki
        /// </summary>
        /// <param name="indeliai">indeliu sarasas</param>
        /// <returns>grazina vidurki</returns>
        static double Vidurkis( Sarasas<Indelis> indeliai)
        {
            int kiekis = 0;
            double suma = 0;
            double vid = 0;

            for (indeliai.Pradzia(); indeliai.Yra(); indeliai.Kitas())
            {
                suma = suma + indeliai.ImtiDuomenis().IndelioKoef;
                kiekis++;
            }

            // Jei vidurkis lygus nuliui,tai grazina nuli
            if (kiekis != 0)
                return vid = (double)suma / kiekis;
            else
                return 0;


        }

        /// <summary>
        /// Atrenka Darbuotojus pagal banko pavadinima
        /// </summary>
        /// <param name="Darb">darbuotoju sarasas</param>
        /// <param name="bankas">banko pavadinimas</param>
        /// <returns>grazina suformuota sarasa</returns>
        static Sarasas<Darbuotojas> BankuAtrinkimas(Sarasas<Darbuotojas> Darb, string bankas)
        {
            var DarbPagalBankus = new Sarasas<Darbuotojas>();
            for (Darb.Pradzia(); Darb.Yra(); Darb.Kitas())
            {
                Darbuotojas duom = Darb.ImtiDuomenis();
                if (duom.BankoPav == bankas)
                    DarbPagalBankus.DetiDuomTiesiog(duom);
            }

            return DarbPagalBankus;
        }

    }
}
