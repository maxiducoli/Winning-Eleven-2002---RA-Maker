namespace rabulder
{
    public class Tools_RA
    {
        public enum RASize : int
        {
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

        public void CrearArchivosRA(string[] listaDeVags)
        { 
            
        }
    }
}

