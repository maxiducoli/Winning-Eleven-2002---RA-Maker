using WE_RA_Maker;
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
        public int ObtenerLargoBloque(byte[] bloque)
        {
            return bloque.Length % 2048 != 0 ? (bloque.Length / 2048) + 1 : bloque.Length / 2048;
        }

        // Byte final del puntero. Si es archivo normal RA10-RA65) retorna 1, si no retorna 3
        public int ObtenerByteFinal(bool esNormal)
        {
            return (esNormal ? 1 : 3);
        }

        public void CrearArchivosRA(string[] listaOffset, string[] listaDeVags, string folder, bool esCallName)
        {
            int indice = -1;
            int ContadorSize = 0;
            int LBAValue = -1;
            int offset;
            int fileSize = -1;
            byte[] buffer = null;
           // Wav2Vag wav2vag = new Wav2Vag();

            string[] raFileNames = { "W2002J10.RA", "W2002J11.RA", "W2002J12.RA", "W2002J60.RA", "W2002J61.RA", "W2002J62.RA", "W2002J63.RA", "W2002J64.RA", "W2002J65.RA", "W2002J70.RA", "W2002J71.RA", "W2002J72.RA", "W2002J73.RA", "W2002J74.RA" };

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
                    using (FileStream fs = new FileStream(folder + raFileNames[indice], FileMode.CreateNew, FileAccess.Write))
                    {
                        // Comenzamos en el offset 2048
                        buffer = new byte[2048];
                        offset = buffer.Length;

                        // Comenzamos a leer los VAGs y a convertir su tamaño
                        for (int i = 0; i < listaDeVags.Length; i++)
                        {
                           
                        }

                    }

                    indice++;
                }
            }
        }
    }
}