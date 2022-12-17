namespace ParkingLotStep4;

public class ParkingBoy
{
    private readonly ParkingLot _lot1;
    private readonly ParkingLot _lot2;
    private readonly IParkingStrategy _strategy;

    public ParkingBoy(ParkingLot lot1, ParkingLot lot2, IParkingStrategy strategy)
    {
        _lot1 = lot1;
        _lot2 = lot2;
        _strategy = strategy;
    }

    public void Park(Car car)
    {
        if (_lot1.HasCar(car) || _lot2.HasCar(car)) 
            throw new ArgumentException("Car " + car + " has been parked");
        
        var lot = FindAvailableLot();
        _ = lot ?? throw new Exception("Not lot for more cars");
        
        lot.Park(car);
    }

    private ParkingLot? FindAvailableLot()
    {
        return _strategy.GetAvailableLot(_lot1, _lot2);
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