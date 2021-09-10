

namespace Practica2_Nico.Core.Reparaciones
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    class SustitucionPiezas:Reparacion
    {
        Aparato p;
        double t;
        public SustitucionPiezas(Aparato p, double tiempo) : base(p, tiempo)
        {
            this.p = p;
            this.t = tiempo;
            this.Factura = this.Cobro();
        }

        public  double Cobro()
        {
            double total = precio_base+(this.t*this.p.Precio)+this.Prez_piezas;
            this.Factura=total;

            return total;

        }
        /// <summary>
        /// Metodo para devolver el objeto en cadena
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents de current <see cref="Practica2_Nico.Core.Reparaciones.SustitucionPiezas"/></returns>
        public override string ToString()
        {
            StringBuilder bld = new StringBuilder();
            bld.Append(base.ToString());
            bld.Append("\n");
            bld.Append("Factura: "+this.Cobro());
            bld.Append("\n");

            return bld.ToString();

        }

    }
}
