using System;

namespace Test.Data.Models;

public class Contact
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public string Number { get; set; } = string.Empty;

    public ContactGroup ContactGroup { get; set; } = new ContactGroup();
    public int GroupId { get; set; }
}
