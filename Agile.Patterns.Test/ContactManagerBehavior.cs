using System;
using Agile.Patterns.Data;
using Agile.Patterns.DependencyInversion;
using Moq;
using Xunit;

namespace Agile.Patterns.Test
{
    public class ContactManagerBehavior
    {
        private Mock<IContactDataAccess> _mockDataAccess;
        private ContactManager _contactManager;

        public ContactManagerBehavior()
        {
            _mockDataAccess = new Mock<IContactDataAccess>();
            _contactManager = new ContactManager(_mockDataAccess.Object);
        }

        [Fact]
        public void ShouldBeAbleToAddNewContact()
        {
            _contactManager.AddContact("Josh", "Carroll", "(865)555-5555");

            _mockDataAccess.Verify(svc => svc.AddContact("Josh", "Carroll", "8655555555"));
        }

        [Fact]
        public void ShouldListAllContacts()
        {
            var contacts = _contactManager.GetAllContacts();

            _mockDataAccess.Verify(svc => svc.GetAllContacts());
        }

        [Fact]
        public void ShouldHandleSevenDigitPhoneNumbers()
        {
            _contactManager.AddContact("Josh", "Carroll", "555-5555");

            _mockDataAccess.Verify(svc => svc.AddContact("Josh", "Carroll", "5555555"));
        }

        [Fact]
        public void ShouldThrowExceptionIfPhoneNumberIsInvalid()
        {
            Assert.Throws<FormatException>(() => {
                _contactManager.AddContact("Josh", "Carroll", "838383838555-5555");
            });
        }

        [Fact]
        public void ShouldThrowExceptionIfContactAlreadyExists()
        {
            _mockDataAccess.Setup(svc => svc.DoesContactExist("Josh", "Carroll")).Returns(true);

            Assert.Throws<InvalidOperationException>(() => {
                _contactManager.AddContact("Josh", "Carroll", "555-5555");
            });
        }
    }
}
