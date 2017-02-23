using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Agile.Patterns.Data;

namespace Agile.Patterns.DependencyInversion
{
    public class ContactManager
    {
        private readonly Regex _allNumeric = new Regex("[^0-9]*");
        private IContactDataAccess DataAccess { get; set; }

        public ContactManager(IContactDataAccess contactDataAccess)
        {
            DataAccess = contactDataAccess;
        }

        public void AddContact(String firstName, String lastName, String phoneNumber)
        {
            if(DataAccess.DoesContactExist(firstName, lastName))
                throw new InvalidOperationException("Contact already exists!");

            phoneNumber = FormatPhoneNumber(phoneNumber);

            DataAccess.AddContact(firstName, lastName, phoneNumber);
        }

        private string FormatPhoneNumber(String phoneNumber)
        {
            var phoneNum = _allNumeric.Replace(phoneNumber, String.Empty);

            if(String.IsNullOrEmpty(phoneNum) || !(phoneNum.Length == 7 || phoneNum.Length == 10))
                throw new FormatException("Phone number is not valid!");

            return phoneNum;
        }

        public List<IContact> GetAllContacts()
        {
            return DataAccess.GetAllContacts();
        }
    }

    public interface IContact
    {
        String FirstName { get; set; }
        String LastName { get; set; }
        String PhoneNumber { get; set; }
    }
}
