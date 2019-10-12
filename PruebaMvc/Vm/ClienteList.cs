using PruebaMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaMvc.Vm
{
    public class ClienteList
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Rtn { get; set; }

        public List<Clientes> Clienteslis { get; set; }
    }
}