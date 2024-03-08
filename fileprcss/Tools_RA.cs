using System.IO;
using System.Windows;
namespace fileprcss
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

        public enum RA_StartLBA : int
        {
            RA_Start00 = 2048,
            RA_Start10 = 2048, 
            RA_Start11 = 2048, 
            RA_Start12 = 2048, 
            RA_Start60 = 2048, 
            RA_Start61 = 2048,
            RA_Start62 = 2048, 
            RA_Start63 = 2048, 
            RA_Start64 = 2048, 
            RA_Start65 = 2048,
            RA_Start70 = 2048, 
            RA_Start71 = 2048, 
            RA_Start72 = 2048, 
            RA_Start73 = 2048, 
            RA_Start74 = 2048
        }

        // Cantidad de bloques del archivo VAGs
        public int ObtenerLargoBloque(int largo)
        {
            return largo % 2048 != 0 ? (largo / 2048) + 1 : largo / 2048;
        }

        // Byte final del puntero. Si es archivo normal RA10-RA65) retorna 1, si no retorna 3
        public int ObtenerByteFinal(bool esCallName)
        {
            return (esCallName ? 3 : 1);
        }

        public void CrearArchivosRA(string[] listaOffset, string[] listaOffset2, string[] listaDeVags, string folder, bool esCallName,int indiceRA, int loopRA)
        {
           
            int ContadorSize = 0;
            int LBAValue = -1;
            int offset;
            int fileSize = -1;
            int RA_Start = 0;
            byte[] buffer = null;
            byte[] datosVAG= new byte[3];
            byte[] dosprimeros = new byte[2];
            byte[] bloque = null;
            int largoTemp = 0;
            int contadorTemp = -1;
            int contadorLista = 0;
            bool terminado = false;
            StreamWriter writeText = null;
           // Wav2Vag wav2vag = new Wav2Vag();

            string[] raFileNames = { "W2002J00.RA", "W2002J10.RA", "W2002J11.RA", "W2002J12.RA", "W2002J60.RA", "W2002J61.RA", "W2002J62.RA", "W2002J63.RA", "W2002J64.RA", "W2002J65.RA", "W2002J70.RA", "W2002J71.RA", "W2002J72.RA", "W2002J73.RA", "W2002J74.RA" };
            try
            {
                //if (!esCallName)
                //{
                    //indiceRA = 1;
                    while (indiceRA <= loopRA)
                    {
                        switch (indiceRA)
                        {
                            case 0: // RA00
                                LBAValue = (int)RA_LBA.J00;
                                fileSize = (int)RASize.W2002J00;
                                RA_Start = (int)RA_StartLBA.RA_Start00;
                                break;
                            case 1: // RA10
                                LBAValue = (int)RA_LBA.J10;
                                fileSize = (int)RASize.W2002J10;
                                RA_Start = (int)RA_StartLBA.RA_Start10;
                                break;
                            case 2: // RA11
                                LBAValue = (int)RA_LBA.J11;
                                fileSize = (int)RASize.W2002J11;
                                RA_Start = (int)RA_StartLBA.RA_Start11;
                                break;
                            case 3: // RA12
                                LBAValue = (int)RA_LBA.J12;
                                fileSize = (int)RASize.W2002J12;
                                RA_Start = (int)RA_StartLBA.RA_Start12;
                                break;
                            case 4: //RA60
                                LBAValue = (int)RA_LBA.J60;
                                fileSize = (int)RASize.W2002J60;
                                RA_Start = (int)RA_StartLBA.RA_Start60;
                                break;
                            case 5: //RA61
                                LBAValue = (int)RA_LBA.J61;
                                fileSize = (int)RASize.W2002J61;
                                RA_Start = (int)RA_StartLBA.RA_Start61;
                                break;
                            case 6: // RA62
                                LBAValue = (int)RA_LBA.J62;
                                fileSize = (int)RASize.W2002J62;
                                RA_Start = (int)RA_StartLBA.RA_Start62;
                                break;
                            case 7: // RA63
                                LBAValue = (int)RA_LBA.J63;
                                fileSize = (int)RASize.W2002J63;
                                RA_Start = (int)RA_StartLBA.RA_Start63;
                                break;
                            case 8: // RA64
                                LBAValue = (int)RA_LBA.J64;
                                fileSize = (int)RASize.W2002J64;
                                RA_Start = (int)RA_StartLBA.RA_Start64;
                                break;
                            case 9: // RA65
                                LBAValue = (int)RA_LBA.J65;
                                fileSize = (int)RASize.W2002J65;
                                RA_Start = (int)RA_StartLBA.RA_Start65;
                                break;
                            case 10: // RA70
                                LBAValue = (int)RA_LBA.J70;
                                fileSize = (int)RASize.W2002J70;
                                RA_Start = (int)RA_StartLBA.RA_Start70;
                                break;
                            case 11: // RA71
                                LBAValue = (int)RA_LBA.J71;
                                fileSize = (int)RASize.W2002J71;
                                RA_Start = (int)RA_StartLBA.RA_Start71;
                                break;
                            case 12: // RA72
                                LBAValue = (int)RA_LBA.J72;
                                fileSize = (int)RASize.W2002J72;
                                RA_Start = (int)RA_StartLBA.RA_Start72;
                                break;
                            case 13: // RA73
                                LBAValue = (int)RA_LBA.J73;
                                fileSize = (int)RASize.W2002J73;
                                RA_Start = (int)RA_StartLBA.RA_Start73;
                                break;
                            case 14: // RA74
                                LBAValue = (int)RA_LBA.J74;
                                fileSize = (int)RASize.W2002J74;
                                RA_Start = (int)RA_StartLBA.RA_Start74;
                                break;
                            default:
                                break;
                        }
                        terminado = false;
                        writeText = new StreamWriter(folder + "\\" + raFileNames[indiceRA] + ".txt");
                        // Creamos el RA
                        using (FileStream fs = new FileStream(folder + "\\" + raFileNames[indiceRA], FileMode.CreateNew, FileAccess.Write))
                        {
                            // Comenzamos en el offset con el tamaño adecuado
                            buffer = new byte[RA_Start];
                            offset = buffer.Length;
                            fs.Seek(0, SeekOrigin.Begin);

                            // Escribimos el comienzo del archivo RA con ceros.
                            fs.Write(buffer, 0, buffer.Length);

                            // Offset del archivo.
                            offset = (int)fs.Length;

                            // Contador de tamaño del archivo creado.
                            ContadorSize = (int)fs.Length;

                            // Comenzamos a leer los VAGs y a convertir su tamaño
                            while (!terminado)
                            {
                                    // Abrimos el archivo recién convertido para leer
                                    using (FileStream f = new FileStream(listaDeVags[contadorLista], FileMode.Open, FileAccess.Read))
                                    {
                                        // Seteamos el buffer y leemos el nuevo VAG.
                                        buffer = new byte[(int)f.Length];
                                        f.Seek(0, SeekOrigin.Begin);
                                        f.Read(buffer, 0, buffer.Length);

                                        // Leemos el largo del archivo y lo convertimos en LBA
                                        largoTemp = ObtenerLargoBloque((int)fs.Length) + LBAValue;

                                        // Guardo los dos bytes del puntero
                                        dosprimeros = BitConverter.GetBytes(largoTemp);
                                        // Guardo en el array a escribir
                                        Array.Copy(dosprimeros, datosVAG, 2);
                                        // Escribo el largo del LBA
                                        datosVAG[2] = (byte)ObtenerLargoBloque((int)f.Length);
                                        // Escribo el último Byte
                                        //datosVAG[3] = (byte)ObtenerByteFinal(esCallName);
                                        
                                        // Contador temporal del tamaño del RA
                                        contadorTemp = (int)f.Length + ContadorSize;
                                    }

                                    if (contadorTemp > fileSize || contadorLista >= listaDeVags.Length)
                                    {
                                        int resto = fileSize - (int)fs.Length;
                                        buffer = new byte[resto];
                                        fs.Write(buffer, 0, resto);
                                        terminado = true;
                                        break;
                                    }
                                    else
                                    {
                                    // Escribimos el VAG en el RA nuevo
                                    fs.Write(buffer, 0, buffer.Length);
                                    // Contador de tamaño del archivo creado.
                                    ContadorSize = (int)fs.Length;
                                    }

                                writeText.WriteLine($"{listaOffset[contadorLista]};" + //{BitConverter.ToString(datosVAG, 0)}");
                                        $"{datosVAG[3].ToString("X2")}" + $"{datosVAG[2].ToString("X2")}" + $"{datosVAG[1].ToString("X2")}" + $"{datosVAG[0].ToString("X2")}");
                            
                                using (FileStream fsPuntero = new FileStream(folder + "\\W2002J00.RA", FileMode.Open, FileAccess.Write))
                                    {
                                        // Obtengo el offset del puntero
                                        int offsetPuntero = Convert.ToInt32(listaOffset[contadorLista]);
                                        // Seteo el offset del puntero
                                        fsPuntero.Seek(offsetPuntero, SeekOrigin.Begin);
                                        fsPuntero.Write(datosVAG, 0, datosVAG.Length);
                                    // Segundo listado de offsets
                                    if (!string.IsNullOrEmpty(listaOffset2[contadorLista]))
                                    {
                                    // Obtengo el offset del puntero
                                    offsetPuntero = Convert.ToInt32(listaOffset2[contadorLista]);
                                    // Seteo el offset del puntero
                                    fsPuntero.Seek(offsetPuntero, SeekOrigin.Begin);
                                    fsPuntero.Write(datosVAG, 0, datosVAG.Length);
                                    }
                                }

                                contadorLista++;
                            }
                        }
                        writeText.Close();
                        indiceRA++;
                    }
                //}
                //File.WriteAllLines()
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { }
        }
    }
}