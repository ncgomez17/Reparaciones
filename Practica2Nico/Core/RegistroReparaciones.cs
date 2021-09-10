

namespace Practica2_Nico
{
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Collections;
    using System.Xml.Linq;
    using System.Collections.Generic;
    using Practica2_Nico.Core;
    using Practica2_Nico.Core.Reparaciones;
    using Practica2_Nico.Core.Aparatos;
    using System;
    using System.Linq.Expressions;

    /// <summary>
    /// Clase para registrar las reparaciones en XML
    /// </summary>
    class RegistroReparaciones:IEnumerable<Reparacion>
    {
        public const string ArchivoXML = "reparaciones.xml";
        public const string EtqReparaciones = "reparaciones";
        public const string EtqReparacion = "reparacion";
        private List<Reparacion> reparaciones;
        /// <summary>
        /// Metodo constructor vacio
        /// </summary>
        public RegistroReparaciones()
        {
            this.reparaciones = new List<Reparacion>();
        }
        /// <summary>
        /// Metodo constructor pasandole una lista de constructores
        /// </summary>
        /// <param name="reparaciones"></param>
        public RegistroReparaciones(IEnumerable<Reparacion> reparaciones)
            :this()
        {
            this.reparaciones.AddRange(reparaciones);
        }
        /// <summary>
        /// inserta una reparacion en la lista
        /// </summary>
        /// <param name="r">un objeto reparacion</param>
        public void Add(Reparacion r)
        {
            this.reparaciones.Add(r);
        }
        /// <summary>
        /// elimina el elemento que se pasa de la lista
        /// </summary>
        /// <param name="r">objeto reparacion</param>
        /// <returns>bool</returns>
        public bool Remove(Reparacion r)
        {
            return this.reparaciones.Remove(r);
        }
        /// <summary>
        /// Metodo para eliminar un objeto de la lista pasandole la posicion
        /// </summary>
        /// <param name="i">posicion</param>
        public void RemoveAt(int i)
        {
            this.reparaciones.RemoveAt(i);
        }
        /// <summary>
        /// Inserta varias reparaciones al final de la lista
        /// </summary>
        /// <param name="r">objetos</param>
        public void AddRange(IEnumerable<Reparacion> r)
        {
            this.reparaciones.AddRange(r);
        }
        /// <summary>
        /// Devuelve el total de reparaciones
        /// </summary>
        public int Count
        {
            get { return reparaciones.Count; }
        }
        /// <summary>
        /// Retorna False, pues este registro no es de solo lectura.
        /// </summary>
        /// <value><c>false</c>.</value>
        public bool IsReadOnly
        {
            get { return false; }
        }
        /// <summary>
        /// Elimina todos las reparaciones almacenados.
        /// </summary>
        public void Clear()
        {
            this.reparaciones.Clear();
        }
        /// <summary>
        /// Comprueba si la reparacion dada se encuentra guardada.
        /// </summary>
        /// <returns>True si se encuentra, False en otro caso.</returns>
        /// <param name="v">El <see cref="Viaje"/> a comprobar.</param>
        public bool Contains(Reparacion r)
        {
            return this.reparaciones.Contains(r);
        }
        /// <summary>
        /// Copia las reparaciones a partir de la pos. dada a un vector.
        /// </summary>
        /// <param name="v">El vector al que copiar las reparaciones.</param>
        /// <param name="i">La pos. desde la que copiar.</param>
        public void CopyTo(Reparacion[] r, int i)
        {
            this.reparaciones.CopyTo(r, i);
        }

        // Enumerador aplicado a Reparacion.
        IEnumerator<Reparacion> IEnumerable<Reparacion>.GetEnumerator()
        {
            foreach (var r in this.reparaciones)
            {
                yield return r;
            }
        }

        // Enumerador sin tipo
        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var r in this.reparaciones)
            {
                yield return r;
            }
        }

        // Indizador
        public Reparacion this[int i]
        {
            get { return this.reparaciones[i]; }
            set { this.reparaciones[i] = value; }
        }

        public override string ToString()
        {
            var toret = new StringBuilder();

            foreach (Reparacion r in this.reparaciones)
            {
                toret.AppendLine(r.ToString());
            }

            return toret.ToString();
        }

        /// <summary>
        /// Guarda la lista de reparaciones como xml.
        /// </summary>
        public void GuardaXml()
        {
            this.GuardaXml(ArchivoXML);
        }

        /// <summary>
        /// Guarda la lista de reparaciones como XML.
        /// <param name="nf">El nombre del archivo.</param>
        /// </summary>
        public void GuardaXml(string nf)
        {
            var doc = new XDocument();
            var root = new XElement(EtqReparaciones);

            foreach (Reparacion r in this.reparaciones)
            {
                try
                {
                    if (r.Aparato.GetType().ToString().Split('.')[3] == "Adaptador")
                    {
                        Adaptador a = (Adaptador)r.Aparato;
                        root.Add(
                            new XElement(EtqReparacion,
                                    new XAttribute("Tipofactura", r.GetType().ToString().Split('.')[3]),
                                    new XAttribute("Costo", r.Factura),
                                    new XAttribute("Tiempo", r.Tiempo),
                                    new XElement("Producto", r.Aparato.GetType().ToString().Split('.')[3],
                                    new XAttribute("NumSerie", r.Aparato.NumSerie),
                                    new XAttribute("Precio", r.Aparato.Precio),
                                    new XAttribute("Modelo", r.Aparato.Modelo),
                                    new XAttribute("TiempoMax", a.TiempoMax))));
                    }
                    if (r.Aparato.GetType().ToString().Split('.')[3] == "Televisor")
                    {
                        Televisor a = (Televisor)r.Aparato;
                        root.Add(
                            new XElement(EtqReparacion,
                                    new XAttribute("Tipofactura", r.GetType().ToString().Split('.')[3]),
                                    new XAttribute("Costo", r.Factura),
                                    new XAttribute("Tiempo", r.Tiempo),
                                    new XElement("Producto", r.Aparato.GetType().ToString().Split('.')[3],
                                    new XAttribute("NumSerie", r.Aparato.NumSerie),
                                    new XAttribute("Precio", r.Aparato.Precio),
                                    new XAttribute("Modelo", r.Aparato.Modelo),
                                    new XAttribute("Pulgadas", a.Pulgadas))));
                    }
                    if (r.Aparato.GetType().ToString().Split('.')[3] == "Reproductor")
                    {
                        Reproductor a = (Reproductor)r.Aparato;
                        root.Add(
                            new XElement(EtqReparacion,
                                    new XAttribute("Tipofactura", r.GetType().ToString().Split('.')[3]),
                                    new XAttribute("Costo", r.Factura),
                                    new XAttribute("Tiempo", r.Tiempo),
                                    new XElement("Producto", r.Aparato.GetType().ToString().Split('.')[3],
                                    new XAttribute("NumSerie", r.Aparato.NumSerie),
                                    new XAttribute("Precio", r.Aparato.Precio),
                                    new XAttribute("Modelo", r.Aparato.Modelo),
                                    new XAttribute("Bluray", a.Bluray),
                                    new XAttribute("Tiempo", a.Tiempo))));
                    }
                    if (r.Aparato.GetType().ToString().Split('.')[3] == "Radio")
                    {
                        Radio a = (Radio)r.Aparato;
                        root.Add(
                            new XElement(EtqReparacion,
                                    new XAttribute("Tipofactura", r.GetType().ToString().Split('.')[3]),
                                    new XAttribute("Costo", r.Factura),
                                    new XAttribute("Tiempo", r.Tiempo),
                                    new XElement("Producto", r.Aparato.GetType().ToString().Split('.')[3],
                                    new XAttribute("NumSerie", r.Aparato.NumSerie),
                                    new XAttribute("Precio", r.Aparato.Precio),
                                    new XAttribute("Modelo", r.Aparato.Modelo),
                                    new XAttribute("Banda", a.Banda))));
                    }
                }
                catch(System.IndexOutOfRangeException e)
                {
                    System.Console.WriteLine("ERROR" + e);
                }
            }

            doc.Add(root);
            doc.Save(nf);
        }

        /// <summary>
        /// Recupera las reparaciones desde un archivo XML.
        /// </summary>
        /// <returns>Un <see cref="RegistroReparaciones"/> con los
        /// <see cref="Reparacion"/>'s.</returns>
        /// <param name="f">El nombre del archivo.</param>
		public static RegistroReparaciones RecuperaXml(string f)
        {
            var toret = new RegistroReparaciones();

            try
            {
                var doc = XDocument.Load(f);

                if (doc.Root != null
                  && doc.Root.Name == EtqReparaciones)
                {
                    var reparaciones = doc.Root.Elements(EtqReparacion);

                    foreach (XElement reparacionXml in reparaciones)
                    {
                        if ((string)reparacionXml.Attribute("Tipofactura") == "SustitucionPiezas")
                        {
                            switch (reparacionXml.Element("Producto").Value){
                                case "Adaptador": toret.Add(new SustitucionPiezas(new Adaptador((int)reparacionXml.Element("Producto").Attribute("NumSerie"), (string)reparacionXml.Element("Producto").Attribute("Modelo"), (int)reparacionXml.Element("Producto").Attribute("TiempoMax")), (double)reparacionXml.Attribute("Tiempo")));
                                    break;
                                case "Televisor":
                                    toret.Add(new SustitucionPiezas(new Televisor((int)reparacionXml.Element("Producto").Attribute("NumSerie"), (string)reparacionXml.Element("Producto").Attribute("Modelo"), (int)reparacionXml.Element("Producto").Attribute("Pulgadas")), (double)reparacionXml.Attribute("Tiempo")));
                                    break;
                                case "Radio":
                                    toret.Add(new SustitucionPiezas(new Radio((int)reparacionXml.Element("Producto").Attribute("NumSerie"), (string)reparacionXml.Element("Producto").Attribute("Modelo"), (string)reparacionXml.Element("Producto").Attribute("Banda")), (double)reparacionXml.Attribute("Tiempo")));
                                    break;
                                case "Reproductor":
                                    toret.Add(new SustitucionPiezas(new Reproductor((int)reparacionXml.Element("Producto").Attribute("NumSerie"), (string)reparacionXml.Element("Producto").Attribute("Modelo"), (bool)reparacionXml.Element("Producto").Attribute("Bluray"), (int)reparacionXml.Element("Producto").Attribute("Tiempo")), (double)reparacionXml.Attribute("Tiempo")));
                                    break;
                            }
                        }
                        if ((string)reparacionXml.Attribute("Tipofactura") == "ReparacionCompleja")
                        {
                            switch (reparacionXml.Element("Producto").Value)
                            {
                                case "Adaptador":
                                    toret.Add(new ReparacionCompleja(new Adaptador((int)reparacionXml.Element("Producto").Attribute("NumSerie"), (string)reparacionXml.Element("Producto").Attribute("Modelo"), (int)reparacionXml.Element("Producto").Attribute("TiempoMax")), (double)reparacionXml.Attribute("Tiempo")));
                                    break;
                                case "Televisor":
                                    toret.Add(new ReparacionCompleja(new Televisor((int)reparacionXml.Element("Producto").Attribute("NumSerie"), (string)reparacionXml.Element("Producto").Attribute("Modelo"), (int)reparacionXml.Element("Producto").Attribute("Pulgadas")), (double)reparacionXml.Attribute("Tiempo")));
                                    break;
                                case "Radio":
                                    toret.Add(new ReparacionCompleja(new Radio((int)reparacionXml.Element("Producto").Attribute("NumSerie"), (string)reparacionXml.Element("Producto").Attribute("Modelo"), (string)reparacionXml.Element("Producto").Attribute("Banda")), (double)reparacionXml.Attribute("Tiempo")));
                                    break;
                                case "Reproductor":
                                    toret.Add(new ReparacionCompleja(new Reproductor((int)reparacionXml.Element("Producto").Attribute("NumSerie"), (string)reparacionXml.Element("Producto").Attribute("Modelo"), (bool)reparacionXml.Element("Producto").Attribute("Bluray"), (int)reparacionXml.Element("Producto").Attribute("Tiempo")), (double)reparacionXml.Attribute("Tiempo")));
                                    break;
                            }
                        }
                        
                    }
                }
            }
            catch (XmlException)
            {
                var error=System.Console.Error;
                System.Console.WriteLine(error);
                toret.Clear();
            }
            catch (IOException)
            {
                var error = System.Console.Error;
                System.Console.WriteLine(error);
                toret.Clear();
            }

            return toret;
        }

        /// <summary>
        /// Crea un registro de reparaciones con la lista de viajes recuperada
        /// del archivo por defecto.
        /// </summary>
        /// <returns>Un <see cref="RegistroReparaciones"/>.</returns>
		public  RegistroReparaciones RecuperaXml()
        {
            return RecuperaXml(ArchivoXML);
        }

    }
}
