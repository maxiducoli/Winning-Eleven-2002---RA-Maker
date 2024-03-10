using System.Diagnostics;
using System.IO;
using System.Media;
using System.Net.Http.Headers;
using fileprcss;
using Microsoft.Win32;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;
using SaveFileDialog = System.Windows.Forms.SaveFileDialog;

namespace Winning_Eleven_2002___RA_Maker
{
    public partial class Form1 : Form
    {
        SoundPlayer player;
        int rowIndex = -1;
        public Form1()
        {
            InitializeComponent();

            CrearTemporal();
        }
        private void CargarGrilla(string rutaGrilla)
        {
            CargarCSVEnGridView(rutaGrilla);

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
                dgvVAGs.Rows.Clear();
                // Agrega las filas al DataTable
                for (int i = 0; i < lineas.Length; i++)
                {
                    string[] campos = lineas[i].Split(';');
                    dgvVAGs.Rows.Add(new DataGridViewRow());
                    dgvVAGs.Rows[i].Cells["colPuntero"].Value = campos[0].Trim();
                    dgvVAGs.Rows[i].Cells["colPuntero2"].Value = campos[1].Trim();
                    dgvVAGs.Rows[i].Cells["colArchivo"].Value = campos[2].Trim();
                    dgvVAGs.Rows[i].Cells["colFrase"].Value = campos[3].Trim();
                }
                lblVAGs.Text = "Cantidad de VAGs reales:" + dgvVAGs.Rows.Count.ToString();
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
                openFileDialog.Filter = "Formatos soportados (*.vag;*.wav)|*.vag;*.wav|Archivos WAV|*.wav|Archivos VAG|*.vag";
                openFileDialog.Title = "Agregar archivos de audio.";
                openFileDialog.Multiselect = true;
                openFileDialog.DefaultExt = "wav;vag";

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
                lblContador.Text = "Files counts: " + lstArchivos.Items.Count.ToString();
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
            FilePrcss filePrcss = new FilePrcss(Application.StartupPath + "Tools\\MFAudio.exe");
            string tempFolder = Application.StartupPath + "Temp\\";
            string[] listadoNombre = new string[dgvVAGs.RowCount];
            int indice = 0;
            string salida = string.Empty;

            try
            {


                progressBar1.Maximum = lstArchivos.Items.Count;
                // Cargamos los nomnbres de los VAGs reales
                foreach (DataGridViewRow row in dgvVAGs.Rows)
                {
                    if (row.Cells["colArchivo"].Value != "")
                    {
                        listadoNombre[indice] = (string)row.Cells["colArchivo"].Value;
                        indice++;
                    }
                }
                for (int i = 0; i < lstArchivos.Items.Count; i++)
                {
                    progressBar1.Value = i;
                    string archivo = lstArchivos.Items[i].ToString();
                    string extension = Path.GetExtension(archivo);

                    if (extension.ToUpper() == ".WAV")
                    {
                        if (filePrcss.ProcesarArchivo(tempFolder, archivo, listadoNombre[i], chkCallnames.Checked, out salida))
                        {
                            if (File.Exists(tempFolder + "\\" + listadoNombre[i] + ".vag"))
                            {
                                filePrcss.FixVag(tempFolder + "\\" + listadoNombre[i] + ".vag");
                                if (filePrcss.ConvertirLBA(tempFolder + "\\" + listadoNombre[i] + ".vag", chkCallnames.Checked)) ;
                            }
                        }
                        lstConsola.Items.Add(salida);
                    }
                    else
                    {
                        if (filePrcss.ConvertirLBA(archivo, chkCallnames.Checked))
                        {
                            File.Copy(archivo, tempFolder + "\\" + listadoNombre[i] + ".vag", true);

                            if (File.Exists(tempFolder + "\\" + listadoNombre[i] + ".vag"))
                            {
                                filePrcss.FixVag(tempFolder + "\\" + listadoNombre[i] + ".vag");

                                if (filePrcss.ConvertirLBA(tempFolder + "\\" + listadoNombre[i] + ".vag", chkCallnames.Checked))
                                {
                                    if (string.IsNullOrEmpty(salida))
                                    {
                                        salida = "Conversión completada con éxito.";
                                    }
                                    lstConsola.Items.Add(salida);
                                }

                            }

                        }
                    }

                    if (!string.IsNullOrEmpty(salida))
                    {
                        if (dgvVAGs.Rows[i].Cells["colArchivo"].Value != "")
                        {

                            dgvVAGs.Rows[i].Cells["colAsignado"].Value = listadoNombre[i];
                            // dgvVAGs.Rows[i].Cells["colEstado"].Value = "OK";
                            dgvVAGs.Rows[i].Cells["colCheckeo"].Value = true;
                            // dgvVAGs.Rows[i].Cells["colEstado"].Style.BackColor = Color.Green;
                            //dgvVAGs.Rows[i].Cells["colEstado"].Style.ForeColor = Color.White;
                        }
                    }
                    else
                    {
                        if (dgvVAGs.Rows[i].Cells["colAsignado"].Value != "")
                            //dgvVAGs.Rows[i].Cells["colEstado"].Value = "ERROR";
                            dgvVAGs.Rows[i].Cells["colCheckeo"].Value = false;
                        //dgvVAGs.Rows[i].Cells["colEstado"].Style.BackColor = Color.Red;
                        //dgvVAGs.Rows[i].Cells["colEstado"].Style.ForeColor = Color.White;
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            btnCrearRA.Enabled = true;
        }
        private void lstArchivos_Click(object sender, EventArgs e)
        {
            FilePrcss filePrcss = new FilePrcss(Application.StartupPath + "Tools\\wavInfo.exe");
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
                    filePrcss.WavInformation("\"" + archivo + "\"", out salida, opciones);
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
            string archivo = string.Empty;
            if (MessageBox.Show("Quit?", "Close program", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                e.Cancel = true;
                return;
            }

            if (rbNormal.Checked)
            {
                archivo = Application.StartupPath + "Tools\\W2002 - Relatos.csv";
            }

            if (rbCall1.Checked)
            {
                archivo = Application.StartupPath + "Tools\\W2002 - CALL01.csv";
            }

            if (rbCall3.Checked)
            {
                archivo = Application.StartupPath + "Tools\\W2002 - CALL02.csv";
            }
            if (rbAll.Checked)
            {
                archivo = Application.StartupPath + "Tools\\W2002 - All.csv";
            }

            if (string.IsNullOrEmpty(archivo))
            {
                return;
            }
            using (var writetext = new StreamWriter(archivo))
            {
                foreach (DataGridViewRow row in dgvVAGs.Rows)
                {
                    writetext.WriteLine($"{row.Cells["colPuntero"].Value};{row.Cells["colpuntero2"].Value};{row.Cells["colArchivo"].Value};{row.Cells["colFrase"].Value}");
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

            try
            {
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
                    Process process = new Process();
                    process.StartInfo.UseShellExecute = true;
                    process.StartInfo.FileName = "chrome";
                    process.StartInfo.Arguments = @"a";
                    process.Start();
                }
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }
        private void btnCrearRA_Click(object sender, EventArgs e)
        {
            int indice = 0;
            int indiceRA = 0;
            int loopRA = 0;
            List<string> listadoPunteros1;
            List<string> listadoPunteros2;
            List<string> listadoDeArchivos;
            Tools_RA tools_RA = new Tools_RA();
            FolderBrowserDialog openFolderDialog = new FolderBrowserDialog();
            try
            {
                if ((!rbNormal.Checked) && (!rbCall1.Checked) && (!rbCall3.Checked) && (!rbAll.Checked))
                {
                    MessageBox.Show("Seleccione un tipo de audio.");
                    return;
                }

                DialogResult result = openFolderDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    File.Copy(Application.StartupPath + "Tools\\W2002J00.RA", openFolderDialog.SelectedPath + "\\W2002J00.RA", true);
                    listadoDeArchivos = new List<string>();
                    listadoPunteros1 = new List<string>();
                    listadoPunteros2 = new List<string>();

                    foreach (DataGridViewRow row in dgvVAGs.Rows)
                    {
                        //string dato = Convert.ToString(row.Cells["colAsignado"].Value).Trim();
                        if (Convert.ToBoolean(row.Cells["colCheckeo"].Value) == true)
                        {
                            listadoDeArchivos.Add(Application.StartupPath + "Temp\\" + Convert.ToString(row.Cells["colAsignado"].Value) + ".vag");
                            listadoPunteros1.Add(Convert.ToString(row.Cells["colPuntero"].Value));
                            listadoPunteros2.Add(Convert.ToString(row.Cells["colpuntero2"].Value));
                            //dato = string.Empty;
                        }
                        //else
                        //{
                        //    MessageBox.Show(indice.ToString());
                        //}
                        indice++;
                    }
                    if (rbNormal.Checked) { indiceRA = 1; loopRA = 3; }
                    if (rbCall1.Checked) { indiceRA = 4; loopRA = 9; }
                    if (rbCall3.Checked) { indiceRA = 10; loopRA = 14; }
                    if (rbAll.Checked) { indiceRA = 1;loopRA = 14; }


                    tools_RA.CrearArchivosRA(listadoPunteros1.ToArray(), listadoPunteros2.ToArray(), listadoDeArchivos.ToArray(), openFolderDialog.SelectedPath, chkCallnames.Checked, indiceRA, loopRA);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (File.Exists(openFolderDialog.SelectedPath + "\\W2002J00.RA"))
                {

                    File.Copy(openFolderDialog.SelectedPath + "\\W2002J00.RA", Application.StartupPath + "Tools\\W2002J00.RA", true);
                }


            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int indice = 0;
            DialogResult dr = new DialogResult();
            dr = MessageBox.Show("Quiere guardar el listado?", "Guardar Listado", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                using (SaveFileDialog save = new SaveFileDialog())
                {
                    save.Filter = "Archivos de text|*.txt";
                    save.Title = "Guardar listado";
                    save.AddExtension = true;
                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        using (var writetext = new StreamWriter(save.FileName))
                        {
                            foreach (string i in lstArchivos.Items)
                            {
                                writetext.WriteLine($"{i}");
                            }
                        }
                    }
                }

            }
        }

        private void btnAbrirlistado_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog open = new OpenFileDialog())
                {
                    open.Filter = "Archivos de text|*.txt";
                    open.Title = "Guardar listado";
                    if (open.ShowDialog() == DialogResult.OK)
                    {
                        using (var readText = new StreamReader(open.FileName))
                        {
                            while (!readText.EndOfStream)
                            {
                                lstArchivos.Items.Add(readText.ReadLine());
                            }


                        }
                    }
                }
                lblContador.Text += lstArchivos.Items.Count.ToString();
            }
            catch (Exception)
            {

                throw;
            }


        }

        private void rbNormal_CheckedChanged(object sender, EventArgs e)
        {
            btnAgregarAudio.Enabled = true;
            btnAbrirlistado.Enabled = true;
            btnProcessData.Enabled = true;
            CargarGrilla("Tools\\W2002 - Relatos.csv");
        }

        private void rbCall1_CheckedChanged(object sender, EventArgs e)
        {
            btnAgregarAudio.Enabled = true;
            btnAbrirlistado.Enabled = true;
            btnProcessData.Enabled = true;
            CargarGrilla("Tools\\W2002 - CALL01.csv");
            //chkCallnames.Checked = rbCall1.Checked;
        }

        private void rbCall3_CheckedChanged(object sender, EventArgs e)
        {
            btnAgregarAudio.Enabled = true;
            btnAbrirlistado.Enabled = true;
            btnProcessData.Enabled = true;
            CargarGrilla("Tools\\W2002 - CALL02.csv");
        }

        private void rbCallEquipo_CheckedChanged(object sender, EventArgs e)
        {
            btnAgregarAudio.Enabled = true;
            btnAbrirlistado.Enabled = true;
            btnProcessData.Enabled = true;
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            btnAgregarAudio.Enabled = true;
            btnAbrirlistado.Enabled = true;
            btnProcessData.Enabled = true;
            CargarGrilla("Tools\\W2002 - All.csv");
        }
    }
}