

using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Contact : Entity<int> //İletişim Kısmı
{
    public Contact()
    {
        Mail = string.Empty;
        PhoneNumber = string.Empty;
        PhoneNumber1 = string.Empty;
        Address = string.Empty;
        MapsLat = float.MinValue;
        MapsLen = float.MinValue;

    }

    public Contact(string mail, string phoneNumber, string phoneNumber1, string address, float mapsLat)
    {
        Mail = mail;
        PhoneNumber = phoneNumber;
        PhoneNumber1 = phoneNumber1;
        Address = address;
        MapsLat = mapsLat;
    }

    public string Mail { get; set; }
    public string PhoneNumber { get; set; }
    public string PhoneNumber1 { get; set; }
    public string Address { get; set; }
    public float MapsLat { get; set; }
    public float MapsLen { get; set; }
}
