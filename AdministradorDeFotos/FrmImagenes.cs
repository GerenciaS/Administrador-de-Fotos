using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Collections;

namespace AdministradorDeFotos
{
    public partial class FrmImagenes : Form
    {
        private string BD = "BMSNayar";

        public FrmImagenes()
        {
            this.InitializeComponent();
        }

        public Image CambiarTamanoImagen(Image pImagen, int pAncho, int pAlto)
        {
            Bitmap bitmap = new Bitmap(pAncho, pAlto);
            using (Graphics graphic = Graphics.FromImage(bitmap))
            {
                graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphic.DrawImage(pImagen, 0, 0, pAncho, pAlto);
            }
            return bitmap;
        }

        private void cargarBD(string foto, string archivo)
        {
            try
            {
                MemoryStream memoryStream = new MemoryStream();
                FileStream fileStream = new FileStream(foto, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                memoryStream.SetLength(fileStream.Length);
                fileStream.Read(memoryStream.GetBuffer(), 0, (int)fileStream.Length);
                byte[] buffer = memoryStream.GetBuffer();
                memoryStream.Flush();
                fileStream.Close();
                char[] chrArray = new char[] { '.' };
                string str = archivo.Split(chrArray).First<string>();
                SqlConnection sqlConnection = conexion.conectar(this.BD);
                SqlCommand sqlCommand = new SqlCommand()
                {
                    Connection = sqlConnection,
                    CommandText = "select count(*) as regs from imagenes where transaccion='4' and folio=@folio"
                };
                sqlCommand.Parameters.AddWithValue("@folio", str);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                int num = 0;
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        num = sqlDataReader.GetInt32(0);
                    }
                }
                if (!sqlDataReader.IsClosed)
                {
                    sqlDataReader.Close();
                }
                if (num > 0)
                {
                    sqlCommand.Parameters.Clear();
                    sqlCommand.CommandText = "update imagenes set ruta=@ruta,imagen=@imagen,nombre=@nombre where transaccion=@transaccion and folio=@folio";
                    sqlCommand.Parameters.AddWithValue("@transaccion", "4");
                    sqlCommand.Parameters.AddWithValue("@folio", str);
                    sqlCommand.Parameters.AddWithValue("@tipo_imagen", "2");
                    sqlCommand.Parameters.AddWithValue("@ruta", foto);
                    sqlCommand.Parameters.AddWithValue("@imagen", buffer);
                    sqlCommand.Parameters.AddWithValue("@nombre", archivo);
                    sqlCommand.ExecuteNonQuery();
                }
                else
                {
                    sqlCommand.Parameters.Clear();
                    sqlCommand.CommandText = "insert into imagenes(transaccion,folio,tipo_imagen,ruta,imagen,nombre) values(@transaccion,@folio,@tipo_imagen,@ruta,@imagen,@nombre)";
                    sqlCommand.Parameters.AddWithValue("@transaccion", "4");
                    sqlCommand.Parameters.AddWithValue("@folio", str);
                    sqlCommand.Parameters.AddWithValue("@tipo_imagen", "2");
                    sqlCommand.Parameters.AddWithValue("@ruta", foto);
                    sqlCommand.Parameters.AddWithValue("@imagen", buffer);
                    sqlCommand.Parameters.AddWithValue("@nombre", archivo);
                    sqlCommand.ExecuteNonQuery();
                }
                if (sqlConnection.State.ToString() == "Open")
                {
                    sqlConnection.Close();
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                MessageBox.Show(exception.Message);
                this.toolStripStatusLabel1.Text = string.Concat("Error: ", exception.Message);
            }
        }

        private void cmdActualizar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtRuta.Text))
            {
                if (Directory.Exists(this.txtRuta.Text))
                {
                    List<String> ListaImagenes = new List<String>();

                    foreach (var item in Directory.GetFiles(this.txtRuta.Text, "*.jpg"))
                    {
                        ListaImagenes.Add(item);
                    }

                    foreach (var item in Directory.GetFiles(this.txtRuta.Text, "*.jpeg"))
                    {
                        ListaImagenes.Add(item);
                    }
                    foreach (var item in Directory.GetFiles(this.txtRuta.Text, "*.png"))
                    {
                        ListaImagenes.Add(item);
                    }
                    this.GridImagenes.Rows.Clear();
                    string[] strArrays = ListaImagenes.ToArray();
                    for (int i = 0; i < (int)strArrays.Length; i++)
                    {
                        string str = strArrays[i];
                        string[] strArrays1 = str.Split(new char[] { '\\' });
                        string[] strArrays2 = str.Split(new char[] { '.' });
                        DataGridViewRowCollection rows = this.GridImagenes.Rows;
                        object[] objArray = new object[] { str, strArrays1.Last<string>(), string.Concat(strArrays2.First<string>(), ".tmp") };
                        rows.Add(objArray);
                    }
                    string[] files1 = Directory.GetFiles(this.txtRuta.Text, "*.tmp");
                    for (int j = 0; j < (int)files1.Length; j++)
                    {
                        File.Delete(files1[j]);
                    }
                    return;
                }
                MessageBox.Show("La carpeta fue removida");
            }
        }

        private void cmdExaminar_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.Description = "Seleccione la carpeta con imagenes";
            this.folderBrowserDialog1.ShowDialog();
            if (!string.IsNullOrEmpty(this.folderBrowserDialog1.SelectedPath.ToString()))
            {
                this.txtRuta.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        private void cmdGuardarBD_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show("Se cargaran y asignaran las fotos contenidas en la cuadricula, desea continuar?", "Confirmar", MessageBoxButtons.YesNo))
            {
                case DialogResult.Yes:
                    {
                        this.toolStripProgressBar1.Minimum = 0;
                        this.toolStripProgressBar1.Maximum = this.GridImagenes.RowCount;
                        foreach (DataGridViewRow row in (IEnumerable)this.GridImagenes.Rows)
                        {
                            Image image = Image.FromFile(row.Cells[0].Value.ToString());
                            string str = row.Cells[1].Value.ToString().Trim();
                            this.toolStripStatusLabel1.Text = string.Concat("Redimencionando: ", str);
                            int num = Convert.ToInt32(Convert.ToDouble(640) * (Convert.ToDouble(image.Height) / Convert.ToDouble(image.Width)));
                            image = this.CambiarTamanoImagen(image, 640, num);
                            image.Save(row.Cells[2].Value.ToString(), ImageFormat.Jpeg);
                            this.toolStripStatusLabel1.Text = string.Concat("Cargando :", str);
                            Application.DoEvents();
                            this.cargarBD(row.Cells[2].Value.ToString(), str);
                            ToolStripProgressBar value = this.toolStripProgressBar1;
                            if (value.Value < value.Maximum)
                                value.Value = value.Value + 1;
                        }
                        this.toolStripStatusLabel1.Text = "Terminado";
                        MessageBox.Show("Proceso terminado", "Resultado");
                        this.GridImagenes.Rows.Clear();
                        return;
                    }
                case DialogResult.No:
                    {
                        MessageBox.Show("No se hicieron cambios", "Resultado");
                        return;
                    }
                default:
                    {
                        return;
                    }
            }
        }

        private void FrmImagenes_Load(object sender, EventArgs e)
        {
            this.toolStripStatusLabel2.Text = this.BD;
        }

        private void GridImagenes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void GridImagenes_Enter(object sender, EventArgs e)
        {
        }

        private void GridImagenes_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (this.GridImagenes.Rows.Count > 1 && File.Exists(this.GridImagenes.CurrentRow.Cells[0].Value.ToString()))
            {
                this.PBImagen.Load(this.GridImagenes.CurrentRow.Cells[0].Value.ToString());
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}



