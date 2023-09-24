using Car_Rental.Common.Interfaces;

namespace Car_Rental.Business.Classes;

public class BookingProcessor
{
    IData _data;

    // Constructor
    public BookingProcessor(IData data)
    {
        _data = data;
    }

    public IEnumerable<IVehicle> VehicleGetter()
    {
        return _data.GetVehicles();
    }
    public IEnumerable<ICustomer> CustomerGetter()
    {
        return _data.GetCustomers();
    }
    public IEnumerable<IBooking> BookingGetter()
    {
        return _data.GetBookings();
    }

    public int CalculateKmDrived(int kmRent, int kmReturn)
    {
        if(kmReturn <= 0)
        {
            return 0;
        }
        return kmReturn - kmRent;
    }
    public int DaysRented(DateTime rented, DateTime returned)
    {
        if(returned == default)
        { return 0; }
        TimeSpan diff = (returned - rented);
        int diffInt = int.Parse(diff.Days.ToString());
        return diffInt;
    }
    public int CalculateCost(string regNo, int kmRent, int kmReturn, DateTime rented, DateTime returned)
    {
        int costPerKm = 0;
        int costPerDay = 0;
        foreach (var vehicle in VehicleGetter())
        {
            if(vehicle.RegNumber == regNo)
            {
                costPerKm = vehicle.CostPerKm;
                costPerDay = vehicle.CostPerDay;
                break;
            }
        }
        int kmDrived = CalculateKmDrived(kmRent, kmReturn);
        int daysRent = DaysRented(rented, returned);
        int costKm = kmDrived * costPerKm;
        int costDays = daysRent * costPerDay;
        int totalCost = costKm + costDays;


        return totalCost;
    }

}
