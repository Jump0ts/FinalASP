using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    class ControladorBBDD
    {
        private static MySqlConnection conexion = new MySqlConnection();
        private static ControladorBBDD control = null;


        private ControladorBBDD() { }

        public static ControladorBBDD getInstance()
        {
            if (control == null)
            {
                control = new ControladorBBDD();
                conectar();
            }
            return control;
        }

        public static Boolean conectar()
        {
            conexion.ConnectionString = "Server=localhost;Database=tienda;Uid=root;Pwd=''";
            try
            {
                conexion.Open();
            }
            catch (MySqlException ex)
            {
                return false;
            }
            return true;
        }

        public void desconectar()
        {
            conexion.Close();
        }

        public Boolean inicioUsuario(String usuario)
        {
            MySqlCommand query = new MySqlCommand("SELECT usuario FROM cuenta", conexion);
            MySqlDataReader reader = query.ExecuteReader();

            while (reader.Read())
            {
                if (usuario.Equals(reader.GetString(0)))
                {
                    reader.Close();
                    return true;
                }
            }
            reader.Close();
            return false;
        }

        public Boolean inicioPass(String pass)
        {
            MySqlCommand query = new MySqlCommand("SELECT contrasena FROM cuenta", conexion);
            MySqlDataReader reader = query.ExecuteReader();

            while (reader.Read())
            {
                if (pass.Equals(reader.GetString(0)))
                {
                    reader.Close();
                    return true;
                }
            }
            reader.Close();
            return false;
        }

        public List<String> getTablas()
        {
            MySqlCommand query = new MySqlCommand("SELECT DISTINCT(TABLE_NAME) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = 'tienda'", conexion);
            MySqlDataReader reader = query.ExecuteReader();
            List<String> nombres = new List<string>();

            while (reader.Read())
            {
                if (reader.GetString(0) != "cuenta") nombres.Add(reader.GetString(0));
            }
            reader.Close();
            return nombres;
        }

        public List<String> getColumnas(String tabla)
        {
            MySqlCommand query = new MySqlCommand("SELECT DISTINCT(COLUMN_NAME) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = 'tienda' AND TABLE_NAME = '"+tabla+"'", conexion);
            MySqlDataReader reader = query.ExecuteReader();
            List<String> nombres = new List<string>();

            while (reader.Read())
            {
                nombres.Add(reader.GetString(0));
            }
            reader.Close();
            return nombres;
        }

        public DataTable getProductos(String columna, String valor, Boolean num)
        {
            MySqlCommand query;
            if (num == true)
            {
                query = new MySqlCommand("SELECT * FROM producto WHERE " + columna + " = '" + valor + "'", conexion);
            }
            else
            {
                query = new MySqlCommand("SELECT * FROM producto WHERE " + columna + " LIKE '%" + valor + "%'", conexion);
            }
            MySqlDataReader reader = query.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(reader);
            reader.Close();
            return tabla;
        }

        public DataTable getFabricantes(String columna, String valor, Boolean num)
        {
            MySqlCommand query;
            if (num == true)
            {
                query = new MySqlCommand("SELECT * FROM fabricante WHERE " + columna + " = '" + valor + "'", conexion);
            }
            else
            {
                query = new MySqlCommand("SELECT * FROM fabricante WHERE " + columna + " LIKE '%" + valor + "%'", conexion);
            }
            MySqlDataReader reader = query.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(reader);
            reader.Close();
            return tabla;
        }

        public List<String> getNombreFabricantes()
        {
            MySqlCommand query = new MySqlCommand("SELECT fabricante.nombre FROM fabricante", conexion);
            MySqlDataReader reader = query.ExecuteReader();
            List<String> nombres = new List<string>();

            while (reader.Read())
            {
                nombres.Add(reader.GetString(0));
            }
            reader.Close();
            return nombres;
        }

        public int insertarFab(String cod, String nombre)
        {
            try
            {
                MySqlCommand insert = new MySqlCommand();
                insert.Connection = conexion;
                insert.CommandText = "INSERT INTO fabricante (codigo, nombre) " +
                    "VALUES(?cod, ?nom)";

                insert.Parameters.AddWithValue("cod", cod);
                insert.Parameters.AddWithValue("nom", nombre);

                return insert.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                return 0;
            }
        }

        public int insertarProd(String cod, String nombre, String precio, String fab)
        {
            try
            {
                String codigoFab = getCodFab(fab);
                MySqlCommand insert = new MySqlCommand();
                insert.Connection = conexion;
                insert.CommandText = "INSERT INTO producto (codigo, nombre, precio, codigo_fabricante) " +
                    "VALUES(?cod, ?nom, ?precio, ?codFab)";

                insert.Parameters.AddWithValue("cod", cod);
                insert.Parameters.AddWithValue("nom", nombre);
                insert.Parameters.AddWithValue("precio", precio);
                insert.Parameters.AddWithValue("codFab", codigoFab);

                return insert.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                return 0;
            }
        }

        private String getCodFab(String nombre)
        {
            MySqlCommand query = new MySqlCommand("SELECT fabricante.codigo FROM fabricante WHERE nombre = '"+ nombre+"'", conexion);
            MySqlDataReader reader = query.ExecuteReader();
            String cod = "";

            while (reader.Read())
            {
                cod = reader.GetInt32(0)+"";
            }
            reader.Close();
            return cod;
        }

        public List<String> getCodigos(String tabla)
        {
            MySqlCommand query = new MySqlCommand("SELECT codigo FROM "+tabla, conexion);
            MySqlDataReader reader = query.ExecuteReader();
            List<String> codigos = new List<string>();

            while (reader.Read())
            {
                codigos.Add(reader.GetInt32(0)+"");
            }
            reader.Close();
            return codigos;
        }

        public List<Object> getDatos(String tabla, String cod)
        {
            MySqlCommand query = new MySqlCommand("SELECT * FROM " + tabla+" WHERE codigo = '"+cod+"'", conexion);
            MySqlDataReader reader = query.ExecuteReader();
            List<Object> datos = new List<Object>();

            while (reader.Read())
            {

                datos.Add(reader.GetInt64(0));

                datos.Add(reader.GetString(1));
                
                if(tabla == "producto")
                {
                    datos.Add(reader.GetDouble(2));

                    datos.Add(reader.GetInt64(3));
                }
            }
            reader.Close();
            return datos;
        }

        public String getNombreFab(String cod)
        {
            MySqlCommand query = new MySqlCommand("SELECT nombre FROM fabricante WHERE codigo = '" + cod + "'", conexion);
            MySqlDataReader reader = query.ExecuteReader();
            String nombre = "";

            while (reader.Read())
            {
                nombre = reader.GetString(0);
            }
            reader.Close();
            return nombre;
        }

        public void updateFab(String cod, String nombre)
        {
            MySqlCommand query = new MySqlCommand("UPDATE fabricante SET nombre = '"+ nombre + "' WHERE codigo = '" + cod + "'", conexion);

            query.ExecuteNonQuery();
        }

        public void updateProd(String cod, String nombre, String precio, String fab)
        {
            String codFab = getCodFab(fab);
            MySqlCommand query = new MySqlCommand("UPDATE producto SET nombre = '" + nombre + "', precio = '"+precio+"', codigo_fabricante = '"+codFab+"' WHERE codigo = '" + cod + "'", conexion);

            query.ExecuteNonQuery();
        }

        public void delete(String tabla, String cod)
        {
            MySqlCommand query = new MySqlCommand("DELETE FROM "+tabla+" WHERE codigo = '" + cod + "'", conexion);

            query.ExecuteNonQuery();
        }
    }
}
