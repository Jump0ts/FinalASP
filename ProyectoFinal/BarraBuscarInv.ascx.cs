using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal
{
    public partial class BarraBuscarInv : System.Web.UI.UserControl
    {
        List<String> tablas;
        List<String> columnas;
        protected void Page_Load(object sender, EventArgs e)
        {
            tablas = Controlador.getTablas();
            if (!IsPostBack)
            {
                rellentaTab();
                rellenaCol();
            }

        }

        public Label getLbl()
        {
            return lblWarn;
        }

        public TextBox getTxt()
        {
            return txtValor;
        }

        public DropDownList getTablas()
        {
            return listaTablas;
        }

        public DropDownList getColums()
        {
            return listaColum;
        }

        protected void selectTabChange(object sender, EventArgs e)
        {

            rellenaCol();

        }

        private void rellentaTab()
        {
            getTablas().Items.Clear();


            for (int i = 0; i < tablas.Count; i++)
            {
                getTablas().Items.Add(tablas[i]);
            }
        }

        private void rellenaCol()
        {
            columnas = Controlador.getColumnas(tablas[getTablas().SelectedIndex]);
            getColums().Items.Clear();
            for (int i = 0; i < columnas.Count; i++)
            {
                getColums().Items.Add(columnas[i]);
            }
        }
    }

}
