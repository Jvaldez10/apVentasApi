using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_venta_erp.Utilidades
{
    public class StringConnection
    {
        public string IpServer { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Port { get; set; }
        public string Database { get; set; }
    }
    public class StringKeyPass
    {
        public string key { get; set; }
        public string Method { get; set; }
    }
}