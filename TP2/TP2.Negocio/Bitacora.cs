using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2.Negocio
{
    public enum TipoLog
    {
        Error = 0,
        Aviso = 1,
        Informacion = 2
    }
    public class Bitacora
    {
        public static void CrearLog(string mensaje, TipoLog tipo, Exception ex = null)
        {
            string ruta = ConfigurationManager.AppSettings["RutaLog"] ?? "C:\\";
            string archivo = string.Format("{0}\\tp2log.txt", ruta);
            using (FileStream fs = new FileStream(archivo, FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    sw.WriteLine(string.Format("{0} - {1}", tipo, DateTime.Now));
                    sw.WriteLine(string.Format("{0}", mensaje));
                    if (ex != null)
                    {
                        sw.WriteLine(string.Format("{0}", ex.Message));
                        sw.WriteLine(string.Format("{0}", ex.StackTrace));
                    }

                    sw.WriteLine("=============================================");
                }
            }
        }
    }
}
