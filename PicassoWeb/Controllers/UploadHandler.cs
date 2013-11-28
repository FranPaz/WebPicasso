using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace PicassoWeb.Controllers {
    public class UploadHandler {

        private static string serverPath(string carpeta) {
            return HttpContext.Current.Server.MapPath("~/Uploads/" + carpeta);
        }

        private static string UploadWholeFile(HttpPostedFileBase file, string carpeta, string nombre) {
            

            var archivoCortado = file.FileName.Split('.');
            string extensionArchivo = archivoCortado.Last();
            string nombreArchivo = nombre + "." + extensionArchivo;
            var fullPath = Path.Combine(serverPath(carpeta), Path.GetFileName(nombreArchivo));

            if (!System.IO.File.Exists(fullPath)) {
                file.SaveAs(fullPath);
            } else {
                System.IO.File.Delete(fullPath);
                file.SaveAs(fullPath);
            }
            return "/Uploads/" + carpeta + "/" + nombreArchivo;
        }

        public static string subir(HttpPostedFileBase archivo, string carpeta, string nombre, string imgOriginal) {
            string imagenURL = "";
            if (archivo.FileName != "") {
                imagenURL = UploadWholeFile(archivo, carpeta, nombre);
                }
            else {
                if (imgOriginal == "") {
                    imagenURL = "/Images/noPhoto.jpg";
                } else {
                    imagenURL = imgOriginal;
                }
            }
            return imagenURL;
        }
    }
}