namespace MaviOnline.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MaviOnline.Models.Sinif.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true; //false ı true yapınca veri tabanındaki değişiklikler yansıyacak
        }

        protected override void Seed(MaviOnline.Models.Sinif.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
