using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.CFDI33
{
    public class PFX
    {
        public string WorkingDir { get; set; }

        string cer = "";
        string key = "";
        string clavePrivada = "";
        string ArchivoPFX = "";
        string ArchivoKPEM = "";
        string ArchivoCPEM = "";

        public string error = "";
        public string mensajeExito = "";

        ///

        ///
        /// </summary>

        /// <param name="cer_">archivo cer a utilizar</param>
        /// <param name="key_">archivo key a utilizar</param>
        /// <param name="clavePrivada_">clave para el archivo pfx</param>
        /// <param name="archivoPfx_">ruta del archivo pfx</param>
        /// <param name="path">ruta para archivos temporales PEM</param>
        public PFX(string cer_, string key_, string clavePrivada_, string archivoPfx_, string pathTemp, string workingDirBinFiles)
        {
            cer = cer_;
            key = key_;
            clavePrivada = clavePrivada_;

            ArchivoKPEM = pathTemp + "k.pem";
            ArchivoCPEM = pathTemp + "c.pem";
            ArchivoPFX = archivoPfx_;
            WorkingDir = workingDirBinFiles;
        }

        public bool creaPFX()
        {
            bool exito = false;

            //validaciones
            if (!File.Exists(cer))
            {
                error = "No existe el archivo cer en el sistema";
                return false;
            }
            if (!File.Exists(key))
            {
                error = "No existe el archivo key en el sistema";
                return false;
            }
            if (clavePrivada.Trim().Equals(""))
            {
                error = "No existe una clave privada aun en el sistema";
                return false;
            }

            //creamos objetos Process
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            System.Diagnostics.Process proc2 = new System.Diagnostics.Process();
            System.Diagnostics.Process proc3 = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc2.EnableRaisingEvents = false;
            proc3.EnableRaisingEvents = false;

            //openssl x509 -inform DER -in certificado.cer -out certificado.pem
            proc.StartInfo.FileName = "openssl";
            proc.StartInfo.Arguments = "x509 -inform DER -in \"" + cer + "\" -out \"" + ArchivoCPEM + "\"";
            proc.StartInfo.WorkingDirectory = WorkingDir;
            proc.Start();
            proc.WaitForExit();

            //openssl pkcs8 -inform DER -in llave.key -passin pass:a0123456789 -out llave.pem
            proc2.StartInfo.FileName = "openssl";
            proc2.StartInfo.Arguments = "pkcs8 -inform DER -in \"" + key + "\" -passin pass:" + clavePrivada + " -out \"" + ArchivoKPEM + "\"";
            proc2.StartInfo.WorkingDirectory = WorkingDir;
            proc2.Start();
            proc2.WaitForExit();

            //openssl pkcs12 -export -out archivopfx.pfx -inkey llave.pem -in certificado.pem -passout pass:clavedesalida
            proc3.StartInfo.FileName = "openssl";
            proc3.StartInfo.Arguments = "pkcs12 -export -out \"" + ArchivoPFX + "\" -inkey \"" + ArchivoKPEM + "\" -in \"" + ArchivoCPEM + "\" -passout pass:" + clavePrivada;
            proc3.StartInfo.WorkingDirectory = WorkingDir;
            proc3.Start();
            proc3.WaitForExit();

            proc.Dispose();
            proc2.Dispose();
            proc3.Dispose();

            //enviamos mensaje exitoso
            if (System.IO.File.Exists(ArchivoPFX))
                mensajeExito = "Se ha creado el archivo PFX ";
            else
            {
                error = "Error al crear el archivo PFX, puede ser que el cer o el key no sean archivos con formato correcto";
                return false;
            }

            //eliminamos los archivos pem
            if (File.Exists(ArchivoCPEM)) File.Delete(ArchivoCPEM);
            if (File.Exists(ArchivoKPEM)) File.Delete(ArchivoKPEM);

            exito = true;

            return exito;
        }
    }
}
