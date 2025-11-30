// See https://aka.ms/new-console-template for more information
using SimpleCalculator;

// Console.WriteLine("Hello, World!");
// List<string> friends = new List<string>();

// friends.Add("Arun");
// friends.Add("Shalvin");
// friends.Add("Theo");

// foreach (var friend in friends)
// {
//     Console.WriteLine($"{friend}");
// }

// Contact theophin = new Contact()
// {
//     Id = 1,
//     Name = "Theophin",
//     Location = "Kochi"
// };

// Console.WriteLine($"Hi,I am {theophin.Name} and I am from {theophin.Location}");

// List<Contact> contacts = new List<Contact>()
// {
//     new Contact
//     {
//     Id=2,
//     Name="Arun",
//     Location="Kochi"
//     },
//     new Contact
//     {
//     Id = 3,
//     Name = "Shalvin",
//     Location= "Vaduthala"
//     }
// };

// foreach (var contact in contacts)
// {
//     Console.WriteLine($"Hi,I am {contact.Name} and I am from {contact.Location}");
// }

MockContactsRepository mockContacts = new MockContactsRepository();

var contacts2 = mockContacts.GetContacts();

foreach (var contact in contacts2)
{
    Console.WriteLine($"Hi,I am {contact.Name} and I am from {contact.Location}");
}
