namespace DataAcsess.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAcsess.StudentDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataAcsess.StudentDBContext context)
        {
            // seed admin in DB
            context.SingIns.AddOrUpdate(x => x.ID,
                new SingIn() { ID = 1, Name = "Ivailo", LastName = "Sakaliev", Email = "sakaliev.ivailo@gmail.com", Username = "isakata", Password = "sakata96", Role = 1 }
                );


        }
    }
}
