using Employee_Web_API.Models;

namespace Employee_Web_API.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Employee_Web_API.Models.EmployeeDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Employee_Web_API.Models.EmployeeDBContext context)
        {
            context.Employees.AddOrUpdate(
                p => p.ID,
                new Employee { FirstName = "Harun", LastName = "Altay", Email = "harun@altay.com", Phone = "1234567" },
                new Employee { FirstName = "Şahin", LastName = "Aydın", Email = "sahin@aydin.com", Phone = "111" },
                new Employee { FirstName = "Ali", LastName = "Meşe", Email = "ali@mese.com", Phone = "222" },
                new Employee { FirstName = "Veli", LastName = "Gürgen", Email = "veli@gurgen.com", Phone = "333" },
                new Employee { FirstName = "Selami", LastName = "Çam", Email = "selami@cam.com", Phone = "444" },
                new Employee { FirstName = "Ahmet", LastName = "Ardıç", Email = "ahmet@ardic.com", Phone = "555" },
                new Employee { FirstName = "Mehmet", LastName = "Kayın", Email = "mehmet@kayin.com", Phone = "666" },
                new Employee { FirstName = "Hasan", LastName = "Kavak", Email = "hasan@kavak.com", Phone = "777" },
                new Employee { FirstName = "Hüseyin", LastName = "Söğüt", Email = "huseyin@sogut.com", Phone = "888" },
            new Employee { FirstName = "Talha", LastName = "Özçelik", Email = "talha@ozcelik.com", Phone = "999" }
                );
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
