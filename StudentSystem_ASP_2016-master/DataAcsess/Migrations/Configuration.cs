
namespace DataAcsess.Migrations
{
    using DataAcsess.Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAcsess.StudentDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataAcsess.StudentDBContext context)
        {
            context.SingIns.AddOrUpdate(x => x.ID,
                new SingIn() { ID = 1, Name = "3K2yRYzCn6Q=", LastName = "whFQhV3ODZvBskURZSoZZw==", Email = "PUrEIdxhNFZrZFUMgffSB73QgUEtVGMRuT0YHZL5Oxk=", Username = "pkGdtEqxIoc=", Password = "JSExh0d0yGfBskURZSoZZw==", Role = 1, isRegisted = true }
                );
        }
    }
}
