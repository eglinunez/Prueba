using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BD.Domain.Entidad
{
    public class Cliente
    {
        public Guid Id { set; get; }
        public string DNI { set; get; }
        public string Nombre { set; get; }
        public DateTime FechaNacimiento { set; get; }
        public bool Delete { set; get; }
        public ICollection<Documentos> Documento { set; get; }
        public Cliente()
        {
            Documento = new HashSet<Documentos>();
        }

        public static List<Cliente> Gets()
        {
            var remicions = new Cliente[]
            {

            };
            return remicions.ToList();
        }

    }
}
