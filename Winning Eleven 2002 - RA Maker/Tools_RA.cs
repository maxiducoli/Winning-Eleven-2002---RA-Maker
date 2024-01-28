using WE_RA_Maker;
using System.IO;
namespace rabulder
{
    public class Tools_RA
    {
        public enum RASize : int
        {
            W2002J00 = 20480000,
            W2002J10 = 20480000,
            W2002J11 = 22528000,
            W2002J12 = 18432000,
            W2002J60 = 10240000,
            W2002J61 = 10240000,
            W2002J62 = 10240000,
            W2002J63 = 8192000,
            W2002J64 = 8192000,
            W2002J65 = 8192000,
            W2002J70 = 10240000,
            W2002J71 = 10240000,
            W2002J72 = 10240000,
            W2002J73 = 10240000,
            W2002J74 = 10240000
        }
        public enum RA_LBA : int
        {
            J00 = 0,
            J10 = 10000,
            J11 = 20000,
            J12 = 31000,
            J60 = 10000,
            J61 = 15000,
            J62 = 20000,
            J63 = 25000,
            J64 = 29000,
            J65 = 33000,
            J70 = 37000,
            J71 = 42000,
            J72 = 47000,
            J73 = 52000,
            J74 = 57000
        }

        // Cantidad de bloques del archivo VAGs
        public int ObtenerLargoBloque(int largo)
        {
            return largo % 2048 != 0 ? (largo / 2048) + 1 : largo / 2048;
        }

        // Byte final del puntero. Si es archivo normal RA10-RA65) retorna 1, si no retorna 3
        public int ObtenerByteFinal(bool esNormal)
        {
            return (esNormal ? 1 : 3);
        }

        public void CrearArchivosRA(string[] listaOffset, string[] listaDeVags, string folder, bool esCallName)
        {
            string ARCHIVO_RAOO = Application.StartupPath +  "Tools\\W2002J00.RA";
            int indice = -1;
            int ContadorSize = 0;
            int LBAValue = -1;
            int offset;
            int fileSize = -1;
            byte[] buffer = null;
            byte[] datosVAG= new byte[4];
            byte[] dosprimeros = new byte[2];
            byte[] bloque = null;
            int largoTemp = 0;
            int contadorTemp = -1;
            int contadorLista = 0;
           // Wav2Vag wav2vag = new Wav2Vag();

            string[] raFileNames = { "W2002J00.RA", "W2002J10.RA", "W2002J11.RA", "W2002J12.RA", "W2002J60.RA", "W2002J61.RA", "W2002J62.RA", "W2002J63.RA", "W2002J64.RA", "W2002J65.RA", "W2002J70.RA", "W2002J71.RA", "W2002J72.RA", "W2002J73.RA", "W2002J74.RA" };
            try
            {
                if (!esCallName)
                {
                    indice = 1;
                    while (indice < 4)
                    {
                        switch (indice)
                        {
                            case 0: // RA00
                                LBAValue = (int)RA_LBA.J00;
                                fileSize = (int)RASize.W2002J00;
                                break;
                            case 1: // RA10
                                LBAValue = (int)RA_LBA.J10;
                                fileSize = (int)RASize.W2002J10;
                                break;
                            case 2: // RA11
                                LBAValue = (int)RA_LBA.J11;
                                fileSize = (int)RASize.W2002J11;
                                break;
                            case 3: // RA12
                                LBAValue = (int)RA_LBA.J12;
                                fileSize = (int)RASize.W2002J12;
                                break;
                            case 4: //RA60
                                LBAValue = (int)RA_LBA.J60;
                                fileSize = (int)RASize.W2002J60;
                                break;
                            case 5: //RA61
                                LBAValue = (int)RA_LBA.J61;
                                fileSize = (int)RASize.W2002J61;
                                break;
                            case 6: // RA62
                                LBAValue = (int)RA_LBA.J62;
                                fileSize = (int)RASize.W2002J62;
                                break;
                            case 7: // RA63
                                LBAValue = (int)RA_LBA.J63;
                                fileSize = (int)RASize.W2002J63;
                                break;
                            case 8: // RA64
                                LBAValue = (int)RA_LBA.J64;
                                fileSize = (int)RASize.W2002J64;
                                break;
                            case 9: // RA65
                                LBAValue = (int)RA_LBA.J65;
                                fileSize = (int)RASize.W2002J65;
                                break;
                            case 10: // RA70
                                LBAValue = (int)RA_LBA.J70;
                                fileSize = (int)RASize.W2002J70;
                                break;
                            case 11: // RA71
                                LBAValue = (int)RA_LBA.J71;
                                fileSize = (int)RASize.W2002J71;
                                break;
                            case 12: // RA72
                                LBAValue = (int)RA_LBA.J72;
                                fileSize = (int)RASize.W2002J72;
                                break;
                            case 13: // RA73
                                LBAValue = (int)RA_LBA.J73;
                                fileSize = (int)RASize.W2002J73;
                                break;
                            case 14: // RA74
                                LBAValue = (int)RA_LBA.J74;
                                fileSize = (int)RASize.W2002J74;
                                break;
                            default:
                                break;
                        }

                        // Creamos el RA
                        using (FileStream fs = new FileStream(folder + "\\" + raFileNames[indice], FileMode.CreateNew, FileAccess.Write))
                        {
                            // Comenzamos en el offset 2048
                            buffer = new byte[2048];
                            offset = buffer.Length;
                            fs.Seek(0, SeekOrigin.Begin);

                            // Escribimos el comienzo del archivo RA con 2048 ceros.
                            fs.Write(buffer, 0, buffer.Length);

                            // Offset del archivo.
                            offset = (int)fs.Length;

                            // Contador de tamaño del archivo creado.
                            ContadorSize = (int)fs.Length;

                            // Comenzamos a leer los VAGs y a convertir su tamaño
                            for (int i = contadorLista; i < listaDeVags.Length; i++)
                            {
                                // Agrando los VAGs a su respectivo tamaño LBA
                                Wav2Vag wav2Vag = new Wav2Vag();

                                // Si convirtió bien, sigue.
                                if (wav2Vag.ConvertirLBA(listaDeVags[i], esCallName))
                                {
                                    // Abrimos el archivo recién convertido para leer
                                    using (FileStream f = new FileStream(listaDeVags[i], FileMode.Open, FileAccess.Read))
                                    {
                                        // Contador temporal del tamaño del RA
                                        contadorTemp = (int)f.Length + ContadorSize;

                                        // Seteamos el buffer y leemos el nuevo VAG.
                                        buffer = new byte[(int)f.Length];
                                        f.Seek(0, SeekOrigin.Begin);
                                        f.Read(buffer, 0, buffer.Length);

                                        // Leemos el largo del archivo y lo convertimos en LBA
                                        largoTemp = ObtenerLargoBloque((int)f.Length) + LBAValue;
                                        // Guardo los dos bytes del puntero
                                        dosprimeros = BitConverter.GetBytes(largoTemp);
                                        // Guardo en el array a escribir
                                        Array.Copy(dosprimeros, datosVAG, 2);
                                        // Escribo el largo del LBA
                                        datosVAG[2] = (byte)largoTemp;
                                        // Escribo el último Byte
                                        datosVAG[3] = (byte)ObtenerByteFinal(esCallName);
                                    }

                                    if (contadorTemp > fileSize)
                                    {
                                        break;
                                    }

                                    // Escribimos el VAG en el RA nuevo
                                    fs.Write(buffer, 0, buffer.Length);
                                    // Contador de tamaño del archivo creado.
                                    ContadorSize = (int)fs.Length;
                                    using (FileStream fsPuntero = new FileStream(ARCHIVO_RAOO, FileMode.Open, FileAccess.Write))
                                    {
                                        // Obtengo el offset del puntero
                                        int offsetPuntero = Convert.ToInt32(listaOffset[i]);
                                        // Seteo el offset del puntero
                                        fsPuntero.Seek(offsetPuntero, SeekOrigin.Begin);
                                        fsPuntero.Write(datosVAG, 0, datosVAG.Length);
                                    }
                                }
                                contadorLista++;
                            }

                        }

                        indice++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { }
        }
    }
}