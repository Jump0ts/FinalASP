using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnIniciar_Click(object sender, EventArgs e)
        {


            if (Controlador.iniciaUs(txtUser.Text) == true)
            {
                lblErrorUs.Visible = false;
                if (Controlador.iniciaPass(txtPass.Text) == true)
                {
                    lblErrorPass.Visible = false;
                    Controlador.setUsuario(txtUser.Text);
                    Response.Redirect("Insercion.aspx");
                }
                else lblErrorPass.Visible = true;
            }
            else lblErrorUs.Visible = true;
        }

        protected void btnInvitado_Click(object sender, EventArgs e)
        {
            Response.Redirect("PagInv.aspx");
        }
    }
}