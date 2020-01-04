using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5
{
    /// <summary>
    /// Indelio duomenu saugojimo klase
    /// </summary>
    public class Indelis:IComparable<Indelis>
    {
        public string AsmensKodas { get; set; }                  //asmens kodas      
        public double IndelioKoef { get; set; }                  //indelio koeficientas

        /// <summary>
        ///konstruktorius be parametru 
        /// </summary>
        public Indelis()
        { }
        /// <summary>
        /// konstruktorius
        /// </summary>
        /// <param name="asmensKodas">asmens kodas</param>
        /// <param name="indelis">indelio koeficientas </param>
        public Indelis(string asmensKodas,double indelis)
        {          
            AsmensKodas = asmensKodas;
            IndelioKoef = indelis;
        }
        /// <summary>
        ///  Uzklotas operatorius ToString()
        /// </summary>
        /// <returns>grazina suformuota eilute</returns>
        public override string ToString()
        {
            string eilute  = String.Format("{0} {1}",AsmensKodas,IndelioKoef);
            return eilute;
        }
        /// <summary>
        /// CompareTo metodas
        /// </summary>
        /// <param name="kitas">kitas indelio elementas</param>
        /// <returns>jei elementas tuscias,tai grazina 1,
        /// jei nelygu 0,tai lygina pagal indelio koef.,kitu atveju lygina pagal asmens koda</returns>
        public int CompareTo(Indelis kitas)
        {
            if (kitas == null)
                return 1;
            if (IndelioKoef.CompareTo(kitas.IndelioKoef) != 0)
                return IndelioKoef.CompareTo(kitas.IndelioKoef);
            else
                return AsmensKodas.CompareTo(kitas.AsmensKodas);
        }


    }
}
