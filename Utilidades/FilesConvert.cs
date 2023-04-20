using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace sistema_venta_erp.Utilidades
{
    public class FilesConvert
    {
        private readonly ILogger<FilesConvert> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private string PathTemporal = @"productos/";
        public FilesConvert(
            ILogger<FilesConvert> logger,
            IWebHostEnvironment webHostEnvironment
        )
        {
            this._logger = logger;
            this._webHostEnvironment = webHostEnvironment;
        }
        public async Task<string> GuardarFileToBase64(string base64, string nombreFile, string extencion)
        {
            byte[] file = Convert.FromBase64String(base64);
            var path = PathTemporal + nombreFile + extencion;
            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, path);
            MemoryStream stream = new MemoryStream(file);

            IFormFile formFile = new FormFile(stream, 0, file.Length, nombreFile, "filename");
            var FileStreamFs = new FileStream(serverFolder, FileMode.Create);
            await formFile.CopyToAsync(FileStreamFs);
            await FileStreamFs.DisposeAsync();
            return nombreFile + extencion;
        }
        public string GetFileToBase64(string ubicacion)
        {
            var ruta = PathTemporal + ubicacion;
            var path = Path.Combine(_webHostEnvironment.WebRootPath, ruta);
            Byte[] bytes = File.ReadAllBytes(path);
            String base64 = Convert.ToBase64String(bytes);
            return base64;
        }
    }
}