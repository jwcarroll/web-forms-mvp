using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;
using Agile.Patterns.Data;
using Agile.Patterns.DependencyInversion;
using Agile.Patterns.MVP;

namespace Agile.WebForms.ContactManager
{
    public partial class WebContactManager : System.Web.UI.Page, IContactManagerView
    {
        private ContactManagerPresenter Presenter { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Presenter = new ContactManagerPresenter { View = this, DataAccess = GetDataAccess() };
            Presenter.InitializeView();
        }

        private IContactDataAccess GetDataAccess()
        {
            if (rblStorageType.SelectedValue == "SQL")
                return new SqlContactDataAccess();

            return new FlatFileContactDataAccess(HostingEnvironment.MapPath("~/App_Data/MyContacts.txt"));
        }

        public List<IContact> Contacts
        {
            set
            {
                gvContactList.DataSource = value;
                gvContactList.DataBind();
            }
        }

        public string FirstName
        {
            get { return tbFirstName.Text; }
            set { tbFirstName.Text = value; }
        }

        public string LastName
        {
            get { return tbLastName.Text; }
            set { tbLastName.Text = value; }
        }

        public string PhoneNumber
        {
            get { return tbPhoneNumber.Text; }
            set { tbPhoneNumber.Text = value; }
        }

        public string ErrorMessage
        {
            get { return lblErrorMessage.Text; }
            set
            {
                lblErrorMessage.Visible = !String.IsNullOrEmpty(value);
                lblErrorMessage.Text = value;
            }
        }

        public event EventHandler AddContact;

        public void InvokeAddContact(EventArgs e)
        {
            AddContact?.Invoke(this, e);
        }

        protected void btnAddContact_Click(object sender, EventArgs e)
        {
            InvokeAddContact(new EventArgs());
        }
    }
}