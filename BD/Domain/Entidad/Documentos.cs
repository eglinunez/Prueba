using System;
using System.Collections.Generic;
using System.Text;

namespace BD.Domain.Entidad
{
    public class Documentos
    {
        public Guid Id { set; get; }
        public string Nombre { set; get; }
        public DateTime Descripcion { set; get; }
        public bool Delete { set; get; }
        public Guid IdCliente { set; get; }
        public Cliente Cliente { set; get; }
    }
}
