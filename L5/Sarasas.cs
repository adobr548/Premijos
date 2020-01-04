using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5
{
    /// <summary>
    /// bendrine vienkrypcio saraso klase
    /// </summary>
    /// <typeparam name="T">tipas</typeparam>
    public sealed class Sarasas<T> where T:IComparable<T>
    {      
        Mazgas<T> pr;                //saraso pradzios nuoroda
        Mazgas<T> pb;                //saraso pabaigos nuoroda
        Mazgas<T> ss;                //sasajos nuoroda

        /// <summary>
        ///  konstruktorius be parametru
        /// </summary>
        public Sarasas()
        {
            this.pr = null;
            this.pb = null;
            this.ss = null;
        }

        //Sasajos metodai
        /// <summary>
        /// Sąsajai priskiriama sąrašo pradžia
        /// </summary>
        public void Pradzia()
        {
            ss = pr;
        }
        /// <summary>
        /// Sąsajai priskiriamas sąrašo sekantis elementas
        /// </summary>
        public void Kitas()
        {
            ss = ss.Kitas;
        }
        /// <summary>
        /// tikrina ar sąsaja netuščia
        /// </summary>
        /// <returns>Grąžina true, jeigu sąsaja netuščia; false - priešingu atveju</returns>
        public bool Yra()
        {
            return ss != null;
        }
        /// <summary>
        /// Imam duomenis
        /// </summary>
        /// <returns>Grąžina pagalbinės rodyklės rodomo elemento reikšmę</returns>
        public T ImtiDuomenis()
        {
            return ss.Duomenys;
        }
        /// <summary>
        /// sukuriamas sąrašo elementas ir prijungiamas prie sąrašo pabaigos (tiesiog. sar.)
        /// </summary>
        /// <param name="info">naujo elemento reikšmė (duomenys)</param>
        public void DetiDuomTiesiog(T info)
        {
            var d = new Mazgas<T>(info, null);

            if (pr != null)
            {
                pb.Kitas = d;
                pb = d;
            }
            else
            {
                pr = d;
                pb = d;
            }
        }

        /// <summary>
        /// Sunaikinamas sarasas
        /// </summary>
        public void Naikinti()
        {
            while (pr != null)
            {
                ss = pr;
                pr = pr.Kitas;
                ss = null;
            }
            pb = ss = pr;
        }

    }
}
