using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5
{
    /// <summary>
    /// Darbuotojo duomenu saugojimo klase
    /// </summary>
    public class Darbuotojas:IComparable<Darbuotojas>
    {
        //Darbuotojo informacija
        public string AsmensKodas { get; set; }                         //asmens kodas
        public string Pavarde     { get; set; }                         //pavarde
        public string Vardas      { get; set; }                         //vardas
        public string BankoPav    { get; set; }                         //banko pavadinimas
        public string SaskaitosNr { get; set; }                         //saskaitos numeris

        /// <summary>
        /// konstruktorius be parametru
        /// </summary>
        public Darbuotojas()
        { }
        /// <summary>
        /// konstruktorius
        /// </summary>
        /// <param name="asmensKodas">asmens kodas</param>
        /// <param name="pavarde">pavarde</param>
        /// <param name="vardas">vardas</param>
        /// <param name="bankoPav">banko pavadinimas</param>
        /// <param name="saskaitosNr">saskaitos numeris</param>
        public Darbuotojas(string asmensKodas,string pavarde,string vardas,string bankoPav,string saskaitosNr )
        {
            AsmensKodas = asmensKodas;
            Pavarde = pavarde;
            Vardas = vardas;
            BankoPav = bankoPav;
            SaskaitosNr = saskaitosNr;
        }
        /// <summary>
        /// Uzklotas operatorius ToString()
        /// </summary>
        /// <returns>grazina suformuota eilute</returns>
        public override string ToString()
        {
            string eilute = String.Format("{0} {1} {2} {3,4} {4,6}", AsmensKodas,Pavarde,Vardas,BankoPav,SaskaitosNr);
            return eilute;
        }
        /// <summary>
        /// CompareTo metodas
        /// </summary>
        /// <param name="kitas">kitas darbuotojo elementas</param>
        /// <returns>jei elementas tuscias,tai grazina 1,
        /// jei nelygu 0,tai lygina pagal saskaitos nr,kitu atveju lygina pagal banko pavadinima</returns>
        public int CompareTo(Darbuotojas kitas)
        {
            if(kitas == null)
                return 1;
            if (SaskaitosNr.CompareTo(kitas.SaskaitosNr) != 0)
                return SaskaitosNr.CompareTo(kitas.SaskaitosNr);
            else 
                return BankoPav.CompareTo(kitas.BankoPav);

        }
        
    }
}
