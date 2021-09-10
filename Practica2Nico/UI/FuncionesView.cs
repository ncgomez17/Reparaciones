

namespace Practica2Nico.UI
{
    using WForms = System.Windows.Forms;
    using Draw = System.Drawing;
    class FuncionesView : WForms.Form
    {
        public FuncionesView()
        {
            this.Build();
        }
        void Build()
        {
            var pnlMain = new WForms.TableLayoutPanel
            {
                Dock = WForms.DockStyle.Fill,
            
            };
            this.Icon = new Draw.Icon("../../Imagenes/reparacion.ico");
            pnlMain.Controls.Add(this.TablaPrincipal());
            this.Controls.Add(pnlMain);
            this.Text = "ReparacionesNico S.L";
            this.AutoSize = true;

        }
        /// <summary>
        /// crea una tabla con los botones de las principales funciones de la aplicación
        /// </summary>
        /// <returns> devuelve la tabla con lso botones creados</returns>
        WForms.TableLayoutPanel TablaPrincipal()
        {
            var toret = new WForms.TableLayoutPanel
            {
                Dock = WForms.DockStyle.Fill,
                Margin = new WForms.Padding(20),

            };
            this.Btn_IntroducirReparaciones = new WForms.Button
            {
                Dock = WForms.DockStyle.Fill,
                Text="Introducir Reparaciones"
            };
            toret.Controls.Add(this.Btn_IntroducirReparaciones);

            this.Btn_ListarReparaciones = new WForms.Button
            {
                Dock = WForms.DockStyle.Fill,
                Text="Listar Reparaciones"
            };
            toret.Controls.Add(this.Btn_ListarReparaciones);
            this.Btn_GuardarReparaciones = new WForms.Button
            {
                Dock = WForms.DockStyle.Fill,
                Text = "Guardar Reparaciones"
            };
            toret.Controls.Add(this.Btn_GuardarReparaciones);
            this.Btn_BorrarReparaciones = new WForms.Button
            {
                Dock = WForms.DockStyle.Top,
                Text = "Borrar Reparaciones"
            };
            toret.Controls.Add(this.Btn_BorrarReparaciones);
            return toret;
        }
        public WForms.Button Btn_IntroducirReparaciones
        {
            get;  set;
        }
        public WForms.Button Btn_ListarReparaciones
        {
            get;  set;
        }
        public WForms.Button Btn_GuardarReparaciones
        {
            get;  set;
        }
        public WForms.Button Btn_BorrarReparaciones
        {
            get;  set;
        }
    }
}
