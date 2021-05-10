using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Windows.Forms;

namespace ProyectoFinal
{
    /// <summary>
    /// Descripción breve de Controlador
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Controlador : System.Web.Services.WebService
    {
        private static String usuario;
        private static Boolean mod;
        

        [WebMethod]
        public static Boolean iniciaUs(String usuario)
        {
            return ControladorBBDD.getInstance().inicioUsuario(usuario);
        }

        [WebMethod]
        public static Boolean iniciaPass(String pass)
        {
            return ControladorBBDD.getInstance().inicioPass(pass);
        }

        [WebMethod]
        public static List<String> getTablas()
        {
            return ControladorBBDD.getInstance().getTablas();
        }

        [WebMethod]
        public static List<String> getColumnas(String tabla)
        {
            return ControladorBBDD.getInstance().getColumnas(tabla);
        }

        [WebMethod]
        public static DataTable getProductos(String columna, String valor, Boolean num)
        {
            return ControladorBBDD.getInstance().getProductos(columna,valor,num);
        }

        [WebMethod]
        public static DataTable getFabricantes(String columna, String valor, Boolean num)
        {
            return ControladorBBDD.getInstance().getFabricantes(columna, valor, num);
        }

        [WebMethod]
        public static String getUsuario()
        {
            return usuario;
        }

        [WebMethod]
        public static void setUsuario(String user)
        {
            usuario = user;
        }

        [WebMethod]
        public static Boolean getMod()
        {
            return mod;
        }

        [WebMethod]
        public static void setMod(Boolean modi)
        {
            mod = modi;
        }

        [WebMethod]
        public static List<String> getNombreFabricantes()
        {
            return ControladorBBDD.getInstance().getNombreFabricantes();
        }

        [WebMethod]
        public static Boolean insertarFab(String cod, String nombre)
        {
            int done = ControladorBBDD.getInstance().insertarFab(cod,nombre);

            if (done == 0) return false;
            else return true;
        }

        [WebMethod]
        public static Boolean insertarProd(String cod, String nombre, String precio, String fab)
        {
            int done = ControladorBBDD.getInstance().insertarProd(cod, nombre, precio, fab);

            if (done == 0) return false;
            else return true;
        }

        [WebMethod]
        public static List<String> getCodigos(String tabla)
        {
            return ControladorBBDD.getInstance().getCodigos(tabla);
        }

        [WebMethod]
        public static List<Object> getDatos(String tabla, String cod)
        {
            return ControladorBBDD.getInstance().getDatos(tabla, cod);
        }

        [WebMethod]
        public static String getNombreFab(String cod)
        {
            return ControladorBBDD.getInstance().getNombreFab(cod);
        }

        [WebMethod]
        public static void updateFab(String cod, String nombre)
        {
            ControladorBBDD.getInstance().updateFab(cod, nombre);
        }

        [WebMethod]
        public static void updateProd(String cod, String nombre, String precio, String fab)
        {
            ControladorBBDD.getInstance().updateProd(cod, nombre, precio, fab);
        }

        [WebMethod]
        public static void delete(String tabla, String cod)
        {
            Boolean resp = false;
            if (tabla.Equals("fabricante"))
            {
                resp = MessageBox.Show("¿Está seguro que desea eliminar el fabricante y todo sus productos?", null, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
            }
            else resp = MessageBox.Show("¿Está seguro que desea eliminar el producto?", null, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;

            if (resp==true)
            {
                ControladorBBDD.getInstance().delete(tabla, cod);
            }
        }
    }
}
