using ContactBook.Services;

class Program
{
    static void Main(string[] args)
    {
        var contactService = new ContactService();

        while (true)
        {
            Console.WriteLine("\n--- Contact Book ---");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. View All Contacts");
            Console.WriteLine("3. Update Contact");
            Console.WriteLine("4. Delete Contact");
            Console.WriteLine("5. Exit");

            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddContact(contactService);
                    break;
                case "2":
                    contactService.ViewAllContacts();
                    break;
                case "3":
                    UpdateContact(contactService);
                    break;
                case "4":
                    DeleteContact(contactService);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void AddContact(ContactService contactService)
    {
        Console.Write("Enter name: ");
        string name = Console.ReadLine();

        Console.Write("Enter phone number (10 digits): ");
        string phoneNumber = Console.ReadLine();

        Console.Write("Enter email: ");
        string email = Console.ReadLine();

        contactService.AddContact(name, phoneNumber, email);
    }

    static void UpdateContact(ContactService contactService)
    {
        Console.Write("Enter the name of the contact to update: ");
        string name = Console.ReadLine();

        Console.Write("Enter new phone number (10 digits): ");
        string newPhoneNumber = Console.ReadLine();

        Console.Write("Enter new email: ");
        string newEmail = Console.ReadLine();

        contactService.UpdateContact(name, newPhoneNumber, newEmail);
    }

    static void DeleteContact(ContactService contactService)
    {
        Console.Write("Enter the name of the contact to delete: ");
        string name = Console.ReadLine();
        contactService.DeleteContact(name);
    }
}
