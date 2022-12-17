using System.Text;

namespace ParkingLotStep7;

public class ParkingLot : IParkable
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

    public int GetCapacity()
    {
        return _capacity;
    }

    public string GetStatus()
    {
        return GetStatus(0);
    }

    public string GetStatus(int level)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append("[ParkingLot: ");
        stringBuilder.Append(_capacity);
        stringBuilder.Append(" total, ");
        stringBuilder.Append(_lots.Count);
        stringBuilder.Append(" occupied, ");
        stringBuilder.Append(GetAvailability());
        stringBuilder.Append(" available]");
        return stringBuilder.ToString();
    }
}