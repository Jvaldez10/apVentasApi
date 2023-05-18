using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using sistema_venta_erp.Contexto;
using sistema_venta_erp.Entidades;

namespace sistema_venta_erp.Repositorio
{
    public class UsuarioRepositorio
    {

        private readonly ILogger<UsuarioRepositorio> _logger;
        private readonly DBContext _dBContext;

        public UsuarioRepositorio(
            ILogger<UsuarioRepositorio> logger,
            DBContext dBContext
        )
        {
            this._logger = logger;
            this._dBContext = dBContext;
        }
        public async Task<Usuario> BuscarUsuario(string usuario,string password)
        {
            this._logger.LogWarning($"UsuarioRepositorio/{System.Reflection.MethodBase.GetCurrentMethod()}({usuario},{password}): Inizialize...");
            var resultado = await this._dBContext.usuario.Where(X => X.id == X.id).FirstOrDefaultAsync();
            this._logger.LogWarning($"UsuarioRepositorio/{System.Reflection.MethodBase.GetCurrentMethod()} SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
    }
}
