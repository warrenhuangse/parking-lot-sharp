namespace ParkingLotStep5;

public abstract class ParkingRole : IParkable
{
    private readonly IParkable _parkable1;
    private readonly IParkable _parkable2;
    private readonly IParkingStrategy _strategy;

    protected ParkingRole(IParkable parkable1, IParkable parkable2, IParkingStrategy strategy)
    {
        _parkable1 = parkable1;
        _parkable2 = parkable2;
        _strategy = strategy;
    }

    public void Park(Car car)
    {
        if (_parkable1.HasCar(car) || _parkable2.HasCar(car))
            throw new ArgumentException("Car " + car + " has been parked");

        var lot = FindAvailableLot();
        _ = lot ?? throw new Exception("No lot for more cars");

        lot.Park(car);
    }

    public void Unpark(Car car)
    {
        if (_parkable1.HasCar(car))
        {
            _parkable1.Unpark(car);
            return;
        }

        if (_parkable2.HasCar(car))
        {
            _parkable2.Unpark(car);
            return;
        }

        throw new ArgumentException("Faile to unpark car " + car);
    }

    public bool HasCar(Car car)
    {
        return _parkable1.HasCar(car) || _parkable2.HasCar(car);
    }

    public bool IsFull()
    {
        return _parkable1.IsFull() && _parkable2.IsFull();
    }

    public int GetAvailability()
    {
        return _parkable1.GetAvailability() + _parkable2.GetAvailability();
    }

    private IParkable? FindAvailableLot()
    {
        return _strategy.GetAvailableLot(_parkable1, _parkable2);
    }
}