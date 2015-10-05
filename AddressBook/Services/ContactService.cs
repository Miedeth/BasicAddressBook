using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AddressBook.Services
{
    public class ContactService
    {
        public List<Models.Contact> GetContacts()
        {
            Repositories.ContactRepository repository = new Repositories.ContactRepository();
            List<Repositories.Contact> repoContacts = repository.GetContacts();

            CreateRepoToModelMappers();
            List<Models.Contact> contacts = AutoMapper.Mapper.Map<List<Models.Contact>>(repoContacts);
            return contacts;
        }

        public Models.Contact GetContact(int contactId)
        {
            Repositories.ContactRepository repository = new Repositories.ContactRepository();
            Repositories.Contact repoContact = repository.GetContact(contactId);

            CreateRepoToModelMappers();
            Models.Contact contact = AutoMapper.Mapper.Map<Models.Contact>(repoContact);
            return contact;
        }

        public int CreateContact(Models.Contact contact)
        {
            CreateModelToRepoMappers();
            Repositories.Contact repoContact = AutoMapper.Mapper.Map<Repositories.Contact>(contact);

            Repositories.ContactRepository repository = new Repositories.ContactRepository();
            return repository.AddContact(repoContact);
        }

        public bool UpdateContact(Models.Contact contact)
        {
            CreateModelToRepoMappers();
            Repositories.Contact repoContact = AutoMapper.Mapper.Map<Repositories.Contact>(contact);

            Repositories.ContactRepository repository = new Repositories.ContactRepository();
            return repository.UpdateContact(repoContact);
        }

        public bool DeleteContact(int contactId)
        {
            Repositories.ContactRepository repository = new Repositories.ContactRepository();
            return repository.DeleteContact(contactId);
        }

        private void CreateModelToRepoMappers()
        {
            AutoMapper.Mapper.CreateMap<Models.Contact, Repositories.Contact>();
            AutoMapper.Mapper.CreateMap<Models.Address, Repositories.Address>();
        }

        private void CreateRepoToModelMappers()
        {
            AutoMapper.Mapper.CreateMap<Repositories.Contact, Models.Contact>();
            AutoMapper.Mapper.CreateMap<Repositories.Address, Models.Address>();
        }
    }
}