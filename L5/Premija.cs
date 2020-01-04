using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5
{
    /// <summary>
    /// premijos klase
    /// </summary>
    class Premija
    {
        public double PremijosDydis { get; set; }             //premijos dydis(Eu)

        /// <summary>
        /// konstruktorius be parametru
        /// </summary>
        public Premija()
        { }
        /// <summary>
        /// konstruktorius
        /// </summary>
        /// <param name="premija">premijos dydis</param>
        public Premija(double premija)
        {
            PremijosDydis = premija;
        }
    }
}
