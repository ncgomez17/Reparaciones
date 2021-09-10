
namespace Practica2_Nico.Core.Aparatos
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Adaptador : Aparato
    {

        public const int precio = 5;
        /// <summary>
        /// Metodo constructor de Adaptador que hereda de Aparato, en este caso solo recibe dos argumentos
        /// </summary>
        /// <param name="numSerie"></param>
        /// <param name="modelo"></param>
        public Adaptador(int numSerie, string modelo) : base(numSerie, modelo,precio)
        {
            this.Grabando = false;

        }
        /// <summary>
        /// Metodo constructor de Adaptador que hereda de Aparato, en este caso recibe tres argumentos
        /// </summary>
        /// <param name="numSerie"></param>
        /// <param name="modelo"></param>
        /// <param name="tiempo"></param>
        public Adaptador(int numSerie, string modelo,int tiempo) : base(numSerie, modelo, precio)
        {
            this.Grabando = true;
            this.TiempoMax = tiempo;

        }
        /// <summary>
        /// Metodo que devuelve si el item puede grabar
        /// </summary>
        /// <value>booleano que nos dice si puede grabar</value>
        public bool Grabando
        {
            get;
            private set;
        }
        /// <summary>
        /// Metodo que devuelve el tiempo maximo de grabacion
        /// </summary>
        /// <value>`tiempo maximo</value>
        public double TiempoMax
        {
            get;
            private set;
        }
        /// <summary>
        /// Metodo para devolver el objeto en cadena
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents de current <see cref="Practica2_Nico.Core.Aparatos.Adaptador"/></returns>
        public override string ToString()
        {
            StringBuilder bld = new StringBuilder();
            bld.Append(base.ToString());
            bld.Append("\n");
            bld.Append("ADAPTADOR:");
            bld.Append("\n");
            bld.Append("Tiempo_max:" + this.TiempoMax);
            return bld.ToString();

        }

    }
}
