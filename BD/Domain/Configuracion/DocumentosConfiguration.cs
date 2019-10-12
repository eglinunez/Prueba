using BD.Domain.Entidad;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BD.Domain.Configuracion
{
   public class DocumentosConfiguration : IEntityTypeConfiguration<Documentos>
    {
        public void Configure(EntityTypeBuilder<Documentos> builder)
        {


            builder.HasKey(e => e.Id);
            builder.Property(d => d.IdCliente).HasColumnName("IdCliente");



            builder.HasOne(d => d.Cliente)
            .WithMany(p => p.Documento)
            .HasForeignKey(d => d.IdCliente);

        }
    }
}
