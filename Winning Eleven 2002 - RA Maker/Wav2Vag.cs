using System.Diagnostics;
using System.IO;
using rabulder;

namespace WE_RA_Maker
{
    public class Wav2Vag
    {
        private readonly string ejecutablePath;

        public Wav2Vag()
        {

        }
        public Wav2Vag(string ejecutablePath)
        {
            this.ejecutablePath = ejecutablePath;
        }

        public void ConvertirAWavVag(string archivoWav, string archivoVag, out string salida, string[] opciones = null)
        {

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                //WorkingDirectory = Path.GetDirectoryName (archivoVag),
                FileName = ejecutablePath,
                Arguments = $"{archivoWav} {archivoVag} {string.Join(" ", opciones)}",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = new Process { StartInfo = startInfo })
            {
                process.Start();
                process.WaitForExit();

                // Puedes manejar la salida estándar o errores si es necesario
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                // Realiza cualquier manipulación adicional según sea necesario
                // ...

                // Muestra la salida en la consola para fines de demostración
                if (!string.IsNullOrEmpty(error))
                {
                    salida = error;
                }
                else
                {
                    salida = output;
                }
            }
        }

        public void WavInformation(string archivoWav, out string salida, string[] opciones = null)
        {
            string args = $"{string.Join(" ", opciones)} {archivoWav}";
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                //WorkingDirectory = Path.GetDirectoryName (archivoVag),
                FileName = ejecutablePath,
                Arguments = $"{string.Join(" ", opciones)} {archivoWav}",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = new Process { StartInfo = startInfo })
            {
                process.Start();
                process.WaitForExit();

                // Puedes manejar la salida estándar o errores si es necesario
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                // Realiza cualquier manipulación adicional según sea necesario
                // ...

                // Muestra la salida en la consola para fines de demostración
                if (!string.IsNullOrEmpty(error))
                {
                    salida = error;
                }
                else
                {
                    salida = output;
                }
            }
        }

        // Abre el archivo VAG y lo adapta al formato que funciona bien en WE-PES
        public bool ConvertirLBA(string archivo, bool isCallName)
        {
            byte[] bytes = null;
            byte[] bytesFinalesCallnames = {
                                            0x0C,0x01,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
                                            0x00,0x07,0x77,0x77,0x77,0x77,0x77,0x77,0x77,0x77,0x77,0x77,0x77,0x77,0x77,0x77
                                            };
            byte[] bytesFinalesRelatos = {
                                            0x00,0x07,0x77,0x77,0x77,0x77,0x77,0x77,0x77,0x77,0x77,0x77,0x77,0x77,0x77,0x77
                                         };
            bool result = false;


            using (FileStream fs = new FileStream(archivo, FileMode.Append, FileAccess.Write))
            {
                int dato = (int)fs.Length / 2048;

               

                // Insertamos el arreglo de bytes para los VAGs del juego
                if (isCallName)
                {
                    int posicion = (int)fs.Length;
                    //fs.Position = posicion - 1;
                    fs.Seek(posicion, SeekOrigin.Begin);
                    fs.Write(bytesFinalesCallnames, 0, bytesFinalesCallnames.Length);
                }
                else
                {
                    int posicion = (int)fs.Length;
                    //fs.Position = posicion + 1;
                    fs.Seek(posicion, SeekOrigin.Begin);
                    fs.Write(bytesFinalesRelatos, 0, bytesFinalesRelatos.Length);
                }

                if (fs.Length % 2048 != 0)
                {
                    decimal resto = ((dato + 1) * 2048) - fs.Length;
                    dato = (int)resto;
                bytes = new byte[dato];
                // Rellenamos con 000000
                fs.Seek(fs.Length, SeekOrigin.Begin);
                fs.Write(bytes, 0, bytes.Length);
                }

                result = fs.Length % 2048 == 0 ? true : false;
            }
            return result;
        }

        public bool ProcesarArchivo(string archivoWav, string archivoVag, out string salida)
        {
            bool resutl = false;
            salida = string.Empty;
            string archivoSalida = Application.StartupPath + "TEMP\\" + archivoVag + ".vag";
            string nuevoWav = Application.StartupPath + "TEMP\\" + archivoVag + ".wav";
            string[] opciones = { };

            try
            {
                File.Copy(archivoWav, nuevoWav, true);

                if (File.Exists(nuevoWav))
                {
                    ConvertirAWavVag("\"" + nuevoWav + "\"", "\"" + archivoSalida + "\"", out salida, opciones);
                    File.Delete(nuevoWav);
                }

                resutl = File.Exists(archivoSalida) ? true : false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return resutl;
        }
    }
}
