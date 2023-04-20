using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_venta_erp.Utilidades
{
    public class Letras
    {
        private readonly ILogger<Letras> _logger;

        public Letras(
            ILogger<Letras> logger
        )
        {
            this._logger = logger;
        }
        public string NombreFormatoBase64(string base64)
        {
            var dividir = base64.Split(';');
            var format = dividir[0];
            var dividirFormat = format.Split('/'); //data:image/jpeg
            return dividirFormat[1];
        }
        public string DataBase64(string base64)
        {
            var dividir = base64.Split(','); //solo data base64
            var soloBase64 = dividir[1];
            return soloBase64;
        }
    }
}