using System.Diagnostics;
using System.IO;
using System.Media;
using System.Security.Policy;
using System.Windows.Controls;
using Microsoft.Win32;
using System.Windows.Forms;
using rabulder;
using WE_RA_Maker;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;

namespace Winning_Eleven_2002___RA_Maker
{
    public partial class Form1 : Form
    {
        SoundPlayer player;
        int rowIndex = -1;
        public Form1()
        {
            InitializeComponent();
            CargarGrilla();
            CrearTemporal();
        }
        private void CargarGrilla()
        {
            CargarCSVEnGridView("Tools\\DatosGrilla.csv");

        }
        private void CrearTemporal()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Application.StartupPath + "Temp\\");

            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
        }
        private void btnAgregarAudio_Click(object sender, EventArgs e)
        {
            CargarArchivosWav();
            //string[] opciones = { "", "" };
            //string salida = string.Empty;
            //Wav2Vag wavToVagConverter = new Wav2Vag("vag2wav.exe");

            //wavToVagConverter.ConvertirAWavVag ("e:\\TEMP\\Wav2Vag\\CONVERTID.vag", "e:\\TEMP\\Wav2Vag\\CONVERT.wav", out salida, opciones);
            ////wavToVagConverter.ConvertirWavEnVag( "e:\\TEMP\\Wav2Vag\\CONVERTID.vag", "e:\\TEMP\\Wav2Vag\\CONVERTI.wav");
            //MessageBox.Show(salida);
        }
        private void CargarCSVEnGridView(string rutaArchivo)
        {
            try
            {
                // Lee todas las líneas del archivo
                string[] lineas = File.ReadAllLines(rutaArchivo);

                // Agrega las filas al DataTable
                for (int i = 0; i < lineas.Length; i++)
                {
                    string[] campos = lineas[i].Split(';');
                    dgvVAGs.Rows.Add(new DataGridViewRow());
                    dgvVAGs.Rows[i].Cells["colPuntero"].Value = campos[0].Trim();
                    dgvVAGs.Rows[i].Cells["colArchivo"].Value = campos[1].Trim();
                    dgvVAGs.Rows[i].Cells["colFrase"].Value = campos[2].Trim();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el archivo CSV: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarArchivosWav()
        {
            string[] listaDeArchivos = null;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos WAV | *.wav";
                openFileDialog.Title = "Agregar archivos WAV";
                openFileDialog.Multiselect = true;
                openFileDialog.DefaultExt = "wav";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    int count = openFileDialog.FileNames.Length;
                    listaDeArchivos = new string[count];
                    int i = 0;
                    //listaDeArchivos = new string[(int)openFileDialog.FileNames.Count];
                    foreach (string item in openFileDialog.FileNames)
                    {
                        listaDeArchivos[i] = item;
                        i++;
                    }
                }
            }
            if (listaDeArchivos != null)
            {
                foreach (string item in listaDeArchivos)
                {
                    lstArchivos.Items.Add(item);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (lstArchivos.Items.Count > 0)
            {
                int indice = lstArchivos.SelectedIndex;
                object linea = lstArchivos.SelectedItem;

                if (indice > 0)
                {
                    lstArchivos.Items.RemoveAt(indice);
                    lstArchivos.Items.Insert(indice - 1, linea);
                    lstArchivos.SelectedIndex = indice - 1;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (lstArchivos.SelectedIndex < lstArchivos.Items.Count - 1)
            {
                int indice = lstArchivos.SelectedIndex;
                object linea = lstArchivos.SelectedItem;

                if (indice < lstArchivos.Items.Count)
                {
                    lstArchivos.Items.RemoveAt(indice);
                    lstArchivos.Items.Insert(indice + 1, linea);
                    lstArchivos.SelectedIndex = indice + 1;
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (lstArchivos.Items.Count > 0)
            {
                int indice = lstArchivos.SelectedIndex;
                if (MessageBox.Show("Are you sure wanna delete selected item?", "Delete Item", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    lstArchivos.Items.RemoveAt(indice);
                    lstArchivos.SelectedIndex = indice;
                }
            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            Wav2Vag wav2Vag = new Wav2Vag(Application.StartupPath + "Tools\\wav2vag.exe");
            string[] listadoNombre = new string[dgvVAGs.RowCount];
            int indice = 0;
            string salida = string.Empty;
            progressBar1.Maximum = lstArchivos.Items.Count;
            // Cargamos los nomnbres de los VAGs reales
            foreach (DataGridViewRow row in dgvVAGs.Rows)
            {
                listadoNombre[indice] = (string)row.Cells["colArchivo"].Value;
                indice++;
            }
            for (int i = 0; i < lstArchivos.Items.Count; i++)
            {
                string archivo = lstArchivos.Items[i].ToString();
                if (wav2Vag.ProcesarArchivo(archivo, listadoNombre[i], out salida))
                {
                    if (string.IsNullOrEmpty(salida))
                    {
                        dgvVAGs.Rows[i].Cells["colAsignado"].Value = listadoNombre[i];
                        dgvVAGs.Rows[i].Cells["colEstado"].Value = "OK";
                        dgvVAGs.Rows[i].Cells["colCheckeo"].Value = true;
                        dgvVAGs.Rows[i].Cells["colEstado"].Style.BackColor = Color.Green;
                        dgvVAGs.Rows[i].Cells["colEstado"].Style.ForeColor = Color.White;
                    }
                    else
                    {
                        dgvVAGs.Rows[i].Cells["colEstado"].Value = "ERROR";
                        dgvVAGs.Rows[i].Cells["colCheckeo"].Value = false;
                        dgvVAGs.Rows[i].Cells["colEstado"].Style.BackColor = Color.Red;
                        dgvVAGs.Rows[i].Cells["colEstado"].Style.ForeColor = Color.White;
                    }
                }
                progressBar1.Value = i;
            }

        }
        private void lstArchivos_Click(object sender, EventArgs e)
        {
            Wav2Vag wav2Vag = new Wav2Vag(Application.StartupPath + "Tools\\wavInfo.exe");
            string salida = string.Empty;
            string[] opciones = { "-m" };


            if (lstArchivos.Items.Count > 0 && lstArchivos.SelectedIndex > -1)
            {
                string archivo = lstArchivos.SelectedItem.ToString();

                if (string.IsNullOrEmpty(archivo))
                {
                    return;
                }
                else
                {
                    wav2Vag.WavInformation("\"" + archivo + "\"", out salida, opciones);
                }
                string[] strings = salida.Split('\r');
                lstInformacionWAV.Items.Clear();
                foreach (string s in strings)
                {
                    if (!s.ToUpper().Contains("ERROR"))
                    {
                        lstInformacionWAV.Items.Add(s);
                    }
                }
            }
        }
        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (lstArchivos.Items.Count > 0)
            {

                string archivoWav = lstArchivos.SelectedItem.ToString();
                player = new SoundPlayer();
                player.SoundLocation = archivoWav;
                player.Load();
                player.Play();
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (player != null)

                player.Stop();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (lstArchivos.Items.Count > 0)
            {
                DialogResult ok = MessageBox.Show("This will clear all wav list. Are you sure?", "Clear list", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ok == DialogResult.Yes)
                {
                    lstArchivos.Items.Clear();
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (lstArchivos.Items.Count > 0)
            {
                int indice = lstArchivos.SelectedIndex + 1;
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {

                    openFileDialog.Filter = "Archivos WAV | *.wav";
                    openFileDialog.Title = "Agregar archivos WAV";
                    openFileDialog.Multiselect = false;
                    openFileDialog.DefaultExt = "wav";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {

                        lstArchivos.Items.Insert(indice, openFileDialog.FileName);
                        lstArchivos.SelectedIndex = indice;
                    }

                }
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Quit?", "Close program", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                e.Cancel = true;
                return;
            }


            string archivo = Application.StartupPath + "Tools\\DatosGrilla.csv";
            using (var writetext = new StreamWriter(archivo))
            {
                foreach (DataGridViewRow row in dgvVAGs.Rows)
                {
                    writetext.WriteLine($"{row.Cells[0].Value};{row.Cells[1].Value};{row.Cells[2].Value}");
                }
            }
            EliminarTodoAlCerrar();
        }
        private void EliminarTodoAlCerrar()
        {
            DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + "TEMP");
            if (dir.Exists)
                dir.Delete(true);

        }
        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
        private void dgvVAGs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Point p = Cursor.Position;
            PopUp.PointToScreen(p);
            PopUp.Show(p);
            rowIndex = e.RowIndex;
        }
        private void tsMenuCopiar_Click(object sender, EventArgs e)
        {
            string mensaje = Convert.ToString(dgvVAGs.Rows[rowIndex].Cells["colFrase"].Value);
            Clipboard.SetText(mensaje);
            MessageBox.Show(mensaje + "\n" + "\n" + "Copy to clipboard");
        }
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string a = string.Empty;
            switch (toolStripComboBox1.SelectedIndex)
            {
                case 0:
                    a = "https://fakeyou.com/tts/TM:8hzs5fwhqs75"

                        ;
                    break;
                case 1:
                    a = "https://fakeyou.com/tts/TM:d4989jhcs46z";

                    break;
                case 2:
                    a = "https://fakeyou.com/tts/TM:b34ppqwan09q";
                    break;
                case 3:
                    a = "https://fakeyou.com/tts/TM:d4hc28vnmz8g";
                    break;

            }
            if (!string.IsNullOrEmpty(a))
            {
                var psi = new ProcessStartInfo
                {
                    FileName = a,
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            //    System.Diagnostics.Process.Start(a); ;
        }
        private void btnCrearRA_Click(object sender, EventArgs e)
        {
            int indice = 0;
            string[] listadoPunteros;
            string[] listadoDeArchivos; 
            Tools_RA tools_RA = new Tools_RA();
            FolderBrowserDialog openFolderDialog = new FolderBrowserDialog();
            DialogResult result = openFolderDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                int count = dgvVAGs.RowCount;
                listadoDeArchivos = new string[count];
                listadoPunteros = new string[count];

                foreach (DataGridViewRow row in dgvVAGs.Rows)
                {
                    listadoPunteros[indice] = Convert.ToString(row.Cells["colPuntero"].Value);
                    listadoDeArchivos[indice] = Application.StartupPath + "Temp\\" + Convert.ToString(row.Cells["colAsignado"].Value) + ".vag";
                    indice++;
                }

                tools_RA.CrearArchivosRA(listadoPunteros, listadoDeArchivos, openFolderDialog.SelectedPath, chkCallnames.Checked);
            }
        }
    }
}