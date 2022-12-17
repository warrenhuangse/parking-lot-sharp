using System.Text;

namespace ParkingLotStep7;

public abstract class ParkingRole : IParkable
{
    private const string Indent = "\t";

    private readonly IParkable _parkable1;
    private readonly IParkable _parkable2;
    private readonly IParkingStrategy _strategy;

    protected ParkingRole(IParkable parkable1, IParkable parkable2, IParkingStrategy strategy)
    {
        _parkable1 = parkable1;
        _parkable2 = parkable2;
        _strategy = strategy;
    }

    protected abstract string Name { get; }

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

    public int GetCapacity()
    {
        return _parkable1.GetCapacity() + _parkable2.GetCapacity();
    }

    public string GetStatus()
    {
        return GetStatus(0);
    }

    public string GetStatus(int level)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append('[');
        stringBuilder.AppendLine(Summary());
        stringBuilder.Append(Detail(level + 1));
        stringBuilder.Append(']');
        return stringBuilder.ToString();
    }

    private string Detail(int level)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append(Prefix(level));
        stringBuilder.Append(_parkable1.GetStatus(level));
        stringBuilder.AppendLine(",");
        stringBuilder.Append(Prefix(level));
        stringBuilder.Append(_parkable2.GetStatus(level));
        return stringBuilder.ToString();
    }

    private string Summary()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append(Name);
        stringBuilder.Append(": ");
        stringBuilder.Append(GetCapacity());
        stringBuilder.Append(" total, ");
        stringBuilder.Append(GetOccupied());
        stringBuilder.Append(" occupied, ");
        stringBuilder.Append(GetAvailability());
        stringBuilder.Append(" available");
        return stringBuilder.ToString();
    }

    private string Prefix(int level)
    {
        var stringBuilder = new StringBuilder();
        for (int i = 0; i < level; i++)
        {
            stringBuilder.Append(Indent);
        }

        return stringBuilder.ToString();
    }

    private int GetOccupied()
    {
        return GetCapacity() - GetAvailability();
    }

    private IParkable? FindAvailableLot()
    {
        return _strategy.GetAvailableLot(_parkable1, _parkable2);
    }
}