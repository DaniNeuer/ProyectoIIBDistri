using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace ProyectoIIBDistri.DAL
{
    public class GestorRestaurante : DbContext
    {
        public DbSet<Usuario> Rocas { get; set; }
        public DbSet<Ticket> Fosiles { get; set; }
        public DbSet<HistorialTicket> HistorialTickets { get; set; }
        public DbSet<Comida> Comidas { get; set; }
    }
}