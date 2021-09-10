

namespace Practica2_Nico.Core
{
    using Practica2_Nico.Core.Reparaciones;
    using System;
    using System.Collections.Generic;
    using System.Text;
    abstract class Reparacion
    {
        public const int precio_base = 10;
        public double  prez_piezas=0;
        public double factura = 0;
        /// <summary>
        /// Constructor de Reparacion que recibe un objeto aparato y un tiempo
        /// </summary>
        /// <param name="p"></param>
        /// <param name="tiempo"></param>
        public Reparacion(Aparato p,double tiempo)
        {
            this.Aparato = p;
            this.Tiempo = tiempo;
        }
        /// <summary>
        /// Crea la reparacion adecuada
        /// </summary>
        /// <returns>El <see cref="Reparacion"/> que mejor se adapta</returns>
        /// <param name="tiempo">El tiempo de la reparacion.</param>
        /// <param name="aparato">El aparato que vamos reparar.</param>
        public static Reparacion Crea(double tiempo,Aparato p)
        {
            Reparacion toret = null;

            if (tiempo <= 1 && tiempo>0)
            {
                toret = new SustitucionPiezas(p,tiempo);
            }
            else
            {
                toret = new ReparacionCompleja(p,tiempo);
            }

            return toret;
        }
        /// <summary>
        /// Devuelve el aparato de la reparacion
        /// </summary>
        public Aparato Aparato
        {
            get;
        }
        /// <summary>
        /// Devuelve el tiempo
        /// </summary>
        public double Tiempo
        {
            get;
            private set;
        }
        /// <summary>
        /// Devuelve el tiempo
        /// </summary>
        public double Prez_piezas
        {
            get { return prez_piezas; }
            private set { prez_piezas = value; }
        }
        /// <summary>
        /// Devuelve la factura
        /// </summary>
        public double Factura
        {
            get { return factura; }
            set { factura = value; }
        }
        /// <summary>
        /// Metodo para devolver el objeto en cadena
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents de current <see cref="Practica2_Nico.Core.Reparacion"/></returns>
        public override string ToString()
        {
            StringBuilder bld = new StringBuilder();
            bld.Append("\n");
            bld.Append("REPARACION:");
            bld.Append("\n");
            bld.Append(this.Aparato.ToString());
            bld.Append("\n");
   
            return bld.ToString();

        }
    }
}
