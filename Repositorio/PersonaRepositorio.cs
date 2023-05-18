using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using sistema_venta_erp.Contexto;
using sistema_venta_erp.Entidades;

namespace sistema_venta_erp.Repositorio
{
    public class PersonaRepositorio
    {
        private readonly ILogger<PersonaRepositorio> _logger;
        private readonly DBContext _dBContext;

        public PersonaRepositorio(
            ILogger<PersonaRepositorio> logger,
            DBContext dBContext
        )
        {
            this._logger = logger;
            this._dBContext = dBContext;
        }
        public async Task<Persona> ObtenerUno(int personaId)
        {
            this._logger.LogWarning($"PersonaRepositorio/{System.Reflection.MethodBase.GetCurrentMethod()}({personaId}): Inizialize...");
            var resultado = await this._dBContext.persona.FirstOrDefaultAsync(X => X.id == X.id);
            this._logger.LogWarning($"PersonaRepositorio/{System.Reflection.MethodBase.GetCurrentMethod()} SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
    }
}
