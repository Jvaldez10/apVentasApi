using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using sistema_venta_erp.Controllers.Dto;
using sistema_venta_erp.Repositorio;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace sistema_venta_erp.Modulos
{
    public class AutenticacionModulo
    {
        private readonly IConfiguration _configuration;
        private readonly UsuarioRepositorio _usuarioRepositorio;
        private readonly PersonaRepositorio _personaRepositorio;

        public AutenticacionModulo(IConfiguration configuration,UsuarioRepositorio usuarioRepositorio,PersonaRepositorio personaRepositorio)
        {
            _configuration = configuration;
            _usuarioRepositorio = usuarioRepositorio;
            _personaRepositorio = personaRepositorio;
        }

        public async Task<TokenDto> Login(string usuario,string password)
        {
            var user = await _usuarioRepositorio.BuscarUsuario(usuario, password);
            if (user == null)
            {
                return null;
            }
            return await ConstrucToken(user.id, user.usuario);
            
        }
        public async Task<UsuarioDto> ObtenerDatosUsuario(int id)
        {
            var user = await _usuarioRepositorio.ObtenerUno(id);
            var persona = await _personaRepositorio.ObtenerUno(user.personaId);
            if (user == null)
            {
                return null;
            }
            return new UsuarioDto
            {
                apellido = persona.apellido,
                nombre = persona.nombre,
                usuario = user.usuario,
                direccion = persona.direccion
            };

        }

        private async Task<TokenDto> ConstrucToken(int usuarioId, string usuario)
        {
            var claims = new List<Claim>(){
                new Claim("id", usuarioId.ToString()),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._configuration.GetSection("KeyTokken").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddMinutes(39);
            var securityToken = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiration,
                signingCredentials: cred
            );

            return new TokenDto()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
                Expiration = expiration
            };
        }
    }
}
