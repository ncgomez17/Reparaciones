

namespace Practica2_Nico.Core.Aparatos
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    class Reproductor : Aparato
    {
        public const int precio = 10;
        /// <summary>
        /// Metodo constructor de Reproductores DVD que hereda de Aparato
        /// </summary>
        /// <param name="numserie"></param>
        /// <param name="modelo"></param>
        /// <param name="bluray"></param>
        public Reproductor(int numserie, string modelo, bool bluray) : base(numserie, modelo, precio)
        {
            this.Grabar = false;
            this.Bluray = bluray;
        }
        /// <summary>
        /// Metodo constructor de Reproductores DVD que hereda de Aparato con solo dos argumentos
        /// </summary>
        /// <param name="numserie"></param>
        /// <param name="modelo"></param>
        /// <param name="bluray"></param>
        /// <param name="tiempo"></param>
        public Reproductor(int numserie, string modelo, bool bluray, double tiempo) : base(numserie, modelo, precio)
        {
            this.Grabar = true;
            this.Bluray = bluray;
            this.Tiempo = tiempo;
        }
        /// <summary>
        /// Devuelve si puede grabar o no
        /// </summary>
        /// <value>bool</value>
        public bool Grabar
        {
            get;
            private set;

        }
        /// <summary>
        /// Devuelve si puede reproducir o no
        /// </summary>
        /// <value>bool</value>
        public bool Bluray
        {
            get;
            private set;

        }
        public double Tiempo
        {
            get;
            private set;

        }
        /// <summary>
        /// Metodo para devolver el objeto en cadena
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents de current <see cref="Practica2_Nico.Core.Aparatos.Reproductor"/></returns>
        public override string ToString()
        {
            StringBuilder bld = new StringBuilder();
            bld.Append(base.ToString());
            bld.Append("\n");
            bld.Append("REPRODUCTOR DVD:");
            bld.Append("\n");
            if (this.Grabar)
            {
                bld.Append("Puede grabar durante:");
                bld.Append(this.Tiempo);
                bld.Append("\n");
            }
            if (this.Bluray)
            {
                bld.Append("Tiene lector blu-ray");
                bld.Append("\n");
            }
            else
            {
                bld.Append("No tiene lector blu-ray");
                bld.Append("\n");
            }
            return bld.ToString();

        }
    }
    }
