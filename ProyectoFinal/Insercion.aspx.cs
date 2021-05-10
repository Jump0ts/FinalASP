using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal
{
    public partial class Inserción : System.Web.UI.Page
    {
        private List<String> tablas;
        protected void Page_Load(object sender, EventArgs e)
        {
            tablas = Controlador.getTablas();
            if (!IsPostBack)
            {
                rellentaTab();
                listaFabricantes.Visible = false;
                txtPrecio.Visible = false;
                lblCod_F.Visible = false;
                lblPrecio.Visible = false;
            }
            rellenaFabricantes();
        }

        protected void tablas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listTabla.SelectedValue.ToString() == "producto")
            {
                listaFabricantes.Visible = true;
                txtPrecio.Visible = true;
                lblCod_F.Visible = true;
                lblPrecio.Visible = true;
            }
            else
            {
                listaFabricantes.Visible = false;
                txtPrecio.Visible = false;
                lblCod_F.Visible = false;
                lblPrecio.Visible = false;
            }
        }

        private void rellentaTab()
        {
            listTabla.Items.Clear();
            

            for (int i = 0; i < tablas.Count; i++)
            {
                listTabla.Items.Add(tablas[i]);
            }
        }

        private void rellenaFabricantes()
        {
            List<String> fab = Controlador.getNombreFabricantes();
            listaFabricantes.Items.Clear();


            for (int i = 0; i < fab.Count; i++)
            {
                listaFabricantes.Items.Add(fab[i]);
            }
        }

        protected void limpiar()
        {
            txtCod.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            listaFabricantes.SelectedIndex = 0;
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            long cod;
            if (Int64.TryParse(txtCod.Text, out cod))
            {
                warningCod.Visible = false;
                if (txtNombre.Text != "")
                {
                    warningNombre.Visible = false;
                    if (listTabla.SelectedValue.ToString() == "fabricante")
                    {
                        if (Controlador.insertarFab(txtCod.Text, txtNombre.Text) == false)
                        {
                            warningCod.InnerText = "Código ya existente pruebe otro.";
                            warningCod.Visible = true;
                        }
                        else limpiar();
                    }
                    else
                    {
                        Double num;
                        if(Double.TryParse(txtPrecio.Text,out num))
                        {
                            warningPrecio.Visible = false;
                            if (Controlador.insertarProd(txtCod.Text, txtNombre.Text, txtPrecio.Text, listaFabricantes.SelectedValue.ToString()) == false)
                            {
                                warningCod.InnerText = "Código ya existente pruebe otro.";
                                warningCod.Visible = true;
                            }
                            else limpiar();
                        }
                        else warningPrecio.Visible = true;
                    }
                    
                }
                else
                {
                    warningNombre.Visible = true;
                }
            }
            else
            {
                warningCod.InnerText = "Debe introducir un código numérico.";
                warningCod.Visible = true;
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}