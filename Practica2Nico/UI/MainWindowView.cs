

namespace Practica2Nico.UI
{
    using WForms = System.Windows.Forms;
    using Draw = System.Drawing;

    class MainWindowView:WForms.Form
    {
        public MainWindowView()
        {
            this.Build();
        }
        /// <summary>
        /// Metodo constructor de la vista principal
        /// </summary>
        void Build()
        {
            var pnlMain = new WForms.TableLayoutPanel
            {
                Dock = WForms.DockStyle.Fill
            };
            this.BuildTablaAdaptador();
            this.BuildTablaTelevisor();
            this.BuildTablaRadio();
            this.BuildTablaReproductor();
            this.BuildTablaAparato();
            pnlMain.Controls.Add(this.BuildPes1());
            pnlMain.Controls.Add(this.BuildPanelPrecio());
            pnlMain.Controls.Add(this.TablaAparato);
            pnlMain.Controls.Add(this.TablaAdaptador);
            pnlMain.Controls.Add(this.TablaTelevisor);
            pnlMain.Controls.Add(this.TablaRadio);
            pnlMain.Controls.Add(this.TablaReproductor);
            pnlMain.Controls.Add(this.BuildReparacion());
            this.Icon = new Draw.Icon("../../Imagenes/reparacion.ico");
            this.Controls.Add(pnlMain);
            this.Text = "ReparacionesNico S.L";
            this.MinimumSize = new Draw.Size(400, 600);

        }
        /// <summary>
        /// Metodo que contruye un panel con el comboBox creado
        /// </summary>
        /// <returns>Panel</returns>
        WForms.Panel BuildPes1()
        {
            var toret = new WForms.Panel
            {
                Dock = WForms.DockStyle.Left
            };
            toret.Controls.Add(new WForms.Label
            {
                Dock = WForms.DockStyle.Fill,
                Text="Aparatos"
            });
            this.CbOperacion = new WForms.ComboBox
            {
                Dock = WForms.DockStyle.Left,
                DropDownStyle = WForms.ComboBoxStyle.DropDownList
            };
            this.CbOperacion.Items.AddRange(new[]
            {
                "Adaptador","Radio","Reproductor","Televisor"
            });
            this.CbOperacion.Text = (string)this.CbOperacion.Items[0];
            toret.Controls.Add(this.CbOperacion);
            toret.MaximumSize = new Draw.Size(this.CbOperacion.Width, this.CbOperacion.Height);
            return toret;
        }
        /// <summary>
        /// Construye la tabla de aparato que será de la que partan todas las demas
        /// </summary>
        void BuildTablaAparato()
        {
            this.TablaAparato = new WForms.TableLayoutPanel
            {
                Dock = WForms.DockStyle.Fill

            };

            TablaAparato.Controls.Add(new WForms.Label
            {
                Dock = WForms.DockStyle.Fill,
                Text = "Numero de Serie"

            });
            this.EdNumSerie = new WForms.TextBox
            {
                Dock = WForms.DockStyle.Fill,
                TextAlign = WForms.HorizontalAlignment.Left
            };
            TablaAparato.Controls.Add(this.EdNumSerie);
            TablaAparato.Controls.Add(new WForms.Label
            {
                Dock = WForms.DockStyle.Fill,
                Text = "Modelo"

            });
            this.EdModelo = new WForms.TextBox
            {
                Dock = WForms.DockStyle.Fill,
                TextAlign = WForms.HorizontalAlignment.Left
            };
            TablaAparato.Controls.Add(this.EdModelo);

        }
        /// <summary>
        /// Método para crear el boton de introducir reparaciones y su label
        /// </summary>
        /// <returns>Devuelve un TableLayout con los dos elementos</returns>
        WForms.TableLayoutPanel BuildReparacion()
        {
            var toret = new WForms.TableLayoutPanel
            {
                Dock = WForms.DockStyle.Fill

            };
            toret.Controls.Add(new WForms.Label
            {
                Dock = WForms.DockStyle.Fill,
                Text = "Tiempo de la reparación"

            });
            this.EdTiempoRep = new WForms.TextBox
            {
                Dock = WForms.DockStyle.Fill,
                TextAlign = WForms.HorizontalAlignment.Left
            };
            toret.Controls.Add(this.EdTiempoRep);
            this.Btn_Reparaciones = new WForms.Button
            {
                Dock = WForms.DockStyle.Top,
                Text = "Introducir Reparación"
            };
            toret.Controls.Add(this.Btn_Reparaciones);

            return toret;
        }

        /// <summary>
        /// Metodo para crear la tabla con la información a introducir de Adaptador
        /// </summary>
        public void BuildTablaAdaptador()
        {
            this.TablaAdaptador = new WForms.TableLayoutPanel
            {
                Dock = WForms.DockStyle.Fill

            };
            TablaAdaptador.Controls.Add(new WForms.Label
            {
                Dock = WForms.DockStyle.Fill,
                Text = "Tiempo Maximo de grabación"

            });
            this.EdTiempoMaxGrab = new WForms.TextBox
            {
                Dock = WForms.DockStyle.Fill,
                TextAlign = WForms.HorizontalAlignment.Left
            };
            TablaAdaptador.Controls.Add(this.EdTiempoMaxGrab);
            TablaAdaptador.Visible = true;
        }
        /// <summary>
        /// Metodo para crear la tabla con la información a introducir de Televisor
        /// </summary>
        public void BuildTablaTelevisor()
        {
            this.TablaTelevisor = new WForms.TableLayoutPanel
            {
                Dock = WForms.DockStyle.Fill,
                Visible = false

            };

            TablaTelevisor.Controls.Add(new WForms.Label
            {
                Dock = WForms.DockStyle.Fill,
                Text = "Pulgadas"

            });
            this.EdPulgadas = new WForms.TextBox
            {
                Dock = WForms.DockStyle.Fill,
                TextAlign = WForms.HorizontalAlignment.Left
            };
            TablaTelevisor.Controls.Add(this.EdPulgadas);

            TablaTelevisor.Visible = false;
        }
        /// <summary>
        /// Metodo para crear la tabla con la información a introducir de Radio
        /// </summary>
       public  void BuildTablaRadio()
        {
            this.TablaRadio = new WForms.TableLayoutPanel
            {
                Dock = WForms.DockStyle.Fill,

            };


            TablaRadio.Controls.Add(new WForms.Label
            {
                Dock = WForms.DockStyle.Fill,
                Text = "Banda de la Radio"

            });
            this.EdBanda = new WForms.ComboBox
            {
                Dock = WForms.DockStyle.Top,
                DropDownStyle = WForms.ComboBoxStyle.DropDownList
            };
            this.EdBanda.Items.AddRange(new[]
            {
                "AM","FM","AMBAS"
            });
            this.EdBanda.Text = (string)this.EdBanda.Items[0];
            TablaRadio.Controls.Add(this.EdBanda);
            TablaRadio.Visible = false;

        }
        /// <summary>
        /// Metodo para crear la tabla con la información a introducir de Reproductor
        /// </summary>
       public void BuildTablaReproductor()
        {
            this.TablaReproductor = new WForms.TableLayoutPanel
            {
                Dock = WForms.DockStyle.Fill,

            };

            TablaReproductor.Controls.Add(new WForms.Label
            {
                Dock = WForms.DockStyle.Fill,
                Text = "Reproducen Blue-Ray"

            });
            this.EdBluray = new WForms.ComboBox
            {
                Dock = WForms.DockStyle.Top,
                DropDownStyle = WForms.ComboBoxStyle.DropDownList
            };
            this.EdBluray.Items.AddRange(new[]
            {
                "SI","NO"
            });
            this.EdBluray.Text = (string)this.EdBluray.Items[0];
            TablaReproductor.Controls.Add(this.EdBluray);

            TablaReproductor.Controls.Add(new WForms.Label
            {
                Dock = WForms.DockStyle.Fill,
                Text = "Tiempo de grabación"

            });
            this.EdTiempoRepro = new WForms.TextBox
            {
                Dock = WForms.DockStyle.Fill,
                TextAlign = WForms.HorizontalAlignment.Left
            };
            TablaReproductor.Controls.Add(this.EdTiempoRepro);


            TablaReproductor.Visible = false;
            

        }
        /// <summary>
        /// Crear una tableLayoutPanel usando el boton y textbox creado 
        /// para introducir y representar el precio respectivamente
        /// </summary>
        /// <returns></returns>
        WForms.TableLayoutPanel BuildPanelPrecio()
        {
            var toret= new WForms.TableLayoutPanel
            {
                Dock = WForms.DockStyle.Top
                
            };
            this.Btn_Precio = new WForms.Button
            {
                Dock = WForms.DockStyle.Top,
                Text = "Calcular Precio"
            };
            toret.Controls.Add(this.Btn_Precio);
            this.TextoPrecio = new WForms.TextBox
            {
                Dock = WForms.DockStyle.Top,
                TextAlign = WForms.HorizontalAlignment.Center
            };
            this.TextoPrecio.Visible = false;
            toret.Controls.Add(this.TextoPrecio);
            return toret;
        }




        public WForms.ComboBox CbOperacion
        {
            get; private set;
        }
        public WForms.TextBox EdNumSerie
        {
            get; private set;
        }

        public WForms.TextBox EdModelo
        {
            get; private set;
        }

        public WForms.TextBox EdTiempoMaxGrab
        {
            get; private set;
        }
        public WForms.TextBox EdPulgadas
        {
            get; private set;
        }
        public WForms.ComboBox EdBanda
        {
            get; private set;
        }
        public WForms.ComboBox EdBluray
        {
            get; private set;
        }
        public WForms.TextBox EdTiempoRepro
        {
            get; private set;
        }
        public WForms.TextBox EdTiempoRep
        {
            get; private set;
        }
        public WForms.TableLayoutPanel TablaAparato
        {
            get; private set;
        }
        public WForms.TableLayoutPanel TablaAdaptador
        {
            get; private set;
        }
        public WForms.TableLayoutPanel TablaRadio
        {
            get; private set;
        }
        public WForms.TableLayoutPanel TablaReproductor
        {
            get; private set;
        }
        public WForms.TableLayoutPanel TablaTelevisor
        {
            get; private set;
        }
        public WForms.TableLayoutPanel TablaPrecio
        {
            get; private set;
        }
        public WForms.Button Btn_Precio
        {
            get; private set;
        }
        public WForms.TextBox TextoPrecio
        {
            get; private set;
        }
        public WForms.Button Btn_Reparaciones
        {
            get; private set;
        }


    }
}
