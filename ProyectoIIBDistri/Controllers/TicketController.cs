using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ProyectoIIBDistri.DAL;
using ProyectoIIBDistri.Models;
using System.Net.Http;
using System.Web.Http;


namespace ProyectoIIBDistri.Controllers
{
    [Route("api/[controller]")]
    public class TicketController : ApiController
    {
        private GestorRestaurante  bd = new GestorRestaurante();
        [HttpPost]
        [Route("agregarTicket")]
        public IHttpActionResult AgregarTicket([FromBody] Ticket model)
        {
            var ticket = new Ticket()
            {
                UsuarioId = model.UsuarioId,
                Cantidad = model.Cantidad
            };
            bd.Ticketes.Add(ticket);
            bd.HistorialTickets.Add(new HistorialTicket
            {
                UsuarioId = model.UsuarioId,
                Accion = "Agregar",
                Cantidad = model.Cantidad,
                Fecha = DateTime.Now
            });
            bd.SaveChanges();
            return Ok(ticket);
        }
        [HttpPost]
        [Route("usarTicket")]
        public IHttpActionResult UsarTicket([FromBody] Ticket model)
        {
            var ticket = bd.Ticketes.FirstOrDefault(t => t.UsuarioId == model.UsuarioId);
            if(ticket == null || ticket.Cantidad < model.Cantidad)
            {
                return BadRequest("no hay suficientes tickets");
            }
            ticket.Cantidad -= model.Cantidad;
            bd.HistorialTickets.Add(new HistorialTicket
            {
                UsuarioId = model.UsuarioId,
                Accion = "Usar",
                Cantidad = model.Cantidad,
                Fecha = DateTime.Now
            });
            bd.SaveChanges();
            return Ok(ticket);
        }
        [HttpGet]
        [Route("consultar/{usuarioId}")]
        public IHttpActionResult ConsultarTickets(int usuarioId)
        {
            var ticket  = bd.Ticketes.FirstOrDefault(t => t.UsuarioId == usuarioId);
            if(ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket.Cantidad);
        }

        [HttpGet]
        [Route("historial/{usuarioId}")]
        public IHttpActionResult HistorialTickets(int usuarioId)
        {
            var historial = bd.HistorialTickets.Where(h => h.UsuarioId == usuarioId).ToList();
            return Ok(historial);
        }
    }
}