

namespace Practica2_Nico.Core.Reparaciones
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    class ReparacionCompleja:Reparacion
    {
        Aparato a;
        double t;
        double factor = 1.25;
        public ReparacionCompleja(Aparato p,double tiempo) : base(p, tiempo)
        {
            this.a = p;
            this.t = tiempo;
            this.Factura = this.Cobro();
        }
        public  double Cobro()
        {
            double total = precio_base + (this.t * this.a.Precio*factor)+prez_piezas;
            this.Factura = total;
            return total;

        }
        /// <summary>
        /// Metodo para devolver el objeto en cadena
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents de current <see cref="Practica2_Nico.Core.Reparaciones.ReparacionCompleja"/></returns>
        public override string ToString()
        {
            StringBuilder bld = new StringBuilder();
            bld.Append(base.ToString());
            bld.Append("\n");
            bld.Append("Factura: " + this.Cobro());
            bld.Append("\n");

            return bld.ToString();

        }


    }
}
