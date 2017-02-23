using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agile.Patterns.DependencyInversion;

namespace Agile.Patterns.Data
{
    public class ContactAdapter: IContact
    {
        internal ContactAdapter(Contact contact)
        {
            if(contact == null)
                throw new ArgumentNullException("contact");

            FirstName = contact.FirstName;
            LastName = contact.LastName;
            PhoneNumber = contact.PhoneNumber;
        }

        public string FirstName { get; set; }

        public string LastName{ get; set;}

        public string PhoneNumber { get; set; }
    }
}
