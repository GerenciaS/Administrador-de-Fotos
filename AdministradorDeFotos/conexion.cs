using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AdministradorDeFotos
{
    class conexion
    {
        public conexion()
        {
        }

        public static SqlConnection conectar(string sBase)
        {
            SqlConnection sqlConnection;
            try
            {
                //SqlConnection sqlConnection1 = new SqlConnection(string.Concat("Server=server-cln;Database=", sBase, ";User Id=eliasb;Password=23032004;"));
                SqlConnection sqlConnection1 = new SqlConnection(string.Concat("Server=187.216.118.170,14335;Database=", sBase, ";User Id=prgrmusr;Password=$M3rc4d0$;"));
                sqlConnection1.Open();
                sqlConnection = sqlConnection1;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                sqlConnection = null;
            }
            return sqlConnection;
        }
    }
}
