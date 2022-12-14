namespace ParkingLotStep2;

public class ParkingBoy
{
    private readonly ParkingLot _lot1;
    private readonly ParkingLot _lot2;

    public ParkingBoy(ParkingLot lot1, ParkingLot lot2)
    {
        _lot1 = lot1;
        _lot2 = lot2;
    }

    public void Park(Car car)
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

    public void Unpark(Car car)
    {
        if (_lot1.HasCar(car))
        {
            _lot1.Unpark(car);
            return;
        }

        if (_lot2.HasCar(car))
        {
            _lot2.Unpark(car);
            return;
        }

        throw new ArgumentException("Failed to unpark car " + car);
    }
}