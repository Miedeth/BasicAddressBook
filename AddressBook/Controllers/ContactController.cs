using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AddressBook.Controllers
{
    public class ContactController : Controller
    {
        Services.ContactService contactService = null;

        public ContactController()
        {
            contactService = new Services.ContactService();
        }

        //
        // GET: /Contact/

        public ActionResult Index()
        {
            List<Models.Contact> contacts = contactService.GetContacts();

            return View("Index", contacts);
        }

        //
        // GET: /Contact/Details/5

        public ActionResult Details(int id)
        {
            Models.Contact contact = contactService.GetContact(id);

            return View("Details", contact);
        }

        //
        // GET: /Contact/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Contact/Create

        [HttpPost]
        public ActionResult Create(Models.Contact contact)
        {
            try
            {
                contactService.CreateContact(contact);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Contact/Edit/5

        public ActionResult Edit(int id)
        {
            Models.Contact contact = contactService.GetContact(id);
            return View("Edit", contact);
        }

        //
        // POST: /Contact/Edit/5

        [HttpPost]
        public ActionResult Edit(Models.Contact contact)
        {
            try
            {
                contactService.UpdateContact(contact);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Contact/Delete/5

        public ActionResult Delete(int id)
        {
            contactService.DeleteContact(id);
            return RedirectToAction("Index");
        }
    }
}
