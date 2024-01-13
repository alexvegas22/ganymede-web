using ganymede_web.Data;
using Microsoft.EntityFrameworkCore;

namespace ganymede_web.Models;
public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
        {
        using (var context = new ganymede_webContext(
            serviceProvider.GetRequiredService<DbContextOptions<ganymede_webContext>>()))
        {
            if (context == null)
            {
                throw new ArgumentNullException("Null RazorPagesContext");
            }

            if (context.Benevole.Any())
            {
                return;
            }

            context.Benevole.AddRange(
                new Benevole
                {
                    Nom = "Joe",
                    Email = "joe@joe.com",
                    Password = "password",
                    Age = 53,
                    NomEtablissement = "College de Rosemont",
                    rolePreferee = true,
                    LibreFinDeSemaine = true,
                    LibreJourFeries = true,
                    RecuFormationPremierSoins = true,
                }
                );
            context.SaveChanges();
        }
    }
}
