using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ProyectoIIBDistri.Models;



namespace ProyectoIIBDistri.DAL
{
    public class GestorRestaurante : DbContext
    {
        
        public DbSet<HistorialTicket> HistorialTickets { get; set; }
        public DbSet<Comida> Comidas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Ticket> Ticketes { get; set; }
    }
}