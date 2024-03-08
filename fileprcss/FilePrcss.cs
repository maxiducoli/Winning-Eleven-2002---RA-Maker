using System.Diagnostics;
using static fileprcss.Tools_RA;
namespace fileprcss
{
    public class FilePrcss
    {
        private readonly string ejecutablePath;

        public FilePrcss()
        {
          
        }

        public FilePrcss(string filename)
            {
            this.ejecutablePath = filename;
        }
        /// <summary>
        /// Ajusta los archivos VAG al tamaño correspondiente a la cantidad de LBA
        /// </summary>
        /// <param name="archivo">Archivo VAG a ajustar. Este archivo será ajustado a cierta cantidad de bytes y además será optimizaado como están los VAGs del Winning Eleven 2002 original.</param>
        /// <param name="isCallName">Indicado booleano. Si es Call name se ajusta de una manera diferente a si no es Call name.</param>
        /// <returns></returns>
        public bool ConvertirLBA(string archivo, bool isCallName)
        {
            bool result = false;
            using (FileStream fs = new FileStream(archivo, FileMode.OpenOrCreate, FileAccess.Write))
            {
                if (fs.Length % 2048 != 0)
                {
                    int dato = (int)fs.Length / 2048;
                    decimal resto = ((dato + 1) * 2048) - fs.Length;
                    dato = (int)resto;

                    byte[] bytes = new byte[dato];
                    fs.Seek(fs.Length, SeekOrigin.Begin);
                    fs.Write(bytes, 0, bytes.Length);
                }
                result = fs.Length % 2048 == 0;
            }
            return result;
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

        public bool ProcesarArchivo(string tempFolder,string archivoWav, string archivoVag, bool esCallname, out string salida)
        {
            bool resutl = false;
            salida = string.Empty;
            string archivoSalida = tempFolder + archivoVag + ".vag";
            string nuevoWav = tempFolder + archivoVag + ".wav";
            string[] opciones = { };

            try
            {
                File.Copy(archivoWav, nuevoWav, true);

                if (File.Exists(nuevoWav))
                {
                    ConvertToVAG( nuevoWav ,  archivoSalida , out salida);
                    File.Delete(nuevoWav);
                }

                resutl = File.Exists(archivoSalida) ? true : false;
            }
            catch (Exception ex)
            {
                
            }
            return resutl;
        }

        public void ConvertToVAG(string inputFilePath, string outputFilePath, out string mensaje)
        {
            try
            {
                // Ruta al ejecutable de MFAudio
                string mfaudioExePath = ejecutablePath;// programExe;
                string name = "By CARP";
                // Configuración de argumentos para la conversión
                //  WAV2VAG.exe string arguments = $" \"{inputFilePath}\" \"{outputFilePath}\" -name={name} -freq=22050";
                // MFAudio.exe
                string arguments = $" /OTVAGC /OF22050 \"{inputFilePath}\" \"{outputFilePath}\"";

                // Configurar el proceso
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = mfaudioExePath,
                    Arguments = arguments,
                    CreateNoWindow = true,  // Oculta la ventana
                    WindowStyle = ProcessWindowStyle.Hidden,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    WorkingDirectory = Environment.CurrentDirectory  // Opcional: establecer el directorio de trabajo
                };

                // Iniciar el proceso
                using (Process process = new Process { StartInfo = startInfo })
                {
                    process.Start();
                    process.WaitForExit();

                    mensaje = "Conversión completada con éxito.";
                }
            }
            catch (Exception ex)
            {
                mensaje = $"Error durante la conversión: {ex.Message}";
            }
        }
    
        public bool FixVag(string vag) 
        {
            bool result = false;
            byte[] aB = { 32 };
            byte[] aC = { 1 };
            int offset = 7;
            byte[] bytes = {0x00,0x07,0x07,0x07,0x07,0x07,0x07,0x07,0x07,0x07,0x07,0x07,0x07,0x07,0x07,0x07};
            try
            {
                using (FileStream fs = new FileStream(vag,FileMode.Open,FileAccess.Write))
                {
                    // Escribimos aB
                    fs.Seek(offset, SeekOrigin.Begin);
                    fs.Write(aB, 0, aB.Length);
                    // Escribimos bytes
                    offset = (int)fs.Length - 16;
                    fs.Seek(offset, SeekOrigin.Begin);
                    fs.Write(bytes, 0, bytes.Length);
                    // Escribimos aC
                    offset = (int)fs.Length - 31;
                    fs.Seek(offset, SeekOrigin.Begin);
                    fs.Write(aC, 0, aC.Length);
                    result = true;  
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentOutOfRangeException(ex.Message);
            }
            return result;
        }
    }
}
