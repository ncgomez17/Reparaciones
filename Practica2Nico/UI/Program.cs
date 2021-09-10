
namespace Practica2_Nico
{
    using Practica2_Nico.Core;
    using Practica2_Nico.Core.Aparatos;
    using Practica2Nico.UI;
    using System;
    using System.Collections.Generic;

    using WForms = System.Windows.Forms;
    class Program
    {
        static void Main(string[] args)
        {
            /*
             Aparato p1 = new Radio(5, "alpha","FM");
             Aparato p2 = new Televisor(6, "alpha",45.6);
             Aparato p3 = new Adaptador(7, "zeta");
             Aparato p4 = new Adaptador(8, "zeta",50);
             Aparato p5 = new Reproductor(9, "zeta",false);
             Aparato p6 = new Reproductor(10, "zeta",true,50);
            */
            /*  Console.WriteLine(p1.ToString());
              Console.WriteLine(p2.ToString());
              Console.WriteLine(p3.ToString());
              Console.WriteLine(p4.ToString());
              Console.WriteLine(p5.ToString());
              Console.WriteLine(p6.ToString());
         */
            /*
           List<Reparacion> l = new List<Reparacion>();
           Reparacion r=Reparacion.Crea(0.5,p4);
           Reparacion s2 = Reparacion.Crea(25, p6);
           r.prez_piezas = 50;
           l.Add(r);
           l.Add(s2);
           RegistroReparaciones v = new RegistroReparaciones(l);
           v.GuardaXml();
           RegistroReparaciones x= RegistroReparaciones.RecuperaXml("reparaciones.xml");
           System.Console.WriteLine(x.ToString());
            */
           
            WForms.Application.Run(new MainWindowCtrl().ViewPrincipal);

        }
    }
}
