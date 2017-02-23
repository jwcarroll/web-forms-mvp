using System;
using System.Collections.Generic;
using System.Linq;
using Agile.Patterns.DependencyInversion;

namespace Agile.Patterns.Data
{
    public class SqlContactDataAccess : IContactDataAccess
    {
        private ContactManagerContext Context { get; set; }

        public SqlContactDataAccess()
        {
            Context = new ContactManagerContext();
        }

        public void AddContact(string firstName, string lastName, string phoneNumber)
        {
            var newContact = new Contact {FirstName = firstName, LastName = lastName, PhoneNumber = phoneNumber};

            Context.Contacts.Add(newContact);

            Context.SaveChanges();
        }

        public bool DoesContactExist(string firstName, string lastName)
        {
            var contact = (from c in Context.Contacts
                           where c.FirstName.ToUpper() == firstName.ToUpper() &&
                                 c.LastName.ToUpper() == lastName.ToUpper()
                           select c).FirstOrDefault();

            return contact != null;
        }

        public List<IContact> GetAllContacts()
        {
            var contacts = Context.Contacts.ToList();

            return contacts.Select(c => new ContactAdapter(c)).Cast<IContact>().ToList();
        }
    }
}