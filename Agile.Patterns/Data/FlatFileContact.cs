using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agile.Patterns.DependencyInversion;

namespace Agile.Patterns.Data
{
    public class FlatFileContact: IContact
    {
        private const int LastNameIndex = 0;
        private const int FirstNameIndex = 1;
        private const int PhoneNumberIndex = 2;

        internal FlatFileContact(String rawContactLine)
        {
            var parts = rawContactLine.Split(',');

            for (int i = 0; i < parts.Length; i++)
            {
                switch (i)
                {
                    case LastNameIndex:
                        LastName = parts[i];
                        break;
                    case FirstNameIndex:
                        FirstName = parts[i];
                        break;
                    case PhoneNumberIndex:
                        PhoneNumber = parts[i];
                        break;
                }
            }
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
    }
}
