namespace ParkingLotStep3;

public abstract class ParkingBoy
{
    protected readonly ParkingLot _lot1;
    protected readonly ParkingLot _lot2;

    protected ParkingBoy(ParkingLot lot1, ParkingLot lot2)
    {
        _lot1 = lot1;
        _lot2 = lot2;
    }

    public abstract void Park(Car car);

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