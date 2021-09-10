

namespace Practica2_Nico.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Clase BASE
    /// </summary>
    public class Aparato
    {

        public Aparato(int numserie,string modelo,double precio)
        {
            this.NumSerie = numserie;
            this.Modelo = modelo;
            this.Precio = precio;
        }
        /// <summary>
        /// Devuelve el numero de serie del aparato
        /// </summary>
        /// <value>El numero de serie</value>
        public int NumSerie
        {
            get;
            private set;
        }
        /// <summary>
        /// Devuelve el modelo
        /// </summary>
        /// <value>El modelo del aparato</value>
        public string Modelo
        {
            get;
            private set;
        }
      /// <summary>
      /// Devuelve el precio
      /// </summary>
      /// <value>El precio que cuesta el aparato</value>
        public double Precio
        {
            get; private set;
        }
        /// <summary>
        /// Metodo para devolver el objeto en cadena
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents de current <see cref="Practica2_Nico.Core.Aparato"/></returns>
        public override string ToString()
        {
            StringBuilder bld = new StringBuilder();
            bld.AppendFormat("Numero de serie: {0}", this.NumSerie);
            bld.Append("\n");
            bld.AppendFormat("Modelo: {0}", this.Modelo);
            bld.Append("\n");
            bld.AppendFormat("Precio: {0}", this.Precio);
            return bld.ToString();
        }
    }
}
