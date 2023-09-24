namespace Car_Rental.Common.Interfaces;

public interface IData
{
    List<IVehicle> GetVehicles();
    List<ICustomer> GetCustomers();
    List<IBooking> GetBookings();
}
