using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AddressBook.Repositories
{
    public class ContactRepository
    {
        private AddressBookEntities repository = null;

        public ContactRepository()
        {
            repository = new AddressBookEntities();
        }

        public List<Repositories.Contact> GetContacts()
        {
            List<Repositories.Contact> contacts = repository.Contacts.ToList();
            return contacts;
        }

        public Repositories.Contact GetContact(int contactId)
        {
            Repositories.Contact contact = repository.Contacts.FirstOrDefault(c => c.ContactId == contactId);
            return contact;
        }

        public int AddContact(Repositories.Contact contact)
        {
            repository.Contacts.Add(contact);
            repository.SaveChanges();

            return contact.ContactId;
        }

        public bool UpdateContact(Repositories.Contact contact)
        {
            try
            {
                Repositories.Contact original = GetContact(contact.ContactId);

                if (original != null)
                {
                    repository.Entry(original).CurrentValues.SetValues(contact);

                    if (original.Address != null)
                        repository.Entry(original.Address).CurrentValues.SetValues(contact.Address);
                    else if (contact.Address != null)
                    {
                        original.Address = new Address();
                        repository.Entry(original.Address).CurrentValues.SetValues(contact.Address);
                    }
                        

                    repository.SaveChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteContact(int contactId)
        {
            try
            {
                Repositories.Contact original = GetContact(contactId);
                repository.Contacts.Remove(original);
                repository.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}