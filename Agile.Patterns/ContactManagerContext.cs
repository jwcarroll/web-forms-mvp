namespace Agile.Patterns
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ContactManagerContext : DbContext
    {
        // Your context has been configured to use a 'ContactManager' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Agile.Patterns.ContactManager' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ContactManager' 
        // connection string in the application configuration file.
        public ContactManagerContext()
            : base("name=ContactManager")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Contact> Contacts { get; set; }
    }

    public class Contact
    {
        public Int32 Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String PhoneNumber { get; set; }
    }
}