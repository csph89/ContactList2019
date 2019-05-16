using ContactList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContactList.Controllers
{
    public class ContactsController : Controller
    {
        // This field represents our database
        private ApplicationDbContext _context;

        public ContactsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Contacts
        public ActionResult Index()
        {
            var contacts = _context.Contacts.ToList();
            return View(contacts);
        }

        // GET: The empty form to create a new customer.
        public ActionResult Create()
        {
            var contact = new Contact(); // This will make a new object and the properties of it will set to default values.
            return View("ContactForm", contact);
        }

        // GET: The form of the contact whose Id is equal to id parameter.
        public ActionResult Edit(int id)
        {
            //Here first we need to get the contact from the database.
            var contact = _context.Contacts.SingleOrDefault(c => id == c.Id);

            if (contact == null)
            {
                return HttpNotFound();
            }

            return View("ContactForm", contact);
            //Sthn ousia provallw th forma sumplhrwmenh me ta stoixeia tou sugkekrimenou customer, me skopo na ta allaksw.
        }

        public ActionResult Delete(int id)
        {
            // We retrieve the contact from the database.
            var contact = _context.Contacts.SingleOrDefault(c => id == c.Id);
            _context.Contacts.Remove(contact);
            _context.SaveChanges();

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Contact contact)
        {
            if (!ModelState.IsValid) // If is not valid render the same View plus the validation error messages.
            {
                return View("CustomerForm", contact);
            }

            if (contact.Id == 0) // An to Id einai 0 tote shmainei oti den exei parei timh to Id epomenws den exei ginei eggrafh sth vash mas.
            {
                // If this is a new contact we should add it to the database.
                _context.Contacts.Add(contact);
            }
            else
            {
                // If this is an existing contact so we should update it.
                var customerInDb = _context.Contacts.Single(c => c.Id == contact.Id); //We first find the customer object in the database.

                //We manually update each property of the existing contact with new values came from the form data.
                customerInDb.Name = contact.Name;
                customerInDb.Email = contact.Email;
                customerInDb.Address = contact.Address;
                customerInDb.Phone = contact.Phone;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Contacts");
        }
    }
}
