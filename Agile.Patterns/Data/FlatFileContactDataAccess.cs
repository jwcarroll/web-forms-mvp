using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Agile.Patterns.DependencyInversion;

namespace Agile.Patterns.Data
{
    public class FlatFileContactDataAccess: IContactDataAccess
    {
        private String FileName { get; set; }

        public FlatFileContactDataAccess(String fileName)
        {
            FileName = fileName;

            if (!File.Exists(FileName))
            {
                using (File.Create(FileName)) { }
            }
        }

        public void AddContact(string firstName, string lastName, string phoneNumber)
        {
            File.AppendAllText(FileName, FormatContact(firstName, lastName, phoneNumber));
        }

        public bool DoesContactExist(string firstName, string lastName)
        {
            var lines = File.ReadAllLines(FileName);

            var contact = (from c in lines
                          where c.Contains(FormatContact(firstName, lastName))
                          select c).FirstOrDefault();

            return !String.IsNullOrEmpty(contact);
        }

        public List<IContact> GetAllContacts()
        {
            var lines = File.ReadAllLines(FileName);

            return lines.Select(l => new FlatFileContact(l)).Cast<IContact>().ToList();
        }

        private String FormatContact(String firstName, String lastName, String phoneNumber)
        {
            return String.Format("{0},{1}{2}", FormatContact(firstName, lastName), phoneNumber, Environment.NewLine);
        }

        private String FormatContact(String firstName, String lastName)
        {
            return String.Format("{0},{1}", lastName.ToUpper(), firstName.ToUpper());
        }
    }
}
