namespace ParkingLotStep1;

public class ParkingLot
{
    private readonly ISet<Car> _lots;
    private readonly int _capacity;

    public ParkingLot(int capacity)
    {
        this._capacity = capacity;
        _lots = new HashSet<Car>();
    }

    public void Park(Car car)
    {
        if (HasCar(car))
        {
            throw new ArgumentException("Car " + car + "has been parked");
        }

        if (this._lots.Count + 1 > _capacity)
        {
            throw new Exception("No lot for more car");
        }

        _lots.Add(car);
    }

    public bool HasCar(Car car) { return _lots.Contains(car); }

    public void Unpark(Car car)
    {
        if (!HasCar(car))
        {
            throw new ArgumentException("Failed to unpark car " + car);
        }

        _lots.Remove(car);
    }
}