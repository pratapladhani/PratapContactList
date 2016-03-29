namespace ContactList.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ContactList.Models;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    internal sealed class Configuration : DbMigrationsConfiguration<ContactList.Controllers.ContactContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ContactList.Controllers.ContactContext context)
        {

            var json = @"[{
                        ""Id"": 1,
                        ""Name"": ""Contoso CEO"",
                        ""Phone"": ""(123) 456 789"",
                        ""Phone2"": ""(123) 456 789"",
                        ""Company"": ""Contoso Inc."",
                        ""Email"": ""one@contoso.com"",
                        ""Title"": ""CEO"",
                        ""ImageURL"": ""https://contactlist.blob.core.windows.net/images/f350e7ed-c53f-433a-aa54-10fcdccb7bcc.jpg"",
                        ""Address"": ""One Contoso Street Contosomond WA 12345""
                      },
                      {
                        ""Id"": 3,
                        ""Name"": ""Rebecca Laszlo"",
                        ""Phone"": ""12345678"",
                        ""Phone2"": ""12131445"",
                        ""Company"": ""Northwind Traders"",
                        ""Email"": ""rebeccal@NorthwindTraders"",
                        ""Title"": ""Developer"",
                        ""ImageURL"": ""https://contactlist.blob.core.windows.net/images/8cdee5ba-99f0-40e8-9d8a-7d7487a84021.png"",
                        ""Address"": ""312 Deer Drive,  Aspen, CO 81104""
                      },
                      {
                        ""Id"": 5,
                        ""Name"": ""Edmond Borkholder"",
                        ""Phone"": ""75462145"",
                        ""Phone2"": ""74512445"",
                        ""Company"": ""Contoso"",
                        ""Email"": ""edb@contoso.com"",
                        ""Title"": ""Web Developer"",
                        ""ImageURL"": ""https://contactlist.blob.core.windows.net/images/9249592e-46e7-48c7-bd74-8656c110fe72.png"",
                        ""Address"": ""12 Mountain Loop Road, Aspen, CO 81006\n""
                      },
                      {
                        ""Id"": 6,
                        ""Name"": ""Dewayen Aamundson"",
                        ""Phone"": ""89965412"",
                        ""Phone2"": ""33214567"",
                        ""Company"": ""Litware Inc"",
                        ""Email"": ""dewayne@litware.com"",
                        ""Title"": ""Marketing Manager"",
                        ""ImageURL"": ""https://contactlist.blob.core.windows.net/images/98c8f4cf-471d-4636-80e4-515a083f962b.png"",
                        ""Address"": ""6525 15th N.W., Denver CO 81065\n""
                      },
                      {
                        ""Id"": 2,
                        ""Name"": ""Bobbie Stein"",
                        ""Phone"": ""1234567890"",
                        ""Phone2"": ""1234567890"",
                        ""Company"": ""Developer"",
                        ""Email"": ""bobbies@contoso.com"",
                        ""Title"": ""Sr. Dev"",
                        ""ImageURL"": ""https://contactlist.blob.core.windows.net/images/2f2b4c3c-c1b7-4680-af9e-ce7af653ac2f.png"",
                        ""Address"": ""One Contoso Way""
                      },
                      {
                        ""Id"": 4,
                        ""Name"": ""Simone Drake"",
                        ""Phone"": ""1231245"",
                        ""Phone2"": ""1231254"",
                        ""Company"": ""Contoso"",
                        ""Email"": ""simoned@contoso.com"",
                        ""Title"": ""Program Manager"",
                        ""ImageURL"": ""https://contactlist.blob.core.windows.net/images/ea158ffe-54e4-4848-b5dd-0b488d40b24f.jpg"",
                        ""Address"": ""12 Mountain Loop Road, Aspen, CO 81006\n""
                      }]
                    ";

            var contacts = JsonConvert.DeserializeObject<IEnumerable<Contact>>(json);


            context.Contacts.AddRange(contacts);

            
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
