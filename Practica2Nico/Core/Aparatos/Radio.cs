

namespace Practica2_Nico.Core.Aparatos
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    class Radio:Aparato
    {
        public const int precio = 5;
        /// <summary>
        /// Metodo constructor de Radio que hereda los atributos de Aparato
        /// </summary>
        /// <param name="numserie">Parametro de la clase base Aparato</param>
        /// <param name="modelo">Parametro de la clase base Aparato</param>
        /// <param name="banda">Parametro propio de la clase Radio</param>
        public Radio(int numserie,string modelo,string banda):base(numserie,modelo,precio)
        {
            this.Banda = banda;
        }
        /// <summary>
        /// Devuelve la cadena de Banda
        /// </summary>
        /// <value>Banda que posee la radio</value>
        public string Banda
        {
            get;
            private set;
        }
        /// <summary>
        /// Metodo para devolver el objeto en cadena
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents de current <see cref="Practica2_Nico.Core.Aparatos.Radio"/></returns>
        public override string ToString()
        {
            StringBuilder bld = new StringBuilder();
            bld.Append(base.ToString());
            bld.Append("\n");
            bld.Append("RADIO:");
            bld.Append("\n");
            bld.Append("banda:"+this.Banda);
            return bld.ToString();

        }
    }
}
