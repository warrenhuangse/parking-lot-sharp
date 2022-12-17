namespace ParkingLotStep3;

public class ParkingLot
{
    private readonly int _capacity;
    private readonly ISet<Car> _lots;

    public ParkingLot(int capacity)
    {
        _capacity = capacity;
        _lots = new HashSet<Car>();
    }

    public void Park(Car car)
    {
        if (HasCar(car)) throw new ArgumentException("Car " + car + " has been parked");

        if (_lots.Count + 1 > _capacity) throw new Exception("No lot for more car");

        _lots.Add(car);
    }

    public bool HasCar(Car car)
    {
        return _lots.Contains(car);
    }

    public void Unpark(Car car)
    {
        if (!HasCar(car)) throw new ArgumentException("Failed to unpark car " + car);

        _lots.Remove(car);
    }

    public bool IsFull()
    {
        return _lots.Count == _capacity;
    }

    public int GetAvailability()
    {
        return _capacity - _lots.Count;
    }
}