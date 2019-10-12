using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using BD.Domain;

namespace First_Code.AddThis
{
    public class SeedData
    {
        public static void EnsureSeedData(IServiceProvider serviceProvider)
        {
            Console.WriteLine("Seeding database...");

            using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<PruebaDbContext>();
                context.Database.Migrate();
                EnsureSeedData(context);
            }

            Console.WriteLine("Done seeding database.");
            Console.WriteLine();
        }

        private static void EnsureSeedData(PruebaDbContext context)
        {
            if (!context.Cliente.Any())
            {
                Console.WriteLine("Proyectos being populated");

                var Proyecto = BD.Domain.Entidad.Cliente.Gets();
                context.Cliente.AddRange(Proyecto);
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Proyectos already populated");
                return;
            }

        }
    }
}
