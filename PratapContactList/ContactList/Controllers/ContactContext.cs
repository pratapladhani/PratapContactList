using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ContactList.Models;

namespace ContactList.Controllers
{
    public class ContactContext : DbContext
    {
        public ContactContext():base("ContactsDatabase")
        {

        }
        public DbSet<Contact> Contacts { get; set; }
    }
}