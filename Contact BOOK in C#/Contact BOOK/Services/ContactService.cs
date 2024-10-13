using ContactBook.Models;
using System.Text.RegularExpressions;

namespace ContactBook.Services
{
    public class ContactService
    {
        private List<Contact> _contacts = new List<Contact>();

        public void AddContact(string name, string phoneNumber, string email)
        {
            if (!ValidatePhoneNumber(phoneNumber) || !ValidateEmail(email))
            {
                Console.WriteLine("Invalid phone number or email format. Please try again.");
                return;
            }

            var contact = new Contact(name, phoneNumber, email);
            _contacts.Add(contact);
            Console.WriteLine("Contact added successfully.");
        }

        public void ViewAllContacts()
        {
            if (_contacts.Count == 0)
            {
                Console.WriteLine("No contacts found.");
                return;
            }

            Console.WriteLine("\n--------------------------------------------");
            Console.WriteLine("           CONTACT LIST (GRID VIEW)         ");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine($"{"Name",-20} | {"Phone Number",-15} | {"Email",-30}");
            Console.WriteLine(new string('-', 70));

            foreach (var contact in _contacts)
            {
                Console.WriteLine(contact.ToString());
            }
            Console.WriteLine(new string('-', 70));
        }

        public void DeleteContact(string name)
        {
            var contact = _contacts.FirstOrDefault(c => c.Name.ToLower() == name.ToLower());
            if (contact == null)
            {
                Console.WriteLine("Contact not found.");
                return;
            }

            _contacts.Remove(contact);
            Console.WriteLine("Contact deleted successfully.");
        }

        public void UpdateContact(string name, string newPhoneNumber, string newEmail)
        {
            var contact = _contacts.FirstOrDefault(c => c.Name.ToLower() == name.ToLower());
            if (contact == null)
            {
                Console.WriteLine("Contact not found.");
                return;
            }

            if (!ValidatePhoneNumber(newPhoneNumber) || !ValidateEmail(newEmail))
            {
                Console.WriteLine("Invalid phone number or email format. Please try again.");
                return;
            }

            contact.UpdateContact(contact.Name, newPhoneNumber, newEmail);
            Console.WriteLine("Contact updated successfully.");
        }

        private bool ValidatePhoneNumber(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, @"^\d{10}$");
        }

        private bool ValidateEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }
}
