
using BD.Domain.Entidad;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BD.Domain.Interface
{
    public interface IPruebaDbContext
    {
        DbSet<Cliente> Cliente { get; set; }
        DbSet<Documentos> Documento { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
