namespace ParkingLotStep3;

public class MostAvailabilityParkingBoy : ParkingBoy
{
    public MostAvailabilityParkingBoy(ParkingLot lot1, ParkingLot lot2) : base(lot1, lot2)
    {
    }

    public override void Park(Car car)
    {
        if (_lot1.HasCar(car) || _lot2.HasCar(car))
            throw new ArgumentException("Car " + car + " has been parked");

        var availability1 = _lot1.GetAvailability();
        var availability2 = _lot2.GetAvailability();

        if (availability1 <= 0 && availability2 <= 0)
            throw new Exception("No lot for more car");

        if (availability1 >= availability2)
        {
            _lot1.Park(car);
            return;
        }

        _lot2.Park(car);
    }
}