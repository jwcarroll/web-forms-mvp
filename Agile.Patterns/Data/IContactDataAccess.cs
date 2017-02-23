using System.Collections.Generic;
using Agile.Patterns.DependencyInversion;

namespace Agile.Patterns.Data
{
    public interface IContactDataAccess
    {
        void AddContact(string firstName, string lastName, string phoneNumber);
        bool DoesContactExist(string firstName, string lastName);
        List<IContact> GetAllContacts();
    }
}