using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal
{
    public partial class PagInv : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
        }

       

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if(datos.getColums().SelectedValue.ToString() == "precio")
            {
                Double num;
                if(Double.TryParse(datos.getTxt().Text,out num) && num>0)
                {
                    datos.getLbl().Visible = false;
                    if (datos.getTablas().SelectedValue.ToString() == "producto")
                    {
                        tabla.DataSource = Controlador.getProductos(datos.getColums().SelectedValue.ToString(), datos.getTxt().Text, true);
                    }
                    else
                    {
                        tabla.DataSource = Controlador.getFabricantes(datos.getColums().SelectedValue.ToString(), datos.getTxt().Text, true);
                    }
                }
                else
                {
                    datos.getLbl().Text = "Debe introducir un precio válido.";
                    datos.getLbl().Visible = true;
                }
            }
            else if (datos.getColums().SelectedValue.ToString() == "codigo" || datos.getColums().SelectedValue.ToString() == "precio")
            {
                long num;
                if (Int64.TryParse(datos.getTxt().Text, out num) && num>0)
                {
                    datos.getLbl().Visible = false;
                    if (datos.getTablas().SelectedValue.ToString() == "producto")
                    {
                        tabla.DataSource = Controlador.getProductos(datos.getColums().SelectedValue.ToString(), datos.getTxt().Text, true);
                    }
                    else
                    {
                        tabla.DataSource = Controlador.getFabricantes(datos.getColums().SelectedValue.ToString(), datos.getTxt().Text, true);
                    }
                }
                else
                {
                    datos.getLbl().Text = "Debe introducir un código numérico válido.";
                    datos.getLbl().Visible = true;
                }
            }
            else
            {
                if (datos.getTablas().SelectedValue.ToString() == "producto")
                {
                    tabla.DataSource=Controlador.getProductos(datos.getColums().SelectedValue.ToString(), datos.getTxt().Text, false);
                }
                else
                {
                    tabla.DataSource = Controlador.getFabricantes(datos.getColums().SelectedValue.ToString(), datos.getTxt().Text, false);
                }
            }
            tabla.DataBind();
            if (tabla.Rows.Count == 0 && datos.getLbl().Visible==false)
            {
                lblCoin.Visible = true;
            }
            else lblCoin.Visible = false;
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }
    }
}