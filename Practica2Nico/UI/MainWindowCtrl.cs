
namespace Practica2Nico.UI
{
    using WForms = System.Windows.Forms;
    using Draw = System.Drawing;
    using Practica2_Nico.Core;
    using System;
    using Practica2_Nico.Core.Aparatos;
    using Practica2_Nico;

    class MainWindowCtrl
    {
        RegistroReparaciones r;
        public MainWindowCtrl()
        {
            this.r = new RegistroReparaciones();
            this.r = r.RecuperaXml();
            this.View = new MainWindowView();
            this.ViewPrincipal = new FuncionesView();
            this.ViewPrincipal.Btn_IntroducirReparaciones.Click+= (sender, args) => this.OnBtMostrarReparaciones();
            this.ViewPrincipal.Btn_ListarReparaciones.Click += (sender, args) => this.OnBtListarReparaciones();
            this.ViewPrincipal.Btn_GuardarReparaciones.Click += (sender, args) => this.OnBtGuardarReparaciones();
            this.ViewPrincipal.Btn_BorrarReparaciones.Click += (sender, args) => this.OnBtBorrarReparaciones();
            this.View.CbOperacion.SelectedIndexChanged += (sender, args) => this.OnBtOperaClick();
            this.View.Btn_Precio.Click += (sender, args) => this.OnBtCalculaPrecio(this.DatosAparato());
            this.View.Btn_Reparaciones.Click += (sender, args) => this.OnBtIntroduceReparacion(this.DatosAparato());
           
        }
        /// <summary>
        /// muestra los distintos formula
        /// </summary>
        public void OnBtMostrarReparaciones()
        {
            this.View.ShowDialog();
        }
        public void OnBtListarReparaciones()
        {
            if (r.Count == 0)
            {
                WForms.MessageBox.Show("No hay reparaciones para listar", "Listado de Reparaciones");

            }
            else
            {
                WForms.MessageBox.Show(r.ToString(), "Listado de Reparaciones");
            }
        }
        public void OnBtGuardarReparaciones()
        {
            if (r.Count == 0)
            {
                WForms.MessageBox.Show("No se ha introducido ninguna reparación","Guardar Reparaciones");

            }
            else
            {
                r.GuardaXml();
                WForms.MessageBox.Show("Se han guardado los datos en el fichero  reparaciones.xml","Guardar Reparaciones");
            }
        }
        public void OnBtBorrarReparaciones()
        {
            if (r.Count == 0)
            {
                WForms.MessageBox.Show("No hay reparaciones para borrar", "Borrar Reparaciones");

            }
            else
            {
                r.Clear();
                WForms.MessageBox.Show("Se han eliminado las reparaciones", "Borrar Reparaciones");
            }
        }

        /// <summary>
        /// Esta funcion permitira actualizar las vista con los campos necesarios dependiendo del elemnto que se seleccione
        /// este metodo también se puede usar para refrescar la vista de manera que los datos que estan en el formulario se pongan vacios
        /// </summary>
        public void OnBtOperaClick()
        {
            string aparato = this.View.CbOperacion.Text;
            this.View.TextoPrecio.Visible = false;

            switch (aparato)
            { //ponemos solo visible la tabla correspondiente que se haya seleccionado y ponemos vacios los campos modelo , num de serie y tiempo de reparacion
                case "Adaptador":
                    this.View.EdModelo.Text = "";
                    this.View.EdNumSerie.Text = "";
                    this.View.EdTiempoRep.Text = "";
                    this.View.EdTiempoMaxGrab.Text = "";
                    this.View.TablaAdaptador.Visible = true;
                    this.View.TablaRadio.Visible = false;
                    this.View.TablaReproductor.Visible = false;
                    this.View.TablaTelevisor.Visible = false;
                    
                    break;
                case "Televisor":
                    this.View.EdModelo.Text = "";
                    this.View.EdNumSerie.Text = "";
                    this.View.EdTiempoRep.Text = "";
                    this.View.EdPulgadas.Text = "";
                    this.View.TablaAdaptador.Visible = false;
                    this.View.TablaRadio.Visible = false;
                    this.View.TablaReproductor.Visible = false;
                    this.View.TablaTelevisor.Visible = true;
                    break;
                case "Reproductor":
                    this.View.EdModelo.Text = "";
                    this.View.EdNumSerie.Text = "";
                    this.View.EdTiempoRep.Text = "";
                    this.View.EdTiempoRepro.Text = "";
                    this.View.TablaAdaptador.Visible = false;
                    this.View.TablaRadio.Visible = false;
                    this.View.TablaReproductor.Visible = true;
                    this.View.TablaTelevisor.Visible = false;
                    break;
                case "Radio":
                    this.View.EdModelo.Text = "";
                    this.View.EdNumSerie.Text = "";
                    this.View.EdTiempoRep.Text = "";
                    this.View.EdBanda.Text = "AM";
                    this.View.TablaAdaptador.Visible = false;
                    this.View.TablaRadio.Visible = true;
                    this.View.TablaReproductor.Visible = false;
                    this.View.TablaTelevisor.Visible = false;
                    break;
            }

         }
        /// <summary>
        /// Este método se encargará de crear el aparato indicado,dependiendo de lo que seleccionara el cliente
        /// </summary>
        /// <returns>devuelve el aparato correspondiente</returns>
        public Aparato DatosAparato()
        {
            string aparato = this.View.CbOperacion.Text;
            int numSerie=0;
            string modelo= this.View.EdModelo.Text.ToString();
            try
            {
                numSerie = Int32.Parse(this.View.EdNumSerie.Text.ToString());
                switch (aparato)
                {
                    case "Adaptador":
                        if (String.IsNullOrEmpty(this.View.EdTiempoMaxGrab.Text))
                        {
                            return new Adaptador(numSerie, modelo); 
                        }
                        else
                        {
                            int tiempoMax = Int32.Parse(this.View.EdTiempoMaxGrab.Text);
                            return new Adaptador(numSerie, modelo, tiempoMax);  
                        }
                        
                    case "Televisor":
                         double pulgadas;
                         pulgadas = Double.Parse(this.View.EdPulgadas.Text);
                        return new Televisor(numSerie, modelo, pulgadas);
                    case "Reproductor":
                        
                        bool bluray;
                        double tiempoRepro;
                        if (this.View.EdBluray.Text == "SI")
                        {
                            bluray = true;
                        }
                        else
                        {
                            bluray = false;
                        }
                        if(String.IsNullOrEmpty(this.View.EdTiempoRepro.Text))
                        {
                            return new Reproductor(numSerie, modelo, bluray);
                        }
                        else
                        {
                            tiempoRepro = Double.Parse(this.View.EdTiempoRepro.Text);
                            return new Reproductor(numSerie, modelo, bluray,tiempoRepro);
                        }
                    case "Radio":
                        return new Radio(numSerie, modelo, this.View.EdBanda.Text);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unable to parse " + e);
                WForms.MessageBox.Show("Formato de los datos no valido");
            }
            return null;
        }
       /// <summary>
       /// esta funcion se encarga de que el boton de precio muestre el coste
       /// </summary>
       /// <param name="a">Aparato con los datos que se han introducido</param>
        public void OnBtCalculaPrecio(Aparato a)
        {
            if (a == null)
            {
                
            }
            else
            {
                try
                {
                    double tiempoRep = Double.Parse(this.View.EdTiempoRep.Text);
                    Reparacion r = Reparacion.Crea(tiempoRep, a);
                    this.View.TextoPrecio.Text = r.Factura.ToString()+"€";
                    this.View.TextoPrecio.Visible = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Unable to parse " + e);
                    WForms.MessageBox.Show("Introduce un tiempo de reparación válido");
                }
            }

        }
        /// <summary>
        /// Añade la reparacion a la lita de reparación que tenemos
        /// </summary>
        /// <param name="a">le pasamos el aparato que recogemos con el formulario</param>
        public void OnBtIntroduceReparacion(Aparato a)
        {
            if (a == null)
            {

            }
            else
            {
                try {
                    double tiempoRep = Double.Parse(this.View.EdTiempoRep.Text);
                    Reparacion rep = Reparacion.Crea(tiempoRep, a);
                    this.r.Add(rep);
                    this.OnBtOperaClick();
                    WForms.MessageBox.Show(rep.ToString());


                }
                catch (Exception e)
                {
                    Console.WriteLine($"Unable to parse " + e);
                    WForms.MessageBox.Show("Introduce un tiempo de reparación válido");
                }
            }


        }



        public MainWindowView View
        {
            get;
        }
        public FuncionesView ViewPrincipal
        {
            get;
        }
    }
}
