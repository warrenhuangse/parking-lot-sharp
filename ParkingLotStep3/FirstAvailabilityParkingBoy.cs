namespace ParkingLotStep3;

public class FirstAvailabilityParkingBoy : ParkingBoy
{
    public FirstAvailabilityParkingBoy(ParkingLot lot1, ParkingLot lot2) : base(lot1, lot2)
    {
    }

    public override void Park(Car car)
    {
        if (_lot1.HasCar(car) || _lot2.HasCar(car))
            throw new ArgumentException("Car " + car + " has been parked");

        if (!_lot1.IsFull())
        {
            _lot1.Park(car);
            return;
        }

        if (!_lot2.IsFull())
        {
            _lot2.Park(car);
            return;
        }

        throw new Exception("No lot for more cars");
    }
}