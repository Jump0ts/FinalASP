using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal
{
    public partial class UsuarioIniciado : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            identificador.Text = "¡Bienvenido de nuevo " + Controlador.getUsuario()+"!";
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }

        protected void btnInsercion_Click(object sender, EventArgs e)
        {
            Response.Redirect("Insercion.aspx");
        }

        protected void btnMod_Click(object sender, EventArgs e)
        {
            Controlador.setMod(true);
            Response.Redirect("Mod_El.aspx");
        }

        protected void btnElim_Click(object sender, EventArgs e)
        {
            Controlador.setMod(false);
            Response.Redirect("Mod_El.aspx");
        }
    }
}