

namespace Practica2_Nico.Core.Aparatos
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    class Televisor:Aparato
    {
        public const int precio = 10;
        public Televisor(int numserie, string modelo, double numpulgadas) : base(numserie, modelo, precio)
        {
            this.Pulgadas = numpulgadas;
        }
        /// <summary>
        /// Devuelve el numero de pulgadas
        /// </summary>
        /// <value>Recibe en numero de pulgadas</value>
        public double Pulgadas
        {
            get;
            private set;
        }
        /// <summary>
        /// Metodo para devolver el objeto en cadena
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents de current <see cref="Practica2_Nico.Core.Aparatos.Televisor"/></returns>
        public override string ToString()
        {
            StringBuilder bld = new StringBuilder();
            bld.Append(base.ToString());
            bld.Append("\n");
            bld.Append("TELEVISOR:");
            bld.Append("\n");
            bld.Append("Pulgadas:" + this.Pulgadas);
            return bld.ToString();

        }
    }
}
