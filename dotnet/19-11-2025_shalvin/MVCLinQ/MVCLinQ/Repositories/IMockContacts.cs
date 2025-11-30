using MVCLinQ.Models;

namespace MVCLinQ.Repositories;

public interface IMockContacts
{
    List<Contact> GetContacts();
}
