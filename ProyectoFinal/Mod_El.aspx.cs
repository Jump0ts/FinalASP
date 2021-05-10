using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal
{
    public partial class Mod_El : System.Web.UI.Page
    {
        private List<String> tablas;
        private Boolean readOnly;
        protected void Page_Load(object sender, EventArgs e)
        {
            readOnly = !Controlador.getMod();
            tablas = Controlador.getTablas();
            txtNombre.ReadOnly = readOnly;
            listaFabricantes.Enabled = !readOnly;
            txtPrecio.ReadOnly = readOnly;
            if(readOnly == true)
            {
                btnAccion.Text = "Eliminar";
                btnLimpiar.Visible = false;
            }
            else
            {
                btnAccion.Text = "Modificar";
                btnLimpiar.Visible = true;
            }

            if (!IsPostBack)
            {
                rellentaTab();
                rellenaCodigos();
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
            rellenaCodigos();
        }

        private void rellentaTab()
        {
            listTabla.Items.Clear();


            for (int i = 0; i < tablas.Count; i++)
            {
                listTabla.Items.Add(tablas[i]);
            }
        }

        private void rellenaCodigos()
        {
            List<String> cods = Controlador.getCodigos(listTabla.SelectedValue.ToString());
            listCod.Items.Clear();


            for (int i = 0; i < cods.Count; i++)
            {
                listCod.Items.Add(cods[i]);
            }

            listCod.SelectedIndex = 1;
            listCod.SelectedIndex = 0;
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
            txtNombre.Text = "";
            txtPrecio.Text = "";
            listaFabricantes.SelectedIndex = 0;
        }

        protected void btnAccion_Click(object sender, EventArgs e)
        {
            if (readOnly == false)
            {
                if (txtNombre.Text != "")
                {
                    warningNombre.Visible = false;
                    if (listTabla.SelectedValue.ToString() == "fabricante")
                    {
                        Controlador.updateFab(listCod.SelectedValue.ToString(), txtNombre.Text);
                        Response.Redirect("Mod_El.aspx");
                    }
                    else
                    {
                        Double num;
                        if (Double.TryParse(txtPrecio.Text, out num) && num>0)
                        {
                            warningPrecio.Visible = false;
                            Controlador.updateProd(listCod.SelectedValue.ToString(), txtNombre.Text, txtPrecio.Text, listaFabricantes.SelectedValue.ToString());
                            Response.Redirect("Mod_El.aspx");
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
                Controlador.delete(listTabla.SelectedValue.ToString(), listCod.SelectedValue.ToString());
                Response.Redirect("Mod_El.aspx");
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        protected void listCod_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Object> datos = Controlador.getDatos(listTabla.SelectedValue.ToString(), listCod.SelectedValue.ToString());

            txtNombre.Text = datos[1]+"";

            if (listTabla.SelectedValue.ToString() == "producto")
            {
                txtPrecio.Text = datos[2]+"";
                listaFabricantes.SelectedValue = Controlador.getNombreFab(datos[3]+"");
            }
        }
    }
}