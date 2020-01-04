using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5
{
    /// <summary>
    /// Saraso elemento klase
    /// </summary>
    /// <typeparam name="T">tipas</typeparam>
    public sealed class Mazgas<T> where T:IComparable<T>
    {
        public T Duomenys { get; set; }
        public Mazgas<T> Kitas { get; set; }

        //konstruktorius be parametru
        public Mazgas() { }

        /// <summary>
        /// konstruktorius
        /// </summary>
        /// <param name="duomenys">darbuotoju duomenys</param>
        /// <param name="adresas">saraso adresas</param>
        public Mazgas(T duomenys, Mazgas<T> adresas)
        {
            this.Duomenys = duomenys;
            this.Kitas = adresas;
        }
    }
}
