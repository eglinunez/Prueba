using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PruebaMvc.Models
{
    public class Documentos
    {
        public Guid Id { get; set; }
        public string Descripcion { get; set; }
        public Guid ClienteId { get; set; }

    }
    public class Clientes
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Rtn { get; set; }
    }

    public class PruebaDBContext : DbContext
    {
        public DbSet<Documentos> Documentos { get; set; }

        public DbSet<Clientes> Clientes { get; set; }
    }
}