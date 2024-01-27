namespace Winning_Eleven_2002___RA_Maker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CargarGrilla();
        }
        private void CargarGrilla()
        {
            CargarCSVEnGridView("Tools\\DatosGrilla.csv");

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
                    dgvVAGs.Rows[i].Cells["colPuntero"].Value = campos[0];
                    dgvVAGs.Rows[i].Cells["colArchivo"].Value = campos[1];
                    dgvVAGs.Rows[i].Cells["colFrase"].Value = campos[2];
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

            Wav2Vag wav2Vag = new Wav2Vag(Application.StartupPath + "Tools\\wav2vag.exe");
            string[] parametros = new string[2] { "", "" };
            string salida = string.Empty;

            wav2Vag.ConvertirAWavVag("e:\\TEMP\\VAGS\\CONVERTID.wav",
                "e:\\TEMP\\VAGS\\C1.vag", out salida, parametros);

            if (!string.IsNullOrEmpty(salida))
                MessageBox.Show(salida);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Wav2Vag wav2Vag = new Wav2Vag();
            wav2Vag.ConvertirLBA("e:\\TEMP\\VAGS\\C1.vag", true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string salida = string.Empty;
            Wav2Vag wav2Vag = new Wav2Vag(Application.StartupPath + "Tools\\wav2vag.exe");
            wav2Vag.ProcesarArchivo("e:\\TEMP\\VAGS\\01a26 - Hoy retransmitimos desde el estadio real.wav",
                "01a15", out salida);

            if (!string.IsNullOrEmpty(salida))
            {
                MessageBox.Show(salida);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Wav2Vag wav2Vag = new Wav2Vag(Application.StartupPath + "Tools\\wav2vag.exe");
            string[] listadoNombre = new string[dgvVAGs.RowCount];
            int indice = 0;
            string salida = string.Empty;

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
            }

        }
    }
}
