using System;
using System.Linq;
using System.Text;
using Agile.Patterns.Data;
using Agile.Patterns.DependencyInversion;

namespace Agile.Patterns.MVP
{
    public class ContactManagerPresenter
    {
        private ContactManager Manager { get; set; }
        public IContactManagerView View { get; set; }

        public IContactDataAccess DataAccess
        {
            set
            {
                Manager = new ContactManager(value);
                UpdateView();
            }
        }

        public void InitializeView()
        {
            if (Manager == null)
                throw new InvalidOperationException("No data access was provided for the contact manager");

            View.AddContact += View_AddContact;

            UpdateView();
        }

        void View_AddContact(object sender, EventArgs e)
        {
            try
            {
                Manager.AddContact(View.FirstName, View.LastName, View.PhoneNumber);
                UpdateView();
            }
            catch (InvalidOperationException ex)
            {
                View.ErrorMessage = ex.Message;
            }
            catch (FormatException ex)
            {
                View.ErrorMessage = ex.Message;
            }
        }

        private void UpdateView()
        {
            View.ErrorMessage = String.Empty;
            View.Contacts = Manager.GetAllContacts();
        }
    }
}
