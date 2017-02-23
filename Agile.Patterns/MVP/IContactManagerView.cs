using System;
using System.Collections.Generic;
using Agile.Patterns.DependencyInversion;

namespace Agile.Patterns.MVP
{
    public interface IContactManagerView
    {
        List<IContact> Contacts { set; }

        String FirstName { get; set; }
        String LastName { get; set; }
        String PhoneNumber { get; set; }

        String ErrorMessage { get; set; }

        event EventHandler AddContact;
    }
}