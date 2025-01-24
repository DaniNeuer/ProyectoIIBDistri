using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProyectoIIBDistri.Models;
using ProyectoIIBDistri.DAL;

namespace ProyectoIIBDistri.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ApiController
    {
        private GestorRestaurante bd = new GestorRestaurante();

        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login([FromBody] LoginModel model)
        {
            var user = bd.Usuarios.FirstOrDefault(u => u.NombreUsuario == model.NombreUsuario && u.Contraseña == model.Contraseña);
            if(user == null)
            {
                return Unauthorized();
            }
            var token = GenerateToken(user);
            return Ok( new { Token = token });
        }

        private string GenerateToken(Usuario user)
        {
            // Implementar generación de token
            return "token";
        }
    }
}
