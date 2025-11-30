using System;
using MVCLinQ.Models;

namespace MVCLinQ.Repositories;

public class MockContacts : IMockContacts
{
    List<Contact> contacts = new List<Contact>()
{
    new Contact { Id = 1,  Name = "Arun",      Location = "Kochi" },
    new Contact { Id = 2,  Name = "Shalvin",   Location = "Vaduthala" },
    new Contact { Id = 3,  Name = "Manu",      Location = "Aluva" },
    new Contact { Id = 4,  Name = "Rakesh",    Location = "Thrissur" },
    new Contact { Id = 5,  Name = "Joel",      Location = "Ernakulam" },
    new Contact { Id = 6,  Name = "Vishnu",    Location = "Kakkanad" },
    new Contact { Id = 7,  Name = "Sandeep",   Location = "Palakkad" },
    new Contact { Id = 8,  Name = "Akhil",     Location = "Kollam" },
    new Contact { Id = 9,  Name = "Thomas",    Location = "Vyttila" },
    new Contact { Id = 10, Name = "Anand",     Location = "Palarivattom" },
    new Contact { Id = 11, Name = "John",      Location = "Fort Kochi" },
    new Contact { Id = 12, Name = "Abin",      Location = "Edappally" },
    new Contact { Id = 13, Name = "Kevin",     Location = "Kozhikode" },
    new Contact { Id = 14, Name = "Robin",     Location = "Kannur" },
    new Contact { Id = 15, Name = "Arjun",     Location = "Perumbavoor" },
    new Contact { Id = 16, Name = "Nikhil",    Location = "Alappuzha" },
    new Contact { Id = 17, Name = "Deepak",    Location = "Pathanamthitta" },
    new Contact { Id = 18, Name = "Rahul",     Location = "Irinjalakuda" },
    new Contact { Id = 19, Name = "Sarath",    Location = "Chalakudy" },
    new Contact { Id = 20, Name = "Vimal",     Location = "Angamaly" }
};

    public List<Contact> GetContacts()
    {
        return contacts;
    }
}
