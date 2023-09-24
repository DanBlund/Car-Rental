using Car_Rental.Common.Classes;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Data.Classes;

public class CollectionData : IData
{
    readonly List<IVehicle> _vehicles = new();
    readonly List<ICustomer> _customers = new();
    readonly List<IBooking> _bookings = new();

    public CollectionData()
    {
        _vehicles.Add(new Car("ABC 123", "Volvo", 1000, Common.Enums.VehicleTypes.Sedan, 3, 100, true));        
        _vehicles.Add(new Car("DEF 456", "Saab", 2000, Common.Enums.VehicleTypes.Combi, 5, 200, false));
        _vehicles.Add(new Car("GHI 789", "Fiat", 3000, Common.Enums.VehicleTypes.Van, 7, 300, true));
        _vehicles.Add(new Motorcycle("JKL 012", "Suzuki", 4000, Common.Enums.VehicleTypes.Motorcycle, 9, 400, false));
        _vehicles.Add(new Motorcycle("LMN 345", "Yamaha", 5000, Common.Enums.VehicleTypes.Motorcycle, 10, 500, true));

        _customers.Add(new Customer(123456, "John", "Snow"));
        _customers.Add(new Customer(789123, "Arya", "Stark"));
        _customers.Add(new Customer(456789, "Tyron", "Lannister"));

        _bookings.Add(new Booking("ABC 123", "John Snow", 500, 1000, new DateTime(2023, 09, 20), new DateTime(2023, 09, 24), 1500, true));
        _bookings.Add(new Booking("DEF 456", "Arya Stark", 1000, 0, new DateTime(2023, 09, 19), default, 5000, false));
        _bookings.Add(new Booking("GHI 789", "Tyrion Lannister", 2800, 3000, new DateTime(2023, 09, 17), new DateTime(2023, 09, 19), 5000, true));
    }

    public List<IVehicle> GetVehicles() => _vehicles;
    public List<ICustomer> GetCustomers() => _customers;
    public List<IBooking> GetBookings() => _bookings;
}
