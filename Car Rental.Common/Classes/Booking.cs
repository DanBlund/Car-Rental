using Car_Rental.Common.Interfaces;
using System.Xml.Linq;

namespace Car_Rental.Common.Classes;

public class Booking : IBooking
{
    public string RegNumber { get; init; }
    public string Customer { get; init; }
    public int KmRented { get; init; }
    public int KmReturned { get; set; }
    public DateTime Rented { get; init; }
    public DateTime Returned { get; set; }
    public int Cost { get; set; }
    public bool Status { get; set; }

    public Booking(string regNo, string cust, int kmRent, int kmReturn, DateTime rented, DateTime returned, int cost, bool status)
    {
        RegNumber = regNo;
        Customer = cust;
        KmRented = kmRent;
        KmReturned = kmReturn;
        Rented = rented;
        Returned = returned;
        Cost = cost;
        Status = status;
    }

    public int CalculateCost()
    {
        return 555;
    }
}
